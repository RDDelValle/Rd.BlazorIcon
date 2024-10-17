// theme
(function () {
    const Auto = "Auto";
    const Dark = "Dark";
    const Light = "Light";
    const Theme = "BlazorIcon.RamonDev.Theme";
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

    const getUserPreferredTheme = () => {
        let theme = localStorage.getItem(Theme);
        if (theme === Light || theme === Dark)
            return theme;
        return Auto;
    }

    const setUserPreferredTheme = (theme) => {
        if (theme === Auto) {
            localStorage.removeItem(Theme);
        }
        if (theme === Light || theme === Dark) {
            localStorage.setItem(Theme, theme);
        }
        updateDisplay();
    }

    window.getUserPreferredTheme = () => getUserPreferredTheme();
    window.setUserPreferredTheme = (theme) => setUserPreferredTheme(theme);

    updateDisplay();
    listenForMediaChanges();
})();

// color
(function () {
    let style = getComputedStyle(document.body)
    const getAccentColor = () => {
        return document.body.style.getPropertyValue("--bi-accent-color");
    }

    const setAccentColor = (color) => {
        document.querySelector('meta[name="theme-color"]').setAttribute("content", color);
        
        document.body.style.setProperty("--bi-accent-color", color);
        document.body.style.setProperty("--bi-accent-color-rgb",  hexToRgb(color));
    }
    
    const hexToRgb = (hex) => {
        return ['0x' + hex[1] + hex[2] | 0, '0x' + hex[3] + hex[4] | 0, '0x' + hex[5] + hex[6] | 0];
    }

    const getDefaultAccentColor = () => {
        return getComputedStyle(document.body).getPropertyValue("--bs-primary");
    }

    const initializeAccentColor = () => {
        let accentColor = getAccentColor();
        if (accentColor.length === 0)
            setAccentColor(getDefaultAccentColor())
    }

    window.getAccentColor = getAccentColor;
    window.setAccentColor = setAccentColor;

    initializeAccentColor();
})();

// clipboard
(function () {
    window.copyToClipboard = (text) => {
        navigator.clipboard.writeText(text)
            .then(function () {
                alert("Copied to clipboard!");
            })
            .catch(function (error) {
                alert(error);
            });
    };
})();
