USE [master]
GO
/****** Object:  Database [DB_TeleBerco2017]    Script Date: 20/12/2024 12:26:57 ******/
CREATE DATABASE [DB_TeleBerco2017]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_TeleBerco2017', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_TeleBerço2017.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_TeleBerco2017_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_TeleBerço2017_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_TeleBerco2017] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_TeleBerco2017].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_TeleBerco2017] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_TeleBerco2017] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_TeleBerco2017] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_TeleBerco2017] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_TeleBerco2017] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_TeleBerco2017] SET  MULTI_USER 
GO
ALTER DATABASE [DB_TeleBerco2017] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_TeleBerco2017] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_TeleBerco2017] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_TeleBerco2017] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_TeleBerco2017] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_TeleBerco2017] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_TeleBerco2017', N'ON'
GO
ALTER DATABASE [DB_TeleBerco2017] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_TeleBerco2017] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

-- Aguarde a base estar disponível
WAITFOR DELAY '00:00:05';
GO

USE [DB_TeleBerco2017]
GO
/****** Object:  Table [dbo].[Armazem]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Armazem](
	[ProdutoID] [nvarchar](20) NOT NULL,
	[Quantidade] [int] NOT NULL,
 CONSTRAINT [PK_Armazem] PRIMARY KEY CLUSTERED 
(
	[ProdutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CabecDocumento]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CabecDocumento](
	[ID] [uniqueidentifier] NOT NULL,
	[TipoDocumento] [nvarchar](10) NOT NULL,
	[NrDocumento] [int] NOT NULL,
	[Cliente] [nvarchar](20) NOT NULL,
	[Total] [decimal](8, 4) NULL,
	[DataRececao] [datetime] NOT NULL,
	[DataEntrega] [datetime] NULL,
	[Estado] [nvarchar](50) NULL,
	[Observacoes] [nvarchar](500) NULL,
	[CodProduto] [nvarchar](20) NULL,
	[Desconto] [int] NULL,
	[TipoDesconto] [nvarchar](50) NULL,
	[Fornecedor] [nvarchar](20) NULL,
 CONSTRAINT [CabProdutos_ID_PK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [CabecDocumento_TipoDocumento_NrDocumento_UN] UNIQUE NONCLUSTERED 
(
	[TipoDocumento] ASC,
	[NrDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CodCat] [nvarchar](20) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
 CONSTRAINT [Cat_Codigo_PK] PRIMARY KEY CLUSTERED 
(
	[CodCat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[CodCl] [nvarchar](20) NOT NULL,
	[Nome] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[Telefone] [nvarchar](26) NOT NULL,
 CONSTRAINT [Clientes_Codigo_PK] PRIMARY KEY CLUSTERED 
(
	[CodCl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fornecedores]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedores](
	[FornecedorID] [nvarchar](20) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Contato] [nvarchar](100) NOT NULL,
	[Site] [nvarchar](200) NULL,
	[Morada] [nvarchar](200) NULL,
	[Categoria] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FornecedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaProdutos]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaProdutos](
	[ID] [uniqueidentifier] NOT NULL,
	[CabProdutoID] [uniqueidentifier] NOT NULL,
	[Produto] [nvarchar](20) NOT NULL,
	[PrecoUnt] [decimal](8, 4) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[Total] [decimal](8, 4) NOT NULL,
	[NomeProduto] [nvarchar](50) NOT NULL,
	[Observacao] [nvarchar](250) NULL,
	[IMEI] [nvarchar](50) NULL,
	[Marca] [int] NOT NULL,
	[NumLInha] [int] NOT NULL,
	[Categoria] [nvarchar](20) NULL,
 CONSTRAINT [ListaProdutos_ID_PK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
 CONSTRAINT [Marcas_Id_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimentacoeStock]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimentacoeStock](
	[MovimentacaoID] [int] IDENTITY(1,1) NOT NULL,
	[ProdutoID] [nvarchar](20) NOT NULL,
	[DataMovimentacao] [datetime] NOT NULL,
	[Quantidade] [int] NOT NULL,
	[TipoMovimentacao] [char](1) NOT NULL,
	[nrDocumnto] [nvarchar](20) NOT NULL,
 CONSTRAINT [Mov_PK] PRIMARY KEY CLUSTERED 
(
	[MovimentacaoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[CodPr] [nvarchar](20) NOT NULL,
	[NomeProduto] [nvarchar](100) NOT NULL,
	[Observacao] [nvarchar](250) NULL,
	[IMEI] [nvarchar](50) NULL,
	[PrecoCusto] [decimal](8, 4) NOT NULL,
	[PreçoVenda] [decimal](8, 4) NULL,
	[Marca] [int] NOT NULL,
	[Categoria] [nvarchar](20) NOT NULL,
	[Tipo] [nvarchar](20) NULL,
 CONSTRAINT [Produtos_Codigo_PK] PRIMARY KEY CLUSTERED 
(
	[CodPr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumentos]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumentos](
	[CodDoc] [nvarchar](10) NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL,
 CONSTRAINT [TipoDocumentos_Codigo_PK] PRIMARY KEY CLUSTERED 
(
	[CodDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MovimentacoeStock] ADD  DEFAULT (getdate()) FOR [DataMovimentacao]
GO
ALTER TABLE [dbo].[Armazem]  WITH CHECK ADD  CONSTRAINT [FK_Armazem_Produtos] FOREIGN KEY([ProdutoID])
REFERENCES [dbo].[Produtos] ([CodPr])
GO
ALTER TABLE [dbo].[Armazem] CHECK CONSTRAINT [FK_Armazem_Produtos]
GO
ALTER TABLE [dbo].[CabecDocumento]  WITH CHECK ADD  CONSTRAINT [CabecDocumento_Cliente_FK] FOREIGN KEY([Cliente])
REFERENCES [dbo].[Clientes] ([CodCl])
GO
ALTER TABLE [dbo].[CabecDocumento] CHECK CONSTRAINT [CabecDocumento_Cliente_FK]
GO
ALTER TABLE [dbo].[CabecDocumento]  WITH CHECK ADD  CONSTRAINT [CabecDocumento_Produtos_FK] FOREIGN KEY([CodProduto])
REFERENCES [dbo].[Produtos] ([CodPr])
GO
ALTER TABLE [dbo].[CabecDocumento] CHECK CONSTRAINT [CabecDocumento_Produtos_FK]
GO
ALTER TABLE [dbo].[CabecDocumento]  WITH CHECK ADD  CONSTRAINT [CabecDocumento_TipoDocumento_FK] FOREIGN KEY([TipoDocumento])
REFERENCES [dbo].[TipoDocumentos] ([CodDoc])
GO
ALTER TABLE [dbo].[CabecDocumento] CHECK CONSTRAINT [CabecDocumento_TipoDocumento_FK]
GO
ALTER TABLE [dbo].[CabecDocumento]  WITH CHECK ADD  CONSTRAINT [FK_cabecDocumento_fornecedor] FOREIGN KEY([Fornecedor])
REFERENCES [dbo].[Fornecedores] ([FornecedorID])
GO
ALTER TABLE [dbo].[CabecDocumento] CHECK CONSTRAINT [FK_cabecDocumento_fornecedor]
GO
ALTER TABLE [dbo].[Fornecedores]  WITH CHECK ADD  CONSTRAINT [Fornecedores_Categoria_FK] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categorias] ([CodCat])
GO
ALTER TABLE [dbo].[Fornecedores] CHECK CONSTRAINT [Fornecedores_Categoria_FK]
GO
ALTER TABLE [dbo].[ListaProdutos]  WITH CHECK ADD  CONSTRAINT [ListaProdutos_CabecProdutos_FK] FOREIGN KEY([CabProdutoID])
REFERENCES [dbo].[CabecDocumento] ([ID])
GO
ALTER TABLE [dbo].[ListaProdutos] CHECK CONSTRAINT [ListaProdutos_CabecProdutos_FK]
GO
ALTER TABLE [dbo].[ListaProdutos]  WITH CHECK ADD  CONSTRAINT [ListaProdutos_Categoria_FK] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categorias] ([CodCat])
GO
ALTER TABLE [dbo].[ListaProdutos] CHECK CONSTRAINT [ListaProdutos_Categoria_FK]
GO
ALTER TABLE [dbo].[ListaProdutos]  WITH CHECK ADD  CONSTRAINT [ListaProdutos_Marcas_FK] FOREIGN KEY([Marca])
REFERENCES [dbo].[Marcas] ([Id])
GO
ALTER TABLE [dbo].[ListaProdutos] CHECK CONSTRAINT [ListaProdutos_Marcas_FK]
GO
ALTER TABLE [dbo].[ListaProdutos]  WITH CHECK ADD  CONSTRAINT [ListaProdutos_Produtos_FK] FOREIGN KEY([Produto])
REFERENCES [dbo].[Produtos] ([CodPr])
GO
ALTER TABLE [dbo].[ListaProdutos] CHECK CONSTRAINT [ListaProdutos_Produtos_FK]
GO
ALTER TABLE [dbo].[MovimentacoeStock]  WITH CHECK ADD  CONSTRAINT [FK_MovimentacoeStock_Produtos] FOREIGN KEY([ProdutoID])
REFERENCES [dbo].[Produtos] ([CodPr])
GO
ALTER TABLE [dbo].[MovimentacoeStock] CHECK CONSTRAINT [FK_MovimentacoeStock_Produtos]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [Produtos_Categoria_FK] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categorias] ([CodCat])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [Produtos_Categoria_FK]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [Produtos_Marcas_FK] FOREIGN KEY([Marca])
REFERENCES [dbo].[Marcas] ([Id])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [Produtos_Marcas_FK]
GO
/****** Object:  StoredProcedure [dbo].[NomeCategoria]    Script Date: 20/12/2024 12:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NomeCategoria]
(
	@Id nvarchar(20)
)
AS
	SET NOCOUNT ON;
Select Categorias.Nome from Categorias
inner join Produtos
ON Produtos.Categoria=Categorias.CodCat
where Produtos.Categoria= @Id
GO
USE [master]
GO
ALTER DATABASE [DB_TeleBerco2017] SET  READ_WRITE 
GO
