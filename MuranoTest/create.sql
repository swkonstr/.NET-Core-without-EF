GO
CREATE TABLE [dbo].[Persons] (
    [Id]   INT           NOT NULL,
    [Name] NVARCHAR (50) NULL,
    [Age]  INT           NULL,
    [City] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
INSERT INTO [dbo].[Persons] ([Id],[Name],[Age],[City])
VALUES	(1,'Name1',31,'City1'),
		(2,'Name2',32,'City2'),
		(3,'Name3',33,'City3'),
		(4,'Name4',34,'City4'),
		(5,'Name5',35,'City5'),
		(6,'Name6',36,'City6'),
		(7,'Name7',37,'City7'),
		(8,'Name8',38,'City8'),
		(9,'Name9',39,'City9'),
		(10,'Name10',40,'City10'),
		(11,'Name11',41,'City11'),
		(12,'Name12',42,'City12'),
		(13,'Name13',43,'City13'),
		(14,'Name14',44,'City14'),
		(15,'Name15',45,'City15'),
		(16,'Name16',46,'City16'),
		(17,'Name17',47,'City17'),
		(18,'Name18',48,'City18'),
		(19,'Name19',49,'City19'),
		(20,'Name20',50,'City20');

GO
CREATE TABLE [dbo].[Employees] (
    [Id]          INT NOT NULL,
    [toPersonsId] INT NULL,
    [Salary]      INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
INSERT INTO [dbo].[Employees] ([Id],[toPersonsId],[Salary])
VALUES	(1,1,101),
		(2,2,101),
		(3,3,101),
		(4,5,101),
		(5,6,101),
		(6,7,101),
		(7,9,101),
		(8,10,101),
		(9,11,101),
		(10,12,101),
		(11,14,101),
		(12,15,101),
		(13,16,101),
		(14,17,101),
		(15,18,101);

GO
CREATE TABLE [dbo].[Managers] (
    [Id]       INT NOT NULL,
    [toEmplid] INT NULL,
    [Kpi]      INT NULL,
    [Bonus]    INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
INSERT INTO [dbo].[Managers] ([Id],[toEmplid],[Kpi],[Bonus])
VALUES	(1,1,101,10),
		(2,4,102,20),
		(3,6,103,30),
		(4,9,104,40),
		(5,12,105,50),
		(6,13,106,60);