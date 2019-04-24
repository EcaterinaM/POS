DROP TABLE [BuildingVitals].[ApartmentSensor];

GO

ALTER TABLE [BuildingVitals].[Sensor] ADD [ApartmentId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

GO

CREATE INDEX [IX_Sensor_ApartmentId] ON [BuildingVitals].[Sensor] ([ApartmentId]);

GO

ALTER TABLE [BuildingVitals].[Sensor] ADD CONSTRAINT [FK_Sensor_Apartment_ApartmentId] FOREIGN KEY ([ApartmentId]) REFERENCES [BuildingVitals].[Apartment] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [BuildingVitals].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190424062620_ModifiedSensor', N'2.2.3-servicing-35854');

GO

