using HotelManagementLibrary.Interfaces;
using HotelManagementLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GuestUI.Pages
{
    public class BookRoomModel : PageModel
    {
        private readonly ISqlData _db;

        public BookRoomModel(ISqlData db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        [BindProperty]
        public GuestModel Guest { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public RoomTypeModel RoomType { get; set; }

        public void OnGet()
        {
            if (RoomTypeId > 0)
            {
                RoomType = _db.GetRoomTypeById(RoomTypeId);
            }
        }

        public IActionResult OnPost()
        {

            _db.BookGuest(Guest.FirstName, Guest.LastName, StartDate, EndDate, RoomTypeId);
            return RedirectToPage("/Index");
        }
    }
}
