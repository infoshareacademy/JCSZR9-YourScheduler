CREATE TABLE [Users] (
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
[Surname] VARCHAR(50) NOT NULL,
[Displayname] VARCHAR(50) NOT NULL,
[Email] VARCHAR(255) NOT NULL UNIQUE,
[Password] VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE [Events] (
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
[Description] VARCHAR(50) NOT NULL,
[Date] DATETIME NOT NULL,
[Isopen] BIT NOT NULL
);

CREATE TABLE [Teams] (
[Id] INT IDENTITY(1,1) PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE [UsersTeams](
Id INT IDENTITY(1,1) PRIMARY KEY,
[UserId] INT FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) NOT NULL,
[TeamId] INT FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id]) NOT NULL
);



CREATE TABLE [UsersEvents](
Id INT IDENTITY(1,1) PRIMARY KEY,
[UserId] INT FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) NOT NULL,
[EventId] INT FOREIGN KEY ([EventId]) REFERENCES [Events]([Id]) NOT NULL
);

--//Insert INTO User 
/*Usuwanie baz danych*/
use master
 alter database [aspnet-WebApp1-da0ed983-0867-43e2-9c2b-01d6b80557f2] set single_user with rollback immediate

 drop database [aspnet-WebApp1-da0ed983-0867-43e2-9c2b-01d6b80557f2]
