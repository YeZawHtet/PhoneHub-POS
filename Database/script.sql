USE [PhoneHubDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](225) NULL,
	[created_staff_id] [int] NOT NULL,
	[updated_staff_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_datetime] [datetime] NOT NULL,
	[is_deleted] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[phone] [nvarchar](30) NOT NULL,
	[address] [nvarchar](200) NOT NULL,
	[created_staff_id] [int] NOT NULL,
	[updated_staff_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_datetime] [datetime] NOT NULL,
	[is_deleted] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[item_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](225) NULL,
	[price] [decimal](18, 2) NOT NULL,
	[category_id] [int] NOT NULL,
	[created_staff_id] [int] NOT NULL,
	[updated_staff_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_datetime] [datetime] NOT NULL,
	[is_deleted] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[purchase_id] [int] IDENTITY(1,1) NOT NULL,
	[staff_id] [int] NOT NULL,
	[supplier_id] [int] NOT NULL,
	[purchase_date] [datetime] NOT NULL,
	[total_amount] [decimal](18, 2) NOT NULL,
	[created_staff_id] [int] NOT NULL,
	[updated_staff_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_datetime] [datetime] NOT NULL,
	[is_deleted] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[purchase_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseDetail]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetail](
	[purchase_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[purchase_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[unit_price] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[purchase_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[sale_id] [int] IDENTITY(1,1) NOT NULL,
	[staff_id] [int] NOT NULL,
	[customer_id] [int] NOT NULL,
	[sale_date] [datetime] NOT NULL,
	[total_amount] [decimal](18, 2) NOT NULL,
	[created_staff_id] [int] NOT NULL,
	[updated_staff_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_datetime] [datetime] NOT NULL,
	[is_deleted] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[sale_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleDetail]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetail](
	[sale_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[sale_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[unit_price] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sale_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[staff_id] [int] IDENTITY(1,1) NOT NULL,
	[staffname] [nvarchar](50) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[staff_role] [smallint] NOT NULL,
	[created_staff_id] [int] NOT NULL,
	[updated_staff_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_datetime] [datetime] NOT NULL,
	[is_deleted] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[staff_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[stock_id] [int] IDENTITY(1,1) NOT NULL,
	[item_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[created_staff_id] [int] NOT NULL,
	[updated_staff_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_datetime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[stock_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 9/15/2023 11:13:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[supplier_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[phone] [nvarchar](30) NOT NULL,
	[address] [nvarchar](200) NOT NULL,
	[created_staff_id] [int] NOT NULL,
	[updated_staff_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_datetime] [datetime] NOT NULL,
	[is_deleted] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([category_id], [name], [description], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (1, N'Phone', N'This is Phone', 1, 1, CAST(N'2023-03-21T00:00:00.000' AS DateTime), CAST(N'2023-03-21T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Category] ([category_id], [name], [description], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (2, N'Type', N'This is Type', 1, 1, CAST(N'2023-03-21T00:00:00.000' AS DateTime), CAST(N'2023-03-21T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([customer_id], [name], [email], [phone], [address], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (1, N'Trojan', N'trojan@gmail.com', N'09899885101', N'Pyin Oo Lwin', 1, 1, CAST(N'2023-09-15T00:00:00.000' AS DateTime), CAST(N'2023-09-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Customer] ([customer_id], [name], [email], [phone], [address], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (3, N'Joker', N'joker@gmail.com', N'09123456789', N'Unknown', 1, 1, CAST(N'2023-09-15T00:00:00.000' AS DateTime), CAST(N'2023-09-15T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([item_id], [name], [description], [price], [category_id], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (1, N'iPhone 13', N'The iPhone 13 is Apple''s latest flagship smartphone, known for its powerful A15 Bionic chip, stunning Super Retina XDR display, and impressive camera capabilities.', CAST(100000.00 AS Decimal(18, 2)), 1, 1, 1, CAST(N'2023-09-15T10:56:19.920' AS DateTime), CAST(N'2023-09-15T10:56:19.920' AS DateTime), 0)
INSERT [dbo].[Item] ([item_id], [name], [description], [price], [category_id], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (2, N'Samsung Galaxy S21', N'The Samsung Galaxy S21 is a premium Android smartphone featuring a vibrant AMOLED display, powerful Exynos or Snapdragon processor, and versatile camera system.', CAST(100000.00 AS Decimal(18, 2)), 1, 1, 1, CAST(N'2023-09-15T00:00:00.000' AS DateTime), CAST(N'2023-09-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Item] ([item_id], [name], [description], [price], [category_id], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (3, N'Samsung Clear View Cover', N'Amazing!', CAST(1000.00 AS Decimal(18, 2)), 2, 1, 1, CAST(N'2023-09-15T00:00:00.000' AS DateTime), CAST(N'2023-09-15T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale] ON 

INSERT [dbo].[Sale] ([sale_id], [staff_id], [customer_id], [sale_date], [total_amount], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (1, 1, 1, CAST(N'2023-09-15T11:04:34.857' AS DateTime), CAST(100000.00 AS Decimal(18, 2)), 1, 1, CAST(N'2023-09-15T11:04:34.857' AS DateTime), CAST(N'2023-09-15T11:04:34.857' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Sale] OFF
GO
SET IDENTITY_INSERT [dbo].[SaleDetail] ON 

INSERT [dbo].[SaleDetail] ([sale_detail_id], [sale_id], [item_id], [quantity], [unit_price]) VALUES (1, 1, 1, 1, CAST(100000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SaleDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([staff_id], [staffname], [password], [email], [staff_role], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (1, N'Admin', N'/ONk2rXeBuqae4nurH11/g==', N'admin@gmail.com', 1, 1, 1, CAST(N'2023-02-20T00:00:00.000' AS DateTime), CAST(N'2023-02-01T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Staff] ([staff_id], [staffname], [password], [email], [staff_role], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime], [is_deleted]) VALUES (5, N'Cashire', N'/ONk2rXeBuqae4nurH11/g==', N'cashire@gmail.com', 0, 1, 1, CAST(N'2023-03-21T00:00:00.000' AS DateTime), CAST(N'2023-03-24T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([stock_id], [item_id], [quantity], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime]) VALUES (1, 1, 19, 1, 1, CAST(N'2023-09-15T00:00:00.000' AS DateTime), CAST(N'2023-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Stock] ([stock_id], [item_id], [quantity], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime]) VALUES (2, 2, 20, 1, 1, CAST(N'2023-09-15T00:00:00.000' AS DateTime), CAST(N'2023-09-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Stock] ([stock_id], [item_id], [quantity], [created_staff_id], [updated_staff_id], [created_datetime], [updated_datetime]) VALUES (3, 3, 9, 1, 1, CAST(N'2023-09-15T00:00:00.000' AS DateTime), CAST(N'2023-09-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Item] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Purchase] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Sale] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Supplier] ADD  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([category_id])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD FOREIGN KEY([staff_id])
REFERENCES [dbo].[Staff] ([staff_id])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD FOREIGN KEY([supplier_id])
REFERENCES [dbo].[Supplier] ([supplier_id])
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD FOREIGN KEY([item_id])
REFERENCES [dbo].[Item] ([item_id])
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD FOREIGN KEY([purchase_id])
REFERENCES [dbo].[Purchase] ([purchase_id])
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD FOREIGN KEY([staff_id])
REFERENCES [dbo].[Staff] ([staff_id])
GO
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD FOREIGN KEY([item_id])
REFERENCES [dbo].[Item] ([item_id])
GO
ALTER TABLE [dbo].[SaleDetail]  WITH CHECK ADD FOREIGN KEY([sale_id])
REFERENCES [dbo].[Sale] ([sale_id])
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD FOREIGN KEY([item_id])
REFERENCES [dbo].[Item] ([item_id])
GO
