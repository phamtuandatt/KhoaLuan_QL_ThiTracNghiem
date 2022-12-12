﻿-- Create Database
create database QL_HETHONGTHITRACNGHIEM
go 
use QL_HETHONGTHITRACNGHIEM
--================================================================================
-- Create table
GO
CREATE TABLE KHOA
(
	MAKHOA CHAR(2) PRIMARY KEY CONSTRAINT PK_KHOA DEFAULT DBO.AUTO__MAKHOA(),
	TENKHOA NVARCHAR(100) NOT NULL,
	SOLUONGGIANGVIEN INT,
	SOLUONGMONHOC INT,
	SONGANHDAOTAO INT,
)

GO
CREATE TABLE LOPHOC
(
	MALOP CHAR(10) NOT NULL,
	TENLOP NVARCHAR(50),
	SISO INT,
	MAKHOA CHAR(2),

	CONSTRAINT PK_LOPHOC PRIMARY KEY (MALOP),
	CONSTRAINT FK_LOPHOC_KHOA FOREIGN KEY (MAKHOA) REFERENCES KHOA(MAKHOA),
)

GO
CREATE TABLE HOCPHAN
(
	MAHOCPHAN CHAR(10) NOT NULL,
	TENHOCPHAN NVARCHAR(100),
	SOTC INT,
	SOTIET_LT INT,
	SOTIET_TH INT,
	MAKHOA CHAR(2),

	CONSTRAINT PK_HOCPHAN PRIMARY KEY (MAHOCPHAN),
	CONSTRAINT FK_HOCPHAN_KHOA FOREIGN KEY (MAKHOA) REFERENCES KHOA(MAKHOA),
)

GO
CREATE TABLE SINHVIEN
(
	MASV CHAR(10) NOT NULL,
	MAKHAU CHAR(20),
	TENSV NVARCHAR(50),
	GIOITINH NVARCHAR(5),
	NGAYSINH DATE,
	EMAIL NVARCHAR(100),
	SDT CHAR(10),
	DIACHI NVARCHAR(100),
	QUEQUAN NVARCHAR(100),
	MALOP CHAR(10),
	HOCPHI NVARCHAR(10),

	CONSTRAINT PK_SINHVIEN PRIMARY KEY (MASV),
	CONSTRAINT FK_SINHVIEN_LOPHOC FOREIGN KEY (MALOP) REFERENCES LOPHOC(MALOP),
)

GO 
CREATE TABLE CT_HOCPHAN
(
	MALOPHOCPHAN CHAR(12) NOT NULL,
	MASV CHAR(10) NOT NULL,
	MAHOCPHAN CHAR(10) NOT NULL,
	MAGV CHAR(10),
	THU INT,
	TIET CHAR(10),
	PHONG CHAR(10),
	NGAYBD DATE,
	NGAYKT DATE,

	CONSTRAINT PK_CT_HOCPHAN PRIMARY KEY (MALOPHOCPHAN, MASV, MAHOCPHAN),
	CONSTRAINT FK_CT_HOCPHAN_SINHVIEN FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV),
	CONSTRAINT FK_CT_HOCPHAN_HOCPHAN FOREIGN KEY (MAHOCPHAN) REFERENCES HOCPHAN(MAHOCPHAN),
)

GO 
CREATE TABLE CHUCVU
(
	MACHUCVU INT NOT NULL IDENTITY(1,1),
	TENCHUCVU NVARCHAR(100),

	CONSTRAINT PK_CHUCVU PRIMARY KEY (MACHUCVU),
)

GO
CREATE TABLE GIANGVIEN
(
	MAGV CHAR(10) NOT NULL,
	MATKHAU CHAR(20),
	TENGV NVARCHAR(50),
	NGAYSINH DATE,
	GIOITINH NVARCHAR(5),
	QUEQUAN NVARCHAR(20),
	HOCVI NVARCHAR(50),
	SDT CHAR(10),
	EMAIL NVARCHAR(100),
	DIACHI NVARCHAR(100),
	AVATA IMAGE,
	MAKHOA CHAR(2),
	MACHUCVU INT,

	CONSTRAINT PK_GIANGVIEN PRIMARY KEY (MAGV),
	CONSTRAINT FK_GIANGVIEN_KHOA FOREIGN KEY (MAKHOA) REFERENCES KHOA(MAKHOA),
	CONSTRAINT FK_GIANGVIEN_CHUCVU FOREIGN KEY (MACHUCVU) REFERENCES CHUCVU(MACHUCVU),
)

GO
CREATE TABLE CT_GIANGDAY
(
	MAHOCPHAN CHAR(10) NOT NULL,
	MAGV CHAR(10) NOT NULL,

	CONSTRAINT PK_CT_GIANGDAY PRIMARY KEY (MAHOCPHAN, MAGV),
	CONSTRAINT FK_CT_GIANGDAY_HOCPHAN FOREIGN KEY (MAHOCPHAN) REFERENCES HOCPHAN(MAHOCPHAN),
	CONSTRAINT FK_CT_GIANGDAY_GIANGVIEN FOREIGN KEY (MAGV) REFERENCES GIANGVIEN(MAGV),
)

GO
CREATE TABLE NGANHANGCAUHOI
(
	MANGANHANG INT IDENTITY(1,1) NOT NULL,
	SLCAUHOI INT,
	NGAYTAO DATE,
	NGAYCAPNHAT DATE,

	CONSTRAINT PK_NGANHANGCAUHOI PRIMARY KEY (MANGANHANG),
)

GO
CREATE TABLE CT_NGANHANGCAUHOI
(
	MANGANHANG INT NOT NULL,
	MAGV CHAR(10) NOT NULL,
	MAHOCPHAN CHAR(10) NOT NULL,

	CONSTRAINT PK_CT_NGANHANGCAUHOI PRIMARY KEY (MANGANHANG, MAGV, MAHOCPHAN),
	CONSTRAINT FK_NGANHANGCAUHOI_NGANHANGCAUHOI FOREIGN KEY (MANGANHANG) REFERENCES NGANHANGCAUHOI(MANGANHANG),
	CONSTRAINT FK_NGANHANGCAUHOI_GIANGVIEN FOREIGN KEY (MAGV) REFERENCES GIANGVIEN(MAGV),
	CONSTRAINT FK_NGANHANGCAUHOI_HOCPHAN FOREIGN KEY (MAHOCPHAN) REFERENCES HOCPHAN(MAHOCPHAN),
)

