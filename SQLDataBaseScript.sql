USE [master]
GO
/****** Object:  Database [APPD_Assignment]    Script Date: 9/2/2017 12:54:41 AM ******/
CREATE DATABASE [APPD_Assignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'APPD_Assignment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\APPD_Assignment.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'APPD_Assignment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\APPD_Assignment_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [APPD_Assignment] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [APPD_Assignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [APPD_Assignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [APPD_Assignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [APPD_Assignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [APPD_Assignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [APPD_Assignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [APPD_Assignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [APPD_Assignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [APPD_Assignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [APPD_Assignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [APPD_Assignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [APPD_Assignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [APPD_Assignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [APPD_Assignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [APPD_Assignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [APPD_Assignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [APPD_Assignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [APPD_Assignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [APPD_Assignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [APPD_Assignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [APPD_Assignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [APPD_Assignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [APPD_Assignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [APPD_Assignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [APPD_Assignment] SET  MULTI_USER 
GO
ALTER DATABASE [APPD_Assignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [APPD_Assignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [APPD_Assignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [APPD_Assignment] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [APPD_Assignment] SET DELAYED_DURABILITY = DISABLED 
GO
USE [APPD_Assignment]
GO
/****** Object:  Table [dbo].[BOOKING]    Script Date: 9/2/2017 12:54:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BOOKING](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[SlotDate] [datetime] NOT NULL,
	[ResourceID] [int] NOT NULL,
	[TimeSlotStart] [time](0) NOT NULL,
	[TimeSlotEnd] [time](0) NOT NULL,
	[NRIC] [varchar](50) NULL,
	[BookingDate] [date] NULL,
 CONSTRAINT [PK__BOOKING__977802D9799AC075] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC,
	[ResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CATEGORY]    Script Date: 9/2/2017 12:54:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [varchar](50) NOT NULL,
	[CatPrice] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK__CATEGORY__6A1C8ADA7E8F2527] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RESOURCE]    Script Date: 9/2/2017 12:54:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RESOURCE](
	[ResourceID] [int] IDENTITY(1,1) NOT NULL,
	[ResourceName] [varchar](50) NOT NULL,
	[CatID] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK__RESOURCE__4ED1814F9ADABD42] PRIMARY KEY CLUSTERED 
(
	[ResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USER]    Script Date: 9/2/2017 12:54:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USER](
	[NRIC] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK__USER__E2F96E86AD1C78D6] PRIMARY KEY CLUSTERED 
(
	[NRIC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BOOKING] ON 

INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (6, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 1, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (7, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 1, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (8, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 1, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (10, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 2, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (12, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 2, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (13, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 2, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (14, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 3, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (15, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 3, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (16, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 3, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (17, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 4, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (18, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 4, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (19, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 4, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (20, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 5, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (21, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 5, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (22, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 5, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (23, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 6, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (24, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 6, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (25, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 6, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (27, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 7, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (28, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 7, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (30, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 7, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (31, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 8, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (32, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 8, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (33, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 8, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (34, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 9, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (35, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 9, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (36, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 9, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (37, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 10, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (38, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 10, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (39, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 10, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (40, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 11, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (41, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 11, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (42, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 11, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (43, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 12, CAST(N'08:00:00' AS Time), CAST(N'10:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (44, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 12, CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), NULL, NULL)
INSERT [dbo].[BOOKING] ([BookingID], [SlotDate], [ResourceID], [TimeSlotStart], [TimeSlotEnd], [NRIC], [BookingDate]) VALUES (45, CAST(N'2017-02-02 00:00:00.000' AS DateTime), 12, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), NULL, NULL)
SET IDENTITY_INSERT [dbo].[BOOKING] OFF
SET IDENTITY_INSERT [dbo].[CATEGORY] ON 

INSERT [dbo].[CATEGORY] ([CatID], [CatName], [CatPrice]) VALUES (1, N'Tennis', CAST(12.00 AS Decimal(4, 2)))
INSERT [dbo].[CATEGORY] ([CatID], [CatName], [CatPrice]) VALUES (2, N'Badminton', CAST(10.00 AS Decimal(4, 2)))
SET IDENTITY_INSERT [dbo].[CATEGORY] OFF
SET IDENTITY_INSERT [dbo].[RESOURCE] ON 

INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (1, N'TCourt 1', 1, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (2, N'TCourt 2', 1, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (3, N'TCourt 3', 1, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (4, N'TCourt 4', 1, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (5, N'TCourt 5', 1, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (6, N'TCourt 6', 1, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (7, N'BCourt 1', 2, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (8, N'BCourt 2', 2, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (9, N'BCourt 3', 2, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (10, N'BCourt 4', 2, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (11, N'BCourt 5', 2, NULL)
INSERT [dbo].[RESOURCE] ([ResourceID], [ResourceName], [CatID], [Image]) VALUES (12, N'BCourt 6', 2, NULL)
SET IDENTITY_INSERT [dbo].[RESOURCE] OFF
INSERT [dbo].[USER] ([NRIC], [UserName], [Password]) VALUES (N'S1234567A', N'BARNABAS', N'123ASD')
INSERT [dbo].[USER] ([NRIC], [UserName], [Password]) VALUES (N'S9924014H', N'GARY', N'123456A')
ALTER TABLE [dbo].[BOOKING]  WITH CHECK ADD  CONSTRAINT [FK__BOOKING__NRIC__5CD6CB2B] FOREIGN KEY([NRIC])
REFERENCES [dbo].[USER] ([NRIC])
GO
ALTER TABLE [dbo].[BOOKING] CHECK CONSTRAINT [FK__BOOKING__NRIC__5CD6CB2B]
GO
ALTER TABLE [dbo].[BOOKING]  WITH CHECK ADD  CONSTRAINT [FK__BOOKING__Resourc__412EB0B6] FOREIGN KEY([ResourceID])
REFERENCES [dbo].[RESOURCE] ([ResourceID])
GO
ALTER TABLE [dbo].[BOOKING] CHECK CONSTRAINT [FK__BOOKING__Resourc__412EB0B6]
GO
ALTER TABLE [dbo].[RESOURCE]  WITH CHECK ADD  CONSTRAINT [FK__RESOURCE__CatID__3E52440B] FOREIGN KEY([CatID])
REFERENCES [dbo].[CATEGORY] ([CatID])
GO
ALTER TABLE [dbo].[RESOURCE] CHECK CONSTRAINT [FK__RESOURCE__CatID__3E52440B]
GO
USE [master]
GO
ALTER DATABASE [APPD_Assignment] SET  READ_WRITE 
GO
