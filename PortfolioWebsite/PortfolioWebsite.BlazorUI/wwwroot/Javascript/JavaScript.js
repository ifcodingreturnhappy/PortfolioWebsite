
let options = {
    root: null,
    rootMargin: '-20px -20px -20px -20px',
    threshold: 0.3
};

let currentId = 0;

function setupViewportAnimations(jsonAnimationSettings) {
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
        let elements = document.querySelectorAll('.' + animationType.animationId);

        elements.forEach(element => {
            if (element.id.length <= 0) {
                element.id = ('VPA' + currentId);
                currentId++;

                observer.observe(element);
            }
        });
    });
}

function observerCallback(entry, cssClass, isRepeatable) {
    if (entry.isIntersecting) {
        if (!entry.target.classList.contains(cssClass)) {
            entry.target.classList.add(cssClass);
        }
    }

    //console.log("Observer callback");
}


function updateCurrentPageIndicator() {
    let navLinks = document.querySelectorAll('.selectable-item');

    let currentPageRef = window.location.pathname;

    navLinks.forEach(navLink => {
        let currentNavLink = navLink.getAttribute('href');

        if (currentPageRef.includes(currentNavLink)) {
            navLink.classList.add('selected-element');
        }
        else {
            navLink.classList.remove('selected-element');
        }
    });

    console.log('updating apge indicator');
}

function logMessage(message) {
    console.log(message);
}
