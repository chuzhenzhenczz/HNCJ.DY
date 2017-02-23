
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/29/2016 19:53:56
-- Generated from EDMX file: F:\DangYuan\HNCJ.DY\HNCJ.DY.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bangyaohe];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfoRoleInfo_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRoleInfo] DROP CONSTRAINT [FK_UserInfoRoleInfo_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRoleInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRoleInfo] DROP CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoUserActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAction] DROP CONSTRAINT [FK_UserInfoUserActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoTopicInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicInfo] DROP CONSTRAINT [FK_UserInfoTopicInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionInfoUserActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAction] DROP CONSTRAINT [FK_ActionInfoUserActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_StudyOnlineStudyItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudyItem] DROP CONSTRAINT [FK_StudyOnlineStudyItem];
GO
IF OBJECT_ID(N'[dbo].[FK_PaityMemberFilesInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilesInfo] DROP CONSTRAINT [FK_PaityMemberFilesInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryContentInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentInfo] DROP CONSTRAINT [FK_CategoryContentInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_TopicInfoUserInfo_TopicInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicInfoUserInfo] DROP CONSTRAINT [FK_TopicInfoUserInfo_TopicInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_TopicInfoUserInfo_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicInfoUserInfo] DROP CONSTRAINT [FK_TopicInfoUserInfo_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_StudyItemUserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudyItem] DROP CONSTRAINT [FK_StudyItemUserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ContentInfoUserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentInfo] DROP CONSTRAINT [FK_ContentInfoUserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_TopicInfoTopicInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TopicInfo] DROP CONSTRAINT [FK_TopicInfoTopicInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoFriend]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friend] DROP CONSTRAINT [FK_UserInfoFriend];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoPaityMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaityMember] DROP CONSTRAINT [FK_UserInfoPaityMember];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[TopicInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TopicInfo];
GO
IF OBJECT_ID(N'[dbo].[NewInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewInfo];
GO
IF OBJECT_ID(N'[dbo].[PaityMember]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaityMember];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[UserAction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAction];
GO
IF OBJECT_ID(N'[dbo].[ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Message];
GO
IF OBJECT_ID(N'[dbo].[StudyOnline]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudyOnline];
GO
IF OBJECT_ID(N'[dbo].[Template]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Template];
GO
IF OBJECT_ID(N'[dbo].[StudyItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudyItem];
GO
IF OBJECT_ID(N'[dbo].[FilesInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilesInfo];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[ContentInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentInfo];
GO
IF OBJECT_ID(N'[dbo].[Friend]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friend];
GO
IF OBJECT_ID(N'[dbo].[VisitorRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitorRecord];
GO
IF OBJECT_ID(N'[dbo].[UserInfoRoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoRoleInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfoActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfoActionInfo];
GO
IF OBJECT_ID(N'[dbo].[TopicInfoUserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TopicInfoUserInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RoleInfo'
CREATE TABLE [dbo].[RoleInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NULL,
    [Status] smallint  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL
);
GO

-- Creating table 'TopicInfo'
CREATE TABLE [dbo].[TopicInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255)  NULL,
    [Content] nvarchar(max)  NULL,
    [Type] smallint  NULL,
    [Status] smallint  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL,
    [UserInfoID] int  NOT NULL,
    [TopicInfoID] int  NULL
);
GO

-- Creating table 'NewInfo'
CREATE TABLE [dbo].[NewInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(255)  NULL,
    [Msg] nvarchar(max)  NULL,
    [Author] nvarchar(64)  NULL,
    [ImagePath] nvarchar(255)  NULL,
    [Type] smallint  NULL,
    [Status] smallint  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL
);
GO

-- Creating table 'PaityMember'
CREATE TABLE [dbo].[PaityMember] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(64)  NULL,
    [Sex] nvarchar(4)  NULL,
    [Brithday] datetime  NULL,
    [ClassNO] nvarchar(max)  NULL,
    [JoinYLTime] datetime  NULL,
    [SubmitTime] datetime  NULL,
    [StartTime] datetime  NULL,
    [EndTime] datetime  NULL,
    [RegularTime] datetime  NULL,
    [ClassPosition] nvarchar(128)  NULL,
    [Telphone] nvarchar(11)  NULL,
    [IDCard] nvarchar(19)  NULL,
    [RewardPunishment] nvarchar(max)  NULL,
    [FailedSubject] nvarchar(max)  NULL,
    [Remark] nvarchar(255)  NULL,
    [DelFlag] bit  NULL,
    [Status] smallint  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL,
    [UserInfoID] int  NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [UserKey] nvarchar(10)  NULL,
    [Userpwd] nvarchar(64)  NOT NULL,
    [Status] smallint  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL,
    [Icon] nvarchar(64)  NULL
);
GO

-- Creating table 'UserAction'
CREATE TABLE [dbo].[UserAction] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [HasPermissin] smallint  NULL,
    [UserInfoID] int  NOT NULL,
    [DelFlag] bit  NULL,
    [ActionInfoID] int  NOT NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ActionName] nvarchar(50)  NULL,
    [Url] nvarchar(max)  NULL,
    [HttpMethd] nvarchar(max)  NULL,
    [IsMenu] bit  NULL,
    [MenuIcon] nvarchar(max)  NULL,
    [Sort] int  NULL,
    [Status] smallint  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL
);
GO

-- Creating table 'Message'
CREATE TABLE [dbo].[Message] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Msg] nvarchar(255)  NULL,
    [Status] smallint  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [SenderID] int  NOT NULL,
    [RecipientID] int  NOT NULL
);
GO

-- Creating table 'StudyOnline'
CREATE TABLE [dbo].[StudyOnline] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(64)  NULL,
    [DelFlag] bit  NULL,
    [Status] smallint  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL,
    [Content] nvarchar(max)  NULL,
    [Count] int  NULL
);
GO

-- Creating table 'Template'
CREATE TABLE [dbo].[Template] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Context] nvarchar(256)  NULL,
    [Path] nvarchar(256)  NULL,
    [DelFlag] bit  NULL,
    [Status] smallint  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL
);
GO

-- Creating table 'StudyItem'
CREATE TABLE [dbo].[StudyItem] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Context] nvarchar(256)  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL,
    [StudyOnlineID] int  NOT NULL,
    [UserInfoID] int  NULL
);
GO

-- Creating table 'FilesInfo'
CREATE TABLE [dbo].[FilesInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(128)  NULL,
    [FilePath] nvarchar(256)  NULL,
    [FileSize] nvarchar(32)  NULL,
    [Remark] nvarchar(256)  NULL,
    [Type] smallint  NULL,
    [Status] smallint  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL,
    [PaityMemberID] int  NOT NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(64)  NULL,
    [Count] int  NULL,
    [Status] smallint  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL,
    [Path] nvarchar(256)  NULL
);
GO

-- Creating table 'ContentInfo'
CREATE TABLE [dbo].[ContentInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [dContent] nvarchar(max)  NULL,
    [DelFlag] bit  NULL,
    [RegTime] datetime  NULL,
    [ModfiedTime] datetime  NULL,
    [CategoryID] int  NOT NULL,
    [UserInfoID] int  NULL
);
GO

-- Creating table 'Friend'
CREATE TABLE [dbo].[Friend] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FriendID] int  NULL,
    [UserInfoID] int  NOT NULL,
    [DelFlag] bit  NULL,
    [Status] smallint  NULL,
    [RegTime] datetime  NULL
);
GO

