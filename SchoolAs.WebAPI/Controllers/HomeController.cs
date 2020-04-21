﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assets.WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [ActionName("GetImage")]
        public string GetImage()
        {
            return "iVBORw0KGgoAAAANSUhEUgAAAloAAAJwCAYAAABRbM+6AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsIAAA7CARUoSoAAAAvYSURBVHhe7d1RahsxFEDRUfbSVWRBXk9W4814L+oYixZaSAn4JtPJOSAk+ycfieXLYyBj27a5LwAAnuxl7QAAPJnQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgIjQAgCICC0AgMjLnHMdAQB4JhMtAICI0AIAiAgtAIDImLsxxnoJ8Hk8I/qbexjOyUQLACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkIL4Mvd1g6czZg7/zUe+Ar79bNOuIfhnEy0AAAiQgsAICK0AAAiQgsAIHJ/+tLTqAAAARMtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiIx9zccRgCOZ89jX8xj3rxDgPSZaAAARoQUAEBFaAAARoQUAEBFaAAARoQUAEBFaAAARoQVweLe1A/8boQUAEBFaAAARoQUAEBFaAAARoQUAEBFaAAARoQUAEBFaAAARoQUAEBn7mo8jAEcy57Gv5zHuXyHAe0y0AAAiQgsAICK0AAAiQgsAIOJheACAiIkWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARIQWAEBEaAEARMa+5uMInNGcPuLfyRj3ax04ChMtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AIAiAgtAICI0AI4jevagaMQWgCn8WPtwFGMfc3HETijOX3Ev5Mx7tc6cBQmWgCncVs7cBQmWnByJlrfh2kWHI+JFsBJiGo4HqEFABARWgAAEc9oAQBETLQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJj7tYZ4C9jjHUC4KNMtAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkILACAitAAAIkLrD7e3122MsdZlu673e7ft7XVsl8/7gXzYdbv8+tvYl18WAP8w9jUfRwAAnslECwAgIrQAACJCCwAgIrQAACJCCwAgIrQAACJCCwAgIrQAABLb9hOuqUEL5SnRBwAAAABJRU5ErkJggg==";
        }

        [HttpPost]
        [ActionName("GetImage")]
        public string ImagePost()
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("id") && headers.Contains("name") && headers.Contains("lastname"))
            {
                return "Bien hecho";
            }
            else
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw new HttpResponseException(responseMessage);
            }
        }


       
    }
}