GO
CREATE TABLE CAUHOI
(
	MACAUHOI INT NOT NULL IDENTITY(1,1),
	NOIDUNG NVARCHAR(MAX),
	DAPAN1 NVARCHAR(MAX),
	DAPAN2 NVARCHAR(MAX),
	DAPAN3 NVARCHAR(MAX),
	DAPAN4 NVARCHAR(MAX),
	DAPANDUNG CHAR(5),
	NGAYTAO DATE,
	NGAYCAPNHAT DATE,
	MANGANHANG INT,
	MAHOCPHAN CHAR(10)

	CONSTRAINT PK_CAUHOI PRIMARY KEY (MACAUHOI),
	CONSTRAINT FK_CAUHOI_NGANHANGCAUHOI FOREIGN KEY (MANGANHANG) REFERENCES NGANHANGCAUHOI(MANGANHANG),
	CONSTRAINT FK_CAUHOI_MAHOCPHAN FOREIGN KEY (MAHOCPHAN) REFERENCES HOCPHAN(MAHOCPHAN),
)

GO
CREATE TABLE DETHI
(
	MADETHI INT IDENTITY(1, 1),
	MAHOCPHAN CHAR(10),
	NGAYTAO DATE,
	TGLAMBAI INT,
	SLCAUHOI INT,
	TINHTRANG BIT,

	CONSTRAINT PK_DETHI PRIMARY KEY (MADETHI),
	CONSTRAINT FK_DETHI_HOCPHAN FOREIGN KEY (MAHOCPHAN) REFERENCES HOCPHAN(MAHOCPHAN),
)

GO 
CREATE TABLE CT_DETHI
(
	STT INT IDENTITY(1, 1),
	MADETHI INT,
	MADECON CHAR(10),
	MACAUHOI INT,

	CONSTRAINT PK_CT_DETHI PRIMARY KEY (STT),
	CONSTRAINT FK_CT_DETHI_DETHI FOREIGN KEY (MADETHI) REFERENCES DETHI(MADETHI),
	CONSTRAINT FK_CT_DETHI_CAUHOI FOREIGN KEY (MACAUHOI) REFERENCES CAUHOI(MACAUHOI),
)

GO
CREATE TABLE NGANHANGCAUHOI_DADUYET
(
	MANH CHAR(10) NOT NULL,
	MAHOCPHAN CHAR(10) NOT NULL,
	MACAUHOI INT NOT NULL,

	CONSTRAINT PK_NGANHANGCAUHOI_DADUYET PRIMARY KEY (MANH, MAHOCPHAN, MACAUHOI),
	CONSTRAINT FK_NGANHANGCAUHOI_DADUYET_HOCPHAN FOREIGN KEY (MAHOCPHAN) REFERENCES HOCPHAN(MAHOCPHAN),
	CONSTRAINT FK_NGANHANGCAUHOI_DADUYET_CAUHOI FOREIGN KEY (MACAUHOI) REFERENCES CAUHOI(MACAUHOI),
)

GO
CREATE TABLE CATHI
(
	MACATHI INT IDENTITY(1,1) NOT NULL,
	MAHOCPHAN CHAR(10),
	MADETHI INT,
	MADECON NVARCHAR(10),
	NGAYTHI DATE,
	PHONGTHI NVARCHAR(20),
	GIOLAMBAI NVARCHAR(10),
	TINHTRANG BIT,
	TINHTRANGTHI BIT,

	CONSTRAINT PK_CATHI PRIMARY KEY (MACATHI),
	CONSTRAINT FK_CATHI_HOCPHAN FOREIGN KEY (MAHOCPHAN) REFERENCES HOCPHAN(MAHOCPHAN),
	CONSTRAINT FK_CATHI_DETHI FOREIGN KEY (MADETHI) REFERENCES DETHI(MADETHI),
)

GO
CREATE TABLE CT_CATHI
(
	MACATHI INT NOT NULL,
	MASV CHAR(10) NOT NULL,
	TENSV NVARCHAR(MAX),

	CONSTRAINT PK_CT_CATHI PRIMARY KEY (MACATHI, MASV),
	CONSTRAINT FK_CT_CATHI_CATHI FOREIGN KEY (MACATHI) REFERENCES CATHI(MACATHI),
	CONSTRAINT FK_CT_CATHI_SINHVIEN FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV),
)

GO
CREATE TABLE BAITHI
(
	MABAITHI INT IDENTITY(1,1) NOT NULL,
	GIONOPBAI NVARCHAR(50),
	DIEM INT,
	MASV CHAR(10),
	TINHTRANG NVARCHAR(20), -- ĐANG LÀM - ĐÃ NỘP
	MACATHI INT,

	CONSTRAINT PK_BAITHI PRIMARY KEY (MABAITHI),
	--CONSTRAINT FK_BAITHI_SINHVIEN FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV),
	--CONSTRAINT FK_BAITHI_CATHI FOREIGN KEY (MACATHI) REFERENCES CATHI(MACATHI),
)

GO
CREATE TABLE CT_BAITHI
(
	MABAITHI INT NOT NULL,
	MACAUHOI INT NOT NULL,
	CAUTRALOI CHAR(5),

	CONSTRAINT PK_CT_BAITHI PRIMARY KEY (MABAITHI, MACAUHOI),
	--CONSTRAINT FK_CT_BAITHI_BAITHI FOREIGN KEY (MABAITHI) REFERENCES BAITHI(MABAITHI),
	--CONSTRAINT FK_CT_BAITHI_CAUHOI FOREIGN KEY (MACAUHOI) REFERENCES CAUHOI(MACAUHOI),
)

-- ===================================================================================================

-- ===================================================================================================
-- TRIGGER UPDATE QUANTITY QUESTION IN NGANHANGCAUHOI WHEN INSERT QUESTION 
GO
CREATE TRIGGER UPDATE_QUANTITY_INSERT ON CAUHOI
AFTER INSERT
AS 
BEGIN
	UPDATE NGANHANGCAUHOI
	SET SLCAUHOI = 0
	WHERE MANGANHANG = (SELECT MANGANHANG FROM inserted)
END
GO

INSERT INTO CAUHOI(NOIDUNG, DAPAN1, DAPAN2, DAPAN3, DAPAN4, DAPANDUNG, MANGANHANG) 
VALUES (N'...', N'...', N'...', N'...', N'...', N'...', 1)

SELECT *FROM NGANHANGCAUHOI
-- ===================================================================================================

-- ===================================================================================================

-- CREATE FUNCTION GENERATE MAKHOA
GO
CREATE FUNCTION AUTO__MAKHOA()
RETURNS VARCHAR(2)
AS
BEGIN
	DECLARE @MAKHOA VARCHAR(2)
	IF (SELECT COUNT(MAKHOA) FROM KHOA) = 0
		SET @MAKHOA = '0'
	ELSE
		SELECT @MAKHOA = MAX(RIGHT(MAKHOA, 2)) FROM KHOA
		SELECT @MAKHOA = CASE 
			WHEN @MAKHOA >= 0 AND @MAKHOA < 9 THEN '0' + CONVERT(CHAR, CONVERT(INT, @MAKHOA) + 1)
			WHEN @MAKHOA >= 9 THEN '' + CONVERT(CHAR, CONVERT(INT, @MAKHOA) + 1)
		END
	RETURN @MAKHOA
