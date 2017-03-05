CREATE DATABASE QLNH
GO

USE QLNH
GO

CREATE TABLE NhanVien
(
	idNhanVien INT IDENTITY PRIMARY KEY,
	tenNhanVien NVARCHAR(100) NOT NULL,
	ngaySinh DATE NOT NULL,
	gioiTinh NVARCHAR(3) NOT NULL,
	chucVu NVARCHAR(100) NOT NULL, 
	queQuan NVARCHAR(100),
	email VARCHAR(100),
	diaChi NVARCHAR(100),
	tel INT NOT	NULL,
)

CREATE TABLE TaiKhoan
(
	userName NVARCHAR(100) PRIMARY KEY,
	pass NVARCHAR(1000) NOT NULL,
	idNhanVien INT NOT NULL,
	loaiTK INT NOT NULL DEFAULT 1, -- 0: Admin || 1: Nhân Viên || 2: Quản Lý

	FOREIGN KEY (idNhanVien) REFERENCES dbo.NhanVien(idNhanVien)
)

CREATE TABLE Sanh
(
	idSanh INT IDENTITY PRIMARY KEY,
	tenSanh NVARCHAR(100) DEFAULT N'Chưa đặt tên sảnh',
)

CREATE TABLE BanAn
(
	idBanAn INT IDENTITY PRIMARY KEY,
	tenBan NVARCHAR(100) DEFAULT N'Chưa đặt tên bàn',
	choNgoi INT NOT NULL, 
	idSanh INT NOT NULL,
	trangThai INT DEFAULT 0, -- 0: Trống || 1: Có Người || 2: Bàn Đặt Chỗ

	FOREIGN KEY (idSanh) REFERENCES dbo.Sanh(idSanh)
)

CREATE TABLE DanhMuc
(
	idMenu INT IDENTITY PRIMARY KEY,
	tenMenu NVARCHAR(100) DEFAULT N'Chưa đặt tên danh mục',
)

CREATE TABLE ThucAn
(
	idThucAn INT IDENTITY PRIMARY KEY,
	tenThucAn NVARCHAR(100) NOT NULL,
	idMenu INT NOT NULL,
	giaTien FLOAT NOT NULL,

	FOREIGN KEY (idMenu) REFERENCES dbo.DanhMuc(idMenu)
)

CREATE TABLE HoaDon
(
	idHoaDon INT IDENTITY PRIMARY KEY,
	ngayDen DATE NOT NULL,
	idBanAn INT NOT NULL,
	discount INT DEFAULT 0, -- mặc định giảm giá 0%
	tongTien FLOAT NOT NULL,
	userName NVARCHAR(100) NOT NULL,
	trangThai INT DEFAULT 0, -- 0: Chưa thanh toán || 1: OK

	FOREIGN KEY (idBanAn) REFERENCES dbo.BanAn(idBanAn),
	FOREIGN KEY (userName) REFERENCES dbo.TaiKhoan(userName)
)

CREATE TABLE ChiTietHoaDon
(
	idCTHD INT IDENTITY PRIMARY KEY,
	idHoaDon INT,
	idThucAn INT,
	soLuong INT,
	chiPhiPhuThem INT, -- đặt chỗ

	FOREIGN KEY (idHoaDon) REFERENCES dbo.HoaDon(idHoaDon),
	FOREIGN KEY (idThucAn) REFERENCES dbo.ThucAn(idThucAn)
)