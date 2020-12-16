using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HawkLab.Courier.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using HawkLab.Courier.Models;

namespace MyApp.Namespace
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IThreadRepository threadRepository;

        public string Message { get; set; }
        public IEnumerable<Thread> Threads { get; set; }

        [BindProperty(SupportsGet = true)] 
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                         IThreadRepository threadRepository)
        {
            this.config = config;
            this.threadRepository = threadRepository;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Threads = threadRepository.GetThreadsBySubject(SearchTerm);
        }
    }
}
