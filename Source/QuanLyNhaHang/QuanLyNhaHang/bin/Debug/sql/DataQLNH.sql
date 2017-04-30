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
	email VARCHAR(200),
	diaChi NVARCHAR(200),
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








-- Func copy trên mạng, dùng để thay thế toàn bộ ký tự đặc biệt (có dấu) thành các ký tự bình thường, dùng cho tìm kiếm gần đúng
CREATE FUNCTION [dbo].[fChuyenCoDauThanhKhongDau](@inputVar NVARCHAR(MAX) )
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END
GO





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

-- procedure quan trọng --- nhớ test lại (8/3/2017) 
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

-- mặc định bàn gộp là bàn trống hoặc 2 bàn 1 2 nhập vào (12/3/2017)
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

--DBCC CHECKIDENT (@nameTable, RESEED, 0) -> reset id


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

CREATE PROC StoredProcedure_PhanTrangNhanVien
@page INT, @pageRows INT
AS
BEGIN
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
-- tạo 1 table tạm cách khác
	;WITH IdNV AS (SELECT idNhanVien AS [ID Nhân Viên], tenNhanVien AS [Tên Nhân Viên], ngaySinh AS [Ngày Sinh], gioiTinh AS [Giới Tính], chucVu AS [Chức Vụ]
	 FROM dbo.NhanVien
	 WHERE checkDelete = 0)
	
	SELECT TOP (@pageRows) * FROM IdNV WHERE IdNV.[ID Nhân Viên] NOT IN (SELECT TOP (@exceptRows) IdNV.[ID Nhân Viên] FROM IdNV)
END
GO

CREATE PROC StoredProcedure_layTongSoNhanVien
AS
BEGIN
	SELECT COUNT(*) FROM dbo.NhanVien WHERE checkDelete = 0
END
GO

CREATE PROC StoredProcedure_doiMatKhau
@userName VARCHAR(100), @passWord VARCHAR(1000), @newPassword VARCHAR(1000)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT(*) FROM	dbo.TaiKhoan WHERE userName = @userName AND pass = @passWord
	IF(@isRightPass = 1)
		UPDATE dbo.TaiKhoan SET pass = @newPassword WHERE userName = @userName 
END
GO




--------------- Demo Transaction ---------------
/*lost updated - mất dữ liệu đã cập nhật*/
CREATE PROC SP_waitUpdate
@chucVu NVARCHAR(100),@id INT
AS
BEGIN
	BEGIN TRAN
		UPDATE dbo.NhanVien SET chucVu = @chucVu WHERE idNhanVien = @id
		WAITFOR DELAY '00:00:05.000'
	COMMIT TRAN
END
GO

CREATE PROC SP_pokeUpdate
@chucVu NVARCHAR(100),@id INT
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	BEGIN TRAN
		UPDATE dbo.NhanVien SET chucVu = @chucVu WHERE idNhanVien = @id
	COMMIT TRAN
	END
GO
/*lost updated*/

/*du lieu rac*/
--reset hàm lại
CREATE PROC SP_waitInsertRollback
AS
BEGIN
	BEGIN TRAN
		INSERT dbo.NhanVien ( tenNhanVien ,ngaySinh ,gioiTinh ,chucVu ,queQuan ,email ,diaChi ,tel)
		VALUES  ( N'Nguyễn' , GETDATE() , N'Nữ' , N'Bảo Trì' , N'Hà Tĩnh' , 'asss@gmail.com' , N'dsadm' ,'51515')
		WAITFOR DELAY '00:00:05.000';
	ROLLBACK
END
GO

CREATE PROC SP_PhanTrangDEMOrac
@page INT, @pageRows INT
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; -- dùng cho demo problem doc du lieu rac 
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
-- tạo 1 table tạm cách khác
	;WITH IdNV AS (SELECT idNhanVien AS [ID Nhân Viên], tenNhanVien AS [Tên Nhân Viên], ngaySinh AS [Ngày Sinh], gioiTinh AS [Giới Tính], chucVu AS [Chức Vụ]
	 FROM dbo.NhanVien
	 WHERE checkDelete = 0)
	
	SELECT TOP (@pageRows) * FROM IdNV WHERE IdNV.[ID Nhân Viên] NOT IN (SELECT TOP (@exceptRows) IdNV.[ID Nhân Viên] FROM IdNV)
