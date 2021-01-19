function myFunction(param) {
    param.forEach(value => {
        console.log(value);
    })
}


function MainCaller(elementsToObserve, cssList) {
    let options = {
        root: null,
        rootMargin: '-15px',
        threshold: 1
    };

    let observer = new IntersectionObserver(function
        (entries, self) {

        entries.forEach(entry => {
            if (entry.isIntersecting) {
                onEnterViewportCallback(entry, cssList);
            }
            else {
                onExitViewportCallback(entry, cssList);
            }
        });
    }, options);

    elementsToObserve.forEach(element => {
        observer.observe(document.getElementById(element));
    });
}

function onEnterViewportCallback(entry, cssList) {
    let element = document.getElementById(entry.target.id);

    cssList.forEach(cssClass => {
        element.classList.add(cssClass);
        console.log("Entered viewport. Added css: " + cssClass);
    });
}

function onExitViewportCallback(entry, cssList) {
    let element = document.getElementById(entry.target.id);

    cssList.forEach(cssClass => {
        element.classList.remove(cssClass);
        console.log("Exited viewport. Removed css: " + cssClass);
    });
}
