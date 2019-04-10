/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


insert into Roles(RoleName) values ('PAGE_1')
insert into Roles(RoleName) values ('PAGE_2')
insert into Roles(RoleName) values ('PAGE_3')
insert into Roles(RoleName) values ('ADMIN')

insert into Users (Username, UserPassword) values ('Joan', 'peperoni')
insert into Users (Username, UserPassword) values ('Manu', 'motzarella')
insert into Users (Username, UserPassword) values ('Montse', 'olives')
insert into Users (Username, UserPassword) values ('zigor', 'fresh')
insert into Users (Username, UserPassword) values ('Edu', 'superadmin')
insert into Users (Username, UserPassword) values ('Nuria', 'borrissol')


insert into UsersRoles(UserId, RoleId) values (
