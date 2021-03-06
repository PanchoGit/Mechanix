USE Mechanix
GO

IF (NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
				 WHERE TABLE_SCHEMA = 'app' 
                 AND  TABLE_NAME = 'Owner'))
BEGIN
	CREATE TABLE app.Owner (
	    [Id] INT IDENTITY (1, 1) NOT NULL,
	    [FirstName] NVARCHAR(255),
	    [LastName] NVARCHAR(255),
		[Created] [DATETIME] NULL CONSTRAINT [DF_Owner_Created] DEFAULT (GETUTCDATE()),
		[Modified] [DATETIME],
	    CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED ([Id] ASC)
	);
END

IF (NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
				 WHERE TABLE_SCHEMA = 'app' 
                 AND  TABLE_NAME = 'Car'))
BEGIN
	CREATE TABLE app.Car (
	    [Id] INT IDENTITY (1, 1) NOT NULL,
	    [Brand] NVARCHAR(255),
	    [Year] INT,
	    [Patent] NVARCHAR(100),
	    [OwnerId] INT NOT NULL,
		[Created] [DATETIME] NULL CONSTRAINT [DF_Car_Created] DEFAULT (GETUTCDATE()),
		[Modified] [DATETIME],
	    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [UQ_Car_Patent] UNIQUE (Patent),
		CONSTRAINT [FK_Car_OwnerId] FOREIGN KEY (OwnerId) REFERENCES app.Owner(Id),
	);
END

IF (NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
				 WHERE TABLE_SCHEMA = 'app' 
                 AND  TABLE_NAME = 'Service'))
BEGIN
	CREATE TABLE app.Service (
	    [Id] INT IDENTITY (1, 1) NOT NULL,
	    [Name] NVARCHAR (255),
		[Created] [DATETIME] NULL CONSTRAINT [DF_Service_Created] DEFAULT (GETUTCDATE()),
	    CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED ([Id] ASC)
	);
END

IF (NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'app' 
                 AND  TABLE_NAME = 'CarService'))
BEGIN
	CREATE TABLE app.CarService (
	    [Id] INT IDENTITY (1, 1) NOT NULL,
	    [CarId] INT NOT NULL,
	    [ServiceId] INT NOT NULL,
		[Date] [DATETIME] NOT NULL,
		[Created] [DATETIME] NULL CONSTRAINT [DF_CarService_Created] DEFAULT (GETUTCDATE()),
		[Modified] [DATETIME],
	    CONSTRAINT [PK_CarService] PRIMARY KEY CLUSTERED ([Id] ASC),
	    CONSTRAINT [UQ_CarService_CarService] UNIQUE (CarId, ServiceId)
	);
END