namespace MyApp.Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class DetailModel : PageModel
    {
        private readonly IThreadRepository threadRepository;

        [TempData]
        public string Message { get; set; }

        public Thread Thread { get; set; }

        public DetailModel(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }
        public IActionResult OnGet(int threadId)
        {
            Thread = threadRepository.GetById(threadId);
            if(Thread == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
            
        }
    }
}
