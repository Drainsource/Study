CREATE PROCEDURE [dbo].[spRoomTypes_GetById]
	@Id int

AS
BEGIN
	set nocount on;

	select [Id], [Title], [Description], [Price]
	from dbo.RoomTypes
	where Id = @Id;

END
