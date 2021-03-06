USE [master]
GO
/****** Object:  Database [DBStoreManagement]    Script Date: 6/17/2019 6:42:06 AM ******/
CREATE DATABASE [DBStoreManagement]
 
USE [DBStoreManagement]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/17/2019 6:42:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[BillDate] [datetime] NOT NULL,
	[CashierID] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL CONSTRAINT [DF__Bill__TotalPrice__1B0907CE]  DEFAULT ((0)),
 CONSTRAINT [PK__Bill__11F2FC4ABE74E2F5] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 6/17/2019 6:42:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[BillID] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
 CONSTRAINT [PK__BillDeta__DAB230260508BBAD] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerInfo]    Script Date: 6/17/2019 6:42:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerInfo](
	[PhoneNumber] [nvarchar](10) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/17/2019 6:42:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Brand] [nvarchar](max) NULL,
	[TypeId] [int] NOT NULL,
	[Price] [float] NOT NULL CONSTRAINT [DF__Product__Price__173876EA]  DEFAULT ((0)),
	[Description] [nvarchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[ImageURL] [nvarchar](max) NULL,
 CONSTRAINT [PK__Product__3214EC076E5FB3D3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/17/2019 6:42:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Type]    Script Date: 6/17/2019 6:42:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/17/2019 6:42:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[IdentityCard] [nvarchar](10) NULL,
	[Birthdate] [datetime] NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK__Users__3214EC07F9921C0C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Warranty]    Script Date: 6/17/2019 6:42:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warranty](
	[WarrantyID] [int] NOT NULL,
	[PhoneNumber] [nvarchar](10) NOT NULL,
	[ProductID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Warranty__2ED318F3706AF8F1] PRIMARY KEY CLUSTERED 
(
	[WarrantyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (1, CAST(N'2019-05-23 00:00:00.000' AS DateTime), 1, 28980000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (2, CAST(N'2019-05-23 00:00:00.000' AS DateTime), 1, 37960000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (3, CAST(N'2019-05-25 00:00:00.000' AS DateTime), 1, 36970000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (4, CAST(N'2019-05-25 00:00:00.000' AS DateTime), 1, 36970000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (5, CAST(N'2019-05-25 00:00:00.000' AS DateTime), 1, 44960000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (6, CAST(N'2019-05-25 00:00:00.000' AS DateTime), 1, 36970000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (7, CAST(N'2019-05-25 00:00:00.000' AS DateTime), 1, 49970000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (8, CAST(N'2019-05-25 00:00:00.000' AS DateTime), 2, 57980000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (9, CAST(N'2019-05-25 00:00:00.000' AS DateTime), 2, 9990000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (1004, CAST(N'2019-06-17 04:43:54.560' AS DateTime), 1, 21990000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (1005, CAST(N'2019-06-17 05:31:05.890' AS DateTime), 1, 21990000)
INSERT [dbo].[Bill] ([BillID], [BillDate], [CashierID], [TotalPrice]) VALUES (1006, CAST(N'2019-06-17 05:45:38.480' AS DateTime), 1, 7990000)
SET IDENTITY_INSERT [dbo].[Bill] OFF
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (1, 2, 1, 20990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (1, 3, 1, 7990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (2, 3, 1, 7990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (2, 4, 3, 9990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (3, 2, 1, 20990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (3, 3, 2, 7990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (4, 2, 1, 20990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (4, 3, 2, 7990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (5, 2, 1, 20990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (5, 3, 3, 7990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (6, 2, 1, 20990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (6, 3, 2, 7990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (7, 2, 2, 20990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (7, 3, 1, 7990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (8, 1, 2, 28990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (9, 4, 1, 9990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (1004, 7, 1, 21990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (1005, 7, 1, 21990000)
INSERT [dbo].[BillDetail] ([BillID], [ProductId], [Amount], [UnitPrice]) VALUES (1006, 3, 1, 7990000)
INSERT [dbo].[CustomerInfo] ([PhoneNumber], [CustomerName]) VALUES (N'0912345678', N'Thanh')
INSERT [dbo].[CustomerInfo] ([PhoneNumber], [CustomerName]) VALUES (N'0912345679', N'Hoàng')
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (1, N'Điện thoại iPhone Xs Max 64GB', N'Apple', 1, 28990000, N'Hoàn toàn xứng đáng với những gì được mong chờ, phiên bản cao cấp nhất iPhone Xs Max của Apple năm nay nổi bật với chip A12 Bionic mạnh mẽ, màn hình rộng đến 6.5 inch, cùng camera kép trí tuệ nhân tạo và Face ID được nâng cấp.
Thiết kế cao cấp với viền thép không gỉ và mặt kính cường lực
Điện thoại iPhone Xs Max sở hữu lối thiết kế vô cùng đẹp mắt với những đường cong mềm mại được thừa hưởng từ chiếc iPhone đời trước đó.', 8, N'https://cdn.tgdd.vn/Products/Images/42/190321/iphone-xs-max-gray-400x460.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (2, N'Điện thoại iPhone X 64GB', N'Apple', 1, 20990000, N'iPhone X là cụm từ được rất nhiều người mong chờ muốn biết và tìm kiếm trên Google bởi đây là chiếc điện thoại mà Apple kỉ niệm 10 năm iPhone đầu tiên được bán ra.
Thiết kế mang tính đột phá
Như các bạn cũng đã biết thì đã 4 năm kể từ chiếc điện thoại iPhone 6 và iPhone 6 Plus thì Apple vẫn chưa có thay đổi nào đáng kể trong thiết kế của mình.', 6, N'https://cdn.tgdd.vn/Products/Images/42/114115/iphone-x-64gb-1-400x460.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (3, N'Điện thoại Samsung Galaxy A50 128GB', N'Samsung', 1, 7990000, N'Samsung Galaxy A50 128GB là mẫu smartphone dòng A mới trong năm 2019 và đặc biệt máy sở hữu công nghệ cảm biến vân tay trong màn hình lần đầu tiên xuất hiện trên một chiếc máy tầm trung tới từ Samsung.
Thiết kế màn hình Infinity-U độc đáo
Samsung Galaxy A50 là mẫu smartphone đầu tiên mà Samsung sử dụng màn hình Infinity-U với phần notch nhỏ gọn hình giọt nước.', 15, N'https://cdn.tgdd.vn/Products/Images/42/200294/samsung-galaxy-a50-128gb-blue-400x460.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (4, N'Điện thoại iPhone 6s Plus 32GB', N'Apple', 1, 9990000, N'iPhone 6s Plus 32 GB là phiên bản nâng cấp hoàn hảo từ iPhone 6 Plus với nhiều tính năng mới hấp dẫn.
Camera được cải tiến
Điện thoại iPhone 6s Plus 32 GB được nâng cấp độ phân giải camera sau lên 12 MP (thay vì 8 MP như trên iPhone 6 Plus), camera cho tốc độ lấy nét và chụp nhanh, thao tác chạm để chụp nhẹ nhàng. Chất lượng ảnh trong các điều kiện chụp khác nhau tốt.

Màu sáng hơn hẳn so với iPhone 6 Plus

Camera trước với độ phân giải 5 MP cho hình ảnh với độ chi tiết rõ nét, đặc biệt máy còn có tính năng Retina Flash, sẽ giúp màn hình sáng lên như đèn Flash để bức ảnh khi bạn chụp trong trời tối được tốt hơn.', 14, N'https://cdn.tgdd.vn/Products/Images/42/87846/iphone-6s-plus-32gb-400x450-400x450.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (6, N'Điện thoại iPhone 8 Plus 256GB', N'Apple', 1, 25790000, N'iPhone 8 Plus là bản nâng cấp nhẹ của chiếc iPhone 7 Plus đã ra mắt trước đó với cấu hình mạnh mẽ cùng camera có nhiều cải tiến.
Thiết kế quen thuộc vốn có của dòng iPhone Apple
Về ngoại hình điện thoại iPhone 8 Plus không có quá nhiều khác biệt so với người đàn anh đi trước. Thay đổi lớn nhất chính là Apple đã chuyển từ thiết kế kim loại nguyên khối sang mặt lưng kính nhằm mang tính năng sạc không dây lên 8 Plus.', 20, N'https://cdn.tgdd.vn/Products/Images/42/114114/iphone-8-plus-256gb-gold-400x460.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (7, N'Điện thoại iPhone Xr 128GB', N'Apple', 1, 21990000, N'Được xem là phiên bản iPhone giá rẻ đầy hoàn hảo, iPhone Xr 128GB khiến người dùng có nhiều sự lựa chọn hơn về màu sắc đa dạng nhưng vẫn sở hữu cấu hình mạnh mẽ và thiết kế sang trọng.
Màn hình tràn viền công nghệ LCD - True Tone
Thay vì sở hữu màn hình OLED truyền thống, chiếc smartphone này sở hữu màn hình LCD.

Bù lại với công nghệ True Tone cùng màn hình tràn viền rộng tới 6.1 inch, mọi trải nghiệm trên máy vẫn đem lại sự thích thú và hoàn hảo, như dòng cao cấp khác của Apple.', 18, N'https://cdn.tgdd.vn/Products/Images/42/191483/iphone-xr-128gb-red-400x460.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (8, N'Điện thoại iPhone Xr 256GB', N'Apple', 1, 23990000, N'Ngoài các phiên bản như thường lệ mọi năm, vào đêm 12/9 theo giờ Việt Nam, Apple đã cho ra mắt thêm một phiên bản iPhone khác với tên gọi iPhone Xr, có mức giá dễ chịu hơn nhưng vẫn mang đầy đủ các tính năng cao cấp đầy hấp dẫn.
Mượt mà mọi trải nghiệm nhờ chip Apple A12
Với mỗi lần ra mắt, Apple lại giới thiệu một con chip mới và Apple A12 Bionic là con chip đầu tiên sản xuất với tiến trình 7nm được tích hợp trên iPhone Xr.', 30, N'https://cdn.tgdd.vn/Products/Images/42/190326/iphone-xr-256gb-white-400x460.png')
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [DisplayName]) VALUES (2, N'Nhân Viên')
INSERT [dbo].[Role] ([RoleId], [DisplayName]) VALUES (3, N'Nhân Viên Kho')
INSERT [dbo].[Role] ([RoleId], [DisplayName]) VALUES (4, N'Quản lý trưởng')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([TypeId], [DisplayName]) VALUES (1, N'Điện thoại')
INSERT [dbo].[Type] ([TypeId], [DisplayName]) VALUES (2, N'Tai nghe')
INSERT [dbo].[Type] ([TypeId], [DisplayName]) VALUES (3, N'Sạc dự phòng')
SET IDENTITY_INSERT [dbo].[Type] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [RoleId], [DisplayName], [UserName], [Password], [IdentityCard], [Birthdate], [Address]) VALUES (1, 1, N'Phạm Duy Thanh', N'admin                                             ', N'admin                                             ', N'333333333 ', CAST(N'1998-04-28 00:00:00.000' AS DateTime), N'Quận 7, TPHCM')
INSERT [dbo].[Users] ([Id], [RoleId], [DisplayName], [UserName], [Password], [IdentityCard], [Birthdate], [Address]) VALUES (2, 2, N'Cashier', N'cashier                                           ', N'123                                               ', N'123456789 ', CAST(N'1994-03-30 00:00:00.000' AS DateTime), N'Quận 5, TPHCM')
INSERT [dbo].[Users] ([Id], [RoleId], [DisplayName], [UserName], [Password], [IdentityCard], [Birthdate], [Address]) VALUES (4, 2, N'Nguyễn Quang Thạch', N'cashier2                                          ', N'123                                               ', N'123456789 ', CAST(N'1994-03-30 00:00:00.000' AS DateTime), N'Quận 5, TPHCM')
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[Warranty] ([WarrantyID], [PhoneNumber], [ProductID], [StartDate], [EndDate]) VALUES (0, N'0912345678', 3, CAST(N'2019-06-17 05:45:38.480' AS DateTime), CAST(N'2020-06-16 05:45:38.480' AS DateTime))
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK__Bill__CashierID__1BFD2C07] FOREIGN KEY([CashierID])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK__Bill__CashierID__1BFD2C07]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK__BillDetai__BillI__1ED998B2] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([BillID])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK__BillDetai__BillI__1ED998B2]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK__BillDetai__Produ__1FCDBCEB] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK__BillDetai__Produ__1FCDBCEB]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__ImageUR__182C9B23] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([TypeId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__ImageUR__182C9B23]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__RoleId__1273C1CD] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__RoleId__1273C1CD]
GO
ALTER TABLE [dbo].[Warranty]  WITH CHECK ADD  CONSTRAINT [FK__Warranty__PhoneN__02084FDA] FOREIGN KEY([PhoneNumber])
REFERENCES [dbo].[CustomerInfo] ([PhoneNumber])
GO
ALTER TABLE [dbo].[Warranty] CHECK CONSTRAINT [FK__Warranty__PhoneN__02084FDA]
GO
ALTER TABLE [dbo].[Warranty]  WITH CHECK ADD  CONSTRAINT [FK__Warranty__Produc__01142BA1] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Warranty] CHECK CONSTRAINT [FK__Warranty__Produc__01142BA1]
GO
USE [master]
GO
ALTER DATABASE [DBStoreManagement] SET  READ_WRITE 
GO
