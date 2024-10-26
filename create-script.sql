USE [master]
GO

/****** Object:  Database [Employment]    Script Date: 10/27/2024 12:24:09 AM ******/
CREATE DATABASE [Employment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Employment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Employment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Employment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Employment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Employment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Employment] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Employment] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Employment] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Employment] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Employment] SET ARITHABORT OFF 
GO

ALTER DATABASE [Employment] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Employment] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Employment] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Employment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Employment] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Employment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Employment] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Employment] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Employment] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Employment] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Employment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Employment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Employment] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Employment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Employment] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Employment] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [Employment] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Employment] SET RECOVERY FULL 
GO

ALTER DATABASE [Employment] SET  MULTI_USER 
GO

ALTER DATABASE [Employment] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Employment] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Employment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Employment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Employment] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Employment] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Employment] SET QUERY_STORE = ON
GO

ALTER DATABASE [Employment] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [Employment] SET  READ_WRITE 
GO

