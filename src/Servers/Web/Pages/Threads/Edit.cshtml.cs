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

        public IActionResult OnGet(int threadId)
        {
            Thread = threadRepository.GetById(threadId);
            if (Thread == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Thread = threadRepository.Update(Thread);
            threadRepository.Commit();
            return Page();
        }
    }
}
