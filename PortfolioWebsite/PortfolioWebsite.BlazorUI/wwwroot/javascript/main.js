// Method that shows app after theme loaded
window.showApp = function () {
    const app = document.getElementById('app');
    if (app) {
        app.style.display = 'block';
    }
};

// Handle outside clicks on provided element
window.outsideClickHandlers = new Map();

window.registerOutsideClick = function (element, dotNetRef) {
    const handler = event => {
        if (!element.contains(event.target)) {
            dotNetRef.invokeMethodAsync("OnOutsideClick");
        }
    };

    document.addEventListener("click", handler);

    const id = generateUUID();
    window.outsideClickHandlers.set(id, handler);
    return id;
};

window.unregisterOutsideClick = function (id) {
    const handler = window.outsideClickHandlers.get(id);
    if (handler) {
        document.removeEventListener("click", handler);
        window.outsideClickHandlers.delete(id);
    }
};

const generateUUID = () => {
    // 1) Take UUID template: "10000000-1000-4000-8000-100000000000"
    // 2) Replace 0,1,8, with random digits
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

// Observer configuration
const domMutationObserverOptions = {
    childList: true,
    subtree: true,
    attributes: true,
    attributeFilter: ['class']
}

const viewportIntersectionOptionsMap = {
    "settings-vp-anim-top-50": {
        root: null,
        rootMargin: '0px 0px -35% 0px',
        threshold: 0.3
    },
    "default": {
        root: null,
        rootMargin: '-20px -20px -20px -20px',
        threshold: 0.3
    },
};

// Observe DOM changes to find elements with viewport animation classes
const domMutationObserver = new MutationObserver(() => {
    const elements = document.querySelectorAll('[class*="vp-anim-"]');

    if (elements.length > 0) {
        elements.forEach(el => {
            const animClasses = [...el.classList].filter(c => c.startsWith("vp-anim-") && !c.endsWith("-trigger"));
            const animClassesTriggered = [...el.classList].filter(c => c.startsWith("vp-anim-") && c.endsWith("-trigger"));

            if (animClasses.length > 0 && animClassesTriggered.length <= 0) {
                setupViewportAnimations(animClasses, el)
            }
        });
    }
});
domMutationObserver.observe(document.body, domMutationObserverOptions);

// Setup element observer to trigger function when element enters viewport
const setupViewportAnimations = (animClasses, element) => {
    const viewportIntersectionObserverOptions = getViewportAnimationConfig(element);

    try {
        let viewportIntersectionObserver = new IntersectionObserver((entries, self) => {
            entries.forEach(entry => {
                observerCallback(entry, animClasses[0], self);
            });
        }, viewportIntersectionObserverOptions);

        viewportIntersectionObserver.observe(element);

    } catch (e) {
        console.log("Unable to set viewport animation.")
    }
}

// Check if there is any specific configuration for the target element
const getViewportAnimationConfig = (element) => {
    const animSettingsClass = [...element.classList].filter(c => c.startsWith("settings-vp-anim-"));
    if (!animSettingsClass || animSettingsClass.length == 0) {
        return viewportIntersectionOptionsMap['default'];
    }

    const animSettingsClassId = animSettingsClass[0];
    return viewportIntersectionOptionsMap[animSettingsClassId];
}

// Callback to add css class that triggers animation, when element enters the viewport
const observerCallback = (entry, animationId, observer) => {
    if (!entry.isIntersecting || !entry.target.classList.contains(animationId)) {
        return;
    }

    const animationCssToAdd = `${animationId}-trigger`;
    if (entry.target.classList.contains(animationCssToAdd)) {
        return;
    } 

    entry.target.classList.add(animationCssToAdd);
    observer.disconnect();
}

// Read CSS variables
window.getCssVariable = function (name) {
    return getComputedStyle(document.documentElement)
        .getPropertyValue(name)
        .trim();
};

// Set style
window.setColor = (colorVarName, hexColor) => {
    hexColor = hexColor.replace('#', '');
    const r = parseInt(hexColor.substring(0, 2), 16);
    const g = parseInt(hexColor.substring(2, 4), 16);
    const b = parseInt(hexColor.substring(4, 6), 16);
    const rgbColor = `${r}, ${g}, ${b}`;
    document.documentElement.style.setProperty(colorVarName, rgbColor);
};

// Save a key/value pair to localStorage
window.saveToLocalStorage = function (key, value) {
    localStorage.setItem(key, value);
};

// Read a value from localStorage
window.readFromLocalStorage = function (key) {
    return localStorage.getItem(key);
};

// Remove a key from localStorage
window.removeFromLocalStorage = function (key) {
    localStorage.removeItem(key);
};