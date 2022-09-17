using HotelManagementLibrary.Models;

namespace HotelManagementLibrary.Interfaces
{
    public interface ISqlData
    {
        void BookGuest(GuestModel guestModel, RoomModel roomModel, DateTime startDate, DateTime endDate);
        void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
        void CheckInGuest(int bookingId);
        List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);
        RoomTypeModel GetRoomTypeById(int id);
        List<BookingFullModel> SeachBookings(string lastName);
    }
}