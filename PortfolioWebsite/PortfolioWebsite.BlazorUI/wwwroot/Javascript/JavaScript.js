
let options = {
    root: null,
    rootMargin: '-20px -20px -20px -20px',
    threshold: 0.3
};

let currentId = 0;

function setupViewportAnimations(jsonAnimationSettings) {
    try {
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
}

function focusElement(element) {
    element.focus();
}

function logMessage(message) {
    console.log(message);
}




// -------------- GAME CODE --------------

let isGamePaused = false;
let dotnetGameInstance = null;

function gameAwake(dotnetInsntace) {
    dotnetGameInstance = dotnetInsntace;

    isGamePaused = false;

    gameLoop();
}

function gameLoop() {
    if (!isGamePaused) {
        dotnetGameInstance.invokeMethodAsync('GameUpdateLoop');

        console.log("In the game loop...");

        window.requestAnimationFrame(gameLoop);
    }
}

function triggerPause() {
    if (!isGamePaused)
        isGamePaused = true;
    else {
        isGamePaused = false;
        gameLoop();
    }
}