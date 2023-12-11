USE master
DROP DATABASE QL_DULICH
CREATE DATABASE QL_DULICH
USE QL_DULICH

CREATE TABLE KhachHang
(
	MaKH CHAR(10) NOT NULL,
	TenKH NVARCHAR(50),
	NgaySinh DATE,
	GioiTinh NVARCHAR(5),
	SoDT CHAR(10),
	Email CHAR(50),
	MatKhau CHAR(30),
	DiaChi NVARCHAR(50),
	TichDiem INT,
    Quyen VARCHAR(5) DEFAULT 'KH',
	CONSTRAINT PK_KhachHang PRIMARY KEY (MaKH)
)

CREATE TABLE Tour
(
	MaTour CHAR(10) NOT NULL,
	TenTour NVARCHAR(50),
	MieuTa NVARCHAR(100),	
	Gia INT,
	DiaDiem NVARCHAR(50),
	CONSTRAINT PK_Tour PRIMARY KEY (MaTour)
)

CREATE TABLE NhanVien
(
    MaNV CHAR(10) NOT NULL,
    TenNV NVARCHAR(50),
    Email CHAR(50),
    SDT CHAR(10),
	NgaySinh DATE,
    ChucVu NVARCHAR(30),
	MatKhau CHAR(30),
    Quyen VARCHAR(5) DEFAULT 'NV',
    CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV)
);

CREATE TABLE ChiTietTour
(
	MaNV CHAR(10) NOT NULL,
	MaTour CHAR(10) NOT NULL,
	SoNgay INT,
	NgayKhoiHanh DATE,
	NgayKetThuc DATE,
	NoiDungTour NVARCHAR(50),
	DuongDan TEXT
	CONSTRAINT PK_ChiTietTour PRIMARY KEY (MaNV, MaTour),
	CONSTRAINT FK_ChiTietTour_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT FK_ChiTietTour_Tour FOREIGN KEY (MaTour) REFERENCES Tour(MaTour)
)

CREATE TABLE DatTour
(
	MaDat CHAR(10) NOT NULL,
	MaKH CHAR(10),
	MaTour CHAR(10) NOT NULL,
	NgayDat DATE,
	TinhTrangThanhToan NVARCHAR(30),
	NguoiLon INT,
	TreEm INT,
	CONSTRAINT PK_DatTour PRIMARY KEY (MaDat),
	FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE,
	CONSTRAINT FK_DatTour_Tour FOREIGN KEY (MaTour) REFERENCES Tour(MaTour)
)

CREATE TABLE DanhGia
(
	MaDanhGia CHAR(10) NOT NULL,
	MaTour CHAR(10) NOT NULL,
	MaKH CHAR(10) NOT NULL,
	DanhGia INT,
	BinhLuan NVARCHAR(50),
	NgayDanhGia DATE,
	CONSTRAINT PK_DanhGia PRIMARY KEY (MaDanhGia),
	CONSTRAINT FK_DanhGia_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE,
	CONSTRAINT FK_DanhGia_Tour FOREIGN KEY (MaTour) REFERENCES Tour(MaTour)
)

CREATE TABLE HoaDon
(
	MaHD CHAR(10) NOT NULL,
	MaKH CHAR(10) NOT NULL,
	TinhTrang NVARCHAR(20) DEFAULT N'Chưa thanh toán',
	CONSTRAINT PK_HoaDon PRIMARY KEY(MaHD),
	CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE,
)

CREATE TABLE ChiTietHoaDon
(
	MaHD CHAR(10) NOT NULL,
	MaTour CHAR(10) NOT NULL,
	NgayThanhToan DATE,
	TongTien INT
	CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY(MaHD, MaTour),
	CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
	CONSTRAINT FK_ChiTietHoaDon_Tour FOREIGN KEY (MaTour) REFERENCES Tour(MaTour) ON DELETE CASCADE,
);

