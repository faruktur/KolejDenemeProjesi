﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace KolejDenemeProjesi.Web.CustomHelpers
{
    public static class CustomHelpers 
    {
        public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            // belki ilerde kullanırım :(
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("type", "text");
            tb.Attributes.Add("name", name);
            tb.Attributes.Add("value", metadata.Model as string);
            tb.Attributes.Add("style", "color:red");
            return new MvcHtmlString(tb.ToString());
        }
    }
}