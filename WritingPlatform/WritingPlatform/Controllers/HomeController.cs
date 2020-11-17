using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WritingPlatform.Models;
using WritingPlatform.Models.Comments;
using WritingPlatform.Models.Users;
using WritingPlatform.Models.Works;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IWorkService workService;
        private readonly ICommentService commentService;

        public HomeController(
            IUserService userService, 
            IWorkService workService, 
            ICommentService commentService)
        {
            this.userService = userService;
            this.workService = workService;
            this.commentService = commentService;
        }


        public ActionResult Index()
        {
            //var users = userService.GetUsers();
            //var works = workService.GetWorks();
            //var comments = commentService.GetComments();

            var users = new List<UserModel>();
            for (int i = 0; i < 10; i++) 
            {
                var user = new UserModel
                {
                    Id = i + 1,
                    Name = $"Name - {i}",
                    Login = $"Name - {i}{i}",
                    IsDeleted = false,
                    Email = $"{i}{i}{i}@mail.com",
                    BirthDay = DateTime.Now,
                };
                users.Add(user);
            }

            var works = new List<WorkModel>();
            for (int i = 0; i < 10; i++) 
            {
                var work = new WorkModel
                {
                    UserId = i + 1,
                    Id = i + 1,
                    TextOfWork = $"Once upon {i}",
                    Genre = $"Genre {i}",
                    Rating = 0,
                    Name = $"Name - {i}",
                    PublicationTime = DateTime.Now
                };
                works.Add(work);
            }

            var comments = new List<CommentModel>();
            for (int i = 0; i < 10; i++)
            {
                var comment = new CommentModel
                {
                    Id = i + 1,
                    WorkId = i + 1,
                    Text = $"{i + 1} work is {i}"
                };
                comments.Add(comment);
            }

            var bestWorks = works.OrderBy(work => work.Rating).Take(10);

            var bestWorksWithComments = bestWorks.GroupJoin(comments,
                work => work.Id,
                comment => comment.WorkId,
                (work, cmnts) => new BestWorkModel
                {
                    Name = work.Name,
                    Genre = work.Genre,
                    Rating = work.Rating,
                    TextOfWork = work.TextOfWork,
                    UserId = work.UserId,
                    Comments = cmnts
                });

            var bestWorksWithAuthors = bestWorksWithComments.Join(users,
                work => work.UserId,
                user => user.Id,
                (work, user) => new BestWorkModel
                {
                    Name = work.Name,
                    Genre = work.Genre,
                    Rating = work.Rating,
                    TextOfWork = work.TextOfWork,
                    UserId = work.UserId,
                    Comments = work.Comments,
                    Author = user
                });

            return View(bestWorksWithAuthors);
        }

        [HttpPost]
        public ActionResult ShowComments(IEnumerable<CommentModel> comments)
        {
            return View(comments);
        }
    }
}