using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HawkLab.Courier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace MyApp.Namespace
{
    public class DetailModel : PageModel
    {
        public Thread Thread { get; set; }
        public void OnGet(int threadId)
        {
            Thread = new Thread()
            {
                Id = threadId
            };
        }
    }
}
