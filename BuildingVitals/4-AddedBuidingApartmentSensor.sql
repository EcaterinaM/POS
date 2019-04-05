CREATE TABLE [BuildingVitals].[Building] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [OwnerId] uniqueidentifier NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Building] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BuildingVitals].[Sensor] (
    [Id] uniqueidentifier NOT NULL,
    [Date] datetime2 NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Value] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Sensor] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BuildingVitals].[Apartment] (
    [Id] uniqueidentifier NOT NULL,
    [Floor] nvarchar(max) NOT NULL,
    [Number] int NOT NULL,
    [OwnerId] uniqueidentifier NOT NULL,
    [BuildingId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Apartment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Apartment_Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [BuildingVitals].[Building] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Apartment_BuildingId] ON [BuildingVitals].[Apartment] ([BuildingId]);

GO

INSERT INTO [BuildingVitals].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190405054616_AddedBuildingApartmentSensorEntities', N'2.2.3-servicing-35854');

GO

