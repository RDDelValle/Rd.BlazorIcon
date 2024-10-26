export function closeOffcanvas(selector) {
    const offcanvas = document.querySelector(selector);
    if (offcanvas) {
        const offcanvasInstance = bootstrap.Offcanvas.getInstance(offcanvas);
        if (offcanvasInstance) {
            offcanvasInstance.hide();
        }
    }
};