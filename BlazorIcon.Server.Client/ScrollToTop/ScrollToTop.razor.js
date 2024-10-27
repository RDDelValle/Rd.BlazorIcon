export function initialize(dotNetObject) {
    window.addEventListener('scroll', () => {
        dotNetObject.invokeMethodAsync('OnScroll');
    });
}

export function scrollToTop() {
    window.scrollTo(0,0);
}

export function isScrolledPastHalfOfViewport() {
    let scrollY = window.scrollY;
    let viewportHeight = window.innerHeight;
    return scrollY > viewportHeight * 0.5;
}