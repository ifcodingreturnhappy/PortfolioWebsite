let options = {
    root: null,
    rootMargin: '-20px -20px -20px -20px',
    threshold: 0.3
};

let currentId = 0;

const observer = new MutationObserver(() => {
    const elements = document.querySelectorAll('[class*="vp-anim-"]');

    if (elements.length > 0) {
        elements.forEach(el => {
            const animClasses = [...el.classList].filter(c => c.startsWith("vp-anim-") && !c.endsWith("-triggered"));
            const animClassesTriggered = [...el.classList].filter(c => c.startsWith("vp-anim-") && c.endsWith("-triggered"));

            if (animClasses.length > 0 && animClassesTriggered.length === 0) {
                setupViewportAnimations(animationMappings)
            }
        });

        console.log("Classes replaced");
        //observer.disconnect();
    }
});

observer.observe(document.body, {
    childList: true,
    subtree: true,
    attributes: true,
    attributeFilter: ['class']
});

const animationMappings = [
    {
        "animationId": "vp-anim-1",
        "animationCSS": "fade-in-with-left-translate"
    },
    {
        "animationId": "vp-anim-2",
        "animationCSS": "fade-in-with-right-translate"
    },
    {
        "animationId": "vp-anim-3",
        "animationCSS": "fade-in-with-top-translate"
    },
    {
        "animationId": "vp-anim-4",
        "animationCSS": "fade-in-with-bottom-translate"
    },
    {
        "animationId": "vp-anim-5",
        "animationCSS": "fade-in-slow"
    }
];

function setupViewportAnimations(animationSettings) {
    try {
        let observer = new IntersectionObserver(function
            (entries, self) {

            entries.forEach(entry => {
                animationSettings.forEach(animationType => {
                    if (entry.target.classList.contains(animationType.animationId)) {
                        observerCallback(entry, animationType.animationCSS);
                    }
                });
            });
        }, options);

        animationSettings.forEach(animationType => {
            let elements = document.querySelectorAll('.' + animationType.animationId);

            elements.forEach(element => {
                if (element.id.length <= 0) {
                    element.id = ('VPA' + currentId);
                    currentId++;

                    observer.observe(element);
                }
            });
        });
    } catch (e) {
        console.log("Unable to set viewport animation.")
    }
}

function observerCallback(entry, cssClass, isRepeatable) {
    if (entry.isIntersecting) {
        if (!entry.target.classList.contains(cssClass)) {
            entry.target.classList.add(cssClass);
        }
    }
}
