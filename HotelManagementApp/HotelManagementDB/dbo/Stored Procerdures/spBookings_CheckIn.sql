CREATE PROCEDURE [dbo].[spBookings_CheckIn]
	@id int

AS

BEGIN
	set nocount on;

	update dbo.Bookings
	set CheckIn = 1
	where Id = @id;
END
