using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace ethereal.Services
{
    public interface IElementRenderService
    {
        Task RenderElements(IHtmlHelper<dynamic> html, IEnumerable<IPublishedElement> elements);
    }

    public class ElementRenderService : IElementRenderService
    {
        private static string GetPartialName(IPublishedElement element)
        {
            var elementTypeAlias = element.ContentType.Alias;
            var elementTypeAsPartial = elementTypeAlias.ToFirstUpper() + ".cshtml";
            return "~/Views/Partials/Element Renders/" + elementTypeAsPartial;
        }

        public async Task RenderElements(IHtmlHelper<dynamic> html, IEnumerable<IPublishedElement> elements)
        {
            foreach (var element in elements)
            {
                await html.RenderPartialAsync(GetPartialName(element), element);
            }
        }
    }
}
