let style = getComputedStyle(document.body)

const hexToRgb = (hex) => {
    return ['0x' + hex[1] + hex[2] | 0, '0x' + hex[3] + hex[4] | 0, '0x' + hex[5] + hex[6] | 0];
}

const getDefaultThemeColor = () => {
    return getComputedStyle(document.body).getPropertyValue("--bs-primary");
}

export function initialize() {
    let themeColor = getThemeColor();
    if (themeColor.length === 0)
        setThemeColor(getDefaultThemeColor())
}

export function getThemeColor () {
    return document.body.style.getPropertyValue("--bi-theme-color");
}

export function setThemeColor (color) {
    document.body.style.setProperty("--bi-theme-color", color);
    document.body.style.setProperty("--bi-theme-color-rgb",  hexToRgb(color));
}