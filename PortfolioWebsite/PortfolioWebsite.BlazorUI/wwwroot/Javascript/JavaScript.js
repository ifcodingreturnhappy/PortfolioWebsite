function setupViewportAnimations(jsonAnimationSettings) {
    let options = {
        root: null,
        rootMargin: '-15px -15px -15px -15px',
        threshold: 0.3
    };

    let animationSettings = JSON.parse(jsonAnimationSettings);

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
        let elements = document.querySelectorAll("." + animationType.animationId); 

        elements.forEach(element => {
            observer.observe(element);
        });
    });
}

function observerCallback(entry, cssClass) {
    if (entry.isIntersecting) {
        entry.target.classList.add(cssClass);
    }
    else {
        entry.target.classList.remove(cssClass);
    }
}