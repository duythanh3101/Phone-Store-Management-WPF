USE [master]
GO
/****** Object:  Database [DBStoreManagement]    Script Date: 5/21/2019 12:31:16 PM ******/
CREATE DATABASE [DBStoreManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBStoreManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DBStoreManagement.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBStoreManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DBStoreManagement_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBStoreManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBStoreManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBStoreManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBStoreManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBStoreManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBStoreManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBStoreManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBStoreManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBStoreManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBStoreManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBStoreManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBStoreManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBStoreManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBStoreManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBStoreManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBStoreManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBStoreManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBStoreManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBStoreManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBStoreManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBStoreManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBStoreManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBStoreManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBStoreManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBStoreManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [DBStoreManagement] SET  MULTI_USER 
GO
ALTER DATABASE [DBStoreManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBStoreManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBStoreManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBStoreManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DBStoreManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBStoreManagement', N'ON'
GO
USE [DBStoreManagement]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 5/21/2019 12:31:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillID] [int] IDENTITY(1,1) NOT NULL,
	[BillDate] [datetime] NULL,
	[CashierID] [int] NOT NULL,
	[TotalPrice] [float] NULL,
 CONSTRAINT [PK__Bill__11F2FC4ABE74E2F5] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 5/21/2019 12:31:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[BillID] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Amount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillID] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/21/2019 12:31:16 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 5/21/2019 12:31:16 PM ******/
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
/****** Object:  Table [dbo].[Type]    Script Date: 5/21/2019 12:31:16 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 5/21/2019 12:31:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nchar](50) NULL,
	[Password] [nchar](50) NULL,
	[IdentityCard] [nchar](10) NULL,
	[Birthdate] [datetime] NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK__Users__3214EC07F9921C0C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (1, N'Điện thoại iPhone Xs Max 64GB', N'Apple', 1, 28990000, N'Hoàn toàn xứng đáng với những gì được mong chờ, phiên bản cao cấp nhất iPhone Xs Max của Apple năm nay nổi bật với chip A12 Bionic mạnh mẽ, màn hình rộng đến 6.5 inch, cùng camera kép trí tuệ nhân tạo và Face ID được nâng cấp.
Thiết kế cao cấp với viền thép không gỉ và mặt kính cường lực
Điện thoại iPhone Xs Max sở hữu lối thiết kế vô cùng đẹp mắt với những đường cong mềm mại được thừa hưởng từ chiếc iPhone đời trước đó.', 10, N'https://cdn.tgdd.vn/Products/Images/42/190321/iphone-xs-max-gray-400x460.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (2, N'Điện thoại iPhone X 64GB', N'Apple', 1, 20990000, N'iPhone X là cụm từ được rất nhiều người mong chờ muốn biết và tìm kiếm trên Google bởi đây là chiếc điện thoại mà Apple kỉ niệm 10 năm iPhone đầu tiên được bán ra.
Thiết kế mang tính đột phá
Như các bạn cũng đã biết thì đã 4 năm kể từ chiếc điện thoại iPhone 6 và iPhone 6 Plus thì Apple vẫn chưa có thay đổi nào đáng kể trong thiết kế của mình.', 10, N'https://cdn.tgdd.vn/Products/Images/42/114115/iphone-x-64gb-1-400x460.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (3, N'Điện thoại Samsung Galaxy A50 128GB', N'Samsung', 1, 7990000, N'Samsung Galaxy A50 128GB là mẫu smartphone dòng A mới trong năm 2019 và đặc biệt máy sở hữu công nghệ cảm biến vân tay trong màn hình lần đầu tiên xuất hiện trên một chiếc máy tầm trung tới từ Samsung.
Thiết kế màn hình Infinity-U độc đáo
Samsung Galaxy A50 là mẫu smartphone đầu tiên mà Samsung sử dụng màn hình Infinity-U với phần notch nhỏ gọn hình giọt nước.', 20, N'https://cdn.tgdd.vn/Products/Images/42/200294/samsung-galaxy-a50-128gb-blue-400x460.png')
INSERT [dbo].[Product] ([Id], [DisplayName], [Brand], [TypeId], [Price], [Description], [Quantity], [ImageURL]) VALUES (4, N'Điện thoại iPhone 6s Plus 32GB', N'Apple', 1, 9990000, N'iPhone 6s Plus 32 GB là phiên bản nâng cấp hoàn hảo từ iPhone 6 Plus với nhiều tính năng mới hấp dẫn.
Camera được cải tiến
Điện thoại iPhone 6s Plus 32 GB được nâng cấp độ phân giải camera sau lên 12 MP (thay vì 8 MP như trên iPhone 6 Plus), camera cho tốc độ lấy nét và chụp nhanh, thao tác chạm để chụp nhẹ nhàng. Chất lượng ảnh trong các điều kiện chụp khác nhau tốt.

Màu sáng hơn hẳn so với iPhone 6 Plus

Camera trước với độ phân giải 5 MP cho hình ảnh với độ chi tiết rõ nét, đặc biệt máy còn có tính năng Retina Flash, sẽ giúp màn hình sáng lên như đèn Flash để bức ảnh khi bạn chụp trong trời tối được tốt hơn.', 15, N'https://cdn.tgdd.vn/Products/Images/42/87846/iphone-6s-plus-32gb-400x450-400x450.png')
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

INSERT [dbo].[Users] ([Id], [RoleId], [DisplayName], [UserName], [Password], [IdentityCard], [Birthdate], [Address]) VALUES (1, 1, N'Admin', N'admin                                             ', N'admin                                             ', N'123456789 ', NULL, NULL)
INSERT [dbo].[Users] ([Id], [RoleId], [DisplayName], [UserName], [Password], [IdentityCard], [Birthdate], [Address]) VALUES (2, 2, N'Cashier', N'cashier                                           ', N'123                                               ', N'123456789 ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF__Bill__TotalPrice__1B0907CE]  DEFAULT ((0)) FOR [TotalPrice]
GO
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
USE [master]
GO
ALTER DATABASE [DBStoreManagement] SET  READ_WRITE 
GO
