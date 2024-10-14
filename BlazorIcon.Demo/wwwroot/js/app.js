(function() {
    const Auto = "Auto";
    const Dark = "Dark";
    const Light = "Light";
    const Theme = "Theme";
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

    const getUserPreferredTheme = () =>  {
        let theme = localStorage.getItem(Theme);
        if(theme === Light || theme === Dark)
            return theme;
        return Auto;
    }
    
    window.getUserPreferredTheme = () => getUserPreferredTheme();
    window.setUserPreferredTheme = (theme) =>  {
        if(theme === Auto)
        {
            localStorage.removeItem(Theme);
        }
        if(theme === Light || theme === Dark)
        {
            localStorage.setItem(Theme, theme);
        }
        updateDisplay();
    }
    
    updateDisplay();
    listenForMediaChanges();
})()
