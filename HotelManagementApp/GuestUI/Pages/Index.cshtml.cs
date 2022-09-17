using HotelManagementLibrary.Interfaces;
using HotelManagementLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISqlData _sqlData;

        public IndexModel(ILogger<IndexModel> logger, ISqlData sqlData)
        {
            _logger = logger;
            _sqlData = sqlData;
        }

        public void OnGet()
        {
   
        }
    }
}