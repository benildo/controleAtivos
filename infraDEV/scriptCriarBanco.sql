USE [master]
GO
/****** Object:  Database [AtivosDB]    Script Date: 19/07/2018 11:01:01 ******/
CREATE DATABASE [AtivosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AtivosDB', FILENAME = N'D:\Microsoft SQL Server\MSSQL11.SQLEXPRESS_12\MSSQL\DATA\AtivosDB.mdf' , SIZE = 9216KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AtivosDB_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL11.SQLEXPRESS_12\MSSQL\DATA\AtivosDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AtivosDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AtivosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AtivosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AtivosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AtivosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AtivosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AtivosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AtivosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AtivosDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AtivosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AtivosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AtivosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AtivosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AtivosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AtivosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AtivosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AtivosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AtivosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AtivosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AtivosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AtivosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AtivosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AtivosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AtivosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AtivosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AtivosDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AtivosDB] SET  MULTI_USER 
GO
ALTER DATABASE [AtivosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AtivosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AtivosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AtivosDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [AtivosDB]
GO
/****** Object:  User [IIS APPPOOL\InfraDB]    Script Date: 19/07/2018 11:01:01 ******/
CREATE USER [IIS APPPOOL\InfraDB] FOR LOGIN [IIS APPPOOL\InfraDB] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [IIS APPPOOL\infra]    Script Date: 19/07/2018 11:01:01 ******/
CREATE USER [IIS APPPOOL\infra] FOR LOGIN [IIS APPPOOL\infra] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\InfraDB]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\InfraDB]
GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\infra]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\infra]
GO
/****** Object:  Table [dbo].[Cadeira]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cadeira](
	[CadeiraID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[ModModelID] [int] NULL,
	[PlaquetaID] [int] NULL,
	[Data] [date] NOT NULL,
 CONSTRAINT [PK_Cadeira] PRIMARY KEY CLUSTERED 
(
	[CadeiraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Celular]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Celular](
	[CelularID] [int] IDENTITY(1,1) NOT NULL,
	[ModTelefoneID] [int] NULL,
	[FuncionarioID] [int] NULL,
	[Imei] [nvarchar](255) NULL,
	[Serial] [nvarchar](255) NULL,
	[Numero] [nvarchar](255) NULL,
 CONSTRAINT [PK_Celular] PRIMARY KEY CLUSTERED 
(
	[CelularID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cftv]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cftv](
	[CftvID] [int] IDENTITY(1,1) NOT NULL,
	[ModCftvID] [int] NULL,
	[PlaquetaID] [int] NULL,
	[Local] [nvarchar](255) NULL,
 CONSTRAINT [PK_Cftv] PRIMARY KEY CLUSTERED 
(
	[CftvID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Email]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[EmailID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[Conta] [nvarchar](255) NULL,
	[Senha] [nvarchar](255) NULL,
	[Finalidade] [nvarchar](255) NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[EmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fabricante]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fabricante](
	[IdFabricante] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NULL,
 CONSTRAINT [PK_Fabricante] PRIMARY KEY CLUSTERED 
(
	[IdFabricante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fechadura]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fechadura](
	[FechaduraID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[NumeroCadastrado] [int] NULL,
 CONSTRAINT [PK_Fechadura] PRIMARY KEY CLUSTERED 
(
	[FechaduraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[FornecedorID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NULL,
 CONSTRAINT [PK_Fornecedor] PRIMARY KEY CLUSTERED 
(
	[FornecedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[FuncionarioID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NULL,
	[SetorID] [int] NULL,
	[Email] [nvarchar](255) NULL,
	[DataAdmissao] [datetime] NULL,
	[Cargo] [nvarchar](255) NULL,
	[Termo] [bit] NOT NULL,
	[Aniversario] [date] NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[FuncionarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Impressora]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impressora](
	[ImpressoraID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[ModImpressoraID] [int] NULL,
	[PlaquetaID] [int] NULL,
 CONSTRAINT [PK_Impressora] PRIMARY KEY CLUSTERED 
(
	[ImpressoraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModCftv]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModCftv](
	[ModCftvID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NULL,
	[FabricanteID] [int] NOT NULL,
	[Modelo] [nvarchar](255) NULL,
 CONSTRAINT [PK_ModCftv] PRIMARY KEY CLUSTERED 
(
	[ModCftvID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModImpressoras]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModImpressoras](
	[ModImpressoraID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [nchar](10) NULL,
	[Fabricante] [int] NULL,
	[Fornecedor] [int] NULL,
 CONSTRAINT [PK_ModImpressoras] PRIMARY KEY CLUSTERED 
(
	[ModImpressoraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModMonitor]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModMonitor](
	[ModMonitorID] [int] IDENTITY(1,1) NOT NULL,
	[FabricanteID] [int] NULL,
	[FornecedorID] [int] NULL,
	[Modelo] [nvarchar](50) NULL,
 CONSTRAINT [PK_ModMonitor] PRIMARY KEY CLUSTERED 
(
	[ModMonitorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModMovel]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModMovel](
	[ModMovelID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [nvarchar](255) NULL,
	[FabricanteID] [int] NULL,
	[Referencia] [nvarchar](255) NULL,
	[FornecedorID] [int] NULL,
 CONSTRAINT [PK_ModMovel] PRIMARY KEY CLUSTERED 
(
	[ModMovelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModNobreak]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModNobreak](
	[ModNobreakID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [nvarchar](255) NULL,
	[FabricanteID] [int] NULL,
 CONSTRAINT [PK_ModNobreak] PRIMARY KEY CLUSTERED 
(
	[ModNobreakID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModPc]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModPc](
	[ModPcID] [int] IDENTITY(1,1) NOT NULL,
	[FabricanteID] [int] NULL,
	[Processador] [nvarchar](50) NULL,
	[Memoria] [nvarchar](50) NULL,
	[Modelo] [nvarchar](255) NULL,
	[FornecedorID] [int] NULL,
 CONSTRAINT [PK_ModPc] PRIMARY KEY CLUSTERED 
(
	[ModPcID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModPilhas]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModPilhas](
	[ModPilhaID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [nvarchar](50) NULL,
	[FabricanteID] [int] NULL,
	[Serie] [int] NULL,
 CONSTRAINT [PK_ModPilhas] PRIMARY KEY CLUSTERED 
(
	[ModPilhaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModSoftware]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModSoftware](
	[ModSoftwareID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [nvarchar](255) NULL,
	[FabricanteID] [int] NULL,
 CONSTRAINT [PK_ModSoftware] PRIMARY KEY CLUSTERED 
(
	[ModSoftwareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModSwitch]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModSwitch](
	[ModSwitchID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [nvarchar](255) NULL,
	[FabricanteID] [int] NULL,
	[FornecedorID] [int] NULL,
 CONSTRAINT [PK_ModSwitch] PRIMARY KEY CLUSTERED 
(
	[ModSwitchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModTeclado]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModTeclado](
	[ModTecladoID] [int] IDENTITY(1,1) NOT NULL,
	[FornecedorID] [int] NULL,
	[FabricanteID] [int] NULL,
	[Modelo] [nvarchar](255) NULL,
 CONSTRAINT [PK_ModTeclado] PRIMARY KEY CLUSTERED 
(
	[ModTecladoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModTelefone]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModTelefone](
	[ModTelefoneID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [nvarchar](255) NULL,
	[FabricanteID] [int] NULL,
	[FornecedorID] [int] NULL,
 CONSTRAINT [PK_ModTelefone] PRIMARY KEY CLUSTERED 
(
	[ModTelefoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Monitor]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitor](
	[MonitorID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[FabricanteID] [int] NULL,
	[Modelo] [int] NULL,
	[PlaquetaID] [int] NULL,
 CONSTRAINT [PK_Monitor] PRIMARY KEY CLUSTERED 
(
	[MonitorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Moveis]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moveis](
	[MovelID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[Modelo] [int] NULL,
	[PlaquetaID] [int] NULL,
 CONSTRAINT [PK_Moveis] PRIMARY KEY CLUSTERED 
(
	[MovelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nobreak]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nobreak](
	[NobreakID] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [int] NULL,
	[FabricanteID] [int] NULL,
	[PlaquetaID] [int] NULL,
 CONSTRAINT [PK_Nobreak] PRIMARY KEY CLUSTERED 
(
	[NobreakID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ocorrencia]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocorrencia](
	[OcorrenciaID] [int] IDENTITY(1,1) NOT NULL,
	[PlaquetaID] [int] NULL,
	[Descrição] [nvarchar](max) NULL,
	[FuncionarioID] [int] NULL,
	[Data] [datetime] NULL,
 CONSTRAINT [PK_Ocorrencia] PRIMARY KEY CLUSTERED 
(
	[OcorrenciaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Office]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Office](
	[OfficeID] [int] IDENTITY(1,1) NOT NULL,
	[ModSoftwareID] [int] NULL,
	[Chave] [nvarchar](255) NULL,
	[Ativado] [bit] NOT NULL,
	[FuncionarioID] [int] NULL,
 CONSTRAINT [PK_Office] PRIMARY KEY CLUSTERED 
(
	[OfficeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pc]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pc](
	[PcID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[ModPcID] [int] NULL,
	[NomePc] [nvarchar](255) NULL,
	[Série] [nvarchar](255) NULL,
	[PlaquetaID] [int] NOT NULL,
	[Auditorado] [bit] NOT NULL,
	[DataCompra] [date] NULL,
	[Preço] [real] NULL,
 CONSTRAINT [PK_Pc] PRIMARY KEY CLUSTERED 
(
	[PcID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pilha]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pilha](
	[PilhaID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[ModPilhaID] [int] NULL,
	[Data] [date] NULL,
 CONSTRAINT [PK_Pilha] PRIMARY KEY CLUSTERED 
(
	[PilhaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Plaqueta]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plaqueta](
	[PlaquetaID] [int] IDENTITY(1,1) NOT NULL,
	[Ativada] [bit] NOT NULL,
 CONSTRAINT [PK_Plaqueta] PRIMARY KEY CLUSTERED 
(
	[PlaquetaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ramal]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ramal](
	[RamalID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[ModTelefoneID] [int] NULL,
	[Mac] [nvarchar](50) NULL,
	[Ip] [nvarchar](50) NULL,
	[Numero] [nchar](10) NULL,
 CONSTRAINT [PK_Ramal] PRIMARY KEY CLUSTERED 
(
	[RamalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Setor]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setor](
	[SetorID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NULL,
 CONSTRAINT [PK_Setor] PRIMARY KEY CLUSTERED 
(
	[SetorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Switch]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Switch](
	[SwitchID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[SetorID] [int] NULL,
	[FabricanteID] [int] NULL,
	[PlaquetaID] [int] NULL,
 CONSTRAINT [PK_Switch] PRIMARY KEY CLUSTERED 
(
	[SwitchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teclado]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teclado](
	[TecladoID] [int] IDENTITY(1,1) NOT NULL,
	[FuncionarioID] [int] NULL,
	[FabricanteID] [int] NULL,
	[ModTecladoID] [int] NULL,
	[PlaquetaID] [int] NULL,
 CONSTRAINT [PK_Teclado] PRIMARY KEY CLUSTERED 
(
	[TecladoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Windows]    Script Date: 19/07/2018 11:01:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Windows](
	[WindowsID] [int] IDENTITY(1,1) NOT NULL,
	[ModSoftwareID] [int] NULL,
	[Serial] [nvarchar](255) NULL,
	[FuncionarioID] [int] NULL,
	[Ativado] [bit] NOT NULL,
 CONSTRAINT [PK_Windows] PRIMARY KEY CLUSTERED 
(
	[WindowsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cadeira]  WITH CHECK ADD  CONSTRAINT [FK_Cadeira_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Cadeira] CHECK CONSTRAINT [FK_Cadeira_Funcionario]
GO
ALTER TABLE [dbo].[Cadeira]  WITH CHECK ADD  CONSTRAINT [FK_Cadeira_ModModel] FOREIGN KEY([ModModelID])
REFERENCES [dbo].[ModMovel] ([ModMovelID])
GO
ALTER TABLE [dbo].[Cadeira] CHECK CONSTRAINT [FK_Cadeira_ModModel]
GO
ALTER TABLE [dbo].[Cadeira]  WITH CHECK ADD  CONSTRAINT [FK_Cadeira_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Cadeira] CHECK CONSTRAINT [FK_Cadeira_Plaqueta]
GO
ALTER TABLE [dbo].[Celular]  WITH NOCHECK ADD  CONSTRAINT [FK_Celular_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Celular] CHECK CONSTRAINT [FK_Celular_Funcionario]
GO
ALTER TABLE [dbo].[Celular]  WITH CHECK ADD  CONSTRAINT [FK_Celular_ModTelefone] FOREIGN KEY([ModTelefoneID])
REFERENCES [dbo].[ModTelefone] ([ModTelefoneID])
GO
ALTER TABLE [dbo].[Celular] CHECK CONSTRAINT [FK_Celular_ModTelefone]
GO
ALTER TABLE [dbo].[Cftv]  WITH CHECK ADD  CONSTRAINT [FK_Cftv_ModCftv] FOREIGN KEY([ModCftvID])
REFERENCES [dbo].[ModCftv] ([ModCftvID])
GO
ALTER TABLE [dbo].[Cftv] CHECK CONSTRAINT [FK_Cftv_ModCftv]
GO
ALTER TABLE [dbo].[Cftv]  WITH CHECK ADD  CONSTRAINT [FK_Cftv_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Cftv] CHECK CONSTRAINT [FK_Cftv_Plaqueta]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Funcionario]
GO
ALTER TABLE [dbo].[Fechadura]  WITH CHECK ADD  CONSTRAINT [FK_Fechadura_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Fechadura] CHECK CONSTRAINT [FK_Fechadura_Funcionario]
GO
ALTER TABLE [dbo].[Funcionario]  WITH CHECK ADD  CONSTRAINT [FK_Funcionario_Setor] FOREIGN KEY([SetorID])
REFERENCES [dbo].[Setor] ([SetorID])
GO
ALTER TABLE [dbo].[Funcionario] CHECK CONSTRAINT [FK_Funcionario_Setor]
GO
ALTER TABLE [dbo].[Impressora]  WITH CHECK ADD  CONSTRAINT [FK_Impressora_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Impressora] CHECK CONSTRAINT [FK_Impressora_Funcionario]
GO
ALTER TABLE [dbo].[Impressora]  WITH CHECK ADD  CONSTRAINT [FK_Impressora_ModImpressora] FOREIGN KEY([ModImpressoraID])
REFERENCES [dbo].[ModImpressoras] ([ModImpressoraID])
GO
ALTER TABLE [dbo].[Impressora] CHECK CONSTRAINT [FK_Impressora_ModImpressora]
GO
ALTER TABLE [dbo].[Impressora]  WITH CHECK ADD  CONSTRAINT [FK_Impressora_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Impressora] CHECK CONSTRAINT [FK_Impressora_Plaqueta]
GO
ALTER TABLE [dbo].[ModCftv]  WITH CHECK ADD  CONSTRAINT [FK_ModCftv_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModCftv] CHECK CONSTRAINT [FK_ModCftv_Fabricante]
GO
ALTER TABLE [dbo].[ModImpressoras]  WITH CHECK ADD  CONSTRAINT [FK_ModImpressoras_Fabricante] FOREIGN KEY([Fabricante])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModImpressoras] CHECK CONSTRAINT [FK_ModImpressoras_Fabricante]
GO
ALTER TABLE [dbo].[ModImpressoras]  WITH CHECK ADD  CONSTRAINT [FK_ModImpressoras_Fornecedor] FOREIGN KEY([Fornecedor])
REFERENCES [dbo].[Fornecedor] ([FornecedorID])
GO
ALTER TABLE [dbo].[ModImpressoras] CHECK CONSTRAINT [FK_ModImpressoras_Fornecedor]
GO
ALTER TABLE [dbo].[ModMonitor]  WITH CHECK ADD  CONSTRAINT [FK_ModMonitor_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModMonitor] CHECK CONSTRAINT [FK_ModMonitor_Fabricante]
GO
ALTER TABLE [dbo].[ModMonitor]  WITH CHECK ADD  CONSTRAINT [FK_ModMonitor_Fornecedor] FOREIGN KEY([FornecedorID])
REFERENCES [dbo].[Fornecedor] ([FornecedorID])
GO
ALTER TABLE [dbo].[ModMonitor] CHECK CONSTRAINT [FK_ModMonitor_Fornecedor]
GO
ALTER TABLE [dbo].[ModMovel]  WITH CHECK ADD  CONSTRAINT [FK_ModMovel_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModMovel] CHECK CONSTRAINT [FK_ModMovel_Fabricante]
GO
ALTER TABLE [dbo].[ModMovel]  WITH CHECK ADD  CONSTRAINT [FK_ModMovel_Fornecedor] FOREIGN KEY([FornecedorID])
REFERENCES [dbo].[Fornecedor] ([FornecedorID])
GO
ALTER TABLE [dbo].[ModMovel] CHECK CONSTRAINT [FK_ModMovel_Fornecedor]
GO
ALTER TABLE [dbo].[ModNobreak]  WITH CHECK ADD  CONSTRAINT [FK_ModNobreak_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModNobreak] CHECK CONSTRAINT [FK_ModNobreak_Fabricante]
GO
ALTER TABLE [dbo].[ModPc]  WITH CHECK ADD  CONSTRAINT [FK_ModPc_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModPc] CHECK CONSTRAINT [FK_ModPc_Fabricante]
GO
ALTER TABLE [dbo].[ModPc]  WITH CHECK ADD  CONSTRAINT [FK_ModPc_Fornecedor] FOREIGN KEY([FornecedorID])
REFERENCES [dbo].[Fornecedor] ([FornecedorID])
GO
ALTER TABLE [dbo].[ModPc] CHECK CONSTRAINT [FK_ModPc_Fornecedor]
GO
ALTER TABLE [dbo].[ModPilhas]  WITH CHECK ADD  CONSTRAINT [FK_ModPilhas_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModPilhas] CHECK CONSTRAINT [FK_ModPilhas_Fabricante]
GO
ALTER TABLE [dbo].[ModSoftware]  WITH CHECK ADD  CONSTRAINT [FK_ModSoftware_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModSoftware] CHECK CONSTRAINT [FK_ModSoftware_Fabricante]
GO
ALTER TABLE [dbo].[ModSwitch]  WITH CHECK ADD  CONSTRAINT [FK_ModSwitch_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModSwitch] CHECK CONSTRAINT [FK_ModSwitch_Fabricante]
GO
ALTER TABLE [dbo].[ModSwitch]  WITH CHECK ADD  CONSTRAINT [FK_ModSwitch_Fornecedor] FOREIGN KEY([FornecedorID])
REFERENCES [dbo].[Fornecedor] ([FornecedorID])
GO
ALTER TABLE [dbo].[ModSwitch] CHECK CONSTRAINT [FK_ModSwitch_Fornecedor]
GO
ALTER TABLE [dbo].[ModTeclado]  WITH CHECK ADD  CONSTRAINT [FK_ModTeclado_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModTeclado] CHECK CONSTRAINT [FK_ModTeclado_Fabricante]
GO
ALTER TABLE [dbo].[ModTeclado]  WITH CHECK ADD  CONSTRAINT [FK_ModTeclado_Fornecedor] FOREIGN KEY([FornecedorID])
REFERENCES [dbo].[Fornecedor] ([FornecedorID])
GO
ALTER TABLE [dbo].[ModTeclado] CHECK CONSTRAINT [FK_ModTeclado_Fornecedor]
GO
ALTER TABLE [dbo].[ModTelefone]  WITH CHECK ADD  CONSTRAINT [FK_ModTelefone_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[ModTelefone] CHECK CONSTRAINT [FK_ModTelefone_Fabricante]
GO
ALTER TABLE [dbo].[ModTelefone]  WITH CHECK ADD  CONSTRAINT [FK_ModTelefone_Fornecedor] FOREIGN KEY([FornecedorID])
REFERENCES [dbo].[Fornecedor] ([FornecedorID])
GO
ALTER TABLE [dbo].[ModTelefone] CHECK CONSTRAINT [FK_ModTelefone_Fornecedor]
GO
ALTER TABLE [dbo].[Monitor]  WITH CHECK ADD  CONSTRAINT [FK_Monitor_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[Monitor] CHECK CONSTRAINT [FK_Monitor_Fabricante]
GO
ALTER TABLE [dbo].[Monitor]  WITH CHECK ADD  CONSTRAINT [FK_Monitor_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Monitor] CHECK CONSTRAINT [FK_Monitor_Funcionario]
GO
ALTER TABLE [dbo].[Monitor]  WITH CHECK ADD  CONSTRAINT [FK_Monitor_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Monitor] CHECK CONSTRAINT [FK_Monitor_Plaqueta]
GO
ALTER TABLE [dbo].[Moveis]  WITH NOCHECK ADD  CONSTRAINT [FK_Moveis_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Moveis] CHECK CONSTRAINT [FK_Moveis_Funcionario]
GO
ALTER TABLE [dbo].[Moveis]  WITH CHECK ADD  CONSTRAINT [FK_Moveis_ModMoveis] FOREIGN KEY([MovelID])
REFERENCES [dbo].[ModMovel] ([ModMovelID])
GO
ALTER TABLE [dbo].[Moveis] CHECK CONSTRAINT [FK_Moveis_ModMoveis]
GO
ALTER TABLE [dbo].[Moveis]  WITH CHECK ADD  CONSTRAINT [FK_Moveis_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Moveis] CHECK CONSTRAINT [FK_Moveis_Plaqueta]
GO
ALTER TABLE [dbo].[Nobreak]  WITH CHECK ADD  CONSTRAINT [FK_Nobreak_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[Nobreak] CHECK CONSTRAINT [FK_Nobreak_Fabricante]
GO
ALTER TABLE [dbo].[Nobreak]  WITH CHECK ADD  CONSTRAINT [FK_Nobreak_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Nobreak] CHECK CONSTRAINT [FK_Nobreak_Plaqueta]
GO
ALTER TABLE [dbo].[Ocorrencia]  WITH CHECK ADD  CONSTRAINT [FK_Ocorrencia_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Ocorrencia] CHECK CONSTRAINT [FK_Ocorrencia_Funcionario]
GO
ALTER TABLE [dbo].[Ocorrencia]  WITH NOCHECK ADD  CONSTRAINT [FK_Ocorrencia_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Ocorrencia] CHECK CONSTRAINT [FK_Ocorrencia_Plaqueta]
GO
ALTER TABLE [dbo].[Office]  WITH CHECK ADD  CONSTRAINT [FK_Office_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Office] CHECK CONSTRAINT [FK_Office_Funcionario]
GO
ALTER TABLE [dbo].[Office]  WITH CHECK ADD  CONSTRAINT [FK_Office_ModSoftware] FOREIGN KEY([ModSoftwareID])
REFERENCES [dbo].[ModSoftware] ([ModSoftwareID])
GO
ALTER TABLE [dbo].[Office] CHECK CONSTRAINT [FK_Office_ModSoftware]
GO
ALTER TABLE [dbo].[Pc]  WITH CHECK ADD  CONSTRAINT [FK_Pc_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Pc] CHECK CONSTRAINT [FK_Pc_Funcionario]
GO
ALTER TABLE [dbo].[Pc]  WITH CHECK ADD  CONSTRAINT [FK_Pc_ModPc] FOREIGN KEY([ModPcID])
REFERENCES [dbo].[ModPc] ([ModPcID])
GO
ALTER TABLE [dbo].[Pc] CHECK CONSTRAINT [FK_Pc_ModPc]
GO
ALTER TABLE [dbo].[Pc]  WITH CHECK ADD  CONSTRAINT [FK_Pc_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Pc] CHECK CONSTRAINT [FK_Pc_Plaqueta]
GO
ALTER TABLE [dbo].[Pilha]  WITH CHECK ADD  CONSTRAINT [FK_Pilha_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Pilha] CHECK CONSTRAINT [FK_Pilha_Funcionario]
GO
ALTER TABLE [dbo].[Pilha]  WITH CHECK ADD  CONSTRAINT [FK_Pilha_ModPilha] FOREIGN KEY([PilhaID])
REFERENCES [dbo].[ModPilhas] ([ModPilhaID])
GO
ALTER TABLE [dbo].[Pilha] CHECK CONSTRAINT [FK_Pilha_ModPilha]
GO
ALTER TABLE [dbo].[Ramal]  WITH CHECK ADD  CONSTRAINT [FK_Ramal_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Ramal] CHECK CONSTRAINT [FK_Ramal_Funcionario]
GO
ALTER TABLE [dbo].[Ramal]  WITH CHECK ADD  CONSTRAINT [FK_Ramal_ModTelefone] FOREIGN KEY([ModTelefoneID])
REFERENCES [dbo].[ModTelefone] ([ModTelefoneID])
GO
ALTER TABLE [dbo].[Ramal] CHECK CONSTRAINT [FK_Ramal_ModTelefone]
GO
ALTER TABLE [dbo].[Switch]  WITH CHECK ADD  CONSTRAINT [FK_Switch_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[Switch] CHECK CONSTRAINT [FK_Switch_Fabricante]
GO
ALTER TABLE [dbo].[Switch]  WITH CHECK ADD  CONSTRAINT [FK_Switch_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Switch] CHECK CONSTRAINT [FK_Switch_Funcionario]
GO
ALTER TABLE [dbo].[Switch]  WITH CHECK ADD  CONSTRAINT [FK_Switch_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Switch] CHECK CONSTRAINT [FK_Switch_Plaqueta]
GO
ALTER TABLE [dbo].[Switch]  WITH CHECK ADD  CONSTRAINT [FK_Switch_Setor] FOREIGN KEY([SetorID])
REFERENCES [dbo].[Setor] ([SetorID])
GO
ALTER TABLE [dbo].[Switch] CHECK CONSTRAINT [FK_Switch_Setor]
GO
ALTER TABLE [dbo].[Teclado]  WITH CHECK ADD  CONSTRAINT [FK_Teclado_Fabricante] FOREIGN KEY([FabricanteID])
REFERENCES [dbo].[Fabricante] ([IdFabricante])
GO
ALTER TABLE [dbo].[Teclado] CHECK CONSTRAINT [FK_Teclado_Fabricante]
GO
ALTER TABLE [dbo].[Teclado]  WITH CHECK ADD  CONSTRAINT [FK_Teclado_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Teclado] CHECK CONSTRAINT [FK_Teclado_Funcionario]
GO
ALTER TABLE [dbo].[Teclado]  WITH CHECK ADD  CONSTRAINT [FK_Teclado_ModTeclado] FOREIGN KEY([ModTecladoID])
REFERENCES [dbo].[ModTeclado] ([ModTecladoID])
GO
ALTER TABLE [dbo].[Teclado] CHECK CONSTRAINT [FK_Teclado_ModTeclado]
GO
ALTER TABLE [dbo].[Teclado]  WITH CHECK ADD  CONSTRAINT [FK_Teclado_Plaqueta] FOREIGN KEY([PlaquetaID])
REFERENCES [dbo].[Plaqueta] ([PlaquetaID])
GO
ALTER TABLE [dbo].[Teclado] CHECK CONSTRAINT [FK_Teclado_Plaqueta]
GO
ALTER TABLE [dbo].[Windows]  WITH CHECK ADD  CONSTRAINT [FK_Windows_Funcionario] FOREIGN KEY([FuncionarioID])
REFERENCES [dbo].[Funcionario] ([FuncionarioID])
GO
ALTER TABLE [dbo].[Windows] CHECK CONSTRAINT [FK_Windows_Funcionario]
GO
ALTER TABLE [dbo].[Windows]  WITH CHECK ADD  CONSTRAINT [FK_Windows_ModSoftware] FOREIGN KEY([ModSoftwareID])
REFERENCES [dbo].[ModSoftware] ([ModSoftwareID])
GO
ALTER TABLE [dbo].[Windows] CHECK CONSTRAINT [FK_Windows_ModSoftware]
GO
USE [master]
GO
ALTER DATABASE [AtivosDB] SET  READ_WRITE 
GO