END
GO
/*du lieu rac*/

CREATE PROC SP_InsertBongMa
AS
BEGIN
	BEGIN TRAN
		INSERT dbo.NhanVien ( tenNhanVien ,ngaySinh ,gioiTinh ,chucVu ,queQuan ,email ,diaChi ,tel)
		VALUES  ( N'Nguyễn' , GETDATE() , N'Nữ' , N'Bảo Trì' , N'Hà Tĩnh' , 'asss@gmail.com' , N'dsadm' ,'51515');
	COMMIT TRAN
END
GO
-------------------------------------------------





CREATE PROC seachCateOrSanhOrThucAn
@id INT, @name NVARCHAR(100), @cateOrSanhOrFood INT
AS
BEGIN
	IF @cateOrSanhOrFood = 0
		SELECT * FROM dbo.DanhMuc WHERE ( idMenu = @id OR @id = 0 ) AND ( dbo.fChuyenCoDauThanhKhongDau(tenMenu) LIKE (N'%'+ dbo.fChuyenCoDauThanhKhongDau(@name) + N'%') OR @name = '') AND checkDelete = 0
	IF @cateOrSanhOrFood = 1 
		SELECT * FROM dbo.Sanh WHERE ( idSanh = @id OR @id = 0 ) AND ( dbo.fChuyenCoDauThanhKhongDau(tenSanh) LIKE (N'%'+ dbo.fChuyenCoDauThanhKhongDau(@name) + N'%') OR @name = '') AND checkDelete = 0
	IF @cateOrSanhOrFood = 2
		SELECT * FROM dbo.ThucAn WHERE (idThucAn = @id OR @id = 0) AND (dbo.fChuyenCoDauThanhKhongDau(tenThucAn) LIKE (N'%'+dbo.fChuyenCoDauThanhKhongDau(@name) +N'%') OR @name = '') AND ThucAn.checkDelete = 0
END
GO













-- trigger cho update sửa idHoaDon (12/3/2017)  -> xem kỹ test lại
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
          N'Quản Lý' , -- chucVu - nvarchar(100)
          N'TPHCM' , -- queQuan - nvarchar(100)
          'zxcvbnm8888@gmail.com' , -- email - varchar(100)
          N'839/11 Hậu Giang' , -- diaChi - nvarchar(100)
          '0123456789' 
        )

INSERT dbo.TaiKhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( N'denygame', -- userName - nvarchar(100)
          N'2ksadjhq1592cb962ac#->87@o{}9ksadjhq159leuleu#->87@o{}b964bksadjhq159leuleuute#->87@o{}2d234bleuleuksadjhq159qwsxaczdervhdsfuebfewpof5jgikngdHSsSFfdspofjsdoifuiegtfweg6514fds65f85sd1fffd65xf', -- pass - nvarchar(1000)
          1, -- idNhanVien - int
          2  -- loaiTK - int
          )
INSERT dbo.TaiKhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( N'huy96', -- userName - nvarchar(100)
          N'2ksadjhq1592cb962ac#->87@o{}9ksadjhq159leuleu#->87@o{}b964bksadjhq159leuleuute#->87@o{}2d234bleuleuksadjhq159qwsxaczdervhdsfuebfewpof5jgikngdHSsSFfdspofjsdoifuiegtfweg6514fds65f85sd1fffd65xf', -- pass - nvarchar(1000)
          1, -- idNhanVien - int
          1  -- loaiTK - int
          )
