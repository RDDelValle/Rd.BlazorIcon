// import {hljs} from "./libs/highlight.js/core.js";
// import {csharp} from "./libs/highlight.js/languages/csharp.js";
// import {css} from "./libs/highlight.js/languages/css.js";
// import {javascript} from "./libs/highlight.js/languages/javascript.js";
// import {xml} from "./libs/highlight.js/languages/xml.js";
//
// const CSharp = "csharp",
//     Css = "css",
//     Javascript = "javascript",
//     Scss = "scss",
//     Typescript = "typescript",
//     Xml = "xml";

export function highlightSnippet(element, language) {
    // registerLanguage(language);
    hljs.highlightBlock(element);
}

// function registerLanguage(language) {
//     switch (language) {
//         case CSharp:
//             registerCSharp();
//             break;
//         case Css:
//             registerCss();
//             break;
//         case Javascript:
//             registerJavascript();
//             break;
//         case Xml:
//             registerXml();
//             break;
//         default:
//             throw new Error(`Unknown language: ${language}`);
//     }
// }

// let csharpRegistered = false;
//
// function registerCSharp() {
//     if (!csharpRegistered) {
//         csharpRegistered = true;
//         hljs.registerLanguage(CSharp, csharp);
//     }
// }
//
// let cssRegistered = false;
//
// function registerCss() {
//     if (!cssRegistered) {
//         cssRegistered = true;
//         hljs.registerLanguage(Css, css);
//     }
// }
//
// let javascriptRegistered = false;
//
// function registerJavascript() {
//     if (!javascriptRegistered) {
//         javascriptRegistered = true;
//         hljs.registerLanguage(Javascript, javascript);
//     }
// }
//
// let xmlRegistered = false;
//
// function registerXml() {
//     if (!xmlRegistered) {
//         xmlRegistered = true;
//         hljs.registerLanguage(Xml, xml);
//     }
// }

