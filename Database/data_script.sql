use DBStoreManagement

INSERT into [Role] VALUES (N'Admin'),
(N'Nhân Viên'),
(N'Nhân Viên Kho'),
(N'Quản lý trưởng')

INSERT INTO [USER] (ROLEID, DISPLAYNAME, USERNAME, [PASSWORD], IDENTITYID, BIRTHDATE, [ADDRESS])
VALUES ((SELECT R.ID FROM [ROLE] R WHERE (R.DisplayName = N'Admin')), N'Nguyễn Quang Thạch', N'admin', N'admin', '123456', CAST(N'1998-01-16 00:00:00.000' AS DateTime), N'227 NVC'),
((SELECT R.ID FROM [ROLE] R WHERE (R.DisplayName = N'Admin')), N'Phạm Duy Thanh', N'admin2', N'admin', '123456', CAST(N'1998-04-28 00:00:00.000' AS DateTime), N'227 NVC'),
((SELECT R.ID FROM [ROLE] R WHERE (R.DisplayName = N'Nhân Viên')), N'Test user', N'cashier', N'123', '123456', CAST(N'2019-06-21 00:00:00.000' AS DateTime), N'227 NVC')

INSERT into CustomerInfo VALUES (N'0912345678', N'Thanh')
INSERT into CustomerInfo VALUES (N'0912345679', N'Hoàng')

INSERT into [Type] VALUES (N'Điện thoại'),
(N'Tai nghe'),
(N'Sạc dự phòng')


