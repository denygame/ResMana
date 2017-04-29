USE master
GO

CREATE DATABASE testTrans
GO

USE testTrans
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


-- bảng truyền vào idBanAn khi insert update Bill
--CREATE TABLE testLoadTableCsharp
--(
--	id INT NOT NULL
--)

--CREATE TABLE IPConnectionDatabase
--(
--	ip VARCHAR(100) NOT NULL
--)
--GO






--CREATE PROC StoredProcedure_InsertIP
--@ip VARCHAR(100)
--AS
--BEGIN
--	DECLARE @count INT = 0
--	SELECT @count = COUNT(*) FROM dbo.IPConnectionDatabase WHERE ip = @ip
--	IF(@count = 0)
--		INSERT dbo.IPConnectionDatabase ( ip ) VALUES  ( @ip )
--END
--GO

--CREATE PROC StoredProcedure_DeleteIP
--@ip VARCHAR(100)
--AS
--BEGIN
--	DELETE FROM dbo.IPConnectionDatabase  WHERE ip = @ip
--END
--GO

--DBCC CHECKIDENT (@nameTable, RESEED, 0) -> reset id

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












/*CREATE PROC SP_PhanTrangDEMOBongMa
@page INT, @pageRows INT
AS
BEGIN
	BEGIN TRAN
		/*DECLARE @exceptRows INT = (@page - 1) * @pageRows
		;WITH IdNV AS (SELECT idNhanVien AS [ID Nhân Viên], tenNhanVien AS [Tên Nhân Viên], ngaySinh AS [Ngày Sinh], gioiTinh AS [Giới Tính], chucVu AS [Chức Vụ] FROM dbo.NhanVien WHERE checkDelete = 0)
		SELECT TOP (@pageRows) * FROM IdNV WHERE IdNV.[ID Nhân Viên] NOT IN (SELECT TOP (@exceptRows) IdNV.[ID Nhân Viên] FROM IdNV)
		WAITFOR DELAY '00:00:02.000';
		;WITH IdNV AS (SELECT idNhanVien AS [ID Nhân Viên], tenNhanVien AS [Tên Nhân Viên], ngaySinh AS [Ngày Sinh], gioiTinh AS [Giới Tính], chucVu AS [Chức Vụ] FROM dbo.NhanVien WHERE checkDelete = 0)
		SELECT TOP (@pageRows) * FROM IdNV WHERE IdNV.[ID Nhân Viên] NOT IN (SELECT TOP (@exceptRows) IdNV.[ID Nhân Viên] FROM IdNV)*/
		SELECT * FROM dbo.NhanVien
		WAITFOR DELAY '00:00:10.000'
		SELECT * FROM dbo.NhanVien
	ROLLBACK
END
GO*/

CREATE PROC SP_InsertBongMa
AS
BEGIN
	BEGIN TRAN
		INSERT dbo.NhanVien ( tenNhanVien ,ngaySinh ,gioiTinh ,chucVu ,queQuan ,email ,diaChi ,tel)
		VALUES  ( N'Nguyễn' , GETDATE() , N'Nữ' , N'Bảo Trì' , N'Hà Tĩnh' , 'asss@gmail.com' , N'dsadm' ,'51515');
	COMMIT TRAN
END
GO



















--CREATE TRIGGER TG_delete_ip ON dbo.IPConnectionDatabase FOR DELETE
--AS
--BEGIN
--	 DECLARE @count INT = 0
--	 SELECT @count = COUNT(*) FROM dbo.IPConnectionDatabase
--	 IF(@count < 2)
--		DELETE FROM dbo.testLoadTableCsharp
--END
--GO







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