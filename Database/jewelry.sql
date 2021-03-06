USE [master]
GO
/****** Object:  Database [Jewelry]    Script Date: 05/07/2018 21:14:40 ******/
CREATE DATABASE [Jewelry] ON  PRIMARY 
( NAME = N'jewelry', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\jewelry.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'jewelry_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\jewelry_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Jewelry] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Jewelry].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Jewelry] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Jewelry] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Jewelry] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Jewelry] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Jewelry] SET ARITHABORT OFF
GO
ALTER DATABASE [Jewelry] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Jewelry] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Jewelry] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Jewelry] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Jewelry] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Jewelry] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Jewelry] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Jewelry] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Jewelry] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Jewelry] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Jewelry] SET  DISABLE_BROKER
GO
ALTER DATABASE [Jewelry] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Jewelry] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Jewelry] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Jewelry] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Jewelry] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Jewelry] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Jewelry] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Jewelry] SET  READ_WRITE
GO
ALTER DATABASE [Jewelry] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Jewelry] SET  MULTI_USER
GO
ALTER DATABASE [Jewelry] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Jewelry] SET DB_CHAINING OFF
GO
USE [Jewelry]
GO
/****** Object:  Table [dbo].[company]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[company](
	[id] [int] NOT NULL,
	[name] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[color]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[color](
	[id] [int] NOT NULL,
	[name] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bill]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bill](
	[id] [int] NOT NULL,
	[address] [varchar](45) NOT NULL,
	[phone] [varchar](45) NOT NULL,
	[name] [varchar](45) NOT NULL,
	[email] [varchar](45) NOT NULL,
	[message] [varchar](45) NULL,
	[total] [decimal](11, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[type]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[type](
	[id] [int] NOT NULL,
	[name] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[size]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[size](
	[id] [int] NOT NULL,
	[name] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] NOT NULL,
	[name] [varchar](45) NOT NULL,
	[price] [decimal](11, 2) NOT NULL,
	[quantity] [int] NULL,
	[idType] [int] NOT NULL,
	[idCompany] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detail_size]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detail_size](
	[idSize] [int] NOT NULL,
	[idProduct] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSize] ASC,
	[idProduct] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detail_color]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detail_color](
	[idProduct] [int] NOT NULL,
	[idColor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC,
	[idColor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detail_bill]    Script Date: 05/07/2018 21:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[detail_bill](
	[idProduct] [int] NOT NULL,
	[idBill] [int] NOT NULL,
	[quantity] [varchar](45) NOT NULL,
	[price] [decimal](11, 2) NOT NULL,
	[idColor] [int] NOT NULL,
	[idSize] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC,
	[idBill] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF__bill__message__014935CB]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[bill] ADD  DEFAULT (NULL) FOR [message]
GO
/****** Object:  Default [DF__size__name__0DAF0CB0]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[size] ADD  DEFAULT (NULL) FOR [name]
GO
/****** Object:  Default [DF__product__quantit__173876EA]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[product] ADD  DEFAULT ('0') FOR [quantity]
GO
/****** Object:  ForeignKey [FK_product_company]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_company] FOREIGN KEY([idCompany])
REFERENCES [dbo].[company] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_company]
GO
/****** Object:  ForeignKey [FK_product_type]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_type] FOREIGN KEY([idType])
REFERENCES [dbo].[type] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_type]
GO
/****** Object:  ForeignKey [FK_detail_size_product]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[detail_size]  WITH CHECK ADD  CONSTRAINT [FK_detail_size_product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[detail_size] CHECK CONSTRAINT [FK_detail_size_product]
GO
/****** Object:  ForeignKey [FK_detail_size_size]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[detail_size]  WITH CHECK ADD  CONSTRAINT [FK_detail_size_size] FOREIGN KEY([idSize])
REFERENCES [dbo].[size] ([id])
GO
ALTER TABLE [dbo].[detail_size] CHECK CONSTRAINT [FK_detail_size_size]
GO
/****** Object:  ForeignKey [FK_detail_color_color]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[detail_color]  WITH CHECK ADD  CONSTRAINT [FK_detail_color_color] FOREIGN KEY([idColor])
REFERENCES [dbo].[color] ([id])
GO
ALTER TABLE [dbo].[detail_color] CHECK CONSTRAINT [FK_detail_color_color]
GO
/****** Object:  ForeignKey [FK_detail_color_product]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[detail_color]  WITH CHECK ADD  CONSTRAINT [FK_detail_color_product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[detail_color] CHECK CONSTRAINT [FK_detail_color_product]
GO
/****** Object:  ForeignKey [FK_detail_bill_bill]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[detail_bill]  WITH CHECK ADD  CONSTRAINT [FK_detail_bill_bill] FOREIGN KEY([idBill])
REFERENCES [dbo].[bill] ([id])
GO
ALTER TABLE [dbo].[detail_bill] CHECK CONSTRAINT [FK_detail_bill_bill]
GO
/****** Object:  ForeignKey [FK_detail_bill_product]    Script Date: 05/07/2018 21:14:41 ******/
ALTER TABLE [dbo].[detail_bill]  WITH CHECK ADD  CONSTRAINT [FK_detail_bill_product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[detail_bill] CHECK CONSTRAINT [FK_detail_bill_product]
GO
