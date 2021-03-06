USE [master]
GO
/****** Object:  Database [CheckehDB]    Script Date: 12/27/2015 12:15:28 AM ******/
CREATE DATABASE [CheckehDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CheckehDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CheckehDB.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [FILES] 
( NAME = N'ChekehDB_Files', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ChekehDB_Files.ndf' , SIZE = 102400KB , MAXSIZE = UNLIMITED, FILEGROWTH = 50%)
 LOG ON 
( NAME = N'CheckehDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CheckehDB_log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CheckehDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CheckehDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CheckehDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CheckehDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CheckehDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CheckehDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CheckehDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CheckehDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CheckehDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CheckehDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CheckehDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CheckehDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CheckehDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CheckehDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CheckehDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CheckehDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CheckehDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CheckehDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CheckehDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CheckehDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CheckehDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CheckehDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CheckehDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CheckehDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CheckehDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CheckehDB] SET  MULTI_USER 
GO
ALTER DATABASE [CheckehDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CheckehDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CheckehDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CheckehDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CheckehDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CheckehDB]
GO
/****** Object:  UserDefinedFunction [dbo].[NationalCodeValidation]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Mohammad Reza
-- Description: NationalCode validation
-- =============================================
CREATE FUNCTION [dbo].[NationalCodeValidation]
(
	@input numeric
)
RETURNS int
AS
BEGIN

declare @lenght int
set @lenght = DATALENGTH(CAST(@input as varchar))

IF (@lenght = 10)
return 1

return 0
END


GO
/****** Object:  Table [dbo].[AdminOwnerSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminOwnerSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminId] [uniqueidentifier] NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AdminOwnerSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdminSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminSet](
	[Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AdminSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CitySet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CitySet](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_City_Id]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FactorProductSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactorProductSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FactorId] [int] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Count] [int] NOT NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_FactoryProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FactorSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FactorSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_FactorSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeedbackSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [uniqueidentifier] NOT NULL,
	[ReciverId] [uniqueidentifier] NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FeedbackSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupSet](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_GroupSet_Id]  DEFAULT (newid()),
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_GroupSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HumanSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HumanSet](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_HumanSet_Id]  DEFAULT (newid()),
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](60) NOT NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_HumanSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [FILES]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OwnerSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OwnerSet](
	[Id] [uniqueidentifier] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PostalCode] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[NationalCode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OwnerSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OwnerStoreSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnerStoreSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_OwnerStoreSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_OwnerStoreUsUnique] UNIQUE NONCLUSTERED 
(
	[OwnerId] ASC,
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductSet](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ProductSet_Id]  DEFAULT (newid()),
	[Name] [nvarchar](150) NOT NULL,
	[Image] [varbinary](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[GroupId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ProductSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StoreProductSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreProductSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[StoreId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_StoreProductSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UniqueStoreProduct] UNIQUE NONCLUSTERED 
(
	[ProductId] ASC,
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StoreSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StoreSet](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Store_Id]  DEFAULT (newid()),
	[Address] [nvarchar](max) NOT NULL,
	[PostalCode] [varchar](50) NOT NULL,
	[CityId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserSet]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSet](
	[Id] [uniqueidentifier] NOT NULL,
	[RegisterDate] [datetime] NOT NULL CONSTRAINT [DF_UserSet_RegisterDate]  DEFAULT (getdate()),
	[PhoneNumber] [nchar](20) NOT NULL,
 CONSTRAINT [PK_UserSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vGroup]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[vGroup]
as
select Id, Name from GroupSet

GO
/****** Object:  View [dbo].[vProduct]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vProduct]
AS
SELECT        dbo.ProductSet.Id AS ProductId, dbo.ProductSet.Name AS ProductName, dbo.ProductSet.Description AS ProductDescription, dbo.ProductSet.GroupId, dbo.vGroup.Name AS GroupName, dbo.ProductSet.Image
FROM            dbo.ProductSet INNER JOIN
                         dbo.vGroup ON dbo.ProductSet.GroupId = dbo.vGroup.Id

GO
/****** Object:  View [dbo].[vOwner]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vOwner]
AS
SELECT        dbo.HumanSet.Id, dbo.HumanSet.Username, dbo.HumanSet.LastName, dbo.HumanSet.FirstName, dbo.HumanSet.[Image], dbo.OwnerSet.NationalCode, dbo.OwnerSet.[Address], dbo.OwnerSet.PostalCode, 
                         dbo.OwnerSet.PhoneNumber
FROM            dbo.OwnerSet INNER JOIN
                         dbo.HumanSet ON dbo.OwnerSet.Id = dbo.HumanSet.Id

GO
/****** Object:  View [dbo].[vOwnerStatus]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vOwnerStatus]
AS
SELECT        dbo.vOwner.Id, dbo.vOwner.Username, dbo.vOwner.LastName, dbo.vOwner.FirstName, dbo.AdminOwnerSet.Status, dbo.AdminOwnerSet.AdminId
FROM            dbo.AdminOwnerSet INNER JOIN
                         dbo.vOwner ON dbo.AdminOwnerSet.OwnerId = dbo.vOwner.Id


GO
/****** Object:  View [dbo].[vAdmin]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vAdmin]
AS
SELECT        dbo.HumanSet.Id, dbo.HumanSet.Username, dbo.HumanSet.FirstName, dbo.HumanSet.LastName, dbo.HumanSet.Image
FROM            dbo.AdminSet INNER JOIN
                         dbo.HumanSet ON dbo.AdminSet.Id = dbo.HumanSet.Id


GO
/****** Object:  View [dbo].[vCity]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vCity]
AS
SELECT        Id, Name
FROM            dbo.CitySet


GO
/****** Object:  View [dbo].[vFeedBack]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vFeedBack]
AS
SELECT        Id, SenderId, ReciverId, Value
FROM            dbo.FeedbackSet


GO
/****** Object:  View [dbo].[vHuman]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vHuman]
	AS SELECT HumanSet.Id, HumanSet.FirstName , HumanSet.LastName , HumanSet.Username , HumanSet.[Image] FROM HumanSet

GO
/****** Object:  View [dbo].[vStore]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vStore]
as

select 

StoreId, StoreSet.Name as [StoreName], StoreSet.[Address] as [StoreAddress], StoreSet.PostalCode as [StorePostalCode],
CitySet.Name as [CityName],
OwnerSet.Id as [OwnerId]

from OwnerStoreSet

inner join StoreSet on StoreSet.Id = OwnerStoreSet.StoreId
inner join CitySet  on StoreSet.CityId = CitySet.Id
inner join OwnerSet on OwnerSet.Id = OwnerStoreSet.OwnerId

GO
/****** Object:  View [dbo].[vUser]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vUser]
AS
SELECT        dbo.HumanSet.Id, dbo.HumanSet.Username, dbo.HumanSet.FirstName, dbo.HumanSet.LastName, dbo.UserSet.RegisterDate, dbo.UserSet.PhoneNumber, dbo.HumanSet.Image
FROM            dbo.UserSet INNER JOIN
                         dbo.HumanSet ON dbo.UserSet.Id = dbo.HumanSet.Id

GO
ALTER TABLE [dbo].[FactorSet] ADD  CONSTRAINT [DF_FactorSet_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[AdminOwnerSet]  WITH CHECK ADD  CONSTRAINT [FK_AdminOwnerSet_AdminSet] FOREIGN KEY([AdminId])
REFERENCES [dbo].[AdminSet] ([Id])
GO
ALTER TABLE [dbo].[AdminOwnerSet] CHECK CONSTRAINT [FK_AdminOwnerSet_AdminSet]
GO
ALTER TABLE [dbo].[AdminOwnerSet]  WITH CHECK ADD  CONSTRAINT [FK_AdminOwnerSet_OwnerSet] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[OwnerSet] ([Id])
GO
ALTER TABLE [dbo].[AdminOwnerSet] CHECK CONSTRAINT [FK_AdminOwnerSet_OwnerSet]
GO
ALTER TABLE [dbo].[AdminSet]  WITH CHECK ADD  CONSTRAINT [FK_AdminSet_HumanSet] FOREIGN KEY([Id])
REFERENCES [dbo].[HumanSet] ([Id])
GO
ALTER TABLE [dbo].[AdminSet] CHECK CONSTRAINT [FK_AdminSet_HumanSet]
GO
ALTER TABLE [dbo].[FactorProductSet]  WITH CHECK ADD  CONSTRAINT [FK_FactoryProduct_FactorSet] FOREIGN KEY([FactorId])
REFERENCES [dbo].[FactorSet] ([Id])
GO
ALTER TABLE [dbo].[FactorProductSet] CHECK CONSTRAINT [FK_FactoryProduct_FactorSet]
GO
ALTER TABLE [dbo].[FactorProductSet]  WITH CHECK ADD  CONSTRAINT [FK_FactoryProduct_ProductSet] FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductSet] ([Id])
GO
ALTER TABLE [dbo].[FactorProductSet] CHECK CONSTRAINT [FK_FactoryProduct_ProductSet]
GO
ALTER TABLE [dbo].[FactorSet]  WITH CHECK ADD  CONSTRAINT [FK_FactorSet_StoreSet] FOREIGN KEY([StoreId])
REFERENCES [dbo].[StoreSet] ([Id])
GO
ALTER TABLE [dbo].[FactorSet] CHECK CONSTRAINT [FK_FactorSet_StoreSet]
GO
ALTER TABLE [dbo].[FactorSet]  WITH CHECK ADD  CONSTRAINT [FK_FactorSet_UserSet] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserSet] ([Id])
GO
ALTER TABLE [dbo].[FactorSet] CHECK CONSTRAINT [FK_FactorSet_UserSet]
GO
ALTER TABLE [dbo].[FeedbackSet]  WITH CHECK ADD  CONSTRAINT [FK_FeedbackSet_HumanSet] FOREIGN KEY([SenderId])
REFERENCES [dbo].[HumanSet] ([Id])
GO
ALTER TABLE [dbo].[FeedbackSet] CHECK CONSTRAINT [FK_FeedbackSet_HumanSet]
GO
ALTER TABLE [dbo].[FeedbackSet]  WITH CHECK ADD  CONSTRAINT [FK_FeedbackSet_HumanSet1] FOREIGN KEY([ReciverId])
REFERENCES [dbo].[HumanSet] ([Id])
GO
ALTER TABLE [dbo].[FeedbackSet] CHECK CONSTRAINT [FK_FeedbackSet_HumanSet1]
GO
ALTER TABLE [dbo].[OwnerSet]  WITH CHECK ADD  CONSTRAINT [FK_OwnerSet_HumanSet] FOREIGN KEY([Id])
REFERENCES [dbo].[HumanSet] ([Id])
GO
ALTER TABLE [dbo].[OwnerSet] CHECK CONSTRAINT [FK_OwnerSet_HumanSet]
GO
ALTER TABLE [dbo].[OwnerStoreSet]  WITH CHECK ADD  CONSTRAINT [FK_OwnerStoreSet_OwnerSet1] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[OwnerSet] ([Id])
GO
ALTER TABLE [dbo].[OwnerStoreSet] CHECK CONSTRAINT [FK_OwnerStoreSet_OwnerSet1]
GO
ALTER TABLE [dbo].[OwnerStoreSet]  WITH CHECK ADD  CONSTRAINT [FK_OwnerStoreSet_StoreSet] FOREIGN KEY([StoreId])
REFERENCES [dbo].[StoreSet] ([Id])
GO
ALTER TABLE [dbo].[OwnerStoreSet] CHECK CONSTRAINT [FK_OwnerStoreSet_StoreSet]
GO
ALTER TABLE [dbo].[ProductSet]  WITH CHECK ADD  CONSTRAINT [FK_ProductSet_GroupSet] FOREIGN KEY([GroupId])
REFERENCES [dbo].[GroupSet] ([Id])
GO
ALTER TABLE [dbo].[ProductSet] CHECK CONSTRAINT [FK_ProductSet_GroupSet]
GO
ALTER TABLE [dbo].[StoreProductSet]  WITH CHECK ADD  CONSTRAINT [FK_StoreProductSet_ProductSet1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductSet] ([Id])
GO
ALTER TABLE [dbo].[StoreProductSet] CHECK CONSTRAINT [FK_StoreProductSet_ProductSet1]
GO
ALTER TABLE [dbo].[StoreProductSet]  WITH CHECK ADD  CONSTRAINT [FK_StoreProductSet_StoreSet1] FOREIGN KEY([StoreId])
REFERENCES [dbo].[StoreSet] ([Id])
GO
ALTER TABLE [dbo].[StoreProductSet] CHECK CONSTRAINT [FK_StoreProductSet_StoreSet1]
GO
ALTER TABLE [dbo].[StoreSet]  WITH CHECK ADD  CONSTRAINT [FK_Store_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[CitySet] ([Id])
GO
ALTER TABLE [dbo].[StoreSet] CHECK CONSTRAINT [FK_Store_City]
GO
ALTER TABLE [dbo].[UserSet]  WITH CHECK ADD  CONSTRAINT [FK_UserSet_UserSet] FOREIGN KEY([Id])
REFERENCES [dbo].[HumanSet] ([Id])
GO
ALTER TABLE [dbo].[UserSet] CHECK CONSTRAINT [FK_UserSet_UserSet]
GO
ALTER TABLE [dbo].[AdminOwnerSet]  WITH CHECK ADD  CONSTRAINT [CK_Status] CHECK  (([Status]='Confirmed' OR [Status]='NotConfirmed'))
GO
ALTER TABLE [dbo].[AdminOwnerSet] CHECK CONSTRAINT [CK_Status]
GO
/****** Object:  StoredProcedure [dbo].[Admin_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Admin_Delete]
	@Id uniqueidentifier
AS
BEGIN
	begin tran
	Delete HumanSet where Id=@Id
	delete AdminSet where Id=@Id
	commit
END


GO
/****** Object:  StoredProcedure [dbo].[Admin_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Admin_Insert]
@Username nvarchar(50),
@Password nvarchar(150),
@FirstName nvarchar(50),
@LastName nvarchar(60),
@Image varbinary(max)
AS
BEGIN
	declare @Id uniqueidentifier
	set @Id = NEWID()

	begin tran
	insert into HumanSet(Id, Username, [Password], FirstName, LastName, [Image]) values (@Id, @Username, @Password, @FirstName, @LastName, @Image)
	insert into AdminSet(Id) values (@Id)
	commit
END


GO
/****** Object:  StoredProcedure [dbo].[Admin_Update]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Admin_Update]
@Id uniqueidentifier,
@Username nvarchar(50),
@Password nvarchar(150),
@FirstName nvarchar(50),
@LastName nvarchar(60),
@Image varbinary(max)
AS
BEGIN

	UPDATE HumanSet Set Username=@Username, [Password]=@Password, FirstName=@FirstName,@LastName=@LastName, [Image]=@Image WHERE Id=@Id
	-- UPDATE OwnerSet where Id=@Id

END


GO
/****** Object:  StoredProcedure [dbo].[City_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[City_Delete]
	@Id uniqueidentifier
AS
BEGIN
delete CitySet where Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[City_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[City_Insert]
@Name nvarchar(50)
AS
BEGIN
	insert into CitySet(Id, Name) VALUES(NEWID(), @Name)
END


GO
/****** Object:  StoredProcedure [dbo].[City_Update]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[City_Update]
	@id uniqueidentifier,
	@Name nvarchar(50)
AS
BEGIN
	UPDATE CitySet Set Name=@Name WHERE Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[Factor_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Factor_Insert]
	@StoreId uniqueidentifier,
	@UserId	uniqueidentifier
AS
BEGIN
	Insert into FactorSet(CreateDate, StoreId, UserId) values (GETDATE(), @StoreId, @UserId)
END


GO
/****** Object:  StoredProcedure [dbo].[FactorProduct_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FactorProduct_Delete]
	@Id int
AS
BEGIN
	Delete FactorProductSet where Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[FactorProduct_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FactorProduct_Insert]
	@FactorId int,
	@productId	uniqueidentifier,
	@Count int,
	@Price money
AS
BEGIN
	Insert into FactorProductSet(FactorId, ProductId, [Count] , Price) values(@FactorId, @ProductId, @Count, @Price)
END


GO
/****** Object:  StoredProcedure [dbo].[FeedBack_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FeedBack_Delete]
@Id int
as
BEGIN
Delete from FeedBackSet where Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[FeedBack_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FeedBack_Insert]
@SenderId uniqueidentifier,
@ReciverId uniqueidentifier null,
@Value nvarchar(MAX)
as
BEGIN
insert into FeedbackSet(SenderId, ReciverId, Value) VALUES(@SenderId, @ReciverId, @Value)
END


GO
/****** Object:  StoredProcedure [dbo].[Group_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Delete]
	@id uniqueidentifier
AS
BEGIN
	DELETE GroupSet WHERE Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[Group_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Insert]
@Name nvarchar(50)
AS
BEGIN
	insert into GroupSet(Id, Name) VALUES(NEWID(), @Name)
END


GO
/****** Object:  StoredProcedure [dbo].[Group_Update]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Update]
	@id uniqueidentifier,
	@Name nvarchar(50)
AS
BEGIN
	UPDATE GroupSet Set Name=@Name WHERE Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[Owner_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Owner_Delete]
	@Id uniqueidentifier
AS
BEGIN
	begin tran
	Delete HumanSet where Id=@Id
	delete OwnerSet where Id=@Id
	commit
END


GO
/****** Object:  StoredProcedure [dbo].[Owner_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Owner_Insert]
@Username nvarchar(50),
@Password nvarchar(150),
@FirstName nvarchar(50),
@LastName nvarchar(60),
@Image varbinary(max),
@NationalCode varchar(50),
@Address nvarchar(max),
@PostalCode varchar(50),
@PhoneNumber varchar(50)
AS
BEGIN
	declare @Id uniqueidentifier
	set @Id = NEWID()

	IF (dbo.NationalCodeValidation(@NationalCode) = 1)
	begin
	begin tran
		insert into HumanSet(Id, Username, [Password], FirstName, LastName, [Image]) values (@Id, @Username, @Password, @FirstName, @LastName, @Image)
		insert into OwnerSet(Id, NationalCode, [Address], PostalCode, PhoneNumber) values (@Id, @NationalCode, @Address, @PostalCode, @PhoneNumber)

		-- SET Status
		Declare @RC int
		EXECUTE @RC = [dbo].[AdminOwner_SetStatus] 
		   @Id
		  ,null
		  ,'NotConfirmed'
		End
	commit
END


GO
/****** Object:  StoredProcedure [dbo].[Owner_Update]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Owner_Update]
	@Id uniqueidentifier,
	@Username nvarchar(50),
	@Password nvarchar(150),
	@FirstName nvarchar(50),
	@LastName nvarchar(60),
	@Image varbinary(max),
	@NationalCode varchar(50),
	@Address nvarchar(max),
	@PostalCode varchar(50),
	@PhoneNumber varchar(50)
AS
BEGIN
	IF (dbo.NationalCodeValidation(@NationalCode) = 1)
	begin
	begin tran
		UPDATE HumanSet Set Username=@Username, [Password]=@Password, FirstName=@FirstName,@LastName=@LastName, [Image]=@Image WHERE Id=@Id
		update OwnerSet set NationalCode=@NationalCode, [Address]=@Address, PostalCode=@PostalCode, PhoneNumber=@PhoneNumber where Id=@Id

		-- set status
		Declare @RC int
		EXECUTE @RC = [dbo].[AdminOwner_SetStatus] 
			@Id
			,null
			,'NotConfirmed'
		End
	commit
	end
	

GO
/****** Object:  StoredProcedure [dbo].[Product_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_Delete]
@Id uniqueidentifier
AS
BEGIN
DELETE ProductSet WHERE Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[Product_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_Insert]
@Name nvarchar(150),
@Image varbinary(max),
@Description nvarchar(max),
@GroupId uniqueidentifier
AS
BEGIN
INSERT INTO ProductSet(Id, Name,[Image], [Description],[GroupId]) VALUES(NEWID(), @Name, @Image, @Description, @GroupId)
END


GO
/****** Object:  StoredProcedure [dbo].[Product_Update]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product_Update]
@Id uniqueidentifier,
@Name nvarchar(150),
@Image varbinary(max),
@Description nvarchar(max),
@GroupId uniqueidentifier
AS
BEGIN
UPDATE ProductSet SET Name=@Name, [Image]=@Image, [Description]=@Description, GroupId=@GroupId WHERE Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[Store_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Store_Delete]
@Id uniqueidentifier
AS
BEGIN
begin tran
begin try
delete OwnerStoreSet where StoreId=@Id
delete StoreSet where Id=@Id
commit
end try
begin catch
rollback
end catch
END


GO
/****** Object:  StoredProcedure [dbo].[Store_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Store_Insert]
@Address nvarchar(max),
@PostalCode varchar(50),
@CityId uniqueidentifier,
@Name nvarchar(150),
@OwnerId uniqueidentifier
AS
BEGIN
Begin Tran
begin try
	declare @StoreId uniqueidentifier
	set @StoreId = newid()
	insert into StoreSet (Id, [Address], PostalCode, CityId, Name) Values (@StoreId, @Address, @PostalCode,@CityId, @Name)
	insert into OwnerStoreSet( OwnerId, StoreId) values ( @OwnerId, @StoreId)
commit
end try
begin catch
rollback
end catch

END


GO
/****** Object:  StoredProcedure [dbo].[Store_Update]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Store_Update]
@Id uniqueidentifier,
@Name nvarchar(150),
@Address nvarchar(max),
@PostalCode varchar(50),
@CityId uniqueidentifier
AS
BEGIN
update StoreSet set [Address]=@Address, PostalCode=@PostalCode, CityId=@CityId where Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[StoreProduct_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoreProduct_Delete]
	@StoreId uniqueidentifier,
	@ProductId uniqueidentifier
AS
BEGIN
	Delete StoreProductSet where StoreId=@StoreId and ProductId=@ProductId
END


GO
/****** Object:  StoredProcedure [dbo].[StoreProduct_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoreProduct_Insert]
@ProductId uniqueidentifier,
@StoreId uniqueidentifier
AS
BEGIN
Insert into StoreProductSet(ProductId, StoreId) values (@ProductId, @StoreId)
END


GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[User_Delete]
@Id uniqueidentifier
AS
BEGIN
	begin tran

	begin try
		delete UserSet where Id=@Id
		delete HumanSet where Id=@Id
		commit
	end try
	begin catch
		rollback
	end catch
END


GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Insert]
	@Username nvarchar(50),
	@Password nvarchar(150),
	@FirstName nvarchar(50),
	@LastName nvarchar(60),
	@Image varbinary(max),
	@PhoneNumber nchar(10)
AS
BEGIN
	declare @Id uniqueidentifier
	set @Id = NEWID()

	begin tran

	begin try
		insert into HumanSet(Id, Username, [Password], FirstName, LastName, [Image]) values (@Id, @Username, @Password, @FirstName, @LastName, @Image)
		insert into UserSet(Id, RegisterDate, PhoneNumber) values (@Id, GETDATE(), @PhoneNumber)
		commit
	end try
	begin catch
		rollback
	end catch
END


GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Update]
	@Id uniqueidentifier,
	@Username nvarchar(50),
	@Password nvarchar(150),
	@FirstName nvarchar(50),
	@LastName nvarchar(60),
	@Image varbinary(max),
	@PhoneNumber nchar(10)
AS
BEGIN
	begin tran

	begin try
		update HumanSet set Username=@Username, [Password]=@Password, FirstName=@FirstName,@LastName=@LastName, [Image]=@Image where Id=@Id
		update UserSet set PhoneNumber=@PhoneNumber where Id=@Id
		commit
	end try
	begin catch
		rollback
	end catch
END


GO
/****** Object:  StoredProcedure [dbo].[vAdminOwner_GetStatus]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vAdminOwner_GetStatus]
	@OwnerId uniqueidentifier
AS
BEGIN
	Declare @Status varchar(50)
	select top 1 [Status] from AdminOwnerSet where OwnerId=@OwnerId order by Id desc
END

GO
/****** Object:  StoredProcedure [dbo].[vAdminOwner_SetStatus]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vAdminOwner_SetStatus]
@OwnerId uniqueidentifier,
@AdminId uniqueidentifier null,
@Status varchar(50)
AS
BEGIN
begin tran
delete from AdminOwnerSet where OwnerId = @OwnerId
insert into AdminOwnerSet(OwnerId,AdminId,[Status]) values(@OwnerId,@AdminId,@Status)
commit
END


GO
/****** Object:  StoredProcedure [dbo].[vCheckLogin]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vCheckLogin]
@Username nvarchar(50),
@Password nvarchar(150)
AS
	Declare @StoredPassword nvarchar(150)
	set @StoredPassword = (select [Password] from HumanSet where Username=@Username)
	IF @StoredPassword = @Password
		Return 1
	Else
		RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[vHuman_GetIdFromUsername]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vHuman_GetIdFromUsername]	
	@Username nvarchar(50)
AS
	select Id from HumanSet where Username=@Username

GO
/****** Object:  StoredProcedure [dbo].[vHuman_GetType]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vHuman_GetType]
	@Id	uniqueidentifier
AS
	Declare @adminCount int
	Declare @ownerCount int
	Declare @userCount int

	set @adminCount = (select count(*) as 'Admin' from AdminSet where Id=@Id)
	set @ownerCount = (select count(*) as 'Owner' from OwnerSet where Id=@Id)
	set @userCount = (select count(*) as 'User' from UserSet where Id=@Id)

	if @userCount > 0
		select 'user' as 'UserType'

	else if @ownerCount > 0
		select 'owner' as 'UserType'

	else if @adminCount > 0
		select 'admin' as 'UserType'



GO
/****** Object:  StoredProcedure [dbo].[vProductAvailabiliity]    Script Date: 12/27/2015 12:15:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vProductAvailabiliity]
	@StoreId uniqueidentifier
AS
BEGIN
	select B.ProductId, ProductName, Available = case [Count]

	when '0' then 'False'
	when '1' then 'True'
	else 'error'

	end

	from
	(
		select A.ProductId, Count(*)-1 as [Count] from
		(
			select ProductId, NULL as StoreId from vProduct
			union
			select ProductId, StoreId from StoreProductSet
			where StoreId=@StoreId
		) as A
		group by
		A.ProductId
	) as B inner join vProduct on vProduct.ProductId = B.ProductId
END


GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AdminSet"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 85
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HumanSet"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vAdmin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vAdmin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CitySet"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 215
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "FeedbackSet"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vFeedBack'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vFeedBack'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[20] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "OwnerSet"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HumanSet"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vOwner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vOwner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AdminOwnerSet"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vOwner"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 202
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vOwnerStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vOwnerStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ProductSet"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vGroup"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vProduct'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UserSet"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HumanSet"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUser'
GO
USE [master]
GO
ALTER DATABASE [CheckehDB] SET  READ_WRITE 
GO