INSERT dbo.TaiKhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( N'aaaa', -- userName - nvarchar(100)
          N'2ksadjhq1592cb962ac#->87@o{}9ksadjhq159leuleu#->87@o{}b964bksadjhq159leuleuute#->87@o{}2d234bleuleuksadjhq159qwsxaczdervhdsfuebfewpof5jgikngdHSsSFfdspofjsdoifuiegtfweg6514fds65f85sd1fffd65xf', -- pass - nvarchar(1000)
          1, -- idNhanVien - int
          1  -- loaiTK - int
          )
INSERT dbo.DanhMuc
        ( tenMenu, checkDelete )
VALUES  ( N'Món Nướng', -- tenMenu - nvarchar(100)
          0  -- checkDelete - int
          )
INSERT dbo.DanhMuc
        ( tenMenu, checkDelete )
VALUES  ( N'Món Xào', -- tenMenu - nvarchar(100)
          0  -- checkDelete - int
          )
INSERT dbo.DanhMuc
        ( tenMenu, checkDelete )
VALUES  ( N'Hải Sản', -- tenMenu - nvarchar(100)
          0  -- checkDelete - int
          )
INSERT dbo.DanhMuc
        ( tenMenu, checkDelete )
VALUES  ( N'Nước Uống', -- tenMenu - nvarchar(100)
          0  -- checkDelete - int
          )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Gà Nướng' , -- tenThucAn - nvarchar(100)
          1 , -- idMenu - int
          100000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Tôm Nướng' , -- tenThucAn - nvarchar(100)
          1 , -- idMenu - int
          50000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Rau Muống Xào Tỏi' , -- tenThucAn - nvarchar(100)
          2 , -- idMenu - int
          30000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Mực Xào' , -- tenThucAn - nvarchar(100)
          2 , -- idMenu - int
          90000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Cá Hấp' , -- tenThucAn - nvarchar(100)
          3 , -- idMenu - int
          150000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Bào Ngư 7 Vị' , -- tenThucAn - nvarchar(100)
          3 , -- idMenu - int
          500000.0 , -- giaTien - float
          0  -- checkDelete - int
		  )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Ken' , -- tenThucAn - nvarchar(100)
          4 , -- idMenu - int
          21000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Tiger' , -- tenThucAn - nvarchar(100)
          4 , -- idMenu - int
          16000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Nước Suối' , -- tenThucAn - nvarchar(100)
          4 , -- idMenu - int
          10000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Trà Đá' , -- tenThucAn - nvarchar(100)
          4 , -- idMenu - int
          5000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.ThucAn
        ( tenThucAn ,
          idMenu ,
          giaTien ,
          checkDelete
        )
VALUES  ( N'Nước Ngọt Các Loại' , -- tenThucAn - nvarchar(100)
          4 , -- idMenu - int
          15000.0 , -- giaTien - float
          0  -- checkDelete - int
        )
INSERT dbo.Sanh
        ( tenSanh, checkDelete )
VALUES  ( N'Sảnh A', -- tenSanh - nvarchar(100)
          0  -- checkDelete - int
          )
INSERT dbo.Sanh
        ( tenSanh, checkDelete )
VALUES  ( N'Sảnh B', -- tenSanh - nvarchar(100)
          0  -- checkDelete - int
          )
DECLARE @i INT = 0
WHILE @i < 10
BEGIN
	INSERT dbo.BanAn
	        ( tenBan ,
	          idSanh ,
	          checkDelete
	        )
	VALUES  ( N'Bàn '+CAST((@i+1) AS NVARCHAR(100)) , -- tenBan - nvarchar(100)
	          1 , -- idSanh - int
	          0  -- checkDelete - int
	        )
	SET @i = @i + 1
END
DECLARE @j INT = 0
WHILE @j < 50
BEGIN
	INSERT dbo.BanAn
	        ( tenBan ,
	          idSanh ,
	          checkDelete
	        )
	VALUES  ( N'Bàn '+CAST((@j+1) AS NVARCHAR(100)) , -- tenBan - nvarchar(100)
	          2 , -- idSanh - int
	          0  -- checkDelete - int
	        )
	SET @j = @j + 1
END