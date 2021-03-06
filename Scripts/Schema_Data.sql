/****** Object:  Default [DF__Orders__OrderDat__173876EA]    Script Date: 09/18/2013 04:02:29 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Orders__OrderDat__173876EA]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
Begin
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [DF__Orders__OrderDat__173876EA]

End
GO
/****** Object:  Default [DF__Products__Stack__1A14E395]    Script Date: 09/18/2013 04:02:29 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Products__Stack__1A14E395]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
Begin
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [DF__Products__Stack__1A14E395]

End
GO
/****** Object:  Table [dbo].[OrderEntries]    Script Date: 09/18/2013 04:02:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderEntries]') AND type in (N'U'))
DROP TABLE [dbo].[OrderEntries]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 09/18/2013 04:02:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 09/18/2013 04:02:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 09/18/2013 04:02:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reviews]') AND type in (N'U'))
DROP TABLE [dbo].[Reviews]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 09/18/2013 04:02:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 09/18/2013 04:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastName] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Phone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK__Customers__07F6335A] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
END
GO
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName], [Email], [Phone]) VALUES (1, N'Vasu', N'Sam', N'vals@live.in', N'9486180175')
SET IDENTITY_INSERT [dbo].[Customers] OFF
/****** Object:  Table [dbo].[Reviews]    Script Date: 09/18/2013 04:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reviews]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reviews](
	[reviewID] [int] NOT NULL,
	[productID] [int] NOT NULL,
	[Description] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReviewerName] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK__Reviews__0BC6C43E] PRIMARY KEY CLUSTERED 
(
	[reviewID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Products]    Script Date: 09/18/2013 04:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Products](
	[ProductID] [int] NOT NULL,
	[Description] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SellerName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Prize] [decimal](18, 0) NOT NULL,
	[Category] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Stack] [int] NOT NULL,
 CONSTRAINT [PK__Products__0DAF0CB0] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
END
GO
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (1, N'8.7 MP Primary Camera, 4.5-inch Touchscreen , Secondary Camera', N'Nokia Lumia 920', N'JJMEHTA', CAST(23999 AS Decimal(18, 0)), N'Mobile', 2)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (2, N'Windows Phone 8 OS, 8 MP Primary Camera , 2.1 MP Secondary Camera', N'HTC 8X C620E (Black)', N'WS Retail', CAST(19999 AS Decimal(18, 0)), N'Mobile', 4)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (3, N'Zero Fee EMI: 3,6 months', N'Nikon D5100 SLR (Black, with AF-S 18-55mm VR Kit Lens)', N'apdeal', CAST(31630 AS Decimal(18, 0)), N'Camera', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (4, N'Zero Fee EMI: 3,6 months', N'Canon EOS 600D SLR (Black, with Kit II EF S18-135mm)', N'apdeal', CAST(50435 AS Decimal(18, 0)), N'Camera', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (5, N'7-inch Touchscreen, Android v4.1 OS, 3 MP Primary Camera', N'Samsung Galaxy Tab 3 T211 Tablet (White, Wi-Fi, 3G, 8 GB)', N'WS Retail', CAST(16900 AS Decimal(18, 0)), N'Tablet', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (6, N'7-inch Touchscreen, Android v4.0 OS, 2 MP Primary Camera', N'Micromax Funbook Infinity P275 Tablet (Black, Wi-Fi, 4GB)', N'WS Retail', CAST(4949 AS Decimal(18, 0)), N'Tablet', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (7, N'Android v4.1 OS, 5-inch Touchscreen, 8 MP Primary Camera', N'Samsung Galaxy Grand Duos I9082 (Elegant White)', N'WS Retail', CAST(20400 AS Decimal(18, 0)), N'Mobile', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (8, N'8 MP Primary Camera, Android v4.1 OS, 4.5-inch Touchscreen', N'XOLO Q800 (White)', N'WS Retail', CAST(9890 AS Decimal(18, 0)), N'Mobile', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (9, N'Android v2.3 OS, 3.2-inch Touchscreen, 5 MP Primary Camera', N'HTC Wildfire S (White Silver)', N'WS Retail', CAST(8249 AS Decimal(18, 0)), N'Mobile', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (10, N'Zero Fee EMI: 3,6 months', N'Canon EOS 600D SLR ', N'apdeal ', CAST(33945 AS Decimal(18, 0)), N'Camera', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (11, N'Zero Fee EMI: 3,6 months', N'Nikon D5100 SLR (Black, Body Only)', N'apdeal ', CAST(26627 AS Decimal(18, 0)), N'Camera', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (13, N'7-inch Touchscreen, Android v4.1 OS, 3 MP Primary Camera', N'Samsung Galaxy Tab 3 T211 Tablet (White, Wi-Fi, 3G, 8 GB)', N'WS Retail', CAST(16900 AS Decimal(18, 0)), N'Tablet', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (14, N'7-inch Touchscreen, Android v4.0 OS, 2 MP Primary Camera', N'Micromax Funbook Infinity P275 Tablet (Black, Wi-Fi, 4GB)', N'WS Retail', CAST(4949 AS Decimal(18, 0)), N'Tablet', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (15, N'7.9 inch LED Backlit, A5 Chip, 5MP iSight Camera', N'Apple 16GB iPad Mini with Wi-Fi (White and Silver)', N'WS Retail', CAST(21900 AS Decimal(18, 0)), N'Tablet', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (16, N'Android 4.0, 7 inch LED Display, 2 MP Primary', N'Lenovo A2107 Tablet (Black)', N'WS Retail', CAST(9199 AS Decimal(18, 0)), N'Tablet', 5)
INSERT [dbo].[Products] ([ProductID], [Description], [Name], [SellerName], [Prize], [Category], [Stack]) VALUES (17, N'7-inch Touchscreen, 1 GHz Processor, 2 MP Primary Camera', N'HCL ME Connect 2G 2.0 Tablet (Silver, Wi-Fi, 3G, 4 GB)', N'WS Retail', CAST(7190 AS Decimal(18, 0)), N'Tablet', 5)
/****** Object:  Table [dbo].[Orders]    Script Date: 09/18/2013 04:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderState] [int] NOT NULL,
	[Prize] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK__Orders__164452B1] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[OrderEntries]    Script Date: 09/18/2013 04:02:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderEntries]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderEntries](
	[OrderEntryID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK__OrderEntries__1920BF5C] PRIMARY KEY CLUSTERED 
(
	[OrderEntryID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Default [DF__Orders__OrderDat__173876EA]    Script Date: 09/18/2013 04:02:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Orders__OrderDat__173876EA]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
Begin
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__OrderDat__173876EA]  DEFAULT (getdate()) FOR [OrderDate]

End
GO
/****** Object:  Default [DF__Products__Stack__1A14E395]    Script Date: 09/18/2013 04:02:29 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__Products__Stack__1A14E395]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products]'))
Begin
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF__Products__Stack__1A14E395]  DEFAULT ((0)) FOR [Stack]

End
GO
