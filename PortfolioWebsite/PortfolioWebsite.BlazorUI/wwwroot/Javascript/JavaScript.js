﻿function setupViewportAnimations(jsonAnimationSettings) {
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
        let elements = document.querySelectorAll('.' + animationType.animationId); 

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


function updateCurrentPageIndicator() {
    let navLinks = document.querySelectorAll('.selectable-item');
    // let currentPageRef = window.location.pathname.replace('/', ''); // currentPageRef === navLink.getAttribute('href')
    // This is the old aproach. 
    // This will probably not underline navlinks when i add pages regarding projects (with href like 'work/project12')
    // i will keep it here to try it when the work showcase page is finished, nevertheless.
    let currentPageRef = window.location.pathname;

    navLinks.forEach(navLink => {
        if (currentPageRef.includes(navLink.getAttribute('href'))) {
            navLink.classList.add('selected-element');
        }
        else {
            navLink.classList.remove('selected-element');
        }
    });
}

function logMessage(message) {
    console.log(message);
}
