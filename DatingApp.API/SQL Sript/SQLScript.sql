USE [master]
GO
/****** Object:  Database [Dating]    Script Date: 11/15/2019 11:40:18 AM ******/
CREATE DATABASE [Dating]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dating', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\Dating.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dating_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\Dating_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dating] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dating].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dating] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dating] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dating] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dating] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dating] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dating] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dating] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dating] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dating] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dating] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dating] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dating] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dating] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dating] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dating] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dating] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dating] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dating] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dating] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dating] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dating] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dating] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dating] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Dating] SET  MULTI_USER 
GO
ALTER DATABASE [Dating] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dating] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dating] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dating] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Dating]
GO
/****** Object:  User [Dating]    Script Date: 11/15/2019 11:40:19 AM ******/
CREATE USER [Dating] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Dating]
GO
/****** Object:  Table [dbo].[BlogComments]    Script Date: 11/15/2019 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComments](
	[BlogCommentsId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](500) NOT NULL,
	[BlogId] [int] NOT NULL,
	[comment] [nvarchar](500) NULL,
	[datecreated] [datetime] NULL,
 CONSTRAINT [PK_BlogsDetails] PRIMARY KEY CLUSTERED 
(
	[BlogCommentsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 11/15/2019 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](500) NOT NULL,
	[title] [nvarchar](100) NULL,
	[Description] [nvarchar](1000) NULL,
	[datecreated] [datetime] NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 11/15/2019 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingredient](
	[uniqID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[amount] [int] NULL,
	[userName] [varbinary](50) NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[uniqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[photos]    Script Date: 11/15/2019 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[photos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateAdded] [datetime] NULL,
	[IsMain] [bit] NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_photos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 11/15/2019 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe](
	[UniqID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](500) NULL,
	[imagePath] [nvarchar](500) NULL,
	[userName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[UniqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RecipeIngredient]    Script Date: 11/15/2019 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeIngredient](
	[uniqID] [int] IDENTITY(1,1) NOT NULL,
	[recipeId] [int] NOT NULL,
	[ingredientId] [int] NOT NULL,
	[userName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ReceipeIngredient] PRIMARY KEY CLUSTERED 
(
	[uniqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/15/2019 11:40:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DateOfBirth] [datetime] NULL,
	[KnownAs] [nvarchar](max) NULL,
	[Created] [datetime] NULL,
	[LastActive] [datetime] NULL,
	[Introduction] [nvarchar](max) NULL,
	[LookingFor] [nvarchar](max) NULL,
	[Interests] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[BlogComments] ADD  CONSTRAINT [DF_BlogsDetails_datecreated]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[Blogs] ADD  CONSTRAINT [DF_Table_1_datePosted]  DEFAULT (getdate()) FOR [datecreated]
GO
ALTER TABLE [dbo].[photos] ADD  CONSTRAINT [DF_photos_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LastActive]  DEFAULT (getdate()) FOR [LastActive]
GO
ALTER TABLE [dbo].[BlogComments]  WITH CHECK ADD  CONSTRAINT [FK_BlogComments_Blogs] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([BlogId])
GO
ALTER TABLE [dbo].[BlogComments] CHECK CONSTRAINT [FK_BlogComments_Blogs]
GO
ALTER TABLE [dbo].[photos]  WITH CHECK ADD  CONSTRAINT [FK_photos_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[photos] CHECK CONSTRAINT [FK_photos_Users]
GO
ALTER TABLE [dbo].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_ReceipeIngredient_Ingredient] FOREIGN KEY([ingredientId])
REFERENCES [dbo].[Ingredient] ([uniqID])
GO
ALTER TABLE [dbo].[RecipeIngredient] CHECK CONSTRAINT [FK_ReceipeIngredient_Ingredient]
GO
ALTER TABLE [dbo].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_ReceipeIngredient_Recipe] FOREIGN KEY([recipeId])
REFERENCES [dbo].[Recipe] ([UniqID])
GO
ALTER TABLE [dbo].[RecipeIngredient] CHECK CONSTRAINT [FK_ReceipeIngredient_Recipe]
GO
USE [master]
GO
ALTER DATABASE [Dating] SET  READ_WRITE 
GO

-- dotnet ef dbcontext scaffold "Server=PSHYANI\SQL2012;Database=Dating;Trusted_Connection=True;MultipleActiveResultSets=true;user Id=dating;password=dating" Microsoft.EntityFrameworkCore.SqlServer -o Models -f