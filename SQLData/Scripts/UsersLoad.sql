
BEGIN
IF NOT EXISTS (SELECT 1 FROM [dbo].[Roles])
SET IDENTITY_INSERT [dbo].[Roles] ON 

insert into Users (Username, UserPassword) values (1,'Joan', 'peperoni')
insert into Users (Username, UserPassword) values (2,'Manu', 'motzarella')
insert into Users (Username, UserPassword) values (3,'Montse', 'olives')
insert into Users (Username, UserPassword) values (4,'zigor', 'fresh')
insert into Users (Username, UserPassword) values (5,'Edu', 'superadmin')
insert into Users (Username, UserPassword) values (6,'Nuria', 'borrissol')

SET IDENTITY_INSERT [dbo].[Users] OFF
END









