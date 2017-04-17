CREATE DATABASE HQTCSDL
GO

USE HQTCSDL
GO



--USE master DROP DATABASE HQTCSDL
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
	tel VARCHAR(11) NOT	NULL,

	checkDelete INT DEFAULT 0,
)

CREATE TABLE TaiKhoan
(
	userName VARCHAR(100) PRIMARY KEY,
	pass VARCHAR(1000) NOT NULL,
	idNhanVien INT NOT NULL,
	loaiTK INT NOT NULL DEFAULT 1, -- 0: Admin || 1: Nhân Viên || 2: Quản Lý

	checkDelete INT DEFAULT 0,
	checkLogin INT DEFAULT 0, -- 0:chưa login, 1:login 

	FOREIGN KEY (idNhanVien) REFERENCES dbo.NhanVien(idNhanVien)
)

CREATE TABLE Sanh
(
	idSanh INT IDENTITY PRIMARY KEY,
	tenSanh NVARCHAR(100) DEFAULT N'Chưa đặt tên sảnh',

	checkDelete INT DEFAULT 0, -- xóa thì sửa thành 1
)

CREATE TABLE BanAn
(
	idBanAn INT IDENTITY PRIMARY KEY,
	tenBan NVARCHAR(100) DEFAULT N'Chưa đặt tên bàn',
	idSanh INT NOT NULL,
	
	trangThai NVARCHAR(100) DEFAULT N'Bàn Trống', -- Bàn Trống || Khách || Bàn Đặt Chỗ

	checkDelete INT DEFAULT 0, -- xóa thì sửa thành 1

	FOREIGN KEY (idSanh) REFERENCES dbo.Sanh(idSanh)
)

CREATE TABLE DanhMuc
(
	idMenu INT IDENTITY PRIMARY KEY,
	tenMenu NVARCHAR(100) DEFAULT N'Chưa đặt tên danh mục',

	checkDelete INT DEFAULT 0, -- xóa thì sửa thành 1, vì xóa luôn sẽ ảnh hưởng nhiều table
)

CREATE TABLE ThucAn
(
	idThucAn INT IDENTITY PRIMARY KEY,
	tenThucAn NVARCHAR(100) NOT NULL,
	idMenu INT NOT NULL,
	giaTien FLOAT NOT NULL,

	checkDelete INT DEFAULT 0, -- xóa thì sửa thành 1

	FOREIGN KEY (idMenu) REFERENCES dbo.DanhMuc(idMenu)
)

