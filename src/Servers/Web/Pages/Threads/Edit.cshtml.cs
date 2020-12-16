using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HawkLab.Courier.Models;
using HawkLab.Courier.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HawkLab.Courier.Servers.Web.Pages.Threads
{
    public class EditModel : PageModel
    {
        private readonly IThreadRepository threadRepository;

        [BindProperty]
        public Thread Thread { get; set; }

        public EditModel(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }

        public IActionResult OnGet(int? threadId)
        {
            if (threadId.HasValue)
            {
                Thread = threadRepository.GetById(threadId.Value);
            }
            else
            {
                Thread = new Thread();
            }

            if (Thread == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Thread.Id > 0)
            {
                threadRepository.Update(Thread);
            }
            else
            {
                threadRepository.Add(Thread);
            }

            threadRepository.Commit();
            TempData["Message"] = "Thread saved";
            return RedirectToPage("./Detail", new { threadId = Thread.Id });
        }
    }
}
