using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocomTrainingPlatform.Models
{
    public static class PagingHtmlHelpers
    {
        public static IHtmlContent PageLinks
        (this IHtmlHelper htmlHelper, PageInfo pageInfo, Func<int, string> PageUrl)
        {
            StringBuilder pagingTags = new StringBuilder();
            //Prev Page
            if (pageInfo.CurrentPage > 1)
            {
                pagingTags.Append(GetTagString
                                 ("Prev", PageUrl(pageInfo.CurrentPage - 1)));
            }
            //Page Numbers
            for (int i = 1; i <= pageInfo.LastPage; i++)
            {
                pagingTags.Append(GetTagString(i.ToString(), PageUrl(i)));
            }
            //Next Page
            if (pageInfo.CurrentPage < pageInfo.LastPage)
            {
                pagingTags.Append(GetTagString
                                 ("Next", PageUrl(pageInfo.CurrentPage + 1)));
            }
            //paging tags
            return new HtmlString(pagingTags.ToString());
        }

        private static string GetTagString(string innerHtml, string hrefValue)
        {
            TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
            tag.MergeAttribute("class", "anchorstyle");
            tag.MergeAttribute("href", hrefValue);
            tag.InnerHtml.Append(" " + innerHtml + "  ");
            using (var sw = new System.IO.StringWriter())
            {
                tag.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                return sw.ToString();
            }
        }
    }
}
