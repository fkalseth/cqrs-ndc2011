
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/06/2011 13:26:37
-- Generated from EDMX file: E:\Dropbox\Dropbox\Source\ndc2011\Cqrs Demo\Domain\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [agenda];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AgendaSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sessions] DROP CONSTRAINT [FK_AgendaSession];
GO
IF OBJECT_ID(N'[dbo].[FK_AgendaSpeaker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Speakers] DROP CONSTRAINT [FK_AgendaSpeaker];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Agendas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agendas];
GO
IF OBJECT_ID(N'[dbo].[Sessions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sessions];
GO
IF OBJECT_ID(N'[dbo].[Speakers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Speakers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Agendas'
CREATE TABLE [dbo].[Agendas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [StartHour] int  NOT NULL,
    [DurationInMinutes] int  NOT NULL,
    [Day] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [AgendaId] int  NOT NULL,
    [Track] int  NOT NULL,
    [StartMinute] int  NOT NULL,
    [Capacity] int  NOT NULL
);
GO

-- Creating table 'Speakers'
CREATE TABLE [dbo].[Speakers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Bio] nvarchar(max)  NOT NULL,
    [AgendaId] int  NOT NULL,
    [PhotoUrl] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Attendees'
CREATE TABLE [dbo].[Attendees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SessionAttendees'
CREATE TABLE [dbo].[SessionAttendees] (
    [Attendees_Id] int  NOT NULL,
    [Sessions_Id] int  NOT NULL
);
GO

-- Creating table 'ConferenceAttendees'
CREATE TABLE [dbo].[ConferenceAttendees] (
    [Conferences_Id] int  NOT NULL,
    [Attendees_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Agendas'
ALTER TABLE [dbo].[Agendas]
ADD CONSTRAINT [PK_Agendas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [PK_Sessions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Speakers'
ALTER TABLE [dbo].[Speakers]
ADD CONSTRAINT [PK_Speakers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Attendees'
ALTER TABLE [dbo].[Attendees]
ADD CONSTRAINT [PK_Attendees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Attendees_Id], [Sessions_Id] in table 'SessionAttendees'
ALTER TABLE [dbo].[SessionAttendees]
ADD CONSTRAINT [PK_SessionAttendees]
    PRIMARY KEY NONCLUSTERED ([Attendees_Id], [Sessions_Id] ASC);
GO

-- Creating primary key on [Conferences_Id], [Attendees_Id] in table 'ConferenceAttendees'
ALTER TABLE [dbo].[ConferenceAttendees]
ADD CONSTRAINT [PK_ConferenceAttendees]
    PRIMARY KEY NONCLUSTERED ([Conferences_Id], [Attendees_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AgendaId] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_AgendaSession]
    FOREIGN KEY ([AgendaId])
    REFERENCES [dbo].[Agendas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AgendaSession'
CREATE INDEX [IX_FK_AgendaSession]
ON [dbo].[Sessions]
    ([AgendaId]);
GO

-- Creating foreign key on [AgendaId] in table 'Speakers'
ALTER TABLE [dbo].[Speakers]
ADD CONSTRAINT [FK_AgendaSpeaker]
    FOREIGN KEY ([AgendaId])
    REFERENCES [dbo].[Agendas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AgendaSpeaker'
CREATE INDEX [IX_FK_AgendaSpeaker]
ON [dbo].[Speakers]
    ([AgendaId]);
GO

-- Creating foreign key on [Attendees_Id] in table 'SessionAttendees'
ALTER TABLE [dbo].[SessionAttendees]
ADD CONSTRAINT [FK_SessionAttendees_Attendee]
    FOREIGN KEY ([Attendees_Id])
    REFERENCES [dbo].[Attendees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sessions_Id] in table 'SessionAttendees'
ALTER TABLE [dbo].[SessionAttendees]
ADD CONSTRAINT [FK_SessionAttendees_Session]
    FOREIGN KEY ([Sessions_Id])
    REFERENCES [dbo].[Sessions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionAttendees_Session'
CREATE INDEX [IX_FK_SessionAttendees_Session]
ON [dbo].[SessionAttendees]
    ([Sessions_Id]);
GO

-- Creating foreign key on [Conferences_Id] in table 'ConferenceAttendees'
ALTER TABLE [dbo].[ConferenceAttendees]
ADD CONSTRAINT [FK_ConferenceAttendees_Agenda]
    FOREIGN KEY ([Conferences_Id])
    REFERENCES [dbo].[Agendas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Attendees_Id] in table 'ConferenceAttendees'
ALTER TABLE [dbo].[ConferenceAttendees]
ADD CONSTRAINT [FK_ConferenceAttendees_Attendee]
    FOREIGN KEY ([Attendees_Id])
    REFERENCES [dbo].[Attendees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConferenceAttendees_Attendee'
CREATE INDEX [IX_FK_ConferenceAttendees_Attendee]
ON [dbo].[ConferenceAttendees]
    ([Attendees_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------