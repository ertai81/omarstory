
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/29/2016 23:16:29
-- Generated from EDMX file: C:\Users\jigos_000\Documents\Visual Studio 2012\Projects\OmarStoryRep\omarstory\OmarStory\OmarStoryDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OmarStory];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Background]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Background];
GO
IF OBJECT_ID(N'[dbo].[CharDialogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CharDialogs];
GO
IF OBJECT_ID(N'[OmarStoryDBModelStoreContainer].[Chars]', 'U') IS NOT NULL
    DROP TABLE [OmarStoryDBModelStoreContainer].[Chars];
GO
IF OBJECT_ID(N'[OmarStoryDBModelStoreContainer].[Decisions]', 'U') IS NOT NULL
    DROP TABLE [OmarStoryDBModelStoreContainer].[Decisions];
GO
IF OBJECT_ID(N'[dbo].[Objects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Objects];
GO
IF OBJECT_ID(N'[dbo].[Statuses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Statuses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Chars'
CREATE TABLE [dbo].[Chars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'CharDialogs'
CREATE TABLE [dbo].[CharDialogs] (
    [Id] int  NOT NULL,
    [CharId] int  NOT NULL,
    [Text] varchar(max)  NOT NULL,
    [Result] varchar(max)  NOT NULL,
    [Condition] varchar(max)  NULL
);
GO

-- Creating table 'Decisions'
CREATE TABLE [dbo].[Decisions] (
    [Id] int  NOT NULL,
    [Option] int  NOT NULL,
    [Text] varchar(max)  NOT NULL,
    [Result] varchar(max)  NOT NULL,
    [Condition] varchar(max)  NULL
);
GO

-- Creating table 'Backgrounds'
CREATE TABLE [dbo].[Backgrounds] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Objects'
CREATE TABLE [dbo].[Objects] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Statuses'
CREATE TABLE [dbo].[Statuses] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id], [Name] in table 'Chars'
ALTER TABLE [dbo].[Chars]
ADD CONSTRAINT [PK_Chars]
    PRIMARY KEY CLUSTERED ([Id], [Name] ASC);
GO

-- Creating primary key on [Id] in table 'CharDialogs'
ALTER TABLE [dbo].[CharDialogs]
ADD CONSTRAINT [PK_CharDialogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Decisions'
ALTER TABLE [dbo].[Decisions]
ADD CONSTRAINT [PK_Decisions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Backgrounds'
ALTER TABLE [dbo].[Backgrounds]
ADD CONSTRAINT [PK_Backgrounds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Objects'
ALTER TABLE [dbo].[Objects]
ADD CONSTRAINT [PK_Objects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Statuses'
ALTER TABLE [dbo].[Statuses]
ADD CONSTRAINT [PK_Statuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------