END
GO

-- CREATE FUNCTION GENERATE STT GIANGVIEN -> ADD PRAMETER
GO
CREATE FUNCTION AUTO_MAGV(@DAU CHAR(3), @MAKHOA CHAR(2))
RETURNS CHAR(8)
AS
BEGIN
	DECLARE @MAGV VARCHAR(8)
	IF (SELECT COUNT(MAGV) FROM GIANGVIEN) = 0
		SET @MAGV = '0'
	ELSE
		SELECT @MAGV = MAX(RIGHT(RTRIM(MAGV), 3)) FROM GIANGVIEN
		SELECT @MAGV = CASE 
			WHEN @MAGV >= 0 AND @MAGV < 9 THEN @DAU + @MAKHOA + '00' + CONVERT(CHAR, CONVERT(INT, @MAGV) + 1)
			WHEN @MAGV >= 9 AND @MAGV < 99 THEN @DAU + @MAKHOA +  '0' + CONVERT(CHAR, CONVERT(INT, @MAGV) + 1)
			WHEN @MAGV >= 99 THEN @DAU + @MAKHOA +  '' + CONVERT(CHAR, CONVERT(INT, @MAGV) + 1)
		END
	RETURN @MAGV
END
GO
SELECT DBO.AUTO_MAGV('010', '01')

-- CREATA FUNCTION GENERATE MASV -> ADD PARAMETER
GO
CREATE FUNCTION AUTO_STT_MASV(@DAIHOC CHAR(2), @MAKHOA CHAR(2), @NAMNHAPHOC CHAR(2))
RETURNS CHAR(10)
AS
BEGIN
	DECLARE @MASV CHAR(10)
	IF (SELECT COUNT(MASV) FROM SINHVIEN) = 0
		SET @MASV = '0'
	ELSE
		SELECT @MASV = MAX(RIGHT(RTRIM(MASV), 4)) FROM SINHVIEN
		SELECT @MASV = CASE 
			WHEN @MASV >= 0 AND @MASV < 9 THEN @DAIHOC + @MAKHOA + @NAMNHAPHOC + '000' + CONVERT(CHAR, CONVERT(INT, @MASV) + 1)
			WHEN @MASV >= 9 AND @MASV < 99 THEN @DAIHOC + @MAKHOA + @NAMNHAPHOC + '00' + CONVERT(CHAR, CONVERT(INT, @MASV) + 1)
			WHEN @MASV >= 99 AND @MASV < 999 THEN @DAIHOC + @MAKHOA + @NAMNHAPHOC + '0' + CONVERT(CHAR, CONVERT(INT, @MASV) + 1)
			WHEN @MASV >= 999 THEN @DAIHOC + @MAKHOA + @NAMNHAPHOC + '' + CONVERT(CHAR, CONVERT(INT, @MASV) + 1)
		END
	RETURN @MASV
END
GO
SELECT DBO.AUTO_STT_MASV('20', '01', '19')

-- CREATE FUNCTION GERERATE MAHOCPHAN 
GO
CREATE FUNCTION AUTO_MAHOCPHAN()
RETURNS CHAR(10)
AS
BEGIN
	DECLARE @MAHOCPHAN CHAR(10)
	IF (SELECT COUNT(MAHOCPHAN) FROM HOCPHAN) = 0
		SET @MAHOCPHAN = '0'
	ELSE
		SELECT @MAHOCPHAN = MAX(RIGHT(RTRIM(MAHOCPHAN), 5)) FROM HOCPHAN
		SELECT @MAHOCPHAN = CASE 
			WHEN @MAHOCPHAN >= 0 AND @MAHOCPHAN < 9 THEN '010100000' + CONVERT(CHAR, CONVERT(INT, @MAHOCPHAN) + 1)
			WHEN @MAHOCPHAN >= 9 AND @MAHOCPHAN < 99 THEN '01010000' + CONVERT(CHAR, CONVERT(INT, @MAHOCPHAN) + 1)
			WHEN @MAHOCPHAN >= 99 AND @MAHOCPHAN < 999 THEN '0101000' + CONVERT(CHAR, CONVERT(INT, @MAHOCPHAN) + 1)
			WHEN @MAHOCPHAN >= 999 AND @MAHOCPHAN < 9999 THEN '010100' + CONVERT(CHAR, CONVERT(INT, @MAHOCPHAN) + 1)
			WHEN @MAHOCPHAN >= 9999 AND @MAHOCPHAN < 99999 THEN '01010' + CONVERT(CHAR, CONVERT(INT, @MAHOCPHAN) + 1)
		END
	RETURN @MAHOCPHAN
END
GO
SELECT DBO.AUTO_MAHOCPHAN()

-- CREATE FUNCTION GERERATE MALOPHOCPHAN -> ADD PARAMETER @MAHOCPHAN
GO
CREATE FUNCTION AUTO_MALOPHOCPHAN(@MAHOCPHAN CHAR(10))
RETURNS CHAR(12)
AS
BEGIN
	DECLARE @MALOPHOCPHAN CHAR(12)
	IF (SELECT COUNT(MALOPHOCPHAN) FROM CT_HOCPHAN) = 0
		SET @MALOPHOCPHAN = '0'
	ELSE
		SELECT @MALOPHOCPHAN = MAX(RIGHT(RTRIM(MALOPHOCPHAN), 2)) FROM CT_HOCPHAN
		SELECT @MALOPHOCPHAN = CASE 
			WHEN @MALOPHOCPHAN >= 0 AND @MALOPHOCPHAN < 9 THEN @MAHOCPHAN + '0' + CONVERT(CHAR, CONVERT(INT, @MALOPHOCPHAN) + 1)
			WHEN @MALOPHOCPHAN >= 9 THEN @MAHOCPHAN + '' + CONVERT(CHAR, CONVERT(INT, @MALOPHOCPHAN) + 1)
		END
	RETURN @MALOPHOCPHAN
END
GO
SELECT DBO.AUTO_MALOPHOCPHAN('0101000958')



-- ===================================================================================================

