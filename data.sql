USE [master]
GO
/****** Object:  Database [qlsv]    Script Date: 30/11/2019 11:49:16 PM ******/
CREATE DATABASE [qlsv]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'qlsv', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\qlsv.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'qlsv_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\qlsv_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [qlsv] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [qlsv].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [qlsv] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [qlsv] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [qlsv] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [qlsv] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [qlsv] SET ARITHABORT OFF 
GO
ALTER DATABASE [qlsv] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [qlsv] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [qlsv] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [qlsv] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [qlsv] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [qlsv] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [qlsv] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [qlsv] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [qlsv] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [qlsv] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [qlsv] SET  DISABLE_BROKER 
GO
ALTER DATABASE [qlsv] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [qlsv] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [qlsv] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [qlsv] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [qlsv] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [qlsv] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [qlsv] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [qlsv] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [qlsv] SET  MULTI_USER 
GO
ALTER DATABASE [qlsv] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [qlsv] SET DB_CHAINING OFF 
GO
ALTER DATABASE [qlsv] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [qlsv] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [qlsv]
GO
/****** Object:  Table [dbo].[sv]    Script Date: 30/11/2019 11:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sv](
	[masv] [nvarchar](50) NOT NULL,
	[tensv] [nvarchar](50) NULL,
	[ngaysinh] [date] NULL,
	[gioitinh] [nvarchar](50) NULL,
	[khoa] [nvarchar](50) NULL,
	[diem1] [float] NULL,
	[diem2] [float] NULL,
	[diem3] [float] NULL,
	[diem4] [float] NULL,
 CONSTRAINT [PK_sv] PRIMARY KEY CLUSTERED 
(
	[masv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[sv] ([masv], [tensv], [ngaysinh], [gioitinh], [khoa], [diem1], [diem2], [diem3], [diem4]) VALUES (N'sv1', N'teo', CAST(0xBC960A00 AS Date), N'Nam', N'CNTT', 1, 9, 7, 10)
INSERT [dbo].[sv] ([masv], [tensv], [ngaysinh], [gioitinh], [khoa], [diem1], [diem2], [diem3], [diem4]) VALUES (N'sv2', N'ti', CAST(0xCE300600 AS Date), N'Nữ', N'VATLY', 1, 2, 3, 10)
INSERT [dbo].[sv] ([masv], [tensv], [ngaysinh], [gioitinh], [khoa], [diem1], [diem2], [diem3], [diem4]) VALUES (N'sv3', N'meocon', CAST(0xABA00500 AS Date), N'Nam', N'VAN', 7, 5, 7, 7)
INSERT [dbo].[sv] ([masv], [tensv], [ngaysinh], [gioitinh], [khoa], [diem1], [diem2], [diem3], [diem4]) VALUES (N'sv5', N'oruku', CAST(0xDF160B00 AS Date), N'Nữ', N'VAN', 10, 9, 8, 10)
INSERT [dbo].[sv] ([masv], [tensv], [ngaysinh], [gioitinh], [khoa], [diem1], [diem2], [diem3], [diem4]) VALUES (N'sv8', N'RONALDO', CAST(0x1C170B00 AS Date), N'Nữ', N'CNTT', 7, 7, 7, 7)
USE [master]
GO
ALTER DATABASE [qlsv] SET  READ_WRITE 
GO
