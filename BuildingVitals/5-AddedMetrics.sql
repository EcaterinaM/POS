DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BuildingVitals].[Sensor]') AND [c].[name] = N'Date');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [BuildingVitals].[Sensor] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [BuildingVitals].[Sensor] DROP COLUMN [Date];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BuildingVitals].[Sensor]') AND [c].[name] = N'Value');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [BuildingVitals].[Sensor] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [BuildingVitals].[Sensor] DROP COLUMN [Value];

GO

CREATE TABLE [BuildingVitals].[Metric] (
    [Id] uniqueidentifier NOT NULL,
    [SensorId] uniqueidentifier NOT NULL,
    [Date] datetime2 NOT NULL,
    [Value] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Metric] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Metric_Sensor_SensorId] FOREIGN KEY ([SensorId]) REFERENCES [BuildingVitals].[Sensor] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Metric_SensorId] ON [BuildingVitals].[Metric] ([SensorId]);

GO

INSERT INTO [BuildingVitals].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190424060211_AddedMetrics', N'2.2.3-servicing-35854');

GO