INSERT INTO KhachHang (MaKH, TenKH, NgaySinh, GioiTinh, SoDT, Email, MatKhau, DiaChi, TichDiem)
VALUES
	('KH001', N'Nguyễn Văn A', '1990-01-15', N'Nam', '0911111111', 'nguyenvana@gmail.com', 'nguyenvana', N'Hà Nội', 100),
	('KH002', N'Nguyễn Thị B', '1995-03-20', N'Nữ', '0922222222', 'nguyenthic@gmail.com', 'nguyenthic', N'Hồ Chí Minh', 150),
	('KH003', N'Trần Văn C', '1988-07-08', N'Nam', '0933333333', 'tranvanc@gmail.com', 'tranvanc', N'Đà Nẵng', 50),
	('KH004', N'Phạm Thị D', '1993-11-25', N'Nữ', '0944444444', 'phamthid@gmail.com', 'phamthid', N'Nha Trang', 75),
	('KH005', N'Lê Văn E', '1996-02-18', N'Nam', '0955555555', 'levane@gmail.com', 'levane', N'Vũng Tàu', 120),
	('KH006', N'Huỳnh Thị F', '1985-05-30', N'Nữ', '0966666666', 'huynhthif@gmail.com', 'huynhthif', N'Cần Thơ', 85),
	('KH007', N'Võ Tiến G', '1992-09-10', N'Nam', '0977777777', 'vovang@gmail.com', 'vovang', N'Phan Thiết', 110),
	('KH008', N'Nguyễn Thị H', '1997-12-03', N'Nữ', '0988888888', 'nguyenthih@gmail.com', 'nguyenthih', N'Đà Lạt', 70),
	('KH009', N'Hoàng Văn I', '1989-06-14', N'Nam', '0999999999', 'hoangvani@gmail.com', 'hoangvani', N'Hội An', 130),
	('KH010', N'Nguyễn Thị K', '1994-04-22', N'Nữ', '0900000000', 'nguyenthik@gmail.com', 'nguyenthik', N'Sapa', 90),
	('KH011', N'Trần Gia Bảo', '1990-01-15', N'Nam', '0911111111', 'baogia1610@gmail.com', 'baogia1610', N'Hà Nội', 100)

INSERT INTO Tour (MaTour, TenTour, MieuTa, Gia, DiaDiem)
VALUES
	('T001', N'Tour Miền Bắc', N'Tour tham quan các điểm du lịch ở Miền Bắc', 2000000, N'Hà Nội'),
	('T002', N'Tour Miền Nam', N'Tour khám phá cảnh đẹp Miền Nam', 2500000, N'Hồ Chí Minh'),
	('T003', N'Tour Miền Trung', N'Tour vùng Miền Trung đầy hấp dẫn', 2200000, N'Đà Nẵng'),
	('T004', N'Tour Hải Phòng', N'Tour tham quan vùng biển Hải Phòng', 1800000, N'Hải Phòng'),
	('T005', N'Tour Đà Nẵng', N'Tour khám phá Đà Nẵng hiện đại', 2300000, N'Đà Nẵng'),
	('T006', N'Tour Nha Trang', N'Tour nghỉ dưỡng tại Nha Trang', 2700000, N'Nha Trang'),
	('T007', N'Tour Vũng Tàu', N'Tour biển Vũng Tàu thú vị', 1900000, N'Vũng Tàu'),
	('T008', N'Tour Cần Thơ', N'Tour sông nước Cần Thơ', 2100000, N'Cần Thơ'),
	('T009', N'Tour Phan Thiết', N'Tour biển Phan Thiết tuyệt vời', 2600000, N'Phan Thiết'),
	('T010', N'Tour Đà Lạt', N'Tour hòa mình vào không gian Đà Lạt', 2400000, N'Đà Lạt')

