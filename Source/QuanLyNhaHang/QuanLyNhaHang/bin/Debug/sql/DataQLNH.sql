CREATE DATABASE HQTCSDL
GO

USE HQTCSDL
GO
--USE master DROP DATABASE QLNH
CREATE TABLE NhanVien
(
	idNhanVien INT IDENTITY PRIMARY KEY,
	tenNhanVien NVARCHAR(100) NOT NULL,
	ngaySinh DATETIME NOT NULL,
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
	
	trangThai NVARCHAR(100) DEFAULT N'Bàn Trống', -- Bàn Trống || Khách || Bàn Đặt Chỗ

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
	ngayDen DATETIME NOT NULL,
	idBanAn INT NOT NULL,
	discount INT DEFAULT 0, -- mặc định giảm giá 0%

	chiPhiPhuThem INT DEFAULT 0, -- đặt chỗ
	
	tongTien FLOAT NOT NULL,
	userName NVARCHAR(100) NOT NULL,
	trangThai NVARCHAR(100) DEFAULT N'Chưa thanh toán', -- 0: Chưa thanh toán || 1: OK

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
GO


-- SP đăng nhập
CREATE PROC	StoredProcedure_DangNhap
@userName nvarchar(100), @passWOrd nvarchar(1000)
AS
BEGIN
	SELECT * FROM dbo.TaiKhoan WHERE userName = @userName AND pass = @passWOrd 
END
GO

CREATE PROC	StoredProcedure_ThemHoaDon
@idBanAn INT, @userName NVARCHAR(100)
AS
BEGIN
	INSERT dbo.HoaDon ( ngayDen , idBanAn , discount , chiPhiPhuThem , tongTien , userName , trangThai )
	VALUES  ( GETDATE() , @idBanAn , 0 , 0 , 0.0 , @userName ,   N'Chưa thanh toán')
END
GO

-- procedure quan trọng --- test lại
CREATE PROC StoredProcedure_ThemCTHD
@idHoaDon INT, @idThucAn INT, @soLuong INT
AS
BEGIN
    DECLARE @kiemTra INT
	SELECT @kiemTra = idCTHD FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn

	DECLARE @soLuongMoi INT
	SELECT @soLuongMoi = @soLuong + soLuong FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn

	IF (@kiemTra > 0)	-- ChiTietHoaDon có r chỉ thêm soLuong
	BEGIN
		IF(@soLuongMoi > 0) UPDATE dbo.ChiTietHoaDon SET soLuong = @soLuongMoi WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn

		ELSE 
		BEGIN
			DELETE FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn

			DECLARE @testHoaDon INT = 0
			SELECT @testHoaDon = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon

			IF(@testHoaDon = 0)
			BEGIN
				DELETE FROM dbo.HoaDon WHERE idHoaDon = @idHoaDon
			END
		END	
	END

	ELSE
    BEGIN
		IF(@soLuong > 0)
			INSERT dbo.ChiTietHoaDon ( idHoaDon, idThucAn, soLuong ) VALUES  ( @idHoaDon, @idThucAn, @soLuong )
	END
END
GO


CREATE TRIGGER TG_insert_HoaDon ON dbo.HoaDon FOR INSERT
AS
BEGIN
	DECLARE @idBanAn INT
	SELECT @idBanAn = idBanAn FROM Inserted

	UPDATE dbo.BanAn SET trangThai = N'Khách' WHERE idBanAn = @idBanAn
END
GO

CREATE TRIGGER TG_delete_HoaDon ON dbo.HoaDon FOR DELETE
AS
BEGIN
	DECLARE @idBanAn INT
	SELECT @idBanAn = idBanAn FROM Deleted

	UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idBanAn
END
GO



-- Xóa món trong chi tiết hóa đơn theo bàn
CREATE PROC StoredProcedure_XoaMonTrongHDtheoBan
@idHoaDon INT, @tenThucAn NVARCHAR(100), @soLuong INT
AS
BEGIN
	 DECLARE @idThucAn INT
	 SELECT @idThucAn = idThucAn FROM dbo.ThucAn WHERE tenThucAn = @tenThucAn

	 DECLARE @sL INT
	 SELECT @sL = soLuong FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn

	 IF(@sL <= @soLuong)
	 BEGIN
	 	 DELETE FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn
		 DECLARE @test INT = 0
		 SELECT @test = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon
		 IF(@test = 0)
			DELETE FROM dbo.HoaDon WHERE idHoaDon = @idHoaDon
	 END
		
	 ELSE
		UPDATE dbo.ChiTietHoaDon SET soLuong = soLuong - @soLuong WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn
END
GO






--- TEST Bộ Dữ Liệu
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
VALUES  ( N'Nguyễn Thanh Huy' , -- tenNhanVien - nvarchar(100)
          22/02/1996 , -- ngaySinh - date
          N'Nam' , -- gioiTinh - nvarchar(3)
          N'Tổng Giám Đốc' , -- chucVu - nvarchar(100)
          N'TPHCM' , -- queQuan - nvarchar(100)
          'thanhhuy96.gtvt@gmail.com' , -- email - varchar(100)
          N'839/11 Hậu Giang' , -- diaChi - nvarchar(100)
          0907352619  -- tel - int
        )
INSERT dbo.TaiKhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( N'denygame', -- userName - nvarchar(100)
          N'123', -- pass - nvarchar(1000)
          1, -- idNhanVien - int
          1  -- loaiTK - int
          )
INSERT dbo.TaiKhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( N'huy96', -- userName - nvarchar(100)
          N'123', -- pass - nvarchar(1000)
          1, -- idNhanVien - int
          0  -- loaiTK - int
          )

INSERT dbo.Sanh
        ( tenSanh )
VALUES  ( N'Sảnh 1'  -- tenSanh - nvarchar(100)
          )
INSERT dbo.Sanh
        ( tenSanh )
VALUES  ( N'Sảnh 2'  -- tenSanh - nvarchar(100)
          )
DECLARE @i INT = 0
WHILE (@i < 10)
BEGIN
	INSERT dbo.BanAn
	        ( tenBan ,
	          choNgoi ,
	          idSanh
	        )
	VALUES  ( N'Bàn ' + CAST((@i+1) AS NVARCHAR(100)) , -- tenBan - nvarchar(100)
	          4 , -- choNgoi - int
	          1  -- idSanh - int
	        )
	SET @i = @i + 1
END

DECLARE @j INT = 0
WHILE (@j < 50)
BEGIN
	INSERT dbo.BanAn
	        ( tenBan ,
	          choNgoi ,
	          idSanh
	        )
	VALUES  ( N'Bàn ' + CAST((@j+1) AS NVARCHAR(100)) , -- tenBan - nvarchar(100)
	          10 , -- choNgoi - int
	          2  -- idSanh - int
	        )
	SET @j = @j + 1
END


INSERT dbo.DanhMuc ( tenMenu )
VALUES  ( N'Món Nướng' )

INSERT dbo.DanhMuc ( tenMenu )
VALUES  ( N'Món Xào' )

INSERT dbo.DanhMuc ( tenMenu )
VALUES  ( N'Lẩu' )

INSERT dbo.DanhMuc ( tenMenu )
VALUES  ( N'Nước uống' )


INSERT dbo.ThucAn
         ( tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Gà Nướng Muối Ớt' , -- tenThucAn - nvarchar(100)
          1 , -- idMenu - int
          200000.0  -- giaTien - float
        )
INSERT dbo.ThucAn
         ( tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Heo Mọi Nướng' , -- tenThucAn - nvarchar(100)
          1 , -- idMenu - int
          500000.0  -- giaTien - float
        )
INSERT dbo.ThucAn
         ( tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Rau muống xào tỏi' , -- tenThucAn - nvarchar(100)
          2 , -- idMenu - int
          30000.0  -- giaTien - float
        )
INSERT dbo.ThucAn
        (  tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Lẩu Thái' , -- tenThucAn - nvarchar(100)
          3 , -- idMenu - int
          199000.0  -- giaTien - float
        )
INSERT dbo.ThucAn
        (  tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Lẩu Cá Mập' , -- tenThucAn - nvarchar(100)
          3 , -- idMenu - int
          500000.0  -- giaTien - float
        )
INSERT dbo.ThucAn
        (  tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Dú Heo Nướng' , -- tenThucAn - nvarchar(100)
          1 , -- idMenu - int
          99000.0  -- giaTien - float
        )
INSERT dbo.ThucAn
        (  tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Ken' , -- tenThucAn - nvarchar(100)
          4 , -- idMenu - int
          18000.0  -- giaTien - float
        )
INSERT dbo.ThucAn
        (  tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Tiger' , -- tenThucAn - nvarchar(100)
          4 , -- idMenu - int
          16000.0  -- giaTien - float
        )
INSERT dbo.ThucAn
        (  tenThucAn ,
          idMenu ,
          giaTien
        )
VALUES  ( N'Nước Suối' , -- tenThucAn - nvarchar(100)
          4 , -- idMenu - int
          10000.0  -- giaTien - float
        )