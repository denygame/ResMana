CREATE DATABASE QLNH
GO

USE QLNH
GO
--USE master DROP DATABASE QLNH
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

	chiPhiPhuThem INT DEFAULT 0, -- đặt chỗ
	
	tongTien FLOAT NOT NULL,
	userName NVARCHAR(100) NOT NULL,
	trangThai INT DEFAULT 0, -- 0: Chưa thanh toán || 1: OK

	FOREIGN KEY (idBanAn) REFERENCES dbo.BanAn(idBanAn),
	FOREIGN KEY (userName) REFERENCES dbo.TaiKhoan(userName)
)

CREATE TABLE ChiTietHoaDon
(
	idCTHD INT IDENTITY PRIMARY KEY,
	idHoaDon INT NOT NULL,
	idThucAn INT NOT NULL,
	soLuong INT NOT NULL,

	FOREIGN KEY (idHoaDon) REFERENCES dbo.HoaDon(idHoaDon),
	FOREIGN KEY (idThucAn) REFERENCES dbo.ThucAn(idThucAn)
)




--- TEST
INSERT dbo.Sanh( tenSanh )VALUES  ( N'Sảnh 1')
INSERT dbo.Sanh( tenSanh )VALUES ( N'Sảnh 2')

DECLARE @i INT =0
WHILE @i<10
BEGIN
	INSERT dbo.BanAn
	        ( tenBan ,
	          choNgoi ,
	          idSanh ,
	          trangThai
	        )
	VALUES  ( 
	          N'Bàn '+CAST((@i+1) AS NVARCHAR(100)) , -- tenBan - nvarchar(100)
	          2 , -- choNgoi - int
	          1 , -- idSanh - int
	          0  -- trangThai - int
	        )
	SET @i = @i +1
END
GO
INSERT dbo.BanAn
	        ( tenBan ,
	          choNgoi ,
	          idSanh ,
	          trangThai
	        )
	VALUES  ( 
	          N'Bàn 11',
	          2 , -- choNgoi - int
	          1 , -- idSanh - int
	          2  -- trangThai - int
	        )
DECLARE @j INT =0
WHILE @j<30
BEGIN
	INSERT dbo.BanAn
	        ( tenBan ,
	          choNgoi ,
	          idSanh ,
	          trangThai
	        )
	VALUES  ( 
	          N'Bàn '+CAST((@j+1) AS NVARCHAR(100)) , -- tenBan - nvarchar(100)
	          4, -- choNgoi - int
	          2 , -- idSanh - int
	          0  -- trangThai - int
	        )
	SET @j = @j +1
END
GO
INSERT dbo.BanAn
	        ( tenBan ,
	          choNgoi ,
	          idSanh ,
	          trangThai
	        )
	VALUES  ( 
	          N'Bàn 12',
	          2 , -- choNgoi - int
	          1 , -- idSanh - int
	          1  -- trangThai - int
	        )

INSERT dbo.NhanVien
        ( tenNhanVien ,
          ngaySinh ,
          gioiTinh ,
          chucVu ,
          queQuan ,
          email ,
          diaChi ,
          tel
        )
VALUES  ( N'asd' , -- tenNhanVien - nvarchar(100)
          GETDATE() , -- ngaySinh - date
          N'nam' , -- gioiTinh - nvarchar(3)
          N'das' , -- chucVu - nvarchar(100)
          N'dsad' , -- queQuan - nvarchar(100)
          'dasd' , -- email - varchar(100)
          N'dasd' , -- diaChi - nvarchar(100)
          0  -- tel - int
        )
INSERT dbo.TaiKhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( N'denygame', -- userName - nvarchar(100)
          N'123', -- pass - nvarchar(1000)
          1, -- idNhanVien - int
          2  -- loaiTK - int
          )
		  INSERT dbo.TaiKhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( N'huy96', -- userName - nvarchar(100)
          N'123', -- pass - nvarchar(1000)
          1, -- idNhanVien - int
          0  -- loaiTK - int
          )

		  GO
          