INSERT INTO NhanVien (MaNV, TenNV, Email, SDT, NgaySinh, ChucVu, MatKhau, Quyen)
VALUES
	('ADMIN', N'Trần Tiến Đạt', 'Admin', '0711111111', '2003-08-25', N'Admin', 'Admin', 'Admin'),
	('NV001', N'Nguyễn Văn A', 'nguyenvana@gmail.com', '0711111111', '1992-08-25', N'Hướng Dẫn Viên', 'password_nv001', 'NV'),
	('NV002', N'Nguyễn Thị Cẩm B', 'nguyenthicamb@gmail.com', '0722222222', '1998-03-10', N'Hướng Dẫn Viên', 'password_nv002', 'NV'),
	('NV003', N'Trần Tiến C', 'trantienc@gmail.com', '0733333333', '1993-11-05', N'Hướng Dẫn Viên', 'password_nv003', 'NV'),
	('NV004', N'Lê Nguyễn Anh D', 'lenguyenanhd@gmail.com', '0744444444', '1991-06-18', N'Hướng Dẫn Viên', 'password_nv004', 'NV'),
	('NV005', N'Phạm Việt E', 'phamviete@gmail.com', '0755555555', '1997-09-30', N'Hướng Dẫn Viên', 'password_nv005', 'NV'),
	('NV006', N'Huỳnh Tiến F', 'huynhtienf@gmail.com', '0766666666', '1994-12-20', N'Tư Vấn Viên', 'password_nv006', 'NV'),
	('NV007', N'Võ Hùng G', 'vohungg@gmail.com', '0777777777', '1989-04-15', N'Tư Vấn Viên', 'password_nv007', 'NV'),
	('NV008', N'Nguyễn Việt H', 'nguyenvieth@gmail.com', '0788888888', '1996-07-28', N'Tư Vấn Viên', 'password_nv008', 'NV'),
	('NV009', N'Huỳnh Thị I', 'huynhthii@gmail.com', '0799999999', '1990-02-08', N'Tư Vấn Viên', 'password_nv009', 'NV'),
	('NV0010', N'Võ Nguyễn Văn K', 'vovank@gmail.com', '0700000000', '1999-01-01', N'Tư Vấn Viên', 'password_nv0010', 'NV');

INSERT INTO ChiTietTour (MaNV, MaTour, SoNgay, NgayKhoiHanh, NgayKetThuc, NoiDungTour, DuongDan)
VALUES
	('NV001', 'T001', 7, '2023-05-10', '2023-05-17', N'Tour Miền Bắc - 7 ngày 6 đêm', 'mien-bac.jpg'),
	('NV002', 'T002', 7, '2023-06-20', '2023-06-27', N'Tour Miền Nam - 7 ngày 6 đêm', 'mien-nam.jpg'),
	('NV004', 'T003', 7, '2023-07-15', '2023-07-22', N'Tour Miền Trung - 7 ngày 6 đêm', 'mien-trung.jpg'),
	('NV002', 'T004', 4, '2023-08-05', '2023-08-09', N'Tour Hải Phòng - 4 ngày 3 đêm', 'hai-phong.jpg'),
	('NV003', 'T005', 3, '2023-09-10', '2023-09-13', N'Tour Đà Nẵng - 3 ngày 2 đêm', 'da-nang.jpg'),
	('NV005', 'T006', 5, '2023-10-20', '2023-10-25', N'Tour Nha Trang - 5 ngày 4 đêm', 'nha-trang.jpg'),
	('NV001', 'T007', 2, '2023-11-15', '2023-11-17', N'Tour Vũng Tàu - 2 ngày 1 đêm', 'vung-tau.jpg'),
	('NV003', 'T008', 2, '2023-12-10', '2023-12-12', N'Tour Cần Thơ - 2 ngày 1 đêm', 'can-tho.jpg'),
	('NV004', 'T009', 4, '2024-01-20', '2024-01-24', N'Tour Phan Thiết - 4 ngày 3 đêm', 'phan-thiet.jpg'),
	('NV004', 'T010', 3, '2024-02-15', '2024-02-18', N'Tour Đà Lạt - 3 ngày 2 đêm', 'da-lat.jpg')