INSERT into Product(DisplayName, Brand, TypeId, Price, [Description], Quantity, ImageURL) VALUES (N'Điện thoại iPhone Xs Max 64GB', N'Apple', (SELECT T.ID FROM [TYPE] T WHERE T.DisplayName = N'Điện thoại'), 28990000, N'Hoàn toàn xứng đáng với những gì được mong chờ, phiên bản cao cấp nhất iPhone Xs Max của Apple năm nay nổi bật với chip A12 Bionic mạnh mẽ, màn hình rộng đến 6.5 inch, cùng camera kép trí tuệ nhân tạo và Face ID được nâng cấp.
Thiết kế cao cấp với viền thép không gỉ và mặt kính cường lực
Điện thoại iPhone Xs Max sở hữu lối thiết kế vô cùng đẹp mắt với những đường cong mềm mại được thừa hưởng từ chiếc iPhone đời trước đó.', 8, N'https://cdn.tgdd.vn/Products/Images/42/190321/iphone-xs-max-gray-400x460.png')

,(N'Điện thoại iPhone X 64GB', N'Apple', (SELECT T.ID FROM [TYPE] T WHERE T.DisplayName = N'Điện thoại'), 20990000, N'iPhone X là cụm từ được rất nhiều người mong chờ muốn biết và tìm kiếm trên Google bởi đây là chiếc điện thoại mà Apple kỉ niệm 10 năm iPhone đầu tiên được bán ra.
Thiết kế mang tính đột phá
Như các bạn cũng đã biết thì đã 4 năm kể từ chiếc điện thoại iPhone 6 và iPhone 6 Plus thì Apple vẫn chưa có thay đổi nào đáng kể trong thiết kế của mình.', 6, N'https://cdn.tgdd.vn/Products/Images/42/114115/iphone-x-64gb-1-400x460.png')

,(N'Điện thoại Samsung Galaxy A50 128GB', N'Samsung', (SELECT T.ID FROM [TYPE] T WHERE T.DisplayName = N'Điện thoại'), 7990000, N'Samsung Galaxy A50 128GB là mẫu smartphone dòng A mới trong năm 2019 và đặc biệt máy sở hữu công nghệ cảm biến vân tay trong màn hình lần đầu tiên xuất hiện trên một chiếc máy tầm trung tới từ Samsung.
Thiết kế màn hình Infinity-U độc đáo
Samsung Galaxy A50 là mẫu smartphone đầu tiên mà Samsung sử dụng màn hình Infinity-U với phần notch nhỏ gọn hình giọt nước.', 15, N'https://cdn.tgdd.vn/Products/Images/42/200294/samsung-galaxy-a50-128gb-blue-400x460.png')

,(N'Điện thoại iPhone 6s Plus 32GB', N'Apple', (SELECT T.ID FROM [TYPE] T WHERE T.DisplayName = N'Điện thoại'), 9990000, N'iPhone 6s Plus 32 GB là phiên bản nâng cấp hoàn hảo từ iPhone 6 Plus với nhiều tính năng mới hấp dẫn.
Camera được cải tiến
Điện thoại iPhone 6s Plus 32 GB được nâng cấp độ phân giải camera sau lên 12 MP (thay vì 8 MP như trên iPhone 6 Plus), camera cho tốc độ lấy nét và chụp nhanh, thao tác chạm để chụp nhẹ nhàng. Chất lượng ảnh trong các điều kiện chụp khác nhau tốt.

Màu sáng hơn hẳn so với iPhone 6 Plus

Camera trước với độ phân giải 5 MP cho hình ảnh với độ chi tiết rõ nét, đặc biệt máy còn có tính năng Retina Flash, sẽ giúp màn hình sáng lên như đèn Flash để bức ảnh khi bạn chụp trong trời tối được tốt hơn.', 14, N'https://cdn.tgdd.vn/Products/Images/42/87846/iphone-6s-plus-32gb-400x450-400x450.png')

,(N'Điện thoại iPhone 8 Plus 256GB', N'Apple', (SELECT T.ID FROM [TYPE] T WHERE T.DisplayName = N'Điện thoại'), 25790000, N'iPhone 8 Plus là bản nâng cấp nhẹ của chiếc iPhone 7 Plus đã ra mắt trước đó với cấu hình mạnh mẽ cùng camera có nhiều cải tiến.
Thiết kế quen thuộc vốn có của dòng iPhone Apple
Về ngoại hình điện thoại iPhone 8 Plus không có quá nhiều khác biệt so với người đàn anh đi trước. Thay đổi lớn nhất chính là Apple đã chuyển từ thiết kế kim loại nguyên khối sang mặt lưng kính nhằm mang tính năng sạc không dây lên 8 Plus.', 20, N'https://cdn.tgdd.vn/Products/Images/42/114114/iphone-8-plus-256gb-gold-400x460.png')

,(N'Điện thoại iPhone Xr 128GB', N'Apple', (SELECT T.ID FROM [TYPE] T WHERE T.DisplayName = N'Điện thoại'), 21990000, N'Được xem là phiên bản iPhone giá rẻ đầy hoàn hảo, iPhone Xr 128GB khiến người dùng có nhiều sự lựa chọn hơn về màu sắc đa dạng nhưng vẫn sở hữu cấu hình mạnh mẽ và thiết kế sang trọng.
Màn hình tràn viền công nghệ LCD - True Tone
Thay vì sở hữu màn hình OLED truyền thống, chiếc smartphone này sở hữu màn hình LCD.

Bù lại với công nghệ True Tone cùng màn hình tràn viền rộng tới 6.1 inch, mọi trải nghiệm trên máy vẫn đem lại sự thích thú và hoàn hảo, như dòng cao cấp khác của Apple.', 18, N'https://cdn.tgdd.vn/Products/Images/42/191483/iphone-xr-128gb-red-400x460.png')

,(N'Điện thoại iPhone Xr 256GB', N'Apple', (SELECT T.ID FROM [TYPE] T WHERE T.DisplayName = N'Điện thoại'), 23990000, N'Ngoài các phiên bản như thường lệ mọi năm, vào đêm 12/9 theo giờ Việt Nam, Apple đã cho ra mắt thêm một phiên bản iPhone khác với tên gọi iPhone Xr, có mức giá dễ chịu hơn nhưng vẫn mang đầy đủ các tính năng cao cấp đầy hấp dẫn.
Mượt mà mọi trải nghiệm nhờ chip Apple A12
Với mỗi lần ra mắt, Apple lại giới thiệu một con chip mới và Apple A12 Bionic là con chip đầu tiên sản xuất với tiến trình 7nm được tích hợp trên iPhone Xr.', 30, N'https://cdn.tgdd.vn/Products/Images/42/190326/iphone-xr-256gb-white-400x460.png')