-- ===================================================================================================
-- INSERT VALUES ----- CHUCVU
SELECT *FROM CHUCVU
INSERT INTO CHUCVU(TENCHUCVU) VALUES (N'TRƯỞNG KHOA')
INSERT INTO CHUCVU(TENCHUCVU) VALUES (N'NHÂN VIÊN PHÒNG KHẢO THÍ')
INSERT INTO CHUCVU(TENCHUCVU) VALUES (N'NHÂN VIÊN PHÒNG ĐÀO TẠO')
INSERT INTO CHUCVU(TENCHUCVU) VALUES (N'GIẢNG VIÊN BỘ MÔN')

-- INSERT VALEUS ----- KHOA
SELECT *FROM KHOA
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA CÔNG NGHỆ THÔNG TIN')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA CÔNG NGHỆ ĐIỆN - ĐIỆN TỬ')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA TÀI CHÍNH KẾ TOÁN')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA CÔNG NGHỆ CƠ KHÍ')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA CHÍNH TRỊ - LUẬT')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA CÔNG NGHỆ SINH HỌC')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA DU LỊCH VÀ ẨM THỰC')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA QUẢN TRỊ KINH DOANH')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA GIÁO DỤC THỂ CHẤT VÀ QUỐC PHÒNG AN NINH')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA NGOẠI NGỮ')
INSERT INTO KHOA(TENKHOA) VALUES (N'CÔNG NGHỆ MAY VÀ THỜI TRANG')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA CÔNG NGHỆ HÓA HỌC')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA KHOA HỌC ỨNG DỤNG')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA THỦY SẢN')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA SINH HỌC VÀ MÔI TRƯỜNG')
INSERT INTO KHOA(TENKHOA) VALUES (N'KHOA CÔNG NGHỆ THỰC PHẨM')

-- INSERT VALUES ----- GIANGVIEN
SELECT *FROM GIANGVIEN
SET DATEFORMAT DMY INSERT INTO GIANGVIEN
VALUES ((SELECT DBO.AUTO_MAGV('010', '01')), '000000000', N'LÂM THỊ HỌA MI', '10/10/1985', N'NỮ', N'**', N'THẠC SĨ', '0654321987', N'milth@hufi.edu.vn', N'......', '01', '1')
SET DATEFORMAT DMY INSERT INTO GIANGVIEN
VALUES ((SELECT DBO.AUTO_MAGV('010', '01')), '000000000', N'NGUYỄN THỊ ĐỊNH', '10/10/1985', N'NỮ', N'**', N'THẠC SĨ', '0654321987', N'dinhnt@hufi.edu.vn', N'......', '01', '4')

-- INSERT VALUES ----- LOPHOC
SELECT *FROM LOPHOC
INSERT INTO LOPHOC VALUES ('10DHTH5', N'10 ĐẠI HỌC TIN HỌC 5', '', '01')
INSERT INTO LOPHOC VALUES ('10DHTH2', N'10 ĐẠI HỌC TIN HỌC 2', '', '01')
INSERT INTO LOPHOC VALUES ('10DHTH3', N'10 ĐẠI HỌC TIN HỌC 3', '', '01')
INSERT INTO LOPHOC VALUES ('10DHTH1', N'10 ĐẠI HỌC TIN HỌC 1', '', '01')

-- INSERT VALUES ----- HOCPHAN
SELECT *FROM HOCPHAN
INSERT INTO HOCPHAN VALUES ((SELECT DBO.AUTO_MAHOCPHAN()), N'CẤU TRÚC DỮ LIỆU & GIẢI THUẬT', 3, 45, 30, '01')
INSERT INTO HOCPHAN VALUES ((SELECT DBO.AUTO_MAHOCPHAN()), N'CƠ SỞ DỮ LIỆU', 3, 45, 30, '01')
INSERT INTO HOCPHAN VALUES ((SELECT DBO.AUTO_MAHOCPHAN()), N'ĐẠI SỐ TUYẾN TÍNH', 3, 45, 30, '01')
INSERT INTO HOCPHAN VALUES ((SELECT DBO.AUTO_MAHOCPHAN()), N'CÔNG NGHỆ .NET', 3, 45, 30, '01')
INSERT INTO HOCPHAN VALUES ((SELECT DBO.AUTO_MAHOCPHAN()), N'NO.SQL', 3, 45, 30, '01')

-- INSERT VALUES ----- SINHVIEN
SELECT *FROM SINHVIEN
SET DATEFORMAT DMY INSERT INTO SINHVIEN 
VALUES ((SELECT DBO.AUTO_STT_MASV('20', '01', '19')), '0000000000', N'PHẠM TUẤN ĐẠT', N'NAM', '16/07/2001', N'dat16072001@gmail.com', '0654321987', N'...', N'...', '10DHTH5')
SET DATEFORMAT DMY INSERT INTO SINHVIEN 
VALUES ((SELECT DBO.AUTO_STT_MASV('20', '01', '19')), '0000000000', N'NGUYỄN VĂN MĂNG', N'NỮ', '16/07/2001', N'...', '...', N'...', N'...', '10DHTH2')

-- INSERT VALUES ----- CT_HOCPHAN
-- KHI INSERT INTO -> GỌI FUNCTION ĐỂ TẠO MÃ HỌC PHẦN
SELECT *FROM CT_HOCPHAN
SET DATEFORMAT DMY INSERT INTO CT_HOCPHAN 
VALUES ((SELECT DBO.AUTO_MALOPHOCPHAN('0101000004')), '2001190001', '0101000004', '01001001', 2, '1-3', N'A101', '15/11/2022', '15/02/2023')
SET DATEFORMAT DMY INSERT INTO CT_HOCPHAN 
VALUES ((SELECT DBO.AUTO_MALOPHOCPHAN('0101000004')), '2001190001', '0101000004', '01001001', 2, '1-3', N'A102', '15/11/2022', '15/02/2023')

-- INSERT VALUES ----- CT_GIANGDAY
SELECT *FROM CT_GIANGDAY
INSERT INTO CT_GIANGDAY VALUES ('0101000004', '01001001')
INSERT INTO CT_GIANGDAY VALUES ('0101000001', '01001001')
INSERT INTO CT_GIANGDAY VALUES ('0101000002', '01001001')
INSERT INTO CT_GIANGDAY VALUES ('0101000003', '01001001')
INSERT INTO CT_GIANGDAY VALUES ('0101000005', '01001001')
INSERT INTO CT_GIANGDAY VALUES ('0101000004', '01001002')

-- INSERT VALUES ----- NGANHANGCAUHOI
SELECT *FROM NGANHANGCAUHOI
SET DATEFORMAT DMY 
INSERT INTO NGANHANGCAUHOI(NGAYTAO, NGAYCAPNHAT) VALUES ('11/07/2022', '25/07/2022')
SET DATEFORMAT DMY 
INSERT INTO NGANHANGCAUHOI(NGAYTAO, NGAYCAPNHAT) VALUES ('11/07/2022', '25/07/2022')

