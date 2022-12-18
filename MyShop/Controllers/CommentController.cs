using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNews.Domains;
using System.Threading.Tasks;
using System;
using MyNews.Models;
using MyShop.DataAccessLayer;

namespace MyNews.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Details(int id, CommentsViewModel model)
        {
            var post = model.PostId;
            if (id != post.ArticleId)
            {
                return NotFound();
            }

            var oldTicket = await _context.Articles.SingleOrDefaultAsync(t => t.ArticleId == post.ArticleId);
            var comment = new Comment();


            oldTicket.Comments.Add(comment);

            comment.Content = model.Comment.Content;
            comment.SendTime = DateTime.Now;
            comment.TicketID = ticket.TicketId;
            comment.Ticket = ticket;
            comment.UserId = user.Id;
            comment.User = user;

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Comments.AddAsync(comment);
                    _context.Update(oldTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(oldTicket.TicketId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
