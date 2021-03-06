USE [master]
GO
/****** Object:  Database [ClienteCilindroDB]    Script Date: 23/7/2022 16:36:26 ******/
CREATE DATABASE [ClienteCilindroDB]
 CONTAINMENT = NONE
ALTER DATABASE [ClienteCilindroDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClienteCilindroDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClienteCilindroDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ClienteCilindroDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ClienteCilindroDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ClienteCilindroDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ClienteCilindroDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ClienteCilindroDB] SET  MULTI_USER 
GO
ALTER DATABASE [ClienteCilindroDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ClienteCilindroDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ClienteCilindroDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ClienteCilindroDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ClienteCilindroDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ClienteCilindroDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ClienteCilindroDB', N'ON'
GO
ALTER DATABASE [ClienteCilindroDB] SET QUERY_STORE = OFF
GO
USE [ClienteCilindroDB]
GO
/****** Object:  Table [dbo].[Cilindros]    Script Date: 23/7/2022 16:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cilindros](
	[idCilindro] [int] IDENTITY(1,1) NOT NULL,
	[tamanio] [int] NULL,
	[tipoResistencia] [int] NULL,
 CONSTRAINT [PK_Cilindros] PRIMARY KEY CLUSTERED 
(
	[idCilindro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 23/7/2022 16:36:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[direccion] [varchar](250) NOT NULL,
	[nacionalidad] [int] NOT NULL,
	[cuit] [varchar](11) NOT NULL,
	[contacto] [varchar](250) NOT NULL,
	[telefono] [varchar](10) NOT NULL,
	[mail] [varchar](250) NOT NULL,
	[mailFacturaElectronica] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (1, N'Arcor', N'Cochabamba 2668', 0, N'30710969619', N'Hernesto Gonzales', N'1149415237', N'arcorargentina@gmail.com', N'arcorfacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (2, N'Zicamor', N'Eleodoro Yanez 2342', 1, N'30867452679', N'Pepe Manziuc', N'61222137', N'zicamorchile@gmail.com', N'zicamorfacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (3, N'Estrada', N'Guayabos 2730', 2, N'30243576891', N'Gonzalo Airton', N'98260696', N'estradauruguay@gmail.com', N'estradafacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (4, N'Textil iberoaméricana', N'Travessa Um 935', 3, N'30908765479', N'Thiago Da Silva', N'92006520', N'textiliberoamericanabrazila@gmail.com', N'textiliberoamericanafacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (5, N'INPACO', N'Calle Falsa 123', 4, N'30012854674', N'Juan Perez', N'90904343', N'inpaco@gmail.com', N'inpacofacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (6, N'Ipesa', N'Av Corrientes 8268', 0, N'30904563781', N'Pedro Gutierrez', N'1187904627', N'ipesaargentina@gmail.com', N'ipesafacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (7, N'Ball', N'Pasaje Manuel Aguilar 0691', 1, N'30157683980', N'Manuel Toledo', N'81510588', N'ballchile@gmail.com', N'ballfacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (8, N'Abbatiello', N'Costanera 1968', 2, N'30768593094', N'Julia Montez', N'94558527', N'abbatiellouruguay@gmail.com', N'abbatiellofacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (9, N'Bolsaflex', N'Travessa Um 935', 3, N'30546378910', N'Joao Luis Gutierrez', N'73889442', N'bolsaflexbrazil@gmail.com', N'bolsaflexfacturas@gmail.com')
GO
INSERT [dbo].[Clientes] ([idCliente], [nombre], [direccion], [nacionalidad], [cuit], [contacto],[telefono],[mail],[mailFacturaElectronica]) VALUES (10,N'Bolsapack', N'Av Siempre Viva', 4, N'30019275869', N'Lisa Simpson', N'1101946578', N'bolsapack@gmail.com', N'bolsapackfacturas@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
INSERT [dbo].[Cilindros] ([tamanio], [tipoResistencia]) VALUES (100,0)
GO
INSERT [dbo].[Cilindros] ([tamanio], [tipoResistencia]) VALUES (120,0)
GO
INSERT [dbo].[Cilindros] ([tamanio], [tipoResistencia]) VALUES (100,1)
GO
INSERT [dbo].[Cilindros] ([tamanio], [tipoResistencia]) VALUES (120,1)
GO
INSERT [dbo].[Cilindros] ([tamanio], [tipoResistencia]) VALUES (100,2)
GO
INSERT [dbo].[Cilindros] ([tamanio], [tipoResistencia]) VALUES (120,2)
GO
USE [master]
GO
ALTER DATABASE [ClienteCilindroDB] SET  READ_WRITE 
GO

