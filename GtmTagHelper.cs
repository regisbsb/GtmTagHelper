using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NovosDesafios.TagHelpers
{
    [HtmlTargetElement("gtm", TagStructure = TagStructure.WithoutEndTag)]
    public class GtmTagHelper : TagHelper
    {
        public string Id { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "script";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.PreElement.SetHtmlContent("<!-- Google Tag Manager -->");

            output.Content.SetHtmlContent($@"(function(w,d,s,l,i){{w[l]=w[l]||[];w[l].push({{'gtm.start':
new Date().getTime(),event:'gtm.js'}});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
}})(window,document,'script','dataLayer','{Id}');");

            output.PostElement.SetHtmlContent("<!-- End Google Tag Manager -->");
        }
    }
}
