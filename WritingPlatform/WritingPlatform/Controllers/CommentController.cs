﻿using System.Web.Mvc;

namespace WritingPlatform.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
    }
}