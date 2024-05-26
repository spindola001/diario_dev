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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520145337_InitialCreate'
)
BEGIN
    CREATE TABLE [ProfileModel] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [DateOfBirth] datetime2 NOT NULL,
        [Age] int NOT NULL,
        [Profesion] nvarchar(max) NOT NULL,
        [ProfessionalSumary] nvarchar(max) NOT NULL,
        [PersonalSumary] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ProfileModel] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240520145337_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240520145337_InitialCreate', N'8.0.4');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240523213515_Create_PostModel'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfileModel]') AND [c].[name] = N'ProfessionalSumary');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ProfileModel] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ProfileModel] ALTER COLUMN [ProfessionalSumary] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240523213515_Create_PostModel'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfileModel]') AND [c].[name] = N'Profesion');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProfileModel] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ProfileModel] ALTER COLUMN [Profesion] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240523213515_Create_PostModel'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfileModel]') AND [c].[name] = N'PersonalSumary');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ProfileModel] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [ProfileModel] ALTER COLUMN [PersonalSumary] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240523213515_Create_PostModel'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProfileModel]') AND [c].[name] = N'Name');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ProfileModel] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [ProfileModel] ALTER COLUMN [Name] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240523213515_Create_PostModel'
)
BEGIN
    CREATE TABLE [PostModel] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [PostContent] nvarchar(max) NULL,
        [DateCreate] datetime2 NOT NULL,
        [DateUpdate] datetime2 NOT NULL,
        CONSTRAINT [PK_PostModel] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240523213515_Create_PostModel'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240523213515_Create_PostModel', N'8.0.4');
END;
GO

COMMIT;
GO

