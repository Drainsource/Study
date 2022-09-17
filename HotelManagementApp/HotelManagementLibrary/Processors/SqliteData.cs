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
    public class SqliteData : ISqlData
    {
        private const string connectionString = "SQLiteDb";
        private readonly ISqliteDataAccess _db;

        public SqliteData(ISqliteDataAccess db)
        {
            _db = db;
        }
        public void BookGuest(GuestModel guestModel, RoomModel roomModel, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
        {
            string sql = @"if not exists (select 1 from Guests where FirstName = @firstName and LastName = @lastName)
	                        begin
		                        insert into dbo.Guests (FirstName, LastName)
		                        values (@firstName, @lastName);
	                        end
	                        select top 1 [Id], [FirstName], [LastName]
	                        from Guests
	                        where FirstName = @firstName and LastName = @lastName";

            var guest = _db.LoadData<GuestModel, dynamic>(sql,
                                                        new { firstName, lastName },
                                                        connectionString).First();

            sql = "select * from dbo.RoomTypes where Id = @Id";
            RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>(sql,
                                                                            new { Id = roomTypeId },
                                                                       connectionString).First();

            var totalCost = (decimal)(endDate.Date.Subtract(startDate.Date)).Days * roomType.Price;

            sql = @"select r.*
	                from Rooms r
	                inner join RoomTypes t on t.Id = r.RoomTypeId
	                where r.RoomTypeId = @roomTypeId 
	                and r.Id not in (
	                select b.RoomId
	                from Bookings b
	                where (@startDate < b.StartDate and @endDate > b.EndDate)
		                or (b.StartDate <= @endDate and @endDate < b.EndDate)
		                or (b.StartDate <= @startDate and @startDate < b.EndDate)
	                );";

            var availableRoom = _db.LoadData<RoomModel, dynamic>(sql,
                                                                new { startDate, endDate, roomTypeId },
                                                        connectionString).First();


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
            _db.SaveData(sql, bookingModel);
        }

        public void CheckInGuest(int bookingId)
        {
            string sql = @"update Bookings
	                set CheckIn = 1
	                where Id = @id;";

            _db.SaveData(sql, new { Id = bookingId }, connectionString);
        }

        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            string sql = @"	select t.Id, t.Title, t.Description, t.Price 
	                    from Rooms r
	                    inner join RoomTypes t on t.Id = r.RoomTypeId
	                    where r.Id not in (
	                    select b.RoomId
	                    from Bookings b
	                    where (@startDate < b.StartDate and @endDate > b.EndDate)
		                    or (b.StartDate <= @endDate and @endDate < b.EndDate)
		                    or (b.StartDate <= @startDate and @startDate < b.EndDate)
	                    )
	                    group by t.Id, t.Title, t.Description, t.Price;";

            return _db.LoadData<RoomTypeModel, dynamic>(sql, new { StartDate = startDate, EndDate = endDate }, connectionString);
        }

        public RoomTypeModel GetRoomTypeById(int id)
        {
            string sql = "select * from dbo.RoomTypes where Id = @Id";
            return _db.LoadData<RoomTypeModel, dynamic>(sql,
                                        new { Id = id },
                                    connectionString).First();
        }

        public List<BookingFullModel> SeachBookings(string lastName)
        {
            string sql = @"	select [b].[Id], [b].[RoomId], [b].[GuestId], [b].[StartDate], [b].[EndDate], 
		                    [b].[CheckIn], [b].[TotalCost], [g].[FirstName], [g].[LastName],
		                    [r].[RoomTypeId], [r].[RoomNumber], [rt].[Title], [rt].[Description], [rt].[Price] 
	                    from Bookings b  
	                    inner join Guests g on b.GuestId = g.id
	                    inner join Rooms r on b.RoomId = r.Id
	                    inner join RoomTypes rt on r.RoomTypeId = rt.Id 
	                    where  g.LastName = @lastName AND b.StartDate = @startDate";

            return _db.LoadData<BookingFullModel, dynamic>(sql, new { lastName }, connectionString);
        }
    }
}
