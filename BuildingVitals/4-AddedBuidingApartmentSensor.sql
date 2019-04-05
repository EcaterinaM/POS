CREATE TABLE [BuildingVitals].[Building] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [OwnerId] uniqueidentifier NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Building] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Building_User_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [BuildingVitals].[User] ([Id]) ON DELETE CASCADE
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
    CONSTRAINT [FK_Apartment_Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [BuildingVitals].[Building] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Apartment_User_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [BuildingVitals].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BuildingVitals].[ApartmentSensor] (
    [Id] uniqueidentifier NOT NULL,
    [SensorId] uniqueidentifier NOT NULL,
    [ApartmentId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ApartmentSensor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ApartmentSensor_Apartment_ApartmentId] FOREIGN KEY ([ApartmentId]) REFERENCES [BuildingVitals].[Apartment] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ApartmentSensor_Sensor_SensorId] FOREIGN KEY ([SensorId]) REFERENCES [BuildingVitals].[Sensor] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Apartment_BuildingId] ON [BuildingVitals].[Apartment] ([BuildingId]);

GO

CREATE INDEX [IX_Apartment_OwnerId] ON [BuildingVitals].[Apartment] ([OwnerId]);

GO

CREATE INDEX [IX_ApartmentSensor_ApartmentId] ON [BuildingVitals].[ApartmentSensor] ([ApartmentId]);

GO

CREATE INDEX [IX_ApartmentSensor_SensorId] ON [BuildingVitals].[ApartmentSensor] ([SensorId]);

GO

CREATE INDEX [IX_Building_OwnerId] ON [BuildingVitals].[Building] ([OwnerId]);

GO

INSERT INTO [BuildingVitals].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190405061636_AddedBuildingApartmentSensorEntities', N'2.2.3-servicing-35854');

GO

