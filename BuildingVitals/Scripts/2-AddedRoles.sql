USE [BuildingVitals]
GO

INSERT INTO [BuildingVitals].[IdentityRole]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           ('0cf46ac9-d6cf-4bbf-8996-e118764264bb'
           ,'Admin'
           ,'ADMIN'
           ,'ec037d2d-15b2-4c47-9268-2bd820cd6469')
GO

INSERT INTO [BuildingVitals].[IdentityRole]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           ('cfb6d6c2-68e0-4f79-8927-34df1476fd10'
           ,'Tenant'
           ,'TENANT'
           ,'ec037d2d-15b2-4c47-9268-2bd820cd6469')
GO