-- INSERT VALUES ----- CT_NGANHANGCAUHOI
SELECT *FROM CT_NGANHANGCAUHOI
INSERT INTO CT_NGANHANGCAUHOI VALUES (1, '01001001', '0101000004')
INSERT INTO CT_NGANHANGCAUHOI VALUES (1, '01001001', '0101000001')
INSERT INTO CT_NGANHANGCAUHOI VALUES (1, '01001001', '0101000002')
INSERT INTO CT_NGANHANGCAUHOI VALUES (2, '01001002', '0101000002')
INSERT INTO CT_NGANHANGCAUHOI VALUES (2, '01001002', '0101000004')

-- INSERT VALUES ----- CAUHOI
SELECT *FROM CAUHOI
INSERT INTO CAUHOI(NOIDUNG, DAPAN1, DAPAN2, DAPAN3, DAPAN4, DAPANDUNG, MANGANHANG) 
VALUES (N'...', N'...', N'...', N'...', N'...', N'...', 1)

-- INSERT VALUES ----- DETHI
SELECT *FROM DETHI
SET DATEFORMAT DMY INSERT INTO DETHI
VALUES (1, '0101000004', '11/07/2022', 60, 45, 0)
SET DATEFORMAT DMY INSERT INTO DETHI
VALUES (2, '0101000004', '11/07/2022', 60, 45, 0)

-- INSERT VALUES ----- CT_DETHI
SELECT *FROM CT_DETHI
INSERT INTO CT_DETHI VALUES (1, 1, '0101000004')
INSERT INTO CT_DETHI VALUES (1, 2, '0101000004')
INSERT INTO CT_DETHI VALUES (1, 3, '0101000004')

-- INSERT VALUES ----- NGANHANGCAUHOI_DADUYET
SELECT *FROM NGANHANGCAUHOI_DADUYET
INSERT INTO NGANHANGCAUHOI_DADUYET VALUES ('0101000004', 1)
INSERT INTO NGANHANGCAUHOI_DADUYET VALUES ('0101000004', 2)
INSERT INTO NGANHANGCAUHOI_DADUYET VALUES ('0101000004', 3)

-- INSERT VALUES ----- CATHI
SELECT *FROM CATHI
SET DATEFORMAT DMY INSERT INTO CATHI(MAHOCPHAN, MADETHI, NGAYTHI, GIOLAMBAI, TINHTRANG)
VALUES ('0101000004', 1, '11/07/2022', '9:30', 0)
SET DATEFORMAT DMY INSERT INTO CATHI(MAHOCPHAN, MADETHI, NGAYTHI, GIOLAMBAI, TINHTRANG)
VALUES ('0101000004', 2, '11/07/2022', '9:30', 0)

-- INSERT VALUES ----- CT_CATHI
SELECT *FROM CT_CATHI
INSERT INTO CT_CATHI VALUES (1, '2001190001')
INSERT INTO CT_CATHI VALUES (1, '2001190002')

-- INSERT VALUES ----- BAITHI
SELECT *FROM BAITHI
INSERT INTO BAITHI(GIONOPBAI, DIEM, MASV, MABAITHI) 
VALUES ('10:30', 10, '2001190001', 1)
INSERT INTO BAITHI(GIONOPBAI, DIEM, MASV, MABAITHI) 
VALUES ('10:25', 9.5, '2001190002', 1)

-- INSERT VALUES ----- CT_BAITHI
SELECT *FROM CT_BAITHI
INSERT INTO CT_BAITHI VALUES (1, 1, 'A')
INSERT INTO CT_BAITHI VALUES (1, 2, 'B')
INSERT INTO CT_BAITHI VALUES (1, 3, 'B')


-- ===================================================================================================

-- ===================================================================================================
-- CREATE PROC GET_CT_NGANHANGCAUHOI
GO
CREATE PROC GET_CT_NGANHANGCAUHOI @MANGANHANG INT
AS
BEGIN
	SELECT NGANHANGCAUHOI.MANGANHANG, TENHOCPHAN, SLCAUHOI, NGAYTAO, NGAYCAPNHAT, CT_NGANHANGCAUHOI.MAHOCPHAN 
	FROM NGANHANGCAUHOI, CT_NGANHANGCAUHOI, HOCPHAN
	WHERE NGANHANGCAUHOI.MANGANHANG = CT_NGANHANGCAUHOI.MANGANHANG
		AND CT_NGANHANGCAUHOI.MAHOCPHAN = HOCPHAN.MAHOCPHAN
		AND NGANHANGCAUHOI.MANGANHANG = @MANGANHANG
END
GO
EXEC GET_CT_NGANHANGCAUHOI 2

-- CREATE PROC GET_DS_CAUHOI_NGANHANG
GO
CREATE PROC GET_DS_CAUHOI_NGANHANG @MANGANHANG INT, @MAHOCPHAN CHAR(10)
AS
BEGIN
	SELECT MACAUHOI, NOIDUNG, DAPAN1, DAPAN2, DAPAN3, DAPAN4, DAPANDUNG, NGAYTAO, NGAYCAPNHAT
	FROM CAUHOI WHERE MANGANHANG = @MANGANHANG AND MAHOCPHAN = @MAHOCPHAN 
					AND MACAUHOI NOT IN (SELECT MACAUHOI FROM NGANHANGCAUHOI_DADUYET WHERE MANH = @MANGANHANG AND MAHOCPHAN = @MAHOCPHAN)
END
GO
EXEC GET_DS_CAUHOI_NGANHANG 1, '0101000005'

-- CREATE PROC GET_DS_MONHOC_NGANHANG
GO
CREATE PROC GET_DS_HOCPHAN_NGANHANG @MANGANHANG INT, @MAGV CHAR(10)
AS
BEGIN
	SELECT HOCPHAN.MAHOCPHAN, TENHOCPHAN FROM CT_GIANGDAY, HOCPHAN 
	WHERE CT_GIANGDAY.MAHOCPHAN = HOCPHAN.MAHOCPHAN
		AND MAGV = @MAGV
		AND CT_GIANGDAY.MAHOCPHAN NOT IN (SELECT MAHOCPHAN FROM CT_NGANHANGCAUHOI WHERE MANGANHANG = @MANGANHANG)
END
GO
EXEC GET_DS_HOCPHAN_NGANHANG 1, '01001001'
	
-- CREATE PROC GET_DS_MONHOC_GIANGVIEN
GO
CREATE PROC GET_DS_HOCPHAN_GIANGVIEN @MAGV CHAR(10)
AS
BEGIN
	SELECT CT_GIANGDAY.MAHOCPHAN, TENHOCPHAN FROM CT_GIANGDAY, HOCPHAN
	WHERE CT_GIANGDAY.MAHOCPHAN = HOCPHAN.MAHOCPHAN AND MAGV = @MAGV