--SELECT t.tenThucAn, ct.soLuong, ct.soLuong*t.giaTien AS [thanhTien] FROM dbo.ChiTietHoaDon AS ct, dbo.HoaDon AS hd, dbo.ThucAn AS t 
--WHERE ct.idHoaDon = hd.idHoaDon AND ct.idThucAn = t.idThucAn AND hd.idBanAn = 

INSERT dbo.HoaDon
        ( 
          ngayDen ,
          idBanAn ,
          discount ,
          chiPhiPhuThem ,
          tongTien ,
          userName ,
          trangThai
        )
VALUES  ( 
          GETDATE() , -- ngayDen - date
          2 , -- idBanAn - int
          0 , -- discount - int
          0 , -- chiPhiPhuThem - int
          0.0 , -- tongTien - float
          N'denygame' , -- userName - nvarchar(100)
          0  -- trangThai - int
        )

		INSERT dbo.HoaDon
        ( 
          ngayDen ,
          idBanAn ,
          discount ,
          chiPhiPhuThem ,
          tongTien ,
          userName ,
          trangThai
        )
VALUES  ( 
          GETDATE() , -- ngayDen - date
          8 , -- idBanAn - int
          0 , -- discount - int
          0 , -- chiPhiPhuThem - int
          0.0 , -- tongTien - float
          N'denygame' , -- userName - nvarchar(100)
          0  -- trangThai - int
        )

		INSERT dbo.HoaDon
        ( 
          ngayDen ,
          idBanAn ,
          discount ,
          chiPhiPhuThem ,
          tongTien ,
          userName ,
          trangThai
        )
VALUES  ( 
          GETDATE() , -- ngayDen - date
          15 , -- idBanAn - int
          0 , -- discount - int
          0 , -- chiPhiPhuThem - int
          0.0 , -- tongTien - float
          N'denygame' , -- userName - nvarchar(100)
          0  -- trangThai - int
        )


INSERT dbo.DanhMuc
        ( tenMenu )
VALUES  ( N'Nước'  -- tenMenu - nvarchar(100)
          )
INSERT dbo.ThucAn
        ( tenThucAn, idMenu, giaTien )
VALUES  ( N'Cafe', -- tenThucAn - nvarchar(100)
          1, -- idMenu - int
          15000.0  -- giaTien - float
          )
		INSERT dbo.ThucAn
        ( tenThucAn, idMenu, giaTien )
VALUES  ( N'Trà', -- tenThucAn - nvarchar(100)
          1, -- idMenu - int
          10000.0  -- giaTien - float
          )
	INSERT dbo.DanhMuc
	        ( tenMenu )
	VALUES  ( N'Gà'  -- tenMenu - nvarchar(100)
	          )
INSERT dbo.ThucAn
        ( tenThucAn, idMenu, giaTien )
VALUES  ( N'Gà hấp', -- tenThucAn - nvarchar(100)
          2, -- idMenu - int
          50000.0  -- giaTien - float
          )
INSERT dbo.ThucAn
        ( tenThucAn, idMenu, giaTien )
VALUES  ( N'Gà hấp xào chua', -- tenThucAn - nvarchar(100)
          2, -- idMenu - int
          150000.0  -- giaTien - float
          )
INSERT dbo.ChiTietHoaDon
        ( idHoaDon, idThucAn, soLuong )
VALUES  ( 1, -- idHoaDon - int
          2, -- idThucAn - int
          5  -- soLuong - int
          )
INSERT dbo.ChiTietHoaDon
        ( idHoaDon, idThucAn, soLuong )
VALUES  ( 1, -- idHoaDon - int
          4, -- idThucAn - int
          1  -- soLuong - int
          )
INSERT dbo.ChiTietHoaDon
        ( idHoaDon, idThucAn, soLuong )
VALUES  ( 2, -- idHoaDon - int
          1, -- idThucAn - int
          4  -- soLuong - int
          )
INSERT dbo.ChiTietHoaDon
        ( idHoaDon, idThucAn, soLuong )
VALUES  ( 2, -- idHoaDon - int
          2, -- idThucAn - int
          1  -- soLuong - int
          )
INSERT dbo.ChiTietHoaDon
        ( idHoaDon, idThucAn, soLuong )
VALUES  ( 3, -- idHoaDon - int
          3, -- idThucAn - int
          1  -- soLuong - int
          )