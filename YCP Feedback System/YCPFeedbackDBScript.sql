USE [master]
GO
/****** Object:  Database [YCPFeedbackDB]    Script Date: 02/04/2017 12:55:12 ******/
CREATE DATABASE [YCPFeedbackDB] ON  PRIMARY 
( NAME = N'YCPFeedbackDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\YCPFeedbackDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'YCPFeedbackDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\YCPFeedbackDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [YCPFeedbackDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YCPFeedbackDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YCPFeedbackDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET ARITHABORT OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [YCPFeedbackDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [YCPFeedbackDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [YCPFeedbackDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [YCPFeedbackDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [YCPFeedbackDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [YCPFeedbackDB] SET  READ_WRITE
GO
ALTER DATABASE [YCPFeedbackDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [YCPFeedbackDB] SET  MULTI_USER
GO
ALTER DATABASE [YCPFeedbackDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [YCPFeedbackDB] SET DB_CHAINING OFF
GO
USE [YCPFeedbackDB]
GO
/****** Object:  Table [dbo].[SuggestionMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SuggestionMaster](
	[DepartmentCode] [nvarchar](5) NULL,
	[Semester] [smallint] NULL,
	[SubjectCode] [bigint] NULL,
	[SubjectName] [varchar](10) NULL,
	[FacultyName] [varchar](30) NULL,
	[Suggestion] [nvarchar](101) NULL,
	[FeedbackDate] [nvarchar](11) NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentMaster](
	[Username] [varchar](10) NOT NULL,
	[StudName] [varchar](50) NULL,
	[DepartmentCode] [nvarchar](5) NULL,
	[StudSemester] [smallint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_StudentMaster] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatusMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatusMaster](
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[Status] [smallint] NULL,
	[FacultyStatus] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionStatus]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionStatus](
	[Question] [nvarchar](200) NULL,
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionMaster](
	[QuestionNo] [smallint] NOT NULL,
	[Question] [nvarchar](200) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_QuestionMaster] PRIMARY KEY CLUSTERED 
(
	[QuestionNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerformanceMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PerformanceMaster](
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[FacultyName] [varchar](30) NULL,
	[SubjectCode] [bigint] NULL,
	[SubjectName] [varchar](10) NULL,
	[Question] [nvarchar](200) NULL,
	[Performance] [nvarchar](15) NULL,
	[Percentage] [float] NULL,
	[FeedbackDate] [nvarchar](11) NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MarksTable]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MarksTable](
	[Username] [varchar](20) NULL,
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[SubjectCode] [bigint] NULL,
	[SubjectName] [varchar](10) NULL,
	[FacultyName] [varchar](30) NULL,
	[Question] [nvarchar](200) NULL,
	[Marks] [smallint] NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeedbackStatus]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FeedbackStatus](
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[StaffStatus] [smallint] NULL,
	[CollegeStatus] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacultyPerformance]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacultyPerformance](
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[FacultyName] [varchar](30) NULL,
	[SubjectCode] [bigint] NULL,
	[SubjectName] [varchar](10) NULL,
	[Performance] [nvarchar](15) NULL,
	[Percentage] [float] NULL,
	[FeedbackDate] [nvarchar](11) NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacultyMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacultyMaster](
	[FacultyName] [varchar](30) NULL,
	[SubjectCode] [bigint] NOT NULL,
	[SubjectName] [varchar](10) NULL,
	[FacultyCode] [nvarchar](13) NOT NULL,
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[Year] [nvarchar](8) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_FacultyMaster_1] PRIMARY KEY CLUSTERED 
(
	[FacultyCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacilityStatus]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacilityStatus](
	[Facility] [varchar](100) NULL,
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacilityMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacilityMaster](
	[FacilityNo] [smallint] NOT NULL,
	[Facility] [varchar](100) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_FacilityMaster] PRIMARY KEY CLUSTERED 
(
	[FacilityNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DepartmentStatus]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DepartmentStatus](
	[Id] [smallint] NOT NULL,
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_DepartmentStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DepartmentMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DepartmentMaster](
	[DepartmentCode] [varchar](5) NOT NULL,
	[DepartmentName] [varchar](50) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_DepartmentMaster] PRIMARY KEY CLUSTERED 
(
	[DepartmentCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DateMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DateMaster](
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[FeedbackDate] [nvarchar](11) NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CollegeSuggestion]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CollegeSuggestion](
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[Suggestion] [nvarchar](101) NULL,
	[FeedbackDate] [nvarchar](11) NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CollegePerformance]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CollegePerformance](
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[Facility] [varchar](101) NULL,
	[Excellent] [smallint] NULL,
	[VeryGood] [smallint] NULL,
	[Satisfactory] [smallint] NULL,
	[Poor] [smallint] NULL,
	[FeedbackDate] [nvarchar](11) NULL,
	[Status] [nchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CollegeMarks]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CollegeMarks](
	[DepartmentCode] [varchar](5) NULL,
	[Semester] [smallint] NULL,
	[Facility] [varchar](100) NULL,
	[Impression] [smallint] NULL,
	[FeedbackDate] [nvarchar](11) NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdminMaster]    Script Date: 02/04/2017 12:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminMaster](
	[Username] [varchar](10) NULL,
	[Password] [varchar](10) NULL,
	[Status] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_StatusMaster_Status]    Script Date: 02/04/2017 12:55:14 ******/
ALTER TABLE [dbo].[StatusMaster] ADD  CONSTRAINT [DF_StatusMaster_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_QuestionMaster_QuestionNo]    Script Date: 02/04/2017 12:55:14 ******/
ALTER TABLE [dbo].[QuestionMaster] ADD  CONSTRAINT [DF_QuestionMaster_QuestionNo]  DEFAULT ((0)) FOR [QuestionNo]
GO
/****** Object:  Default [DF_FacilityMaster_Status]    Script Date: 02/04/2017 12:55:14 ******/
ALTER TABLE [dbo].[FacilityMaster] ADD  CONSTRAINT [DF_FacilityMaster_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_DepartmentMaster_Status]    Script Date: 02/04/2017 12:55:14 ******/
ALTER TABLE [dbo].[DepartmentMaster] ADD  CONSTRAINT [DF_DepartmentMaster_Status]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF_AdminMaster_Status]    Script Date: 02/04/2017 12:55:14 ******/
ALTER TABLE [dbo].[AdminMaster] ADD  CONSTRAINT [DF_AdminMaster_Status]  DEFAULT ((1)) FOR [Status]
GO
