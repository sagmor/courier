using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HawkLab.Courier.Models;
using HawkLab.Courier.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace MyApp.Namespace
{
    public class DetailModel : PageModel
    {
        private readonly IThreadRepository threadRepository;

        public Thread Thread { get; set; }

        public DetailModel(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }
        public void OnGet(int threadId)
        {
            Thread = threadRepository.GetById(threadId);
            
        }
    }
}
