// Observer configuration
const domMutationObserverOptions = {
    childList: true,
    subtree: true,
    attributes: true,
    attributeFilter: ['class']
}

const viewportIntersectionObserverOptions = {
    root: null,
    rootMargin: '-20px -20px -20px -20px',
    threshold: 0.3
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