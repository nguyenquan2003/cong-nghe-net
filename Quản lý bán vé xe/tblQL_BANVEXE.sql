USE [master]
GO
/****** Object:  Database [QL_BANVEXE]    Script Date: 29/11/2023 10:32:07 ******/
CREATE DATABASE [QL_BANVEXE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_BANVEXE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QL_BANVEXE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QL_BANVEXE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QL_BANVEXE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QL_BANVEXE] SET COMPATIBILITY_LEVEL = 160
GO
--IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
--begin
--EXEC [QL_BANVEXE].[dbo].[sp_fulltext_database] @action = 'enable'
--end
--GO
--ALTER DATABASE [QL_BANVEXE] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET AUTO_CLOSE OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [QL_BANVEXE] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET CURSOR_DEFAULT  GLOBAL 
--GO
--ALTER DATABASE [QL_BANVEXE] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET  DISABLE_BROKER 
--GO
--ALTER DATABASE [QL_BANVEXE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET DATE_CORRELATION_OPTIMIZATION OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET TRUSTWORTHY OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [QL_BANVEXE] SET READ_COMMITTED_SNAPSHOT OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET HONOR_BROKER_PRIORITY OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET RECOVERY SIMPLE 
--GO
--ALTER DATABASE [QL_BANVEXE] SET  MULTI_USER 
--GO
--ALTER DATABASE [QL_BANVEXE] SET PAGE_VERIFY CHECKSUM  
--GO
--ALTER DATABASE [QL_BANVEXE] SET DB_CHAINING OFF 
--GO
--ALTER DATABASE [QL_BANVEXE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
--GO
--ALTER DATABASE [QL_BANVEXE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
--GO
--ALTER DATABASE [QL_BANVEXE] SET DELAYED_DURABILITY = DISABLED 
--GO
--ALTER DATABASE [QL_BANVEXE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
--GO
--ALTER DATABASE [QL_BANVEXE] SET QUERY_STORE = ON
--GO
--ALTER DATABASE [QL_BANVEXE] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
--GO
USE QLBV
GO
/****** Object:  Table [dbo].[CHUYENXE]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE DATABASE QLBV
USE QLBV
CREATE TABLE [dbo].[CHUYENXE](
	[MaChuyen] [varchar](20) NOT NULL,
	[MaTuyen] [varchar](20) NOT NULL,
	[NgayKH] [date] NOT NULL,
	[GioDi] [time](0) NOT NULL,
	[GioDen] [time](7) NOT NULL,
	[GheTrong] [int] NOT NULL,
	[MaTaiXe] [varchar](20) NOT NULL,
	[BienSo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_CHUYENXE] PRIMARY KEY CLUSTERED 
(
	[MaChuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTVEXE]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTVEXE](
	[SDTKH] [varchar](11) NOT NULL,
	[MaVe] [varchar](20) NOT NULL,
	[ThanhTien] [float] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[NgayDatVe] [date] NOT NULL,
	[GhiChu] [text] NOT NULL,
	[TenGhe] [varchar](50) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[HoTenKH] [nvarchar](50) NOT NULL,
	[SDTKH] [varchar](11) NOT NULL,
	[GTinh] [nchar](5) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[SDTKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIXE]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIXE](
	[MaLoai] [varchar](20) NOT NULL,
	[TenLoai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LOAIXE] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [varchar](20) NOT NULL,
	[TenDangNhap] [varchar](30) NOT NULL,
	[MaQuyen] [varchar](20) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nchar](5) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[CCCD] [varchar](15) NOT NULL,
	[SDT] [varchar](11) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[NgayVaoLam] [date] NOT NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYENTRUYCAP]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYENTRUYCAP](
	[MaQuyen] [varchar](20) NOT NULL,
	[TenQuyen] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_QUYENTRUYCAP] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[TenDangNhap] [varchar](30) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIXE]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIXE](
	[MaTaiXe] [varchar](20) NOT NULL,
	[TenTaiXe] [nvarchar](50) NOT NULL,
	[NSinh] [date] NULL,
	[GT] [nchar](5) NULL,
	[DChi] [nvarchar](50) NULL,
	[CanCuoc] [varchar](15) NOT NULL,
	[SoDT] [varchar](11) NOT NULL,
	[DChiEmail] [varchar](50) NOT NULL,
	[NgayNhanViec] [date] NULL,
 CONSTRAINT [PK_TAIXE] PRIMARY KEY CLUSTERED 
(
	[MaTaiXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TUYENXE]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TUYENXE](
	[MaTuyen] [varchar](20) NOT NULL,
	[TenTuyen] [nvarchar](50) NOT NULL,
	[DiemDi] [nvarchar](50) NOT NULL,
	[DiemDen] [nvarchar](50) NOT NULL,
	[BangGia] [float] NOT NULL,
 CONSTRAINT [PK_TUYENXE] PRIMARY KEY CLUSTERED 
(
	[MaTuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VEXE]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VEXE](
	[MaVe] [varchar](20) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[MaChuyen] [varchar](20) NOT NULL,
 CONSTRAINT [PK_VEXE] PRIMARY KEY CLUSTERED 
(
	[MaVe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XE]    Script Date: 29/11/2023 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XE](
	[BienSo] [varchar](15) NOT NULL,
	[SoGhe] [nchar](10) NOT NULL,
	[MaLoai] [varchar](20) NOT NULL,
 CONSTRAINT [PK_XE] PRIMARY KEY CLUSTERED 
(
	[BienSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHUYENXE]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENXE_TAIXE] FOREIGN KEY([MaTaiXe])
REFERENCES [dbo].[TAIXE] ([MaTaiXe])
GO
ALTER TABLE [dbo].[CHUYENXE] CHECK CONSTRAINT [FK_CHUYENXE_TAIXE]
GO
ALTER TABLE [dbo].[CHUYENXE]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENXE_TUYENXE] FOREIGN KEY([MaTuyen])
REFERENCES [dbo].[TUYENXE] ([MaTuyen])
GO
ALTER TABLE [dbo].[CHUYENXE] CHECK CONSTRAINT [FK_CHUYENXE_TUYENXE]
GO
ALTER TABLE [dbo].[CHUYENXE]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENXE_XE] FOREIGN KEY([BienSo])
REFERENCES [dbo].[XE] ([BienSo])
GO
ALTER TABLE [dbo].[CHUYENXE] CHECK CONSTRAINT [FK_CHUYENXE_XE]
GO
ALTER TABLE [dbo].[CTVEXE]  WITH CHECK ADD  CONSTRAINT [FK_CTVEXE_KHACHHANG] FOREIGN KEY([SDTKH])
REFERENCES [dbo].[KHACHHANG] ([SDTKH])
GO
ALTER TABLE [dbo].[CTVEXE] CHECK CONSTRAINT [FK_CTVEXE_KHACHHANG]
GO
ALTER TABLE [dbo].[CTVEXE]  WITH CHECK ADD  CONSTRAINT [FK_CTVEXE_VEXE] FOREIGN KEY([MaVe])
REFERENCES [dbo].[VEXE] ([MaVe])
GO
ALTER TABLE [dbo].[CTVEXE] CHECK CONSTRAINT [FK_CTVEXE_VEXE]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_QUYENTRUYCAP] FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[QUYENTRUYCAP] ([MaQuyen])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_QUYENTRUYCAP]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_TAIKHOAN] FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[TAIKHOAN] ([TenDangNhap])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_TAIKHOAN]
GO
ALTER TABLE [dbo].[VEXE]  WITH CHECK ADD  CONSTRAINT [FK_VEXE_CHUYENXE] FOREIGN KEY([MaChuyen])
REFERENCES [dbo].[CHUYENXE] ([MaChuyen])
GO
ALTER TABLE [dbo].[VEXE] CHECK CONSTRAINT [FK_VEXE_CHUYENXE]
GO
ALTER TABLE [dbo].[VEXE]  WITH CHECK ADD  CONSTRAINT [FK_VEXE_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[VEXE] CHECK CONSTRAINT [FK_VEXE_NHANVIEN]
GO
ALTER TABLE [dbo].[XE]  WITH CHECK ADD  CONSTRAINT [FK_XE_LOAIXE] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LOAIXE] ([MaLoai])
GO
ALTER TABLE [dbo].[XE] CHECK CONSTRAINT [FK_XE_LOAIXE]
GO
USE [master]
GO
ALTER DATABASE [QLBV] SET  READ_WRITE 
GO
