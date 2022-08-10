IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220809221408_Initial Create')
BEGIN
    CREATE TABLE [Usuario] (
        [LoginId] int NOT NULL IDENTITY,
        [Email] varchar(50) NOT NULL,
        [Nome] varchar(70) NOT NULL,
        [Senha] varchar(10) NOT NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([LoginId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220809221408_Initial Create')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220809221408_Initial Create', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220810002943_Initial create on Azure')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220810002943_Initial create on Azure', N'6.0.8');
END;
GO

COMMIT;
GO