-- Creating table 'VisitorRecord'
CREATE TABLE [dbo].[VisitorRecord] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [VisitorID] int  NOT NULL,
    [RegTime] datetime  NULL,
    [DelFlag] bit  NULL,
    [VisitorName] nvarchar(64)  NULL,
    [VisitorIcon] nvarchar(256)  NULL,
    [UserInfoID] int  NOT NULL
);
GO

-- Creating table 'UserInfoRoleInfo'
CREATE TABLE [dbo].[UserInfoRoleInfo] (
    [UserInfo_ID] int  NOT NULL,
    [RoleInfo_ID] int  NOT NULL
);
GO

-- Creating table 'RoleInfoActionInfo'
CREATE TABLE [dbo].[RoleInfoActionInfo] (
    [RoleInfo_ID] int  NOT NULL,
    [ActionInfo_ID] int  NOT NULL
);
GO

-- Creating table 'TopicInfoUserInfo'
CREATE TABLE [dbo].[TopicInfoUserInfo] (
    [TopicInfo1_ID] int  NOT NULL,
    [UserInfo1_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'RoleInfo'
ALTER TABLE [dbo].[RoleInfo]
ADD CONSTRAINT [PK_RoleInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TopicInfo'
ALTER TABLE [dbo].[TopicInfo]
ADD CONSTRAINT [PK_TopicInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'NewInfo'
ALTER TABLE [dbo].[NewInfo]
ADD CONSTRAINT [PK_NewInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PaityMember'
ALTER TABLE [dbo].[PaityMember]
ADD CONSTRAINT [PK_PaityMember]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [PK_UserAction]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [PK_Message]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StudyOnline'
ALTER TABLE [dbo].[StudyOnline]
ADD CONSTRAINT [PK_StudyOnline]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Template'
ALTER TABLE [dbo].[Template]
ADD CONSTRAINT [PK_Template]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'StudyItem'
ALTER TABLE [dbo].[StudyItem]
ADD CONSTRAINT [PK_StudyItem]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FilesInfo'
ALTER TABLE [dbo].[FilesInfo]
ADD CONSTRAINT [PK_FilesInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ContentInfo'
ALTER TABLE [dbo].[ContentInfo]
ADD CONSTRAINT [PK_ContentInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Friend'
ALTER TABLE [dbo].[Friend]
ADD CONSTRAINT [PK_Friend]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VisitorRecord'
ALTER TABLE [dbo].[VisitorRecord]
ADD CONSTRAINT [PK_VisitorRecord]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserInfo_ID], [RoleInfo_ID] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [PK_UserInfoRoleInfo]
    PRIMARY KEY NONCLUSTERED ([UserInfo_ID], [RoleInfo_ID] ASC);
GO

-- Creating primary key on [RoleInfo_ID], [ActionInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [PK_RoleInfoActionInfo]
    PRIMARY KEY NONCLUSTERED ([RoleInfo_ID], [ActionInfo_ID] ASC);
GO

-- Creating primary key on [TopicInfo1_ID], [UserInfo1_ID] in table 'TopicInfoUserInfo'
ALTER TABLE [dbo].[TopicInfoUserInfo]
ADD CONSTRAINT [PK_TopicInfoUserInfo]
    PRIMARY KEY NONCLUSTERED ([TopicInfo1_ID], [UserInfo1_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_ID] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_UserInfo]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleInfo_ID] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_ID])
    REFERENCES [dbo].[RoleInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRoleInfo_RoleInfo'
CREATE INDEX [IX_FK_UserInfoRoleInfo_RoleInfo]
ON [dbo].[UserInfoRoleInfo]
    ([RoleInfo_ID]);
GO

-- Creating foreign key on [UserInfoID] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [FK_UserInfoUserActionInfo]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoUserActionInfo'
CREATE INDEX [IX_FK_UserInfoUserActionInfo]
ON [dbo].[UserAction]
    ([UserInfoID]);
GO

-- Creating foreign key on [UserInfoID] in table 'TopicInfo'
ALTER TABLE [dbo].[TopicInfo]
ADD CONSTRAINT [FK_UserInfoTopicInfo]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoTopicInfo'
CREATE INDEX [IX_FK_UserInfoTopicInfo]
ON [dbo].[TopicInfo]
    ([UserInfoID]);
GO

-- Creating foreign key on [ActionInfoID] in table 'UserAction'
ALTER TABLE [dbo].[UserAction]
ADD CONSTRAINT [FK_ActionInfoUserActionInfo]
    FOREIGN KEY ([ActionInfoID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoUserActionInfo'
CREATE INDEX [IX_FK_ActionInfoUserActionInfo]
ON [dbo].[UserAction]
    ([ActionInfoID]);
GO

-- Creating foreign key on [RoleInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_ID])
    REFERENCES [dbo].[RoleInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoActionInfo_ActionInfo'
CREATE INDEX [IX_FK_RoleInfoActionInfo_ActionInfo]
ON [dbo].[RoleInfoActionInfo]
    ([ActionInfo_ID]);
GO

-- Creating foreign key on [StudyOnlineID] in table 'StudyItem'
ALTER TABLE [dbo].[StudyItem]
ADD CONSTRAINT [FK_StudyOnlineStudyItem]
    FOREIGN KEY ([StudyOnlineID])
    REFERENCES [dbo].[StudyOnline]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudyOnlineStudyItem'
CREATE INDEX [IX_FK_StudyOnlineStudyItem]
ON [dbo].[StudyItem]
    ([StudyOnlineID]);
GO

-- Creating foreign key on [PaityMemberID] in table 'FilesInfo'
ALTER TABLE [dbo].[FilesInfo]
ADD CONSTRAINT [FK_PaityMemberFilesInfo]
    FOREIGN KEY ([PaityMemberID])
    REFERENCES [dbo].[PaityMember]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaityMemberFilesInfo'
CREATE INDEX [IX_FK_PaityMemberFilesInfo]
ON [dbo].[FilesInfo]
    ([PaityMemberID]);
GO

-- Creating foreign key on [CategoryID] in table 'ContentInfo'
ALTER TABLE [dbo].[ContentInfo]
ADD CONSTRAINT [FK_CategoryContentInfo]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Category]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryContentInfo'
CREATE INDEX [IX_FK_CategoryContentInfo]
ON [dbo].[ContentInfo]
    ([CategoryID]);
GO

-- Creating foreign key on [TopicInfo1_ID] in table 'TopicInfoUserInfo'
ALTER TABLE [dbo].[TopicInfoUserInfo]
ADD CONSTRAINT [FK_TopicInfoUserInfo_TopicInfo]
    FOREIGN KEY ([TopicInfo1_ID])
    REFERENCES [dbo].[TopicInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserInfo1_ID] in table 'TopicInfoUserInfo'
ALTER TABLE [dbo].[TopicInfoUserInfo]
ADD CONSTRAINT [FK_TopicInfoUserInfo_UserInfo]
    FOREIGN KEY ([UserInfo1_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicInfoUserInfo_UserInfo'
CREATE INDEX [IX_FK_TopicInfoUserInfo_UserInfo]
ON [dbo].[TopicInfoUserInfo]
    ([UserInfo1_ID]);
GO

-- Creating foreign key on [UserInfoID] in table 'StudyItem'
ALTER TABLE [dbo].[StudyItem]
ADD CONSTRAINT [FK_StudyItemUserInfo]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudyItemUserInfo'
CREATE INDEX [IX_FK_StudyItemUserInfo]
ON [dbo].[StudyItem]
    ([UserInfoID]);
GO

-- Creating foreign key on [UserInfoID] in table 'ContentInfo'
ALTER TABLE [dbo].[ContentInfo]
ADD CONSTRAINT [FK_ContentInfoUserInfo]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentInfoUserInfo'
CREATE INDEX [IX_FK_ContentInfoUserInfo]
ON [dbo].[ContentInfo]
    ([UserInfoID]);
GO

-- Creating foreign key on [TopicInfoID] in table 'TopicInfo'
ALTER TABLE [dbo].[TopicInfo]
ADD CONSTRAINT [FK_TopicInfoTopicInfo]
    FOREIGN KEY ([TopicInfoID])
    REFERENCES [dbo].[TopicInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TopicInfoTopicInfo'
CREATE INDEX [IX_FK_TopicInfoTopicInfo]
ON [dbo].[TopicInfo]
    ([TopicInfoID]);
GO

-- Creating foreign key on [UserInfoID] in table 'Friend'
ALTER TABLE [dbo].[Friend]
ADD CONSTRAINT [FK_UserInfoFriend]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoFriend'
CREATE INDEX [IX_FK_UserInfoFriend]
ON [dbo].[Friend]
    ([UserInfoID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------