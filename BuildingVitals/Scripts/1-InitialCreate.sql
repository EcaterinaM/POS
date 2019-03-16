IF OBJECT_ID(N'[BuildingVitals].[__EFMigrationsHistory]') IS NULL
BEGIN
    IF SCHEMA_ID(N'BuildingVitals') IS NULL EXEC(N'CREATE SCHEMA [BuildingVitals];');
    CREATE TABLE [BuildingVitals].[__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'BuildingVitals') IS NULL EXEC(N'CREATE SCHEMA [BuildingVitals];');

GO

CREATE TABLE [BuildingVitals].[IdentityRole] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_IdentityRole] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BuildingVitals].[User] (
    [Id] uniqueidentifier NOT NULL,
    [UserName] varchar(128) NOT NULL,
    [NormalizedUserName] varchar(128) NULL,
    [Email] varchar(128) NOT NULL,
    [NormalizedEmail] varchar(128) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] varchar(32) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [Name] varchar(128) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BuildingVitals].[IdentityRoleClaim] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_IdentityRoleClaim] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IdentityRoleClaim_IdentityRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [BuildingVitals].[IdentityRole] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BuildingVitals].[IdentityUserClaim] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_IdentityUserClaim] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IdentityUserClaim_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [BuildingVitals].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BuildingVitals].[IdentityUserLogin] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_IdentityUserLogin] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_IdentityUserLogin_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [BuildingVitals].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BuildingVitals].[IdentityUserRole] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_IdentityUserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_IdentityUserRole_IdentityRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [BuildingVitals].[IdentityRole] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_IdentityUserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [BuildingVitals].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [BuildingVitals].[IdentityUserToken] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_IdentityUserToken] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_IdentityUserToken_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [BuildingVitals].[User] ([Id]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [BuildingVitals].[IdentityRole] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_IdentityRoleClaim_RoleId] ON [BuildingVitals].[IdentityRoleClaim] ([RoleId]);

GO

CREATE INDEX [IX_IdentityUserClaim_UserId] ON [BuildingVitals].[IdentityUserClaim] ([UserId]);

GO

CREATE INDEX [IX_IdentityUserLogin_UserId] ON [BuildingVitals].[IdentityUserLogin] ([UserId]);

GO

CREATE INDEX [IX_IdentityUserRole_RoleId] ON [BuildingVitals].[IdentityUserRole] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [BuildingVitals].[User] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [BuildingVitals].[User] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

INSERT INTO [BuildingVitals].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190316104129_InitialCreate', N'2.2.3-servicing-35854');

GO