INSERT INTO DatTour (MaDat, MaKH, MaTour, NgayDat, TinhTrangThanhToan, NguoiLon, TreEm)
VALUES
	('D001', 'KH001', 'T001', '2023-04-15', N'Đã thanh toán', 2, 1),
	('D002', 'KH001', 'T003', '2023-05-01', N'Chưa thanh toán', 3, 2),
	('D003', 'KH002', 'T003', '2023-05-12', N'Đã thanh toán', 2, 0),
	('D004', 'KH002', 'T004', '2023-06-02', N'Đã thanh toán', 1, 1),
	('D005', 'KH002', 'T008', '2023-06-20', N'Chưa thanh toán', 2, 2),
	('D006', 'KH004', 'T002', '2023-04-05', N'Chưa thanh toán', 1, 0),
	('D007', 'KH005', 'T001', '2023-03-01', N'Đã thanh toán', 3, 1),
	('D008', 'KH005', 'T007', '2023-08-15', N'Chưa thanh toán', 2, 2),
	('D009', 'KH008', 'T006', '2023-09-10', N'Đã thanh toán', 4, 0),
	('D010', 'KH009', 'T002', '2023-05-01', N'Chưa thanh toán', 3, 1)

INSERT INTO DanhGia (MaDanhGia, MaTour, MaKH, DanhGia, BinhLuan, NgayDanhGia)
VALUES
	('DG001', 'T001', 'KH001', 4, N'Tour rất tuyệt vời', '2023-05-20'),
	('DG002', 'T003', 'KH001', 5, N'Tour Miền Bắc tuyệt vời', '2023-07-23'),
	('DG003', 'T003', 'KH002', 4, N'Tour Miền Bắc thú vị', '2023-07-25'),
	('DG004', 'T004', 'KH002', 3, N'Tour Hải Phòng tuyệt đẹp', '2023-08-11'),
	('DG005', 'T008', 'KH002', 5, N'Tour Cần Thơ đáng nhớ', '2023-12-13'),
	('DG006', 'T002', 'KH004', 4, N'Tour Miền Nam thú vị', '2023-06-28'),
	('DG007', 'T001', 'KH005', 3, N'Tour Miền Bắc tuyệt đẹp', '2023-05-19'),
	('DG008', 'T007', 'KH005', 5, N'Tour Vũng Tàu đáng nhớ', '2023-11-18'),
	('DG009', 'T006', 'KH008', 4, N'Tour Nha Trang thú vị', '2023-10-27'),
	('DG010', 'T002', 'KH009', 3, N'Tour Miền Nam tuyệt đẹp', '2023-06-30')

INSERT INTO HoaDon (MaHD, MaKH, TinhTrang)
VALUES
	('HD001', 'KH001', N'Chưa thanh toán'),
	('HD002', 'KH002', N'Đã thanh toán'),
	('HD003', 'KH003', N'Đã thanh toán'),
	('HD004', 'KH004', N'Chưa thanh toán'),
	('HD005', 'KH005', N'Đã thanh toán')

INSERT INTO ChiTietHoaDon (MaHD, MaTour, NgayThanhToan, TongTien)
VALUES
	('HD001', 'T001', '2023-08-01', 5500000),
	('HD002', 'T002', '2023-09-01', 6000000),
	('HD003', 'T003', '2023-10-01', 5200000),
	('HD004', 'T004', '2023-11-01', 4800000),
	('HD005', 'T005', '2023-12-01', 5000000)

--============================== PROCEDURE ================================================
-- Đăng ký nhân viên
CREATE FUNCTION dbo.GenerateEmployeeCode()
RETURNS CHAR(10)
AS
BEGIN
    DECLARE @NVCode CHAR(10);
    DECLARE @NextId INT;

    SELECT @NextId = ISNULL(MAX(CAST(SUBSTRING(MaNV, 3, LEN(MaNV)) AS INT)), 0) + 1
    FROM NhanVien
    WHERE MaNV NOT LIKE 'ADMIN%';

    SET @NVCode = 'NV' + RIGHT('000' + CAST(@NextId AS VARCHAR(3)), 3);

    RETURN @NVCode;
END;

-- Thống kê doanh thu theo tháng
CREATE PROCEDURE ThongKeDoanhThuTheoThang
AS
BEGIN
    SELECT
        YEAR(DatTour.NgayDat) AS Nam,
        MONTH(DatTour.NgayDat) AS Thang,
        SUM((DatTour.NguoiLon * Tour.Gia) + (DatTour.TreEm * Tour.Gia * 0.55)) AS DoanhThu
    FROM DatTour
    JOIN Tour ON DatTour.MaTour = Tour.MaTour
    GROUP BY YEAR(DatTour.NgayDat), MONTH(DatTour.NgayDat)
    ORDER BY Nam, Thang;