END
GO
EXEC GET_DS_HOCPHAN_GIANGVIEN '01001001'

-- CREATE PROC GET_DS_NGANHANGCAUHOI_GIANGVIEN
GO
CREATE PROC GET_DS_NGANHANGCAUHOI_GIANGVIEN 
AS
BEGIN
	SELECT CT_NGANHANGCAUHOI.MAGV, TENGV, COUNT(*) AS SOLUONGMON, NGAYCAPNHAT, NGANHANGCAUHOI.MANGANHANG 
	FROM GIANGVIEN, NGANHANGCAUHOI, CT_NGANHANGCAUHOI
	WHERE GIANGVIEN.MAGV = CT_NGANHANGCAUHOI.MAGV
		AND NGANHANGCAUHOI.MANGANHANG = CT_NGANHANGCAUHOI.MANGANHANG
	GROUP BY CT_NGANHANGCAUHOI.MAGV, TENGV, NGAYCAPNHAT, NGANHANGCAUHOI.MANGANHANG
END
GO
EXEC GET_DS_NGANHANGCAUHOI_GIANGVIEN

-- CREATE PROC GET_DS_CAUHOI_DADUYET
GO
CREATE PROC GET_DS_CAUHOI_DADUYET
AS
BEGIN
	SELECT NGANHANGCAUHOI_DADUYET.MANH, NGANHANGCAUHOI_DADUYET.MAHOCPHAN,
			NGANHANGCAUHOI_DADUYET.MACAUHOI, NOIDUNG, DAPAN1, DAPAN2, DAPAN3, DAPAN4, DAPANDUNG
	FROM NGANHANGCAUHOI_DADUYET, CAUHOI 
	WHERE NGANHANGCAUHOI_DADUYET.MACAUHOI = CAUHOI.MACAUHOI
END
GO
EXEC GET_DS_CAUHOI_DADUYET

-- CREATE PROC GET_DS_DETHI
GO
CREATE PROC GET_DS_DETHI @MAHOCPHAN CHAR(10)
AS
BEGIN
	SELECT MADETHI, DETHI.MAHOCPHAN, TENHOCPHAN, NGAYTAO, TGLAMBAI, SLCAUHOI, TINHTRANG
	FROM DETHI, HOCPHAN
	WHERE DETHI.MAHOCPHAN = HOCPHAN.MAHOCPHAN
		AND DETHI.MAHOCPHAN = @MAHOCPHAN
END
GO
EXEC GET_DS_DETHI '0101000004'

-- CREATE PROC GET_DS_DETHI_DETHICON
GO
CREATE PROC GET_DS_DETHI_DETHICON @MAHOCPHAN CHAR(10), @MADETHI INT
AS
BEGIN
	SELECT DISTINCT(DETHI.MADETHI), (MADECON), DETHI.MAHOCPHAN, TENHOCPHAN, NGAYTAO, TGLAMBAI, SLCAUHOI, TINHTRANG
	FROM DETHI, CT_DETHI, HOCPHAN
	WHERE DETHI.MADETHI = CT_DETHI.MADETHI AND DETHI.MAHOCPHAN = HOCPHAN.MAHOCPHAN
		AND DETHI.MAHOCPHAN = @MAHOCPHAN AND DETHI.MADETHI = @MADETHI
END
GO
EXEC GET_DS_DETHI_DETHICON '0101000001', 1

-- CREATE PROC GET_DS_DETHI
GO
CREATE PROC GET_DS_DETHIS
AS
BEGIN
	SELECT MADETHI, DETHI.MAHOCPHAN, TENHOCPHAN, NGAYTAO, TGLAMBAI, SLCAUHOI, TINHTRANG
	FROM DETHI, HOCPHAN
	WHERE DETHI.MAHOCPHAN = HOCPHAN.MAHOCPHAN
END
GO
EXEC GET_DS_DETHIS

-- CREATE PROC GET_DS_DETHI_CAUHOI
GO
CREATE PROC GET_DS_DETHI_CAUHOI @MADETHI INT, @MADECON CHAR(10)
AS
BEGIN
	SELECT MADETHI, CT_DETHI.MACAUHOI, NOIDUNG, DAPAN1, DAPAN2, DAPAN3, DAPAN4, DAPANDUNG
	FROM CT_DETHI, CAUHOI
	WHERE CT_DETHI.MACAUHOI = CAUHOI.MACAUHOI
		AND MADETHI = @MADETHI AND MADECON = @MADECON
END
GO
EXEC GET_DS_DETHI_CAUHOI 3, '01'
EXEC GET_DS_DETHI_CAUHOI 3, '02'

-- CREATE PROC GET_DS_SV_HOCPHAN
-- LẤY SINH VIÊN CÓ THAM GIA LỚP HỌC PHẦN MÀ CHƯA THAM GIA THI
GO
CREATE PROC GET_DS_SV_LOPHOCPHAN @MAHOCPHAN CHAR(10)
AS
BEGIN
SELECT DISTINCT(CT_HOCPHAN.MASV), TENSV, GIOITINH, NGAYSINH, EMAIL, SDT, DIACHI, QUEQUAN, MALOP, HOCPHI
	FROM CT_HOCPHAN, SINHVIEN
	WHERE CT_HOCPHAN.MASV = SINHVIEN.MASV
		AND MAHOCPHAN = @MAHOCPHAN AND CT_HOCPHAN.MASV NOT IN (SELECT DISTINCT(MASV) FROM CATHI, CT_CATHI 
														WHERE CATHI.MACATHI = CT_CATHI.MACATHI
														AND MAHOCPHAN = @MAHOCPHAN)
END
GO
EXEC GET_DS_SV_LOPHOCPHAN '0101000004'


SET DATEFORMAT DMY INSERT INTO CT_HOCPHAN 
VALUES ((SELECT DBO.AUTO_MALOPHOCPHAN('0101000004')), '2001190001', '0101000004', '01001001', 2, '1-3', N'A102', '15/11/2022', '15/02/2023')

SELECT *FROM CT_HOCPHAN 


SELECT *FROM CT_CATHI



-- CREATE PROC GET_DS_CATHIS
GO
CREATE PROC GET_DS_CATHIS 
AS
BEGIN
	SELECT MACATHI, CATHI.MAHOCPHAN, TENHOCPHAN, MADETHI, MADECON, NGAYTHI, GIOLAMBAI, PHONGTHI
	FROM CATHI, HOCPHAN
	WHERE CATHI.MAHOCPHAN = HOCPHAN.MAHOCPHAN
