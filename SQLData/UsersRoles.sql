﻿CREATE TABLE [UsersRoles]
(
  Id int identity not null,
  UserId int NOT NULL,
  RoleId int NOT NULL,
  PRIMARY KEY CLUSTERED ( UserId, RoleId ),
  FOREIGN KEY ( UserId ) REFERENCES [Users] ( Id ) ON UPDATE  NO ACTION  ON DELETE  CASCADE,
  FOREIGN KEY ( RoleId ) REFERENCES [Roles] ( Id ) ON UPDATE  NO ACTION  ON DELETE  CASCADE
);
