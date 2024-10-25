const Auto = "Auto";
const Dark = "Dark";
const Light = "Light";
const ThemeKey = "BlazorIcon.RamonDev.Theme";
const ThemeAttribute = "data-bs-theme";
const darkMedia = window.matchMedia("(prefers-color-scheme: dark)");
const getSystemPreferredTheme = () => darkMedia.matches ? Dark : Light;
const listenForMediaChanges = () => darkMedia.addEventListener("change", updateDisplay);

const updateDisplay = () => {
    let userPreferredTheme = getUserPreferredTheme();
    let theme = userPreferredTheme === Auto
        ? getSystemPreferredTheme()
        : userPreferredTheme;
    document.body.setAttribute(ThemeAttribute, theme.toLowerCase());
}

export function initialize() {
    updateDisplay();
    listenForMediaChanges();
}

export function getUserPreferredTheme() {
    let theme = localStorage.getItem(ThemeKey);
    if (theme === Light || theme === Dark)
        return theme;
    return Auto;
}

export function setUserPreferredTheme(theme) {
    if (theme === Auto) {
        localStorage.removeItem(ThemeKey);
    }
    if (theme === Light || theme === Dark) {
        localStorage.setItem(ThemeKey, theme);
    }
    updateDisplay();
}