END
GO
EXEC GET_DS_CATHIS

-- CREATE PROC GET_DS_CATHIS_HOCPHAN
GO
CREATE PROC GET_DS_CATHIS_HOCPHAN @MAHOCPHAN CHAR(10)
AS
BEGIN
	SELECT MACATHI, CATHI.MAHOCPHAN, TENHOCPHAN, MADETHI, MADECON, NGAYTHI, GIOLAMBAI, PHONGTHI
	FROM CATHI, HOCPHAN
	WHERE CATHI.MAHOCPHAN = HOCPHAN.MAHOCPHAN AND CATHI.MAHOCPHAN = @MAHOCPHAN
END
GO
EXEC GET_DS_CATHIS_HOCPHAN '0101000001'

-- CREATE PROC GET_DSSV_CATHI
GO
CREATE PROC GET_DSSV_CATHI @MACATHI INT
AS
BEGIN
	SELECT SINHVIEN.MASV, SINHVIEN.TENSV, GIOITINH, NGAYSINH, MALOP
	FROM SINHVIEN, CT_CATHI
	WHERE SINHVIEN.MASV = CT_CATHI.MASV
		AND MACATHI = @MACATHI
END
GO
EXEC GET_DSSV_CATHI 6

SELECT *FROM CATHI

-- CREATE PROC GET_DSSV_CHUA_THAM_GIA_THI
GO
CREATE PROC GET_DSSV_CHUA_THAM_GIA_THI @MAHOCPHAN CHAR(10)
AS
BEGIN
	SELECT DISTINCT(CT_HOCPHAN.MASV), TENSV, GIOITINH, NGAYSINH, EMAIL, SDT, DIACHI, QUEQUAN, MALOP, HOCPHI
	FROM CT_HOCPHAN, SINHVIEN
	WHERE CT_HOCPHAN.MASV = SINHVIEN.MASV
		AND MAHOCPHAN = @MAHOCPHAN AND CT_HOCPHAN.MASV NOT IN (SELECT DISTINCT(MASV) FROM CATHI, CT_CATHI
																	WHERE CATHI.MACATHI = CT_CATHI.MACATHI 
																	AND MAHOCPHAN = @MAHOCPHAN)
END
GO
EXEC GET_DSSV_CHUA_THAM_GIA_THI '0101000004'

-- CREATE PROC GET_DSGV
GO
CREATE PROC GET_DSGV
AS
BEGIN
	SELECT GIANGVIEN.MAGV, TENGV, NGAYSINH, GIOITINH, QUEQUAN, HOCVI, SDT, EMAIL, DIACHI, TENKHOA, TENCHUCVU, GIANGVIEN.MAKHOA, GIANGVIEN.MACHUCVU
	FROM GIANGVIEN, KHOA, CHUCVU
	WHERE GIANGVIEN.MAKHOA = KHOA.MAKHOA AND GIANGVIEN.MACHUCVU = CHUCVU.MACHUCVU
END
GO
EXEC GET_DSGV

-- CREATE PROC GET_DSGV_KHOA
GO
CREATE PROC GET_DSGV_KHOA @MAKHOA CHAR(2)
AS
BEGIN
	SELECT GIANGVIEN.MAGV, TENGV, NGAYSINH, GIOITINH, QUEQUAN, HOCVI, SDT, EMAIL, DIACHI, TENKHOA, TENCHUCVU, GIANGVIEN.MAKHOA, GIANGVIEN.MACHUCVU
	FROM GIANGVIEN, KHOA, CHUCVU
	WHERE GIANGVIEN.MAKHOA = KHOA.MAKHOA AND GIANGVIEN.MACHUCVU = CHUCVU.MACHUCVU AND GIANGVIEN.MAKHOA = @MAKHOA
END
GO
EXEC GET_DSGV_KHOA '02'

-- CREATE PROC GET_DSKHOA
GO
CREATE PROC GET_DSKHOA
AS
BEGIN
	SELECT KHOA.MAKHOA, TENKHOA, COUNT(MAGV) AS SLGV
	FROM KHOA, GIANGVIEN
	WHERE KHOA.MAKHOA = GIANGVIEN.MAKHOA 
	GROUP BY KHOA.MAKHOA, TENKHOA
END
GO
EXEC GET_DSKHOA

-- CREATE PROC GET_DSHOCPHAN
GO
CREATE PROC GET_DSHOCPHAN
AS
BEGIN
	SELECT MAHOCPHAN, TENHOCPHAN, SOTC, SOTIET_LT, SOTIET_TH, TENKHOA, HOCPHAN.MAKHOA
	FROM HOCPHAN, KHOA
	WHERE HOCPHAN.MAKHOA = KHOA.MAKHOA
END
GO
EXEC GET_DSHOCPHAN

-- CREATE PROC GET_DSHOCPHAN
GO
CREATE PROC GET_DSHOCPHAN_KHOA @MAKHOA CHAR(2)
AS
BEGIN
	SELECT MAHOCPHAN, TENHOCPHAN, SOTC, SOTIET_LT, SOTIET_TH, TENKHOA, HOCPHAN.MAKHOA
	FROM HOCPHAN, KHOA
	WHERE HOCPHAN.MAKHOA = KHOA.MAKHOA
		AND HOCPHAN.MAKHOA = @MAKHOA
END
GO
EXEC GET_DSHOCPHAN_KHOA '01'

select *from HOCPHAN

-- CREATE PROC GET_DSLOPHOC
GO
CREATE PROC GET_DSLOPHOC
AS
BEGIN
	SELECT MALOP, TENLOP, SISO, TENKHOA, LOPHOC.MAKHOA
	FROM LOPHOC, KHOA
	WHERE LOPHOC.MAKHOA = KHOA.MAKHOA
END
GO
EXEC GET_DSLOPHOC

-- CREATE PROC GET_DSLOPHOC_KHOA
GO
CREATE PROC GET_DSLOPHOC_KHOA @MAKHOA CHAR(2)
AS
BEGIN
	SELECT MALOP, TENLOP, SISO, TENKHOA, LOPHOC.MAKHOA
	FROM LOPHOC, KHOA
	WHERE LOPHOC.MAKHOA = KHOA.MAKHOA
		AND LOPHOC.MAKHOA = @MAKHOA
END
GO
EXEC GET_DSLOPHOC_KHOA '01'

