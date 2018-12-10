﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Sample01.Models;

namespace Sample01.Controllers
{
    public class ContentController : Controller
    {
        private readonly Content contents;
        public ContentController(IOptions<Content> option)
        {
            contents = option.Value;
        }

        public IActionResult Index()
        {
            return View(new ContentViewModel
            {
                Contents = new List<Content> { contents }
            });

            //var contents = new List<Content>();
            //for (int i = 0; i < 11; i++)
            //{
            //    contents.Add(new Content
            //    {
            //        id = i,
            //        title = $"{i}的标题",
            //        content = $"{i}的内容",
            //        status = "1",
            //        add_time = DateTime.Now.AddDays(-1)
            //    });
            //}

            //return View(new ContentViewModel() { Contents = contents });
        }
    }
}