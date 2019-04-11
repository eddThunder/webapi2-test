



BEGIN
IF NOT EXISTS (SELECT 1 FROM [dbo].[Users])
SET IDENTITY_INSERT [dbo].[Users] ON 

insert into Roles(RoleName) values (1,'PAGE_1')
insert into Roles(RoleName) values (2,'PAGE_2')
insert into Roles(RoleName) values (3,'PAGE_3')
insert into Roles(RoleName) values (4,'ADMIN')

SET IDENTITY_INSERT [dbo].[Users] OFF
END