END;

--- Tour đặt nhiều nhất
CREATE PROCEDURE TourDatNhieuNhat
AS
BEGIN
	SELECT TOP 1 MaTour, COUNT(MaTour) AS SoLuotDat
    FROM DatTour
    GROUP BY MaTour
    ORDER BY SoLuotDat DESC;
END;

--- Lấy thông tin tour
CREATE PROCEDURE GetTourInformation
    @MaTour CHAR(10)
AS
BEGIN
    SELECT *
    FROM Tour
    WHERE MaTour = @MaTour;
END;

--- Sinh mã khách hàng
CREATE FUNCTION dbo.GenerateKhachHangCode()
RETURNS CHAR(10)
AS
BEGIN
    DECLARE @KHCode CHAR(10);
    DECLARE @NextId INT;

    -- Tìm số thứ tự lớn nhất hiện tại trong bảng KhachHang
    SELECT @NextId = ISNULL(MAX(CAST(SUBSTRING(MaKH, 3, LEN(MaKH)) AS INT)), 0) + 1
    FROM KhachHang;

    -- Tạo mã khách hàng mới
    SET @KHCode = 'KH' + RIGHT('000' + CAST(@NextId AS VARCHAR(3)), 3);

    RETURN @KHCode;
END;

--- Thêm khách hàng
CREATE PROCEDURE dbo.InsertKhachHang
    @TenKH NVARCHAR(50),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(5),
    @SoDT CHAR(10),
    @Email CHAR(50),
    @MatKhau CHAR(30),
    @DiaChi NVARCHAR(50),
    @TichDiem INT
AS
BEGIN
    DECLARE @MaKH CHAR(10);

    -- Sử dụng hàm để sinh mã khách hàng mới
    SET @MaKH = dbo.GenerateKhachHangCode();

    -- Thêm khách hàng vào bảng
    INSERT INTO KhachHang (MaKH, TenKH, NgaySinh, GioiTinh, SoDT, Email, MatKhau, DiaChi, TichDiem)
    VALUES (@MaKH, @TenKH, @NgaySinh, @GioiTinh, @SoDT, @Email, @MatKhau, @DiaChi, @TichDiem);
END;

--- Thêm nhân viên
CREATE PROCEDURE dbo.InsertNhanVien
    @TenNV NVARCHAR(50),
    @Email CHAR(50),
    @SDT CHAR(10),
    @NgaySinh DATE,
    @ChucVu NVARCHAR(30),
    @MatKhau CHAR(30)
AS
BEGIN
    DECLARE @MaNV CHAR(10);

    -- Sử dụng hàm để sinh mã nhân viên mới
    SET @MaNV = dbo.GenerateEmployeeCode();

    -- Thêm nhân viên vào bảng
    INSERT INTO NhanVien (MaNV, TenNV, Email, SDT, NgaySinh, ChucVu, MatKhau)
    VALUES (@MaNV, @TenNV, @Email, @SDT, @NgaySinh, @ChucVu, @MatKhau);
END;

SELECT * FROM NhanVien

--Dat Tour
CREATE FUNCTION dbo.GenerateDatTourCode()
RETURNS CHAR(10)
AS
BEGIN
    DECLARE @DTCode CHAR(10);
    DECLARE @NextId INT;

    SELECT @NextId = ISNULL(MAX(CAST(SUBSTRING(MaDat, 3, LEN(MaDat)) AS INT)), 0) + 1
    FROM DatTour
    WHERE MaDat NOT LIKE 'ADMIN%';

    SET @DTCode = 'D' + RIGHT('000' + CAST(@NextId AS VARCHAR(3)), 3);

    RETURN @DTCode;
END;

--- Loc hóa đơn
CREATE PROCEDURE GetHoaDonByDateRange
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT chd.MaHD
    FROM ChiTietHoaDon chd
    WHERE chd.NgayThanhToan BETWEEN @NgayBatDau AND @NgayKetThuc;
END;
