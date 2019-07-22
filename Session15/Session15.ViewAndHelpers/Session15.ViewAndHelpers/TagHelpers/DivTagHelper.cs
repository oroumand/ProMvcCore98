using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session15.ViewAndHelpers.TagHelpers
{
    [HtmlTargetElement(tag:"", Attributes = "aro-alert")]
    public class DivTagHelper : TagHelper
    {
        public bool AroAlert { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (AroAlert)
            {
                if (DateTime.Now.Hour > 21)
                {
                    output.SuppressOutput();
                }
                else
                {
                    output.TagName = "p";
                    output.Attributes.Add("class", "alert alert-danger");
                }
            }
        }
    }
    [HtmlTargetElement(tag: "div", Attributes = "aro-card")]
    public class CardTagHelper : TagHelper
    {
        public string HeaderText { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SuppressOutput();
            var card = new TagBuilder("div");
            card.AddCssClass("card");

            var Header = new TagBuilder("div");
            Header.AddCssClass("card-header");

            Header.InnerHtml.Append(HeaderText);

            var body = new TagBuilder("div");
            body.AddCssClass("card-body");
            body.InnerHtml.AppendHtml(output.Content.GetContent());
            card.InnerHtml.AppendHtml(Header);
            card.InnerHtml.AppendHtml(body);
            output.Content.AppendHtml(card);


        }
    }
}
