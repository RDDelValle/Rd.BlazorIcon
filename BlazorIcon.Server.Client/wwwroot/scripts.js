(function() {
    const Auto = "Auto";
    const Dark = "Dark";
    const Light = "Light";
    const ThemeKey = "BlazorIcon.RamonDev.Theme";
    const ThemeAttribute = "data-bs-theme";
    const darkMedia = window.matchMedia("(prefers-color-scheme: dark)");
    const getSystemPreferredTheme = () => darkMedia.matches ? Dark : Light;

    const updateDisplay = () => {
        let userPreferredTheme = getUserPreferredTheme();
        let theme = userPreferredTheme === Auto
            ? getSystemPreferredTheme()
            : userPreferredTheme;
        document.body.setAttribute(ThemeAttribute, theme.toLowerCase());
    }

    const getUserPreferredTheme = () => {
        let theme = localStorage.getItem(ThemeKey);
        if (theme === Light || theme === Dark)
            return theme;
        return Auto;
    }

    updateDisplay();
})()