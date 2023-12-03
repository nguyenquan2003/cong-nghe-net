
create database QL_bida
use QL_bida

create table NhanVien
(
	maNV varchar(10),
	hoTen nvarchar(50),
	gioiTinh nvarchar(10),
	ngaySinh date,
	CCCD varchar(20),
	sdt varchar(15),
	queQuan nvarchar(30),
	diaChi nvarchar(100),
	chucVu nvarchar(30)

	constraint PK_maNV_NV primary key (maNV)
)

create table KhachHang
(
	maKH varchar(10),
	tenKH nvarchar(50),
	sdt varchar(15),
	email varchar(30)

	constraint PK_maKH_KH primary key (maKH)
)

create table DanhSachBan
(
	maBan varchar(10),
	loaiBan nvarchar(20),
	soBan char(5),
	trangThai nvarchar(20)

	constraint PK_maBan_DSB primary key (maBan)
)

create table DanhSachMonAn
(
	maMA varchar(10),
	/*anhMA varchar(50),*/
	tenMonAn nvarchar(30),
	DVT nvarchar(20),
	donGia money

	constraint PK_maMA_DSMA primary key (maMA)
)

create table LichDatSan
(
	maKH varchar(10),
	maBan varchar(10),
	tenKH nvarchar(50),
	ngayDat date,
	tgBatDau time

	constraint FK_maKH_LDS foreign key (maKH) references KhachHang(maKH),
	constraint FK_maBan_LDS foreign key (maBan) references DanhSachBan(maBan)
)

create table HoaDon
(
	maHD varchar(10),
	maNV varchar(10),
	maBan varchar(10),
	tenKH nvarchar(50),
	ngayHD datetime,
	tongTien money

	constraint PK_maHD_HD primary key (maHD)
	constraint FK_maBan_HD foreign key (maBan) references DanhSachBan(maBan),
	constraint FK_maNV_HD foreign key (maNV) references NhanVien(maNV)
)

create table ChiTietHoaDon
(
	maHD varchar(10),
	maMA varchar(10),
	tenMonAn nvarchar(50),
	donGia money

	constraint FK_maHD_CTHD foreign key (maHD) references HoaDon(maHD),
	constraint FK_maMA_CTHD foreign key (maMA) references DanhSachMonAn(maMA)
)

select * from NhanVien
select * from ChiTietHoaDon
select * from DanhSachBan
select * from DanhSachMonAn
select * from HoaDon
select * from KhachHang
select * from LichDatSan
----------ChiTietHoaDon------
insert into ChiTietHoaDon
values
('HD001',N'Trái Cây',N'Nước', 50000)

----------NHÂN VIÊN----------
insert into NhanVien
values
('NV001', N'Phan Minh Khải', N'Nam','1999-09-11', '079203023351','0971123456', N'Hồ Chí Minh', N'23 Lê Trọng Tấn,Tây Thạnh, Tân Phú', N'Nhân Viên'),
('NV002', N'Nguyễn Văn Anh', N'Nam','1999-09-11', '079203023301','0971123456', N'Cần Thơ', N'117 Tân Kỳ Tân Quý, Bình Hưng Hòa , Tân Phú', N'Nhân Viên'),
('NV003', N'Phạm Thị Hoa', N'Nữ','1999-09-11', '079203023302','0971123456', N'Bình Định', N'50/2 Dương Đức Hiền, Tây Thạnh ,Tân Phú', N'Nhân Viên'),
('NV004', N'Phan Minh Khải', N'Nam','1999-09-11', '079203023303','0971123456', N'Long An', N'47/7 Nguyễn Thị Tú, Bình Hưng Hòa , Bình Tân', N'Nhân Viên'),
('NV005', N'Phan Minh Khải', N'Nữ','1999-09-11', '079203023304','0971123456', N'Kiên Giang', N'96/6/7 Nguyễn Hữu Tiến, Tây Thạnh , Tân Phú', N'Nhân Viên'),
('NV006', N'Phan Minh Khải', N'Nam','1999-09-11', '079203023305','0971123456', N'Tiền Giang', N'14 Nguyễn Hữu Tiến, Tây Thạnh , Tân Phú', N'Nhân Viên'),
('NV007', N'Phan Minh Khải', N'Nữ','1999-09-11', '079203023306','0971123456', N'Phú Yên', N'12 Cộng Hòa, Phường 12 , Tân Bình', N'Quản Lý'),
('NV008', N'Phan Minh Khải', N'Nữ','1999-09-11', '079203023307','0971123456', N'Quảng Ngãi', N'15 Tân Sơn Nhì, Phường 10, Tân Phú', N'Nhân Viên'),
('NV009', N'Phan Minh Khải', N'Nam','1999-09-11', '079203023308','0971123456', N'Đồng Tháp', N'47/7 Nguyễn Đỗ Cung, Tây Thạnh , Tân Phú', N'Nhân Viên'),
('NV010', N'Phan Minh Khải', N'Nữ','1999-09-11', '079203023308','0971123456', N'Bình Dương', N'47/7 Phan Đăng Giảng, Bình Hưng Hòa , Bình Tân', N'Nhân Viên')
----------KHÁCH HÀNG----------
insert into KhachHang
values
('KH001', N'Phan Minh Khải', '0971234567', 'phankhai042@gmail.com'),
('KH002', N'Phan Minh Khải', '0971234567', 'phankhai042@gmail.com'),
('KH003', N'Phan Minh Khải', '0971234567', 'phankhai042@gmail.com'),
('KH004', N'Phan Minh Khải', '0971234567', 'phankhai042@gmail.com'),
('KH005', N'Phan Minh Khải', '0971234567', 'phankhai042@gmail.com'),
('KH006', N'Phan Minh Khải', '0971234567', 'phankhai042@gmail.com'),
('KH007', N'Phan Minh Khải', '0971234567', 'phankhai042@gmail.com')
----------DANH SÁCH BÀN----------
insert into DanhSachBan
values
('MB001', N'Pool', '001', N'Đang trống'),
('MB002', N'Pool', '002', N'Đang sử dụng'),
('MB003', N'Pool', '003', N'Đang trống'),
('MB004', N'Pool', '004', N'Đang trống'),
('MB005', N'Pool', '005', N'Đang trống'),
('MB006', N'Carom', '006', N'Đang trống'),
('MB007', N'Carom', '007', N'Đang trống'),
('MB008', N'Carom', '008', N'Đang sử dụng'),
('MB009', N'Carom', '009', N'Đang trống'),
('MB010', N'Carom', '010', N'Đang trống'),
('MB011', N'Snooker', '011', N'Đang trống'),
('MB012', N'Snooker', '012', N'Đang trống'),
('MB013', N'Snooker', '013', N'Đang sử dụng'),
('MB014', N'Snooker', '014', N'Đang trống'),
('MB015', N'Snooker', '015', N'Đang trống')
select distinct(loaiBan) from DanhSachBan
delete from DanhSachBan
----------DANH SÁCH MÓN ĂN----------
insert into DanhSachMonAn
values
('MA001',N'Trái Cây',N'Nước', 50000),
('MA002',N'Coca Cola',N'Nước', 15000),
('MA003',N'Sting',N'Nước', 12000),
('MA004',N'Cam ép',N'Nước', 30000),
('MA005',N'Khoai Tây Chiên',N'Món Ăn', 25000),
('MA006',N'Trà chanh',N'Nước', 15000),
('MA007',N'Nước ép táo',N'Nước', 35000),
('MA008',N'Sinh tố bơ',N'Nước', 40000),
('MA009',N'Cafe đen',N'Nước', 10000),
('MA010',N'Cafe sữa',N'Nước', 12000),
('MA011',N'Thuốc lá 555',N'Thuốc lá', 30000),
('MA012',N'Thuốc lá con mèo',N'Thuốc lá', 32000),
('MA013',N'Thuốc lá kent',N'Thuốc lá', 25000),
('MA014',N'Thuốc lá marboro',N'Thuốc lá', 25000),
('MA015',N'Thuốc lá dunhill đỏ',N'Món ăn', 31000),
('MA016',N'Bò viên chiên',N'Món ăn', 30000),
('MA017',N'Cá viên chiên',N'Món ăn', 30000),
('MA018',N'Mực chiên nước mắm',N'Món ăn', 50000),
('MA019',N'Khô bò',N'Món ăn', 35000),
('MA020',N'Khô mực',N'Món ăn', 35000)
--khi thêm lịch đặt danh sách bàn update trạng thái--
create trigger UpdateDSBan
on LichDatSan
after insert
as
begin
	update Q
    SET
        Q.trangThai = N'Đã đặt trước'
    FROM DanhSachBan Q
    JOIN INSERTED I ON Q.maBan = I.maBan;
end;



insert into LichDatSan
values
('KH001', 'MB001', N'Phan Minh Khải', '2023/11/08', '09:00:00')

select * from DanhSachBan
delete from LichDatSan
select * from LichDatSan
select * from ChiTietHoaDon
delete from ChiTietHoaDon
select * from HoaDon

-- Thêm dữ liệu vào bảng HoaDon
INSERT INTO HoaDon (maHD, maNV, maBan, tenKH, ngayHD, tongTien)
VALUES
('HD001', 'NV001', 'MB002', N'Khách Hàng 1', '2023-11-21 10:30:00', 150000),
('HD002', 'NV002', 'MB008', N'Khách Hàng 2', '2023-11-21 11:45:00', 200000),
('HD003', 'NV003', 'MB013', N'Khách Hàng 3', '2023-11-21 13:15:00', 180000);

-- Cập nhật trạng thái của các bàn sau khi thêm hóa đơn
UPDATE DanhSachBan SET trangThai = N'Đang sử dụng' WHERE maBan IN ('MB002', 'MB008', 'MB013');

