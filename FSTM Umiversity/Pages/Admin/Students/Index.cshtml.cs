using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FSTM_Umiversity.Data;
using FSTM_Umiversity.Models;

namespace FSTM_Umiversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly FSTM_Umiversity.Data.SchoolContext _context;

        public IndexModel(FSTM_Umiversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
