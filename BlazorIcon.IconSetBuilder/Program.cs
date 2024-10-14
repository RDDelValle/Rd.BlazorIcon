// See https://aka.ms/new-console-template for more information

using Rd.BlazorIcon.IconSetBuilder.Utilities;

var value = new DocsBlockBuilder
{
    VendorSource = "npm/bootstrap-icons/icons/",
    VendorName = "Bootstrap Icons v1.11.3 (https://icons.getbootstrap.com/)",
    VendorCopyright = "Copyright 2019-2024 The Bootstrap Authors",
    VendorLicense = "Licensed under MIT (https://github.com/twbs/icons/blob/main/LICENSE)",
};

Console.WriteLine(value.ToString());
