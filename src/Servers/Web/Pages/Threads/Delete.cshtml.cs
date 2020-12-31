using System;
using HawkLab.Data.Core.Persistence;
using HawkLab.Data.Core.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class DeleteModel : PageModel
    {
        private readonly IThreadRepository threadRepository;

        [TempData]
        public string Message { get; set; }

        public Thread Thread { get; set; }

        public DeleteModel(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }
        public IActionResult OnPost(Guid threadId)
        {
            Thread = threadRepository.GetById(threadId);
            if(Thread != null)
            {
                threadRepository.Delete(Thread);
            }
            return RedirectToPage("./List");
        }
    }
}


