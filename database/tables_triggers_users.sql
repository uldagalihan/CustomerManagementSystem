USE [master]
GO
/****** Object:  Database [musteriDB]    Script Date: 4.10.2024 14:36:12 ******/
CREATE DATABASE [musteriDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'musteriDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\musteriDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'musteriDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\musteriDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [musteriDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [musteriDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [musteriDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [musteriDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [musteriDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [musteriDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [musteriDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [musteriDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [musteriDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [musteriDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [musteriDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [musteriDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [musteriDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [musteriDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [musteriDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [musteriDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [musteriDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [musteriDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [musteriDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [musteriDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [musteriDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [musteriDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [musteriDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [musteriDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [musteriDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [musteriDB] SET  MULTI_USER 
GO
ALTER DATABASE [musteriDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [musteriDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [musteriDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [musteriDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [musteriDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [musteriDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [musteriDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [musteriDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [musteriDB]
GO
/****** Object:  Table [dbo].[musteriNumaralari]    Script Date: 4.10.2024 14:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteriNumaralari](
	[musteriNo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBireyselMusteri]    Script Date: 4.10.2024 14:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBireyselMusteri](
	[musteriNo] [int] NULL,
	[GercekTuzelDrm] [nchar](1) NULL,
	[tcKimlikNo] [nchar](11) NULL,
	[KKTCKimlikNo] [nchar](10) NULL,
	[dogumTarihi] [date] NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[babaAdi] [nvarchar](50) NOT NULL,
	[anneAdi] [nvarchar](50) NOT NULL,
	[kayitDrm] [int] NULL,
	[sahisFirmaDrm] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblIrtibatMusteri]    Script Date: 4.10.2024 14:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblIrtibatMusteri](
	[irtibatID] [int] IDENTITY(1001,1) NOT NULL,
	[musteriNo] [int] NULL,
	[iletisimDrm] [int] NULL,
	[kayitDrm] [int] NULL,
	[adresTipKd] [int] NOT NULL,
	[adresBilgisi] [nvarchar](200) NOT NULL,
	[eadresTipKd] [int] NOT NULL,
	[eadresBilgisi] [nchar](50) NOT NULL,
	[telefonTipKd] [int] NOT NULL,
	[hatTipiKd] [int] NOT NULL,
	[alanKod] [nchar](4) NOT NULL,
	[telNo] [nchar](7) NOT NULL,
 CONSTRAINT [PK_tblIrtibatMusteri] PRIMARY KEY CLUSTERED 
(
	[irtibatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKurumsalMusteri]    Script Date: 4.10.2024 14:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKurumsalMusteri](
	[musteriNo] [int] NULL,
	[GercekTuzelDrm] [nchar](1) NULL,
	[vergiKimlikNo] [nchar](11) NOT NULL,
	[firmaKurulusTarihi] [date] NOT NULL,
	[musteriTuruKod] [int] NOT NULL,
	[calisanSayisi] [int] NOT NULL,
	[nominalSermaye] [int] NOT NULL,
	[kayitDrm] [int] NULL,
	[unvan] [nvarchar](100) NOT NULL,
	[kisaUnvan] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[musteriNumaralari] ([musteriNo]) VALUES (3)
GO
INSERT [dbo].[tblBireyselMusteri] ([musteriNo], [GercekTuzelDrm], [tcKimlikNo], [KKTCKimlikNo], [dogumTarihi], [Ad], [Soyad], [babaAdi], [anneAdi], [kayitDrm], [sahisFirmaDrm]) VALUES (1, N'B', N'11122233345', N'          ', CAST(N'2000-01-01' AS Date), N'Test', N'Kayıt1', N'testBaba', N'testAnne', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[tblIrtibatMusteri] ON 

INSERT [dbo].[tblIrtibatMusteri] ([irtibatID], [musteriNo], [iletisimDrm], [kayitDrm], [adresTipKd], [adresBilgisi], [eadresTipKd], [eadresBilgisi], [telefonTipKd], [hatTipiKd], [alanKod], [telNo]) VALUES (1041, 1, 0, 1, 0, N'Bahçelievler/Ankara', 0, N'example@example.com                               ', 0, 0, N'535 ', N'6237630')
INSERT [dbo].[tblIrtibatMusteri] ([irtibatID], [musteriNo], [iletisimDrm], [kayitDrm], [adresTipKd], [adresBilgisi], [eadresTipKd], [eadresBilgisi], [telefonTipKd], [hatTipiKd], [alanKod], [telNo]) VALUES (1042, 2, 0, 1, 1, N'Esenler/İstanbul', 1, N'example2@example.com                              ', 1, 1, N'212 ', N'0393178')
SET IDENTITY_INSERT [dbo].[tblIrtibatMusteri] OFF
GO
INSERT [dbo].[tblKurumsalMusteri] ([musteriNo], [GercekTuzelDrm], [vergiKimlikNo], [firmaKurulusTarihi], [musteriTuruKod], [calisanSayisi], [nominalSermaye], [kayitDrm], [unvan], [kisaUnvan]) VALUES (2, N'K', N'1002003001 ', CAST(N'2007-01-01' AS Date), 1, 100, 100000, 1, N'Kurumsal Test Kayıt 1 ', N'Kurumsal Test Kayıt 1 ')
GO
/****** Object:  Trigger [dbo].[trg_musteriNumaralariBaslat]    Script Date: 4.10.2024 14:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trg_musteriNumaralariBaslat]
on [dbo].[musteriNumaralari]
after delete
as
begin
insert into musteriNumaralari (musteriNo) values(1)
end
GO
ALTER TABLE [dbo].[musteriNumaralari] ENABLE TRIGGER [trg_musteriNumaralariBaslat]
GO
/****** Object:  Trigger [dbo].[trg_bireyselMusteriEkle]    Script Date: 4.10.2024 14:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trg_bireyselMusteriEkle]
on [dbo].[tblBireyselMusteri]
after insert
as
begin
declare @musteriNo int
declare @tckimlikNo nchar(11)
declare @kktcKimlikNo nchar(10)

select @musteriNo = musteriNo from musteriNumaralari
select @tckimlikNo = tcKimlikNo from inserted
select @kktcKimlikNo = KKTCKimlikNo from inserted

update tblBireyselMusteri 
set musteriNo = @musteriNo 
where tckimlikNo = @tcKimlikNo

update tblBireyselMusteri
set kayitDrm = 1 
where tcKimlikNo = @tckimlikNo

update musteriNumaralari 
set musteriNo = musteriNo+1

update tblBireyselMusteri
set GercekTuzelDrm = 'B'
where tcKimlikNo = @tckimlikNo

end
GO
ALTER TABLE [dbo].[tblBireyselMusteri] ENABLE TRIGGER [trg_bireyselMusteriEkle]
GO
/****** Object:  Trigger [dbo].[trg_irtibatMusteriEkle]    Script Date: 4.10.2024 14:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trg_irtibatMusteriEkle]
on [dbo].[tblIrtibatMusteri]
after insert
as
begin

declare @musteriNo int
declare @irtibatID int

select @musteriNo = musteriNo-1 from musteriNumaralari
select @irtibatID = irtibatID from tblIrtibatMusteri

update tblIrtibatMusteri 
set musteriNo = @musteriNo
where irtibatID = @irtibatID

update tblIrtibatMusteri
set kayitDrm = 1
where irtibatID = @irtibatID

end
GO
ALTER TABLE [dbo].[tblIrtibatMusteri] ENABLE TRIGGER [trg_irtibatMusteriEkle]
GO
/****** Object:  Trigger [dbo].[trg_tmusteriekle]    Script Date: 4.10.2024 14:36:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trg_tmusteriekle]
on [dbo].[tblKurumsalMusteri]
after insert
as
begin

declare @musteriNo int
declare @vergiKimlikNo nchar(11)

select @musteriNo = musteriNo from musteriNumaralari
select @vergiKimlikNo = vergiKimlikNo from inserted

update tblKurumsalMusteri 
set musteriNo = @musteriNo
where vergiKimlikNo = @vergiKimlikNo

update tblKurumsalMusteri
set kayitDrm = 1 
where musteriNo = @musteriNo

update tblIrtibatMusteri
set iletisimDrm = 1
where musteriNo = @musteriNo

update musteriNumaralari
set musteriNo = musteriNo+1

update tblKurumsalMusteri
set GercekTuzelDrm = 'K'
where vergiKimlikNo= @vergiKimlikNo

end
GO
ALTER TABLE [dbo].[tblKurumsalMusteri] ENABLE TRIGGER [trg_tmusteriekle]
GO
USE [master]
GO
ALTER DATABASE [musteriDB] SET  READ_WRITE 
GO
