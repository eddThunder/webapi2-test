BEGIN

IF NOT EXISTS (SELECT 1 FROM [dbo].[UsersRoles])

SET IDENTITY_INSERT [dbo].[UsersRoles] ON 

insert into UsersRoles(UserId, RoleId) values (1,1)
insert into UsersRoles(UserId, RoleId) values (2,2)

insert into UsersRoles(UserId, RoleId) values (3,3)
insert into UsersRoles(UserId, RoleId) values (4,1)

insert into UsersRoles(UserId, RoleId) values (4,2)

insert into UsersRoles(UserId, RoleId) values (5,1)
insert into UsersRoles(UserId, RoleId) values (5,2)
insert into UsersRoles(UserId, RoleId) values (5,3)
insert into UsersRoles(UserId, RoleId) values (5,4)

insert into UsersRoles(UserId, RoleId) values (6,1)

SET IDENTITY_INSERT [dbo].[Roles] OFF
END