ALTER TABLE [BuildingVitals].[User] ADD [Surname] varchar(128) NOT NULL DEFAULT N'';

GO

INSERT INTO [BuildingVitals].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190328200354_AddedSurnameToUserTable', N'2.2.3-servicing-35854');

GO

