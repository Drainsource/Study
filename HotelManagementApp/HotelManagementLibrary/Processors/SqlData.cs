using HotelManagementLibrary.Database;
using HotelManagementLibrary.Interfaces;
using HotelManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Processors
{
    public class SqlData : ISqlData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public SqlData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }
        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            string sql = "dbo.spRoomTypes_GetAvailableTypes";
            return _sqlDataAccess.LoadData<RoomTypeModel, dynamic>(sql,
                                                    new { StartDate = startDate, EndDate = endDate },
                                                    "Default",
                                                    true);
        }

        public void BookGuest(GuestModel guestModel, RoomModel roomModel, DateTime startDate, DateTime endDate)
        {
            BookingModel bookingModel = new();
            bookingModel.RoomId = roomModel.Id;
            bookingModel.StartDate = startDate;
            bookingModel.EndDate = endDate;
            bookingModel.CheckIn = false;
            string sql = "select * from dbo.RoomTypes where Id = @Id";
            var roomType = _sqlDataAccess.LoadData<RoomTypeModel, dynamic>(sql, new { Id = roomModel.RoomTypeId }).First();


            bookingModel.TotalCost = (decimal)(endDate - startDate).TotalDays * roomType.Price;


            sql = "select * from dbo.Guests where FirstName = @FirstName and LastName = @LastName;";
            var loadedGuestModel = _sqlDataAccess.LoadData<GuestModel, dynamic>(sql, new { guestModel.FirstName, guestModel.LastName }).FirstOrDefault();
            if (loadedGuestModel == null)
            {
                sql = @"insert into dbo.Guests (FirstName, LastName) 
                        values (@FirstName, @LastName) select @@IDENTITY;";
                guestModel.Id = _sqlDataAccess.SaveData(sql, guestModel);
            }
            else
            {
                guestModel = loadedGuestModel;
            }
            bookingModel.GuestId = guestModel.Id;


            sql = @"insert into dbo.Bookings (RoomId, GuestId, StartDate, EndDate, CheckIn, TotalCost) 
                        values (@RoomId, @GuestId, @StartDate, @EndDate, @CheckIn, @TotalCost) select @@IDENTITY;";
            _sqlDataAccess.SaveData(sql, bookingModel);

        }

        public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
        {
            var guest = _sqlDataAccess.LoadData<GuestModel, dynamic>("dbo.spGuests_Insert",
                                                                    new { firstName, lastName },
                                                                    "Default",
                                                                    true).First();

            string sql = "select * from dbo.RoomTypes where Id = @Id";
            RoomTypeModel roomType = _sqlDataAccess.LoadData<RoomTypeModel, dynamic>(sql,
                                                                            new { Id = roomTypeId },
                                                                       "Default",
                                                                        false).First();

            var totalCost = (decimal)(endDate.Date.Subtract(startDate.Date)).Days * roomType.Price;

            var availableRoom = _sqlDataAccess.LoadData<RoomModel, dynamic>("dbo.spRooms_GetAvailableRooms",
                                                                               new { startDate, endDate, roomTypeId },
                                                                        "Default",
                                                                        true).First();


            BookingModel bookingModel = new BookingModel
            {
                RoomId = availableRoom.Id,
                GuestId = guest.Id,
                StartDate = startDate,
                EndDate = endDate,
                TotalCost = totalCost
            };
            sql = @"insert into dbo.Bookings (RoomId, GuestId, StartDate, EndDate, CheckIn, TotalCost) 
                        values (@RoomId, @GuestId, @StartDate, @EndDate, @CheckIn, @TotalCost) select @@IDENTITY;";
            _sqlDataAccess.SaveData(sql, bookingModel);

        }

        public List<BookingFullModel> SeachBookings(string lastName)
        {
            string sql = "dbo.spBookings_SearchBookings";
            return _sqlDataAccess.LoadData<BookingFullModel, dynamic>(sql,
                                                            new { lastName, startDate = DateTime.Now.Date },
                                                            "Default",
                                                            true);
        }

        public void CheckInGuest(int bookingId)
        {
            _sqlDataAccess.SaveData("dbo.spBookings_CheckIn", new { Id = bookingId }, "Default", true);
        }

        public RoomTypeModel GetRoomTypeById(int id)
        {
            return _sqlDataAccess.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetById", 
                        new { Id = id }, 
                        "Default", 
                        true)
                                 .First();
        }
    }
}
