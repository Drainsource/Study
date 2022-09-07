CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonId] INT NOT NULL, 
    [StreetAddress] NVARCHAR(100) NOT NULL, 
    [City] NVARCHAR(20) NOT NULL, 
    [State] NVARCHAR(20) NOT NULL, 
    [ZipCode] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_PeopleOrder] FOREIGN KEY ([PersonId]) REFERENCES dbo.People(Id), 
   
)
