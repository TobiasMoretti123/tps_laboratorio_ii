USE [master]
GO
/****** Object:  Database [Cliente_DB]    Script Date: 15/6/2022 21:05:57 ******/
CREATE DATABASE [Cliente_DB]
 CONTAINMENT = NONE
ALTER DATABASE [Cliente_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cliente_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cliente_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cliente_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cliente_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cliente_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cliente_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cliente_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cliente_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cliente_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cliente_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cliente_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cliente_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cliente_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cliente_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cliente_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cliente_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Cliente_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cliente_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cliente_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cliente_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cliente_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cliente_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cliente_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cliente_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [Cliente_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Cliente_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cliente_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cliente_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cliente_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cliente_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cliente_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cliente_DB', N'ON'
GO
ALTER DATABASE [Cliente_DB] SET QUERY_STORE = OFF
GO
USE [Cliente_DB]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 15/6/2022 21:05:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[cuit] [varchar](11) NOT NULL,
	[idCilindro] [int] NOT NULL,
	[tamanioCilindro] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (1, N'Arcor', N'30710969619', 0, 100)
INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (2, N'Zicamor', N'30710123388', 1, 120)
INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (3, N'Estrada', N'30717145220', 2, 100)
INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (4, N'Textil iberoamérica', N'30717582922', 0, 120)
INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (5, N'INPACO', N'30715645579', 1, 100)
INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (6, N'Ipesa', N'30717248534', 2, 120)
INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (7, N'Ball', N'30714583960', 0, 120)
INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (8, N'Abbatiello', N'30717149889', 1, 120)
INSERT [dbo].[Cliente] ([idCliente], [nombre], [cuit], [idCilindro], [tamanioCilindro]) VALUES (9, N'Bolsaflex', N'30708442034', 2, 100)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
USE [master]
GO
ALTER DATABASE [Cliente_DB] SET  READ_WRITE 
GO
