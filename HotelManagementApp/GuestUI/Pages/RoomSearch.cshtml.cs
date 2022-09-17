using HotelManagementLibrary.Interfaces;
using HotelManagementLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GuestUI.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly ISqlData _db;

        public RoomSearchModel(ISqlData db)
        {
            _db = db;
        }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public bool SearchEnabled { get; set; } = false;

        [BindProperty]
        public List<RoomTypeModel> AvaibleRoomTypes { get; set; }
        public void OnGet()
        {
            if (SearchEnabled)
            {
                AvaibleRoomTypes = _db.GetAvailableRoomTypes(StartDate, EndDate);
            }
            
        }

        public IActionResult OnPost()
        {
            
            return RedirectToPage(new 
            { 
                SearchEnabled = true, 
                StartDate = StartDate.ToString("yyyy-MM-dd"), 
                EndDate = EndDate.ToString("yyyy-MM-dd")
            });
        }
    }
}
