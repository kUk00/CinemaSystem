USE [master]
GO
/****** Object:  Database [CinemaSystem]    Script Date: 09.05.2023 13:16:35 ******/
CREATE DATABASE [CinemaSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CinemaSystem', FILENAME = N'D:\Pgs\DataBases\CinemaSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CinemaSystem_log', FILENAME = N'D:\Pgs\DataBases\CinemaSystem_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CinemaSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CinemaSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CinemaSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CinemaSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CinemaSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CinemaSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CinemaSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [CinemaSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CinemaSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CinemaSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CinemaSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CinemaSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CinemaSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CinemaSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CinemaSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CinemaSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CinemaSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CinemaSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CinemaSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CinemaSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CinemaSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CinemaSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CinemaSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CinemaSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CinemaSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [CinemaSystem] SET  MULTI_USER 
GO
ALTER DATABASE [CinemaSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CinemaSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CinemaSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CinemaSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CinemaSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CinemaSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CinemaSystem', N'ON'
GO
ALTER DATABASE [CinemaSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [CinemaSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CinemaSystem]
GO
/****** Object:  Table [dbo].[Halls]    Script Date: 09.05.2023 13:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Halls](
	[IDhall] [int] IDENTITY(1,1) NOT NULL,
	[NameHall] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Halls] PRIMARY KEY CLUSTERED 
(
	[IDhall] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 09.05.2023 13:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[IDmovie] [int] IDENTITY(1,1) NOT NULL,
	[NameMovie] [nvarchar](50) NOT NULL,
	[Country] [nchar](10) NOT NULL,
	[YearOfIssue] [int] NOT NULL,
	[Genre] [nchar](20) NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[IDmovie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 09.05.2023 13:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[Date] [date] NOT NULL,
	[Time] [time](0) NOT NULL,
	[Hall] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[Date] ASC,
	[Time] ASC,
	[Hall] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seatcategories]    Script Date: 09.05.2023 13:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seatcategories](
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_Seat categories] PRIMARY KEY CLUSTERED 
(
	[Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seatsandrows]    Script Date: 09.05.2023 13:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seatsandrows](
	[Hall] [int] NOT NULL,
	[Row] [int] NOT NULL,
	[Place] [int] NOT NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_Seatsandrows] PRIMARY KEY CLUSTERED 
(
	[Hall] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 09.05.2023 13:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Date] [date] NOT NULL,
	[Time] [time](0) NOT NULL,
	[Hall] [int] NOT NULL,
	[Movie] [int] NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[Date] ASC,
	[Time] ASC,
	[Hall] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 09.05.2023 13:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[IDticket] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](0) NOT NULL,
	[Hall] [int] NOT NULL,
	[Row] [int] NOT NULL,
	[Place] [int] NOT NULL,
	[Sold] [bit] NOT NULL,
 CONSTRAINT [PK_Tickets_1] PRIMARY KEY CLUSTERED 
(
	[Date] ASC,
	[Time] ASC,
	[Hall] ASC,
	[Row] ASC,
	[Place] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Halls] ON 

INSERT [dbo].[Halls] ([IDhall], [NameHall]) VALUES (1, N'3D                            ')
INSERT [dbo].[Halls] ([IDhall], [NameHall]) VALUES (2, N'Диванный                      ')
INSERT [dbo].[Halls] ([IDhall], [NameHall]) VALUES (3, N'Большой                       ')
SET IDENTITY_INSERT [dbo].[Halls] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (1, N'Голодные игры 1', N'США       ', 2014, N'Боевик              ', 99)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (2, N'Голодные игры', N'Франция   ', 2021, N'Фантастика          ', 99)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (3, N'Голодные игры: Сойка-пересмешница. Часть 1', N'США       ', 2014, N'Боевик              ', 123)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (4, N'Голодные игры: Сойка-пересмешница. Часть 2', N'США       ', 2015, N'Боевик              ', 137)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (5, N'Геошторм', N'США       ', 2017, N'Научная Фантастика  ', 109)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (6, N'Тупой и ещё тупее', N'США       ', 1994, N'Комедия             ', 107)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (7, N'Я худею', N'Россия    ', 2018, N'Комедия             ', 102)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (8, N'Жмурки', N'Россия    ', 2005, N'Комедия             ', 111)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (9, N'Холоп', N'Россия    ', 2019, N'Комедия             ', 109)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (10, N'Ёлки 3', N'Россия    ', 2013, N'Комедия             ', 100)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (11, N'Чебурашка', N'Россия    ', 2023, N'Детский фильм       ', 113)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (12, N'Самый лучший день', N'Россия    ', 2015, N'Комедия             ', 112)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (13, N'Пункт назначения', N'США       ', 2000, N'Ужасы               ', 98)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (14, N'Пункт назначения 2', N'США       ', 2003, N'Ужасы               ', 90)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (15, N'Пункт назначения 3', N'США       ', 2006, N'Ужасы               ', 93)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (16, N'Пункт назначения 4', N'США       ', 2009, N'Ужасы               ', 82)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (17, N'Пункт назначения 5', N'США       ', 2011, N'Ужасы               ', 92)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (18, N'Поворот не туда', N'США       ', 2003, N'Ужасы               ', 85)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (19, N'Коллекционер', N'США       ', 2009, N'Ужасы               ', 90)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (20, N'Тайна перевала Дятлова', N'Россия    ', 2013, N'Ужасы               ', 100)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (21, N'Хочу замуж', N'Россия    ', 2022, N'Мелодрамы           ', 106)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (22, N'Непослушная', N'Россия    ', 2023, N'Мелодрамы           ', 107)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (23, N'Я — легенда', N'США       ', 2007, N'Научная фантастика  ', 101)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (24, N'По наклонной', N'США       ', 2021, N'Драма               ', 141)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (25, N'Чернобыль', N'Россия    ', 2021, N'Драма               ', 136)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (26, N'Ледяной драйв', N'Канада    ', 2021, N'Триллер             ', 103)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (28, N'Волк и лев', N'Франция   ', 2021, N'Детский филь        ', 99)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Country], [YearOfIssue], [Genre], [Duration]) VALUES (29, N'Голодны игы', N'сш        ', 2013, N'Боев                ', 100)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
INSERT [dbo].[Prices] ([Date], [Time], [Hall], [Price]) VALUES (CAST(N'2023-05-09' AS Date), CAST(N'10:18:00' AS Time), 2, 8.0000)
GO
INSERT [dbo].[Seatcategories] ([Category]) VALUES (1)
INSERT [dbo].[Seatcategories] ([Category]) VALUES (2)
INSERT [dbo].[Seatcategories] ([Category]) VALUES (3)
GO
INSERT [dbo].[Seatsandrows] ([Hall], [Row], [Place], [Category]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Seatsandrows] ([Hall], [Row], [Place], [Category]) VALUES (2, 1, 1, 2)
INSERT [dbo].[Seatsandrows] ([Hall], [Row], [Place], [Category]) VALUES (3, 1, 1, 3)
GO
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-04-10' AS Date), CAST(N'12:00:00' AS Time), 3, 20)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-04-10' AS Date), CAST(N'15:00:00' AS Time), 2, 22)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-04-10' AS Date), CAST(N'18:00:00' AS Time), 3, 21)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-04-10' AS Date), CAST(N'21:00:00' AS Time), 1, 5)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'12:50:00' AS Time), 1, 10)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'16:40:00' AS Time), 3, 2)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'16:56:00' AS Time), 2, 1)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'16:57:00' AS Time), 1, 18)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'17:05:00' AS Time), 2, 4)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'18:13:00' AS Time), 1, 1)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'18:13:00' AS Time), 2, 11)
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (4, CAST(N'2023-04-10' AS Date), CAST(N'12:00:00' AS Time), 3, 1, 2, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (7, CAST(N'2023-04-10' AS Date), CAST(N'15:00:00' AS Time), 2, 1, 13, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (8, CAST(N'2023-04-10' AS Date), CAST(N'16:00:00' AS Time), 2, 1, 10, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (65, CAST(N'2023-04-24' AS Date), CAST(N'11:00:00' AS Time), 2, 1, 3, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (66, CAST(N'2023-04-24' AS Date), CAST(N'11:00:00' AS Time), 3, 1, 4, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (73, CAST(N'2023-05-02' AS Date), CAST(N'22:00:00' AS Time), 2, 5, 5, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (76, CAST(N'2023-05-05' AS Date), CAST(N'19:00:00' AS Time), 3, 6, 3, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (20, CAST(N'2023-05-08' AS Date), CAST(N'00:00:00' AS Time), 2, 4, 3, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (29, CAST(N'2023-05-08' AS Date), CAST(N'10:00:00' AS Time), 1, 1, 5, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (35, CAST(N'2023-05-08' AS Date), CAST(N'10:05:00' AS Time), 1, 2, 2, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (36, CAST(N'2023-05-08' AS Date), CAST(N'10:05:00' AS Time), 1, 2, 3, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (37, CAST(N'2023-05-08' AS Date), CAST(N'10:05:00' AS Time), 1, 2, 4, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (44, CAST(N'2023-05-08' AS Date), CAST(N'10:05:00' AS Time), 1, 4, 5, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (38, CAST(N'2023-05-08' AS Date), CAST(N'10:05:00' AS Time), 1, 4, 6, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (45, CAST(N'2023-05-08' AS Date), CAST(N'10:05:00' AS Time), 1, 4, 7, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (46, CAST(N'2023-05-08' AS Date), CAST(N'13:30:00' AS Time), 1, 1, 1, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (48, CAST(N'2023-05-08' AS Date), CAST(N'13:30:00' AS Time), 1, 2, 1, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (49, CAST(N'2023-05-08' AS Date), CAST(N'13:30:00' AS Time), 1, 2, 3, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (50, CAST(N'2023-05-08' AS Date), CAST(N'13:30:00' AS Time), 1, 2, 4, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (28, CAST(N'2023-05-08' AS Date), CAST(N'14:30:00' AS Time), 3, 3, 6, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (31, CAST(N'2023-05-08' AS Date), CAST(N'15:15:00' AS Time), 2, 1, 7, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (12, CAST(N'2023-05-08' AS Date), CAST(N'18:00:00' AS Time), 1, 5, 8, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (52, CAST(N'2023-05-08' AS Date), CAST(N'22:02:00' AS Time), 3, 2, 1, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (26, CAST(N'2023-05-08' AS Date), CAST(N'22:22:00' AS Time), 3, 7, 1, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (25, CAST(N'2023-05-08' AS Date), CAST(N'22:22:00' AS Time), 3, 7, 8, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (32, CAST(N'2023-05-09' AS Date), CAST(N'10:03:00' AS Time), 1, 1, 1, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (82, CAST(N'2023-05-09' AS Date), CAST(N'10:17:00' AS Time), 3, 3, 6, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (83, CAST(N'2023-05-09' AS Date), CAST(N'10:18:00' AS Time), 2, 3, 9, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (54, CAST(N'2023-05-09' AS Date), CAST(N'10:59:00' AS Time), 2, 10, 1, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (55, CAST(N'2023-05-09' AS Date), CAST(N'11:00:00' AS Time), 1, 1, 1, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (60, CAST(N'2023-05-09' AS Date), CAST(N'11:11:00' AS Time), 1, 4, 4, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (61, CAST(N'2023-05-09' AS Date), CAST(N'11:11:00' AS Time), 2, 4, 5, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (62, CAST(N'2023-05-09' AS Date), CAST(N'11:11:00' AS Time), 3, 4, 7, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (56, CAST(N'2023-05-09' AS Date), CAST(N'11:15:00' AS Time), 2, 8, 10, 1)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (80, CAST(N'2023-05-09' AS Date), CAST(N'12:12:00' AS Time), 1, 13, 15, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (64, CAST(N'2023-05-09' AS Date), CAST(N'13:13:00' AS Time), 1, 8, 3, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (63, CAST(N'2023-05-09' AS Date), CAST(N'13:13:00' AS Time), 3, 8, 12, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (58, CAST(N'2023-05-09' AS Date), CAST(N'13:30:00' AS Time), 3, 11, 15, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (57, CAST(N'2023-05-09' AS Date), CAST(N'15:00:00' AS Time), 3, 2, 2, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (59, CAST(N'2023-05-09' AS Date), CAST(N'15:45:00' AS Time), 1, 1, 3, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (81, CAST(N'2023-05-09' AS Date), CAST(N'19:33:00' AS Time), 2, 13, 14, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (84, CAST(N'2023-05-09' AS Date), CAST(N'20:10:00' AS Time), 2, 5, 8, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (79, CAST(N'2023-05-09' AS Date), CAST(N'23:20:00' AS Time), 3, 10, 7, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (78, CAST(N'2023-05-09' AS Date), CAST(N'23:25:00' AS Time), 2, 6, 3, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (67, CAST(N'2023-05-10' AS Date), CAST(N'21:00:00' AS Time), 3, 4, 3, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (74, CAST(N'2023-05-12' AS Date), CAST(N'17:05:00' AS Time), 3, 2, 10, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (70, CAST(N'2023-05-17' AS Date), CAST(N'21:05:00' AS Time), 2, 3, 1, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (68, CAST(N'2023-05-18' AS Date), CAST(N'22:30:00' AS Time), 3, 3, 8, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (69, CAST(N'2023-05-18' AS Date), CAST(N'22:30:00' AS Time), 3, 4, 8, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (75, CAST(N'2023-05-19' AS Date), CAST(N'11:00:00' AS Time), 3, 4, 2, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (77, CAST(N'2023-05-19' AS Date), CAST(N'19:00:00' AS Time), 2, 2, 5, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (72, CAST(N'2023-05-25' AS Date), CAST(N'13:30:00' AS Time), 2, 5, 3, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (71, CAST(N'2023-06-02' AS Date), CAST(N'23:00:00' AS Time), 2, 1, 1, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (14, CAST(N'2023-09-07' AS Date), CAST(N'19:30:00' AS Time), 1, 2, 9, 0)
INSERT [dbo].[Tickets] ([IDticket], [Date], [Time], [Hall], [Row], [Place], [Sold]) VALUES (16, CAST(N'2023-09-07' AS Date), CAST(N'19:30:00' AS Time), 2, 1, 9, 1)
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
ALTER TABLE [dbo].[Tickets] ADD  CONSTRAINT [DF_Tickets/_Продан]  DEFAULT ((0)) FOR [Sold]
GO
ALTER TABLE [dbo].[Seatsandrows]  WITH CHECK ADD  CONSTRAINT [FK_Seats and rows_Halls] FOREIGN KEY([Hall])
REFERENCES [dbo].[Halls] ([IDhall])
GO
ALTER TABLE [dbo].[Seatsandrows] CHECK CONSTRAINT [FK_Seats and rows_Halls]
GO
ALTER TABLE [dbo].[Seatsandrows]  WITH CHECK ADD  CONSTRAINT [FK_Seats and rows_Seat categories] FOREIGN KEY([Category])
REFERENCES [dbo].[Seatcategories] ([Category])
GO
ALTER TABLE [dbo].[Seatsandrows] CHECK CONSTRAINT [FK_Seats and rows_Seat categories]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Halls] FOREIGN KEY([Hall])
REFERENCES [dbo].[Halls] ([IDhall])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Halls]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Movies] FOREIGN KEY([Movie])
REFERENCES [dbo].[Movies] ([IDmovie])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Movies]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Seatsandrows] FOREIGN KEY([Hall])
REFERENCES [dbo].[Seatsandrows] ([Hall])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Seatsandrows]
GO
USE [master]
GO
ALTER DATABASE [CinemaSystem] SET  READ_WRITE 
GO