CREATE TABLE HoaDon
(
	idHoaDon INT IDENTITY PRIMARY KEY,
	ngayDen DATE NOT NULL,
	idBanAn INT NOT NULL,
	discount INT DEFAULT 0, -- mặc định giảm giá 0%

	tongTien FLOAT NOT NULL,
	userName VARCHAR(100),
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

-- bảng truyền vào idBanAn khi insert update Bill
CREATE TABLE testLoadTableCsharp
(
	id INT NOT NULL
)

CREATE TABLE IPConnectionDatabase
(
	ip VARCHAR(100) NOT NULL
)
GO





--CREATE PROC	StoredProcedure_DangNhap
--@userName nvarchar(100), @passWOrd nvarchar(1000)
--AS
--BEGIN
--	SELECT * FROM dbo.TaiKhoan WHERE userName = @userName AND pass = @passWOrd AND checkDelete = 0
--END
--GO

CREATE PROC	StoredProcedure_ThemHoaDon
@idBanAn INT, @userName NVARCHAR(100)
AS
BEGIN
	INSERT dbo.HoaDon ( ngayDen , idBanAn , discount  , tongTien , userName , trangThai )
	VALUES  ( GETDATE() , @idBanAn , 0 , 0.0 , @userName ,   N'Chưa thanh toán')
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
	 	 DELETE FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn
		
	 ELSE
		UPDATE dbo.ChiTietHoaDon SET soLuong = soLuong - @soLuong WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn
END
GO

-- procedure quan trọng --- <nhớ test lại> 8/3/2017 thanhhuy
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

	-- đã viết trigger cho delete cthd nên k cần xét

			/*DECLARE @testHoaDon INT = 0
			SELECT @testHoaDon = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon

			IF(@testHoaDon = 0)
			BEGIN
				DELETE FROM dbo.HoaDon WHERE idHoaDon = @idHoaDon
			END*/
		END	
	END
	
	ELSE
    BEGIN
		IF(@soLuong > 0)
			INSERT dbo.ChiTietHoaDon ( idHoaDon, idThucAn, soLuong ) VALUES  ( @idHoaDon, @idThucAn, @soLuong )
	END
END
GO

CREATE PROC StoredProcedure_ChuyenBan
@idBan1 INT, @idBan2 INT
AS
BEGIN
	DECLARE @trangThaiBan1 NVARCHAR(100)
	DECLARE @trangThaiBan2 NVARCHAR(100)
	
	SELECT @trangThaiBan1 = trangThai FROM dbo.BanAn WHERE idBanAn = @idBan1
	SELECT @trangThaiBan2 = trangThai FROM dbo.BanAn WHERE idBanAn = @idBan2

	--Chuyển từ bàn 2 khách qua bàn 1 trống
	IF(@trangThaiBan1 = N'Bàn Trống' AND @trangThaiBan2 = N'Khách')	
	BEGIN
		UPDATE dbo.HoaDon SET idBanAn = @idBan1 WHERE idBanAn = @idBan2 AND trangThai = N'Chưa thanh toán'
		UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idBan2
		UPDATE dbo.BanAn SET trangThai = N'Khách' WHERE idBanAn = @idBan1 
    END

	--Chuyển từ bàn 1 khách qua bàn 2 trống
	IF(@trangThaiBan2 = N'Bàn Trống' AND @trangThaiBan1 = N'Khách')	
	BEGIN
		UPDATE dbo.HoaDon SET idBanAn = @idBan2 WHERE idBanAn = @idBan1 AND trangThai = N'Chưa thanh toán'
		UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idBan1
		UPDATE dbo.BanAn SET trangThai = N'Khách' WHERE idBanAn = @idBan2
    END

	IF(@trangThaiBan2 = N'Khách' AND @trangThaiBan1 = N'Khách')	
	BEGIN
		DECLARE @idHoaDonBan1 INT
		DECLARE @idHoaDonBan2 INT

		SELECT @idHoaDonBan1 = idHoaDon FROM dbo.HoaDon WHERE idBanAn = @idBan1 AND trangThai = N'Chưa thanh toán'
		SELECT @idHoaDonBan2 = idHoaDon FROM dbo.HoaDon WHERE idBanAn = @idBan2 AND trangThai = N'Chưa thanh toán'

		UPDATE dbo.HoaDon SET idBanAn = @idBan1 WHERE idHoaDon = @idHoaDonBan2
		UPDATE dbo.HoaDon SET idBanAn = @idBan2 WHERE idHoaDon = @idHoaDonBan1
    END
END
GO

-- mặc định bàn gộp là bàn trống hoặc 2 bàn 1 2 nhập vào 12/3/2017 thanhhuy
CREATE PROC StoredProcedure_GopBan
@idBan1 INT, @idBan2 INT, @idBanGop INT
AS
BEGIN
	DECLARE @idHoaDonBan1 INT
	DECLARE @idHoaDonBan2 INT
	DECLARE @idHoaDonBanGop INT

	SELECT @idHoaDonBan1 = idHoaDon FROM dbo.HoaDon WHERE idBanAn = @idBan1 AND trangThai = N'Chưa thanh toán'
	SELECT @idHoaDonBan2 = idHoaDon FROM dbo.HoaDon WHERE idBanAn = @idBan2 AND trangThai = N'Chưa thanh toán'


	IF(@idBanGop = @idBan1)
	BEGIN
		UPDATE dbo.ChiTietHoaDon SET idHoaDon = @idHoaDonBan1 WHERE idHoaDon = @idHoaDonBan2
		UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idBan2
		DELETE FROM dbo.HoaDon WHERE idHoaDon = @idHoaDonBan2
	END
    

	IF(@idBanGop = @idBan2)
	BEGIN
		UPDATE dbo.ChiTietHoaDon SET idHoaDon = @idHoaDonBan2 WHERE idHoaDon = @idHoaDonBan1
		UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idBan1
		DELETE FROM dbo.HoaDon WHERE idHoaDon = @idHoaDonBan1
	END


	IF(@idBan1 <> @idBanGop AND	@idBan2 <> @idBanGop)
	BEGIN
		INSERT dbo.HoaDon( ngayDen , idBanAn , tongTien  , trangThai )
		VALUES  ( GETDATE() , @idBanGop , 0.0 , N'Chưa thanh toán' )

		UPDATE dbo.BanAn SET trangThai = N'Khách' WHERE idBanAn = @idBanGop

		SELECT @idHoaDonBanGop = idHoaDon FROM dbo.HoaDon WHERE idBanAn = @idBanGop AND trangThai = N'Chưa thanh toán'

		---phải chuyển những cái chi tiết hóa đơn của 2 bàn về bàn gộp
		UPDATE dbo.ChiTietHoaDon SET idHoaDon = @idHoaDonBanGop WHERE idHoaDon = @idHoaDonBan1
		UPDATE dbo.ChiTietHoaDon SET idHoaDon = @idHoaDonBanGop WHERE idHoaDon = @idHoaDonBan2

		UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idBan1
		UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idBan2

		DELETE FROM dbo.HoaDon WHERE idHoaDon = @idHoaDonBan1
		DELETE FROM dbo.HoaDon WHERE idHoaDon = @idHoaDonBan2
	END

	-- xem trigger update CTHD => tiếp tục
END
GO

-- hủy bàn hay là xóa hóa đơn
CREATE PROC StoredProcedure_HuyBan_XoaHoaDon
@idBanAn INT
AS
BEGIN
	DECLARE @idHoaDon INT
	SELECT @idHoaDon = idHoaDon FROM dbo.HoaDon WHERE idBanAn = @idBanAn AND trangThai = N'Chưa thanh toán'

	DELETE FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon
END
GO

CREATE PROC StoredProcedure_DeleteCategory
@idCategory INT
AS
BEGIN
	SELECT idThucAn INTO idFoodInCategory FROM dbo.ThucAn WHERE idMenu = @idCategory
	UPDATE dbo.ThucAn SET checkDelete = 1 WHERE idThucAn IN (SELECT * FROM idFoodInCategory)
	UPDATE dbo.DanhMuc SET checkDelete = 1 WHERE idMenu = @idCategory
	DROP TABLE idFoodInCategory
END
GO

CREATE PROC StoredProcedure_DeleteSanh
@idSanh INT
AS
BEGIN
	SELECT idBanAn INTO idTableInSanh FROM dbo.BanAn WHERE idSanh = @idSanh
	UPDATE dbo.BanAn SET checkDelete = 1 WHERE idBanAn IN (SELECT * FROM idTableInSanh)
	UPDATE dbo.Sanh SET checkDelete = 1 WHERE idSanh = @idSanh
	DROP TABLE idTableInSanh
END
GO



CREATE PROC StoredProcedure_InsertIP
@ip VARCHAR(100)
AS
BEGIN
	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.IPConnectionDatabase WHERE ip = @ip
	IF(@count = 0)
		INSERT dbo.IPConnectionDatabase ( ip ) VALUES  ( @ip )
END
GO

CREATE PROC StoredProcedure_DeleteIP
@ip VARCHAR(100)
AS
BEGIN
	DELETE FROM dbo.IPConnectionDatabase  WHERE ip = @ip
END
GO

--DBCC CHECKIDENT (@nameTable, RESEED, 0)





CREATE PROC StoredProcedure_PhanTrangHoaDonDTT
@dateIn DATE, @dateOut DATE, @page INT, @pageRows INT
AS
BEGIN
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
-- tạo 1 table tạm cách khác
	;WITH BillShow AS (SELECT b.idHoaDon AS [ID Bill], s.tenSanh AS [Tên sảnh],t.tenBan AS [Tên bàn], b.ngayDen AS [Ngày đến], b.tongTien AS [Tổng tiền], CAST(discount AS NVARCHAR(100)) + N'%' AS [Đã giảm giá]
	FROM dbo.HoaDon AS b, dbo.BanAn AS t, dbo.Sanh AS s
	WHERE b.ngayDen >= @dateIn AND b.ngayDen <= @dateOut AND b.trangThai = N'Đã thanh toán'
	AND t.idBanAn = b.idBanAn AND t.idSanh = s.idSanh) 
	
	SELECT TOP (@pageRows) * FROM BillShow WHERE BillShow.[ID Bill] NOT IN (SELECT TOP (@exceptRows) BillShow.[ID Bill] FROM BillShow)
END
GO


CREATE PROC StoredProcedure_laySoHoaDonDTT
@dateIn DATE, @dateOut DATE
AS
BEGIN
	SELECT COUNT(*)
	FROM dbo.HoaDon AS b, dbo.BanAn AS t
	WHERE b.ngayDen >= @dateIn AND b.ngayDen <= @dateOut AND b.trangThai = N'Đã thanh toán'
	AND t.idBanAn = b.idBanAn 
END
GO

CREATE PROC StoredProcedure_PhanTrangHoaDonCTT
@page INT, @pageRows INT
AS
BEGIN
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
-- tạo 1 table tạm cách khác
	;WITH BillShow AS (SELECT b.idHoaDon AS [ID Bill], s.tenSanh AS[Tên sảnh], t.tenBan AS [Tên bàn], b.ngayDen AS [Ngày đến], b.trangThai AS [Trạng thái] 
	FROM dbo.HoaDon AS b, dbo.BanAn AS t, dbo.Sanh AS s
	WHERE b.trangThai = N'Chưa thanh toán'
	AND t.idBanAn = b.idBanAn AND t.idSanh = s.idSanh) 
	
	SELECT TOP (@pageRows) * FROM BillShow WHERE BillShow.[ID Bill] NOT IN (SELECT TOP (@exceptRows) BillShow.[ID Bill] FROM BillShow)
END
GO


CREATE PROC StoredProcedure_laySoHoaDonCTT
AS
BEGIN
	SELECT COUNT(*)
	FROM dbo.HoaDon
	WHERE trangThai = N'Chưa thanh toán'
END
GO



CREATE PROC StoredProcedure_layTongDoanhThu
@dateIn DATE, @dateOut DATE
AS
BEGIN
	SELECT SUM(tongTien)
	FROM dbo.HoaDon
	WHERE ngayDen >= @dateIn AND ngayDen <= @dateOut AND trangThai = N'Đã thanh toán'
END
GO














-- trigger cho update sửa idHoaDon, hay 12/3/2017 thanhhuy
CREATE TRIGGER TG_update_ChiTietHoaDon ON dbo.ChiTietHoaDon FOR UPDATE
AS
BEGIN
	DECLARE @idHoaDon INT
	SELECT @idHoaDon = Inserted.idHoaDon  FROM Inserted

	DECLARE @idBanAn INT 
	SELECT @idBanAn = idBanAn FROM dbo.HoaDon WHERE idHoaDon = @idHoaDon

	DECLARE @idThucAn INT
	SELECT @idThucAn = Inserted.idThucAn  FROM Inserted

	DECLARE @demIdFood INT = 0
	SELECT @demIdFood = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn

	IF(@demIdFood > 1) -- tức là có món ăn trùng nhau, cộng sl
	BEGIN
		DECLARE @tongSl INT
		SELECT @tongSl = SUM(soLuong) FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND	idThucAn = @idThucAn

		DELETE FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThucAn = @idThucAn

		DECLARE @demCTHDconlaiTrongHd INT	-- vì trigger sẽ xóa hóa đơn nếu k còn cthd
		SELECT @demCTHDconlaiTrongHd = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon

		IF(@demCTHDconlaiTrongHd = 0)
		BEGIN
			INSERT dbo.HoaDon( ngayDen , idBanAn , tongTien  , trangThai )
			VALUES  ( GETDATE() , @idBanAn , 0.0 , N'Chưa thanh toán' )

			DECLARE @idHoaDonMoi INT
			SELECT @idHoaDonMoi = MAX(idHoaDon) FROM dbo.HoaDon

			INSERT dbo.ChiTietHoaDon ( idHoaDon, idThucAn, soLuong )
			VALUES  ( @idHoaDonMoi, @idThucAn , @tongSl)
		END

		ELSE
        BEGIN
        	INSERT dbo.ChiTietHoaDon ( idHoaDon, idThucAn, soLuong )
			VALUES  ( @idHoaDon, @idThucAn , @tongSl)
        END

    END
END
GO

CREATE TRIGGER TG_insert_HoaDon ON dbo.HoaDon FOR INSERT
AS
BEGIN
	DECLARE @idBanAn INT
	SELECT @idBanAn = idBanAn FROM Inserted
	UPDATE dbo.BanAn SET trangThai = N'Khách' WHERE idBanAn = @idBanAn

	IF(@idBanAn IS NOT NULL)
	BEGIN
		DECLARE @count INT
		SELECT @count = COUNT(*) FROM dbo.testLoadTableCsharp WHERE id = @idBanAn
		IF(@count = 0)
			INSERT dbo.testLoadTableCsharp( id ) VALUES  ( @idBanAn )
	END	
END
GO

CREATE TRIGGER TG_delete_HoaDon ON dbo.HoaDon FOR DELETE
AS
BEGIN
	DECLARE @idBanAn INT
	SELECT @idBanAn = idBanAn FROM Deleted
	UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idBanAn

	IF(@idBanAn IS NOT NULL)
	BEGIN
		DECLARE @count INT
		SELECT @count = COUNT(*) FROM dbo.testLoadTableCsharp WHERE id = @idBanAn
		IF(@count = 0)
			INSERT dbo.testLoadTableCsharp( id ) VALUES  ( @idBanAn )
	END
END
GO

CREATE TRIGGER TG_delete_ChiTietHoaDon ON dbo.ChiTietHoaDon FOR DELETE
AS
BEGIN
	DECLARE @idHoaDon INT
	SELECT @idHoaDon = idHoaDon FROM Deleted

	DECLARE @demCTHD INT = 0
	SELECT @demCTHD = COUNT(*) FROM dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon

	IF(@demCTHD = 0)
		DELETE FROM dbo.HoaDon WHERE idHoaDon = @idHoaDon
END
GO	

CREATE TRIGGER TG_delete_ip ON dbo.IPConnectionDatabase FOR DELETE
AS
BEGIN
	 DECLARE @count INT = 0
	 SELECT @count = COUNT(*) FROM dbo.IPConnectionDatabase
	 IF(@count < 2)
		DELETE FROM dbo.testLoadTableCsharp
END
GO


CREATE TRIGGER TG_update_HoaDon ON dbo.HoaDon FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = Inserted.idHoaDon FROM Inserted
	DECLARE @idTable INT
	SELECT @idTable = idBanAn FROM dbo.HoaDon WHERE idHoaDon = @idBill
	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.HoaDon WHERE idBanAn = @idTable AND trangThai = N'Chưa thanh toán'
	IF(@count = 0)
		UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = @idTable
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
          '02/22/1996' , -- ngaySinh - date
          N'Nam' , -- gioiTinh - nvarchar(3)
          N'Tổng Giám Đốc' , -- chucVu - nvarchar(100)
          N'TPHCM' , -- queQuan - nvarchar(100)
          'thanhhuy96.gtvt@gmail.com' , -- email - varchar(100)
          N'839/11 Hậu Giang' , -- diaChi - nvarchar(100)
          '0907352619'  -- tel - int
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
          1  -- loaiTK - int
          )
INSERT dbo.TaiKhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( N'aaaa', -- userName - nvarchar(100)
          N'123', -- pass - nvarchar(1000)
          1, -- idNhanVien - int
          1  -- loaiTK - int
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
	          idSanh
	        )
	VALUES  ( N'Bàn ' + CAST((@i+1) AS NVARCHAR(100)) , -- tenBan - nvarchar(100)
	          1  -- idSanh - int
	        )
	SET @i = @i + 1
END

DECLARE @j INT = 0
WHILE (@j < 50)
BEGIN
	INSERT dbo.BanAn
	        ( tenBan ,
	          idSanh
	        )
	VALUES  ( N'Bàn ' + CAST((@j+1) AS NVARCHAR(100)) , -- tenBan - nvarchar(100)
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