-- CREATE PROC GET_DSSV_KHOA
GO
CREATE PROC GET_DSSV_KHOA @MALOP CHAR(10), @MAKHOA CHAR(2)
AS
BEGIN
	SELECT SINHVIEN.MASV, TENSV, GIOITINH, NGAYSINH, EMAIL, SDT, DIACHI, QUEQUAN, MALOP, HOCPHI
	FROM SINHVIEN, LOPHOC
	WHERE SINHVIEN.MASV = CT_HOCPHAN.MASV 
		AND HOCPHAN.MAHOCPHAN = CT_HOCPHAN.MAHOCPHAN
		AND MAKHOA = '01'
END
GO
EXEC GET_DSSV_KHOA

-- CREATE PROC GET_DSSV_HOCPHAN
GO
CREATE PROC GET_DSSV_HOCPHAN @MALOPHOCPHAN CHAR(12)
AS
BEGIN
	SELECT CT_HOCPHAN.MASV, TENSV, GIOITINH, NGAYSINH, EMAIL, SDT, DIACHI, QUEQUAN, MALOP, HOCPHI
	FROM CT_HOCPHAN, SINHVIEN
	WHERE CT_HOCPHAN.MASV = SINHVIEN.MASV
		AND MALOPHOCPHAN = @MALOPHOCPHAN
END
GO
EXEC GET_DSSV_HOCPHAN '010100000401'

-- CREATE PROC GET_CT_HOCPHAN
GO
CREATE PROC GET_CT_HOCPHAN @MAHOCPHAN CHAR(10)
AS
BEGIN
	SELECT DISTINCT(MALOPHOCPHAN), CT_HOCPHAN.MAGV, THU, TIET, PHONG, NGAYBD, NGAYKT, TENGV
	FROM CT_HOCPHAN, GIANGVIEN
	WHERE CT_HOCPHAN.MAGV = GIANGVIEN.MAGV
		AND MAHOCPHAN = @MAHOCPHAN
END
GO
EXEC GET_CT_HOCPHAN '0101000004'
select *from CT_HOCPHAN

-- CREATE PROC GET_DSSV_CHUA_THAMGIA_HOCPHAN
-- LẤY DANH SÁCH SINH VIÊN CỦA KHOA CHƯA THAM GIA HỌC PHẦN CỦA KHOA
GO
CREATE PROC GET_DSSV_CHUA_THAMGIA_HOCPHAN @MAKHOA CHAR(2), @MALOPHOCPHAN CHAR(12)
AS
BEGIN
	SELECT MASV, TENSV, GIOITINH, NGAYSINH, EMAIL, SDT, DIACHI, QUEQUAN, SINHVIEN.MALOP, HOCPHI
	FROM SINHVIEN, LOPHOC WHERE SINHVIEN.MALOP = LOPHOC.MALOP AND MAKHOA = @MAKHOA
		AND  MASV NOT IN (SELECT MASV FROM CT_HOCPHAN WHERE MALOPHOCPHAN = @MALOPHOCPHAN)
END
GO
EXEC GET_DSSV_CHUA_THAMGIA_HOCPHAN '01', '010100000401'

-- CREATE PROC GETDSSVKHOALOPHP
-- LẤY DANH SÁCH SINH VIÊN CỦA KHOA CHƯA THAM GIA LỚP HỌC PHẦN NÀO CÓ THỨ ĐÓ - TIẾT ĐÓ
GO
CREATE PROC GETDSSVKHOALOPHP @MAKHOA CHAR(2), @THU INT, @TIET CHAR(10)
AS
BEGIN
	SELECT MASV, TENSV, GIOITINH, NGAYSINH, EMAIL, SDT, DIACHI, QUEQUAN, HOCPHI, SINHVIEN.MALOP
	FROM SINHVIEN, LOPHOC
	WHERE SINHVIEN.MALOP = LOPHOC.MALOP AND MAKHOA = @MAKHOA 
		AND MASV NOT IN (SELECT MASV FROM CT_HOCPHAN WHERE THU = @THU AND TIET = @TIET)
END
GO
EXEC GETDSSVKHOALOPHP '01', 2, '1-3'

-- CREATE PROC GETDSCATHI_TRONGNGAY
GO
CREATE PROC GETDSCATHI
AS
BEGIN
	SELECT CATHI.MACATHI, CATHI.MAHOCPHAN, TENHOCPHAN, MADECON, PHONGTHI, GIOLAMBAI, NGAYTHI, COUNT(CT_CATHI.MASV) AS SLSV, TINHTRANG
	FROM CATHI, CT_CATHI, HOCPHAN
	WHERE CATHI.MAHOCPHAN = HOCPHAN.MAHOCPHAN
		AND CATHI.MACATHI = CT_CATHI.MACATHI
		AND TINHTRANG = 1
	GROUP BY CATHI.MACATHI, CATHI.MAHOCPHAN, TENHOCPHAN, MADECON, PHONGTHI, GIOLAMBAI, NGAYTHI, TINHTRANG	
END
GO
EXEC GETDSCATHI

-- CREATE PROC GETDSBAITHI
GO
CREATE PROC GETDSBAITHI @MACATHI INT
AS
BEGIN
	SELECT CT_CATHI.MASV, SINHVIEN.TENSV, NGAYSINH, GIOITINH, MALOP, TINHTRANG, GIONOPBAI, MABAITHI
	FROM CT_CATHI, SINHVIEN, BAITHI
	WHERE CT_CATHI.MASV = SINHVIEN.MASV
		AND BAITHI.MASV = CT_CATHI.MASV
		AND BAITHI.MACATHI = 1003
END
GO
EXEC GETDSBAITHI 1003

-- CREATE PROC GETDSSVTHAMGIA
GO
CREATE PROC GETDSSVTHAMGIA @MACATHI INT
AS
BEGIN
	SELECT DISTINCT(CT_CATHI.MASV), SINHVIEN.TENSV, NGAYSINH, GIOITINH, MALOP, TINHTRANG, GIONOPBAI, MABAITHI
	FROM (CT_CATHI INNER JOIN SINHVIEN ON CT_CATHI.MASV = SINHVIEN.MASV) 
		LEFT JOIN BAITHI ON CT_CATHI.MASV = BAITHI.MASV 
	WHERE CT_CATHI.MACATHI = @MACATHI
END
GO
EXEC GETDSSVTHAMGIA 1004

-- CREATE PROC GETDSCAUHOIBAITHI
GO
CREATE PROC GETDSCAUHOIBAITHI @MABAITHI INT
AS
BEGIN
	SELECT CT_BAITHI.MACAUHOI, NOIDUNG, DAPAN1, DAPAN2, DAPAN3, DAPAN4, DAPANDUNG, CAUTRALOI
	FROM CT_BAITHI, CAUHOI
	WHERE CT_BAITHI.MACAUHOI = CAUHOI.MACAUHOI
		AND MABAITHI = @MABAITHI
END
GO
EXEC GETDSCAUHOIBAITHI 12
