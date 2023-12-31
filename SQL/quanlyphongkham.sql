USE [master]
GO
/****** Object:  Database [QuanLyPhongKham]    Script Date: 7/6/2023 4:45:10 PM ******/
CREATE DATABASE [QuanLyPhongKham]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyPhongKham', FILENAME = N'E:\TaiLieuHocTap\Đồ Án\Thực Tập\QuanLyPhongKham\SQL\QuanLyPhongKham.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyPhongKham_log', FILENAME = N'E:\TaiLieuHocTap\Đồ Án\Thực Tập\QuanLyPhongKham\SQL\QuanLyPhongKham_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyPhongKham] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyPhongKham].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyPhongKham] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyPhongKham] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyPhongKham] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyPhongKham] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyPhongKham] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyPhongKham] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyPhongKham] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyPhongKham] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyPhongKham] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyPhongKham] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyPhongKham] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyPhongKham] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyPhongKham]
GO
/****** Object:  StoredProcedure [dbo].[USP_CapNhatSoLuongKho]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_CapNhatSoLuongKho]
@idHoaDon INT
AS
BEGIN
	UPDATE dbo.Thuoc SET SoLuong = t.soluong - cthd.soluong
	FROM ChiTietHoaDon as cthd, Thuoc as t
	WHERE cthd.idThuoc = t.id and cthd.idHoaDon = @idHoaDon
END


GO
/****** Object:  StoredProcedure [dbo].[USP_CapNhatSoLuongKhoNhapHang]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_CapNhatSoLuongKhoNhapHang]
@idHoaDonNhapHang INT
AS
BEGIN
	UPDATE dbo.Thuoc SET SoLuong = t.soluong + cthdnh.soluong
	FROM ChiTietHoaDonNhapHang as cthdnh, Thuoc as t
	WHERE cthdnh.idThuoc = t.id and cthdnh.idHoaDonNhapHang = @idHoaDonNhapHang
END


GO
/****** Object:  StoredProcedure [dbo].[USP_DangNhap]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DangNhap]
@taiKhoan nvarchar(100), @matKhau nvarchar(100)
as
begin
    select * from dbo.TaiKhoan WHERE taikhoan = @taiKhoan AND matkhau = @matKhau
end


GO
/****** Object:  StoredProcedure [dbo].[USP_DanhSachHenTheoNgay]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_DanhSachHenTheoNgay]
@ngayBD date, @ngayKT date
as
begin
    select dsk.ngaykham as [Ngày Khám], dsk.stt as [Số Thứ Tự], dsk.id as [Mã Khám], bn.id as [Mã Bênh Nhân], bn.tenbn as [Tên Bệnh Nhân], bn.sdtbn as [Số Điện Thoại]
	from DanhSachKham as dsk, BenhNhan as bn
	where dsk.ngaykham >= @ngayBD and dsk.ngaykham <= @ngayKT and dsk.idBenhNhan = bn.id and dsk.tinhtrang = 0
end

GO
/****** Object:  StoredProcedure [dbo].[USP_DanhSachHoaDonTheoNgay]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_DanhSachHoaDonTheoNgay]
@ngayBD date, @ngayKT date
as
begin
    select hd.id as [Mã Hóa Đơn], bn.id as [Mã Bệnh Nhân], nv.tennv as [Nhân Viên], bn.tenbn as [Bệnh Nhân], bn.namsinhbn as [Năm Sinh], bn.gioitinhbn as [Giới Tính], bn.diachibn as [Địa Chỉ], bn.sdtbn as [SĐT], hd.tongtien as [Tổng Tiền], hd.ngayban as [Ngày Bán], hd.tinhtrang as [Tình Trạng]
	from HoaDon as hd, NhanVien as nv, BenhNhan as bn
	where hd.ngayban >= @ngayBD and hd.ngayban <= @ngayKT and hd.idNhanVien = nv.id and hd.idBenhNhan = bn.id
end


GO
/****** Object:  StoredProcedure [dbo].[USP_DanhSachNhapHangTheoNgay]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: QuanLyPhongKham1.sql|304|0|E:\TaiLieuHocTap\Đồ Án\Thực Tập\QuanLyPhongKham\SQL\QuanLyPhongKham1.sql

CREATE proc [dbo].[USP_DanhSachNhapHangTheoNgay]
@ngayBD date, @ngayKT date
as
begin
    select hdnh.NgayNhap as [Ngày Nhập], hdnh.id as [Mã Nhập], nv.tennv as [Tên Nhân Viên], hdnh.tongtien as [Tổng Tiền Nhập], nsx.tennhasanxuat as [Nhà Sản Xuất]
	from dbo.NhaSanXuat as nsx, dbo.HoaDonNhapHang as hdnh, dbo.NhanVien as nv
	where hdnh.NgayNhap >= @ngayBD and hdnh.NgayNhap <= @ngayKT and hdnh.idNhaSanXuat = nsx.id and hdnh.idNhanVien = nv.id and hdnh.tinhtrang = 1
end

GO
/****** Object:  StoredProcedure [dbo].[USP_DoanhThuTheoNgay]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DoanhThuTheoNgay]
@ngayBD date, @ngayKT date
as
begin
    select hd.id as [Mã hóa đơn], nv.tennv as [Tên bác sĩ], bn.tenbn as [Tên khách hàng], hd.tongtien as [Tổng tiền], hd.ngayban as [Ngày bán]
	from HoaDon as hd, NhanVien as nv, BenhNhan as bn
	where hd.ngayban >= @ngayBD and hd.ngayban <= @ngayKT and hd.idBenhNhan = bn.id and hd.idNhanVien = nv.id and hd.tinhtrang = 1
end


GO
/****** Object:  StoredProcedure [dbo].[USP_HoaDonKhamCuaBenhNhan]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_HoaDonKhamCuaBenhNhan]
as
begin
    declare @idHD int
	Select @idHD = MAX(id) from dbo.HoaDon
    SELECT bn.id, bn.tenbn, bn.namsinhbn, bn.gioitinhbn, bn.diachibn, bn.sdtbn, t.tenthuoc, t.chucnang, dvt.tendonvi, t.giale, cthd.soluong, (t.giale*cthd.soluong) as ThanhTien, hd.tongtien, ba.lydokham, ba.chuandoan, ba.ngaylap, ba.loidan, nv.tennv
	FROM dbo.ChiTietHoaDon AS cthd, dbo.HoaDon AS hd, dbo.BenhNhan AS bn, dbo.BenhAn as ba, dbo.NhanVien as nv, dbo.Thuoc as t, DonViTinh as dvt
	WHERE hd.idBenhNhan = bn.id and hd.idNhanVien = nv.id and cthd.idHoaDon = hd.id and cthd.idThuoc = t.id and t.idDonViTinh = dvt.id and ba.idHoaDon = hd.id and hd.id = @idHD
end

GO
/****** Object:  StoredProcedure [dbo].[USP_HoaDonThuocCuaBenhNhan]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_HoaDonThuocCuaBenhNhan]
as
begin
    declare @idHD int
	Select @idHD = MAX(id) from dbo.HoaDon
    SELECT bn.id, bn.tenbn, bn.namsinhbn, bn.gioitinhbn, bn.diachibn, bn.sdtbn, t.tenthuoc, t.chucnang, dvt.tendonvi, t.giale, cthd.soluong, (t.giale*cthd.soluong) as ThanhTien, hd.tongtien, nv.tennv
	FROM dbo.ChiTietHoaDon AS cthd, dbo.HoaDon AS hd, dbo.BenhNhan AS bn, dbo.NhanVien as nv, dbo.Thuoc as t, DonViTinh as dvt
	WHERE hd.idBenhNhan = bn.id and hd.idNhanVien = nv.id and cthd.idHoaDon = hd.id and cthd.idThuoc = t.id and t.idDonViTinh = dvt.id and hd.id = @idHD
end

GO
/****** Object:  StoredProcedure [dbo].[USP_LayDanhSachThuoc]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_LayDanhSachThuoc]
as
begin
    select t.id as [Mã Thuốc], t.tenthuoc as [Tên Thuốc], t.duonguong as [Đường Uống], t.dangbaoche as [Dạng Bào Chế], t.hamluong as [Hàm Lượng], t.thanhphan as [Thành Phần], t.hinhdang as [Hình Dáng], t.handung as [Hạn Dùng], t.chucnang as [Chức Năng], t.soluong as [Số Lượng], t.gianhap as [Giá Nhập], t.giasi as [Giá Sỉ], t.giale as [Giá Lẻ], t.giankhuyenmai as [Giá Khuyến Mãi], lt.tenloai as [Tên Loại], dvt.tendonvi as [Đơn Vị], nsx.tennhasanxuat as [Nhà Sản Xuất]
	from dbo.Thuoc as t, dbo.LoaiThuoc as lt, dbo.DonViTinh as dvt, dbo.NhaSanXuat as nsx
	where t.idLoaiThuoc = lt.id and t.idDonViTinh = dvt.id and t.idNhaSanXuat = nsx.id
end


GO
/****** Object:  StoredProcedure [dbo].[USP_ThemChiTietHoaDon]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_ThemChiTietHoaDon]
@idHoaDon INT, @idThuoc INT, @soluong INT
AS
BEGIN
    DECLARE @idTonTaiChiTietHoaDon INT
	DECLARE @soluongSanPham INT = 1

	SELECT @idTonTaiChiTietHoaDon = cthd.id, @soluongSanPham = cthd.soluong FROM dbo.ChiTietHoaDon AS cthd WHERE cthd.idHoaDon = @idHoaDon AND cthd.idThuoc = @idThuoc

	IF (@idTonTaiChiTietHoaDon > 0)
	BEGIN
	    DECLARE @soluongmoi INT = @soluongSanPham + @soluong
		IF(@soluongmoi > 0)
		UPDATE dbo.ChiTietHoaDon SET SoLuong = @soluongSanPham + @soluong WHERE idThuoc = @idThuoc
		ELSE
		DELETE dbo.ChiTietHoaDon WHERE idHoaDon = @idHoaDon AND idThuoc = @idThuoc
	END
	ELSE
	BEGIN
	    INSERT dbo.ChiTietHoaDon(idHoaDon, idThuoc, soluong)
		VALUES (@idHoaDon, @idThuoc, @soluong)
	END
END


GO
/****** Object:  StoredProcedure [dbo].[USP_ThemChiTietHoaDonNhapKho]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_ThemChiTietHoaDonNhapKho]
@idHoaDonNhapKho INT, @idThuoc INT, @soluong INT
AS
BEGIN
    DECLARE @idTonTaiChiTietHoaDonNhapKho INT
	DECLARE @soluongSanPham INT = 1

	SELECT @idTonTaiChiTietHoaDonNhapKho = cthdnh.id, @soluongSanPham = cthdnh.soluong FROM dbo.ChiTietHoaDonNhapHang AS cthdnh WHERE cthdnh.idHoaDonNhapHang = @idHoaDonNhapKho AND cthdnh.idThuoc = @idThuoc

	IF (@idTonTaiChiTietHoaDonNhapKho > 0)
	BEGIN
	    DECLARE @soluongmoi INT = @soluongSanPham + @soluong
		IF(@soluongmoi > 0)
		UPDATE dbo.ChiTietHoaDonNhapHang SET SoLuong = @soluongSanPham + @soluong WHERE idThuoc = @idThuoc
		ELSE
		DELETE dbo.ChiTietHoaDonNhapHang WHERE idHoaDonNhapHang = @idHoaDonNhapKho AND idThuoc = @idThuoc
	END
	ELSE
	BEGIN
	    INSERT dbo.ChiTietHoaDonNhapHang(idHoaDonNhapHang, idThuoc, soluong)
		VALUES (@idHoaDonNhapKho, @idThuoc, @soluong)
	END
END


GO
/****** Object:  StoredProcedure [dbo].[USP_ThemHoaDon]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: QuanLyPhongKham1.sql|241|0|E:\TaiLieuHocTap\Đồ Án\Thực Tập\QuanLyPhongKham\SQL\QuanLyPhongKham1.sql

CREATE PROC [dbo].[USP_ThemHoaDon]
@idBN int, @idNV int
AS
BEGIN
    INSERT dbo.HoaDon( ngayban, tongtien, idNhanVien, idBenhNhan, tinhtrang)
	VALUES (GETDATE(), 0, @idNV, @idBN, 0)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_ThemHoaDonNhapKho]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: QuanLyPhongKham1.sql|250|0|E:\TaiLieuHocTap\Đồ Án\Thực Tập\QuanLyPhongKham\SQL\QuanLyPhongKham1.sql

CREATE PROC [dbo].[USP_ThemHoaDonNhapKho]
@idNSX int, @idNV int
AS
BEGIN
    INSERT dbo.HoaDonNhapHang( NgayNhap, tongtien, idNhanVien, idNhaSanXuat, tinhtrang)
	VALUES (GETDATE(), 0, @idNV, @idNSX, 0)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_TimKiemDanhSachThuoc]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: QuanLyPhongKham1.sql|196|0|E:\TaiLieuHocTap\Đồ Án\Thực Tập\QuanLyPhongKham\SQL\QuanLyPhongKham1.sql

CREATE proc [dbo].[USP_TimKiemDanhSachThuoc]
as
begin
    select t.id as [Mã Thuốc], t.tenthuoc as [Tên Thuốc], t.duonguong as [Đường Uống], t.dangbaoche as [Dạng Bào Chế], t.hamluong as [Hàm Lượng], t.thanhphan as [Thành Phần], t.hinhdang as [Hình Dáng], t.handung as [Hạn Dùng], t.chucnang as [Chức Năng], t.soluong as [Số Lượng], t.gianhap as [Giá Nhập], t.giasi as [Giá Sỉ], t.giale as [Giá Lẻ], t.giankhuyenmai as [Giá Khuyến Mãi], lt.tenloai as [Tên Loại], dvt.tendonvi as [Đơn Vị], nsx.tennhasanxuat as [Nhà Sản Xuất]
	from dbo.Thuoc as t, dbo.LoaiThuoc as lt, dbo.DonViTinh as dvt, dbo.NhaSanXuat as nsx
	where t.idLoaiThuoc = lt.id and t.idDonViTinh = dvt.id and t.idNhaSanXuat = nsx.id
end

GO
/****** Object:  Table [dbo].[BenhAn]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhAn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lydokham] [nvarchar](1000) NOT NULL DEFAULT (N'Chưa Biết'),
	[trieuchung] [nvarchar](1000) NOT NULL DEFAULT (N'Chưa Biết'),
	[sieuam] [nvarchar](1000) NOT NULL DEFAULT (N'không có'),
	[chuandoan] [nvarchar](1000) NOT NULL DEFAULT (N'Chưa Biết'),
	[loidan] [nvarchar](1000) NOT NULL DEFAULT (N'Chưa Biết'),
	[ngaylap] [date] NOT NULL DEFAULT (getdate()),
	[tinhtrang] [int] NOT NULL DEFAULT ((1)),
	[idNhanVien] [int] NOT NULL,
	[idBenhNhan] [int] NOT NULL,
	[idHoaDon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenbn] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[namsinhbn] [int] NOT NULL DEFAULT ((2001)),
	[gioitinhbn] [nvarchar](3) NOT NULL DEFAULT (N'Nam'),
	[diachibn] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[sdtbn] [nvarchar](10) NOT NULL DEFAULT (N'1234567890'),
	[emailbn] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[tieusubenh] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[ghichu] [nvarchar](100) NOT NULL DEFAULT (N'Chưa có ghi chú'),
	[ngaytao] [date] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idHoaDon] [int] NOT NULL,
	[idThuoc] [int] NOT NULL,
	[soluong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDonNhapHang]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonNhapHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idHoaDonNhapHang] [int] NOT NULL,
	[idThuoc] [int] NOT NULL,
	[soluong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhSachKham]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhSachKham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBenhNhan] [int] NOT NULL,
	[stt] [int] NOT NULL,
	[tinhtrang] [int] NOT NULL DEFAULT ((0)),
	[ngaykham] [date] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonViTinh]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonViTinh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tendonvi] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HangCho]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangCho](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBenhNhan] [int] NOT NULL,
	[idNhanVien] [int] NOT NULL,
	[noidung] [nvarchar](100) NOT NULL,
	[tinhtrang] [int] NOT NULL DEFAULT ((0)),
	[thoigianhen] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idNhanVien] [int] NOT NULL,
	[idBenhNhan] [int] NOT NULL,
	[tongtien] [float] NOT NULL,
	[ngayban] [date] NOT NULL DEFAULT (getdate()),
	[tinhtrang] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonNhapHang]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhapHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idNhaSanXuat] [int] NOT NULL,
	[tongtien] [float] NOT NULL,
	[NgayNhap] [date] NOT NULL DEFAULT (getdate()),
	[tinhtrang] [int] NOT NULL DEFAULT ((0)),
	[idNhanVien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiThuoc]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiThuoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tennv] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[namsinhnv] [int] NOT NULL DEFAULT ((2001)),
	[gioitinhnv] [nvarchar](3) NOT NULL DEFAULT (N'Nam'),
	[diachinv] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[sdtnv] [nvarchar](10) NOT NULL DEFAULT (N'1234567890'),
	[emailnv] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[chucvu] [nvarchar](100) NOT NULL DEFAULT (N'admin'),
	[vitri] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tennhasanxuat] [nvarchar](1000) NOT NULL DEFAULT (N'Chưa Biết'),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[taikhoan] [nvarchar](100) NOT NULL DEFAULT (N'admin'),
	[matkhau] [nvarchar](100) NOT NULL DEFAULT (N'admin'),
	[loaitk] [int] NOT NULL DEFAULT ((0)),
	[idNhanVien] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Thuoc]    Script Date: 7/6/2023 4:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thuoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenthuoc] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[duonguong] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[dangbaoche] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[hamluong] [nvarchar](100) NOT NULL DEFAULT (N'không biết'),
	[thanhphan] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[hinhdang] [nvarchar](100) NOT NULL DEFAULT (N'Chưa Biết'),
	[handung] [nvarchar](1000) NOT NULL DEFAULT (N'Chưa Biết'),
	[chucnang] [nvarchar](1000) NOT NULL DEFAULT (N'Chưa Biết'),
	[soluong] [int] NOT NULL DEFAULT ((100)),
	[gianhap] [float] NOT NULL DEFAULT ((10000)),
	[giasi] [float] NOT NULL DEFAULT ((20000)),
	[giale] [float] NOT NULL DEFAULT ((15000)),
	[giankhuyenmai] [float] NOT NULL DEFAULT ((18000)),
	[idLoaiThuoc] [int] NOT NULL,
	[idNhaSanXuat] [int] NOT NULL,
	[idDonViTinh] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BenhAn] ON 

INSERT [dbo].[BenhAn] ([id], [lydokham], [trieuchung], [sieuam], [chuandoan], [loidan], [ngaylap], [tinhtrang], [idNhanVien], [idBenhNhan], [idHoaDon]) VALUES (3, N'Đau bụng', N'đầu bên hông', N'không có', N'Đau dạ dày', N'Nên ăn uống đầy đủ', CAST(N'2023-05-11' AS Date), 1, 1, 1, 1)
INSERT [dbo].[BenhAn] ([id], [lydokham], [trieuchung], [sieuam], [chuandoan], [loidan], [ngaylap], [tinhtrang], [idNhanVien], [idBenhNhan], [idHoaDon]) VALUES (4, N'Đau đầu', N'Đau đầu', N'không có', N'Đau đầu', N'Nên nghỉ ngơi đầy đủ', CAST(N'2023-05-22' AS Date), 1, 1, 1, 5)
INSERT [dbo].[BenhAn] ([id], [lydokham], [trieuchung], [sieuam], [chuandoan], [loidan], [ngaylap], [tinhtrang], [idNhanVien], [idBenhNhan], [idHoaDon]) VALUES (5, N'Đau mắt', N'Đau mắt', N'Đau mắt', N'Đau mắt', N'Đau mắt', CAST(N'2023-05-22' AS Date), 1, 2, 2, 26)
INSERT [dbo].[BenhAn] ([id], [lydokham], [trieuchung], [sieuam], [chuandoan], [loidan], [ngaylap], [tinhtrang], [idNhanVien], [idBenhNhan], [idHoaDon]) VALUES (6, N'Đau bụng', N'đầu bên hông', N'không có', N'Đau dạ dày', N'Nên ăn uống đầy đủ', CAST(N'2023-05-29' AS Date), 1, 1, 1, 28)
INSERT [dbo].[BenhAn] ([id], [lydokham], [trieuchung], [sieuam], [chuandoan], [loidan], [ngaylap], [tinhtrang], [idNhanVien], [idBenhNhan], [idHoaDon]) VALUES (7, N'Đau mắt', N'Đau mắt', N'Đau mắt', N'Đau mắt', N'Đau mắt', CAST(N'2023-06-03' AS Date), 1, 1, 2, 30)
INSERT [dbo].[BenhAn] ([id], [lydokham], [trieuchung], [sieuam], [chuandoan], [loidan], [ngaylap], [tinhtrang], [idNhanVien], [idBenhNhan], [idHoaDon]) VALUES (8, N'tesst', N'tesst', N'tesst', N'tesst', N'tesst', CAST(N'2023-06-28' AS Date), 1, 1, 6, 31)
INSERT [dbo].[BenhAn] ([id], [lydokham], [trieuchung], [sieuam], [chuandoan], [loidan], [ngaylap], [tinhtrang], [idNhanVien], [idBenhNhan], [idHoaDon]) VALUES (9, N'te', N'te', N'te', N'te', N'te', CAST(N'2023-07-05' AS Date), 1, 1, 2, 32)
SET IDENTITY_INSERT [dbo].[BenhAn] OFF
SET IDENTITY_INSERT [dbo].[BenhNhan] ON 

INSERT [dbo].[BenhNhan] ([id], [tenbn], [namsinhbn], [gioitinhbn], [diachibn], [sdtbn], [emailbn], [tieusubenh], [ghichu], [ngaytao]) VALUES (1, N'Nguyễn Văn A', 2001, N'Nam', N'Cần Thơ', N'1234567890', N'VanA@gmail.com', N'Đau Bụng', N'Chưa có ghi chú', CAST(N'2023-05-16' AS Date))
INSERT [dbo].[BenhNhan] ([id], [tenbn], [namsinhbn], [gioitinhbn], [diachibn], [sdtbn], [emailbn], [tieusubenh], [ghichu], [ngaytao]) VALUES (2, N'Nguyễn Văn B', 2002, N'Nữ', N'Cà Mau', N'0987654321', N'VanBGgmail.com', N'Đau đầu', N'Chưa có ghi chú', CAST(N'2023-05-11' AS Date))
INSERT [dbo].[BenhNhan] ([id], [tenbn], [namsinhbn], [gioitinhbn], [diachibn], [sdtbn], [emailbn], [tieusubenh], [ghichu], [ngaytao]) VALUES (6, N'Test', 2000, N'Nữ', N'test', N'1231231230', N'test', N'Chưa Biết', N'Chưa có ghi chú', CAST(N'2023-05-22' AS Date))
SET IDENTITY_INSERT [dbo].[BenhNhan] OFF
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 

INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (6, 1, 2, 7)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (11, 5, 2, 7)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (12, 5, 4, 3)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (16, 26, 2, 7)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (17, 26, 4, 2)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (18, 27, 4, 5)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (19, 27, 2, 7)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (20, 28, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (21, 29, 4, 6)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (22, 30, 4, 5)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (23, 31, 2, 2)
INSERT [dbo].[ChiTietHoaDon] ([id], [idHoaDon], [idThuoc], [soluong]) VALUES (24, 32, 2, 4)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonNhapHang] ON 

INSERT [dbo].[ChiTietHoaDonNhapHang] ([id], [idHoaDonNhapHang], [idThuoc], [soluong]) VALUES (1, 3, 2, 50)
INSERT [dbo].[ChiTietHoaDonNhapHang] ([id], [idHoaDonNhapHang], [idThuoc], [soluong]) VALUES (2, 3, 4, 50)
INSERT [dbo].[ChiTietHoaDonNhapHang] ([id], [idHoaDonNhapHang], [idThuoc], [soluong]) VALUES (5, 9, 2, 50)
INSERT [dbo].[ChiTietHoaDonNhapHang] ([id], [idHoaDonNhapHang], [idThuoc], [soluong]) VALUES (6, 9, 4, 50)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDonNhapHang] OFF
SET IDENTITY_INSERT [dbo].[DanhSachKham] ON 

INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (1, 1, 1, 1, CAST(N'2023-05-28' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (2, 2, 2, 1, CAST(N'2023-05-28' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (6, 6, 3, 1, CAST(N'2023-05-28' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (1002, 6, 1, 1, CAST(N'2023-05-30' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (1003, 1, 2, 1, CAST(N'2023-05-30' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (2003, 1, 1, 1, CAST(N'2023-05-29' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (2004, 2, 3, 1, CAST(N'2023-06-03' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (2007, 6, 1, 1, CAST(N'2023-06-28' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (2009, 1, 1, 1, CAST(N'2023-06-29' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (2010, 2, 1, 0, CAST(N'2023-06-29' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (2011, 6, 2, 0, CAST(N'2023-06-29' AS Date))
INSERT [dbo].[DanhSachKham] ([id], [idBenhNhan], [stt], [tinhtrang], [ngaykham]) VALUES (3009, 2, 1, 1, CAST(N'2023-07-05' AS Date))
SET IDENTITY_INSERT [dbo].[DanhSachKham] OFF
SET IDENTITY_INSERT [dbo].[DonViTinh] ON 

INSERT [dbo].[DonViTinh] ([id], [tendonvi]) VALUES (1, N'Viên')
SET IDENTITY_INSERT [dbo].[DonViTinh] OFF
SET IDENTITY_INSERT [dbo].[HangCho] ON 

INSERT [dbo].[HangCho] ([id], [idBenhNhan], [idNhanVien], [noidung], [tinhtrang], [thoigianhen]) VALUES (1, 1, 1, N'khám bệnh', 0, CAST(N'2023-05-16 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[HangCho] OFF
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (1, 1, 1, 86000, CAST(N'2023-05-11' AS Date), 1)
INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (5, 1, 1, 72000, CAST(N'2023-05-22' AS Date), 1)
INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (26, 2, 2, 102000, CAST(N'2023-05-22' AS Date), 1)
INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (27, 1, 6, 27540, CAST(N'2023-05-22' AS Date), 1)
INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (28, 1, 1, 62000, CAST(N'2023-05-29' AS Date), 1)
INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (29, 1, 2, 10800, CAST(N'2023-05-30' AS Date), 1)
INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (30, 1, 2, 60000, CAST(N'2023-06-03' AS Date), 1)
INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (31, 1, 6, 21600, CAST(N'2023-06-28' AS Date), 1)
INSERT [dbo].[HoaDon] ([id], [idNhanVien], [idBenhNhan], [tongtien], [ngayban], [tinhtrang]) VALUES (32, 1, 2, 48000, CAST(N'2023-07-05' AS Date), 1)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
SET IDENTITY_INSERT [dbo].[HoaDonNhapHang] ON 

INSERT [dbo].[HoaDonNhapHang] ([id], [idNhaSanXuat], [tongtien], [NgayNhap], [tinhtrang], [idNhanVien]) VALUES (3, 1, 1250000, CAST(N'2023-05-23' AS Date), 1, 1)
INSERT [dbo].[HoaDonNhapHang] ([id], [idNhaSanXuat], [tongtien], [NgayNhap], [tinhtrang], [idNhanVien]) VALUES (9, 1, 1125000, CAST(N'2023-05-23' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[HoaDonNhapHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiThuoc] ON 

INSERT [dbo].[LoaiThuoc] ([id], [tenloai]) VALUES (1, N'Thuốc chống dị ứng')
INSERT [dbo].[LoaiThuoc] ([id], [tenloai]) VALUES (2, N'Thuốc giảm đau')
INSERT [dbo].[LoaiThuoc] ([id], [tenloai]) VALUES (3, N'Thuốc tiêu hóa')
SET IDENTITY_INSERT [dbo].[LoaiThuoc] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([id], [tennv], [namsinhnv], [gioitinhnv], [diachinv], [sdtnv], [emailnv], [chucvu], [vitri]) VALUES (1, N'ty', 2001, N'Nam', N'Cần Thơ', N'1234567890', N'ty@gmail.com', N'Admin', N'Bác sĩ')
INSERT [dbo].[NhanVien] ([id], [tennv], [namsinhnv], [gioitinhnv], [diachinv], [sdtnv], [emailnv], [chucvu], [vitri]) VALUES (2, N'tri', 2001, N'Nam', N'An Giang', N'1251251250', N'tri@gami.com', N'Nhân Viên', N'Bác Sĩ')
INSERT [dbo].[NhanVien] ([id], [tennv], [namsinhnv], [gioitinhnv], [diachinv], [sdtnv], [emailnv], [chucvu], [vitri]) VALUES (4, N'nghia', 2001, N'Nữ', N'Cần Thơ', N'1478523690', N'nghia@gmail.com', N'Nhân Viên', N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[NhaSanXuat] ON 

INSERT [dbo].[NhaSanXuat] ([id], [tennhasanxuat]) VALUES (1, N'Dược và Vật tư y tế Bình Thuận')
INSERT [dbo].[NhaSanXuat] ([id], [tennhasanxuat]) VALUES (2, N'Dược và Vật tư Cần Thơ')
SET IDENTITY_INSERT [dbo].[NhaSanXuat] OFF
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([id], [taikhoan], [matkhau], [loaitk], [idNhanVien]) VALUES (1, N'ty', N'0', 0, 1)
INSERT [dbo].[TaiKhoan] ([id], [taikhoan], [matkhau], [loaitk], [idNhanVien]) VALUES (2, N'tri', N'0', 1, 2)
INSERT [dbo].[TaiKhoan] ([id], [taikhoan], [matkhau], [loaitk], [idNhanVien]) VALUES (1003, N'nghia', N'admin', 1, 4)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[Thuoc] ON 

INSERT [dbo].[Thuoc] ([id], [tenthuoc], [duonguong], [dangbaoche], [hamluong], [thanhphan], [hinhdang], [handung], [chucnang], [soluong], [gianhap], [giasi], [giale], [giankhuyenmai], [idLoaiThuoc], [idNhaSanXuat], [idDonViTinh]) VALUES (2, N'Vitamin C', N'Uống', N'Viên nang cứng', N'500mg', N'Vitamin C', N'Viên tròn', N'36 tháng kể từ ngày sản xuất', N'Điều trị thiếu hụt vitamin C', 130, 10000, 0, 12000, 0, 1, 1, 1)
INSERT [dbo].[Thuoc] ([id], [tenthuoc], [duonguong], [dangbaoche], [hamluong], [thanhphan], [hinhdang], [handung], [chucnang], [soluong], [gianhap], [giasi], [giale], [giankhuyenmai], [idLoaiThuoc], [idNhaSanXuat], [idDonViTinh]) VALUES (4, N'Thuốc đau dạ dày', N'uống', N'bột', N'', N'', N'', N'', N'làm giảm đau dạ dày', 126, 15000, 19000, 2000, 0, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Thuoc] OFF
ALTER TABLE [dbo].[BenhAn]  WITH CHECK ADD FOREIGN KEY([idBenhNhan])
REFERENCES [dbo].[BenhNhan] ([id])
GO
ALTER TABLE [dbo].[BenhAn]  WITH CHECK ADD FOREIGN KEY([idHoaDon])
REFERENCES [dbo].[HoaDon] ([id])
GO
ALTER TABLE [dbo].[BenhAn]  WITH CHECK ADD FOREIGN KEY([idNhanVien])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([idHoaDon])
REFERENCES [dbo].[HoaDon] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([idThuoc])
REFERENCES [dbo].[Thuoc] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhapHang]  WITH CHECK ADD FOREIGN KEY([idHoaDonNhapHang])
REFERENCES [dbo].[HoaDonNhapHang] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhapHang]  WITH CHECK ADD FOREIGN KEY([idThuoc])
REFERENCES [dbo].[Thuoc] ([id])
GO
ALTER TABLE [dbo].[DanhSachKham]  WITH CHECK ADD FOREIGN KEY([idBenhNhan])
REFERENCES [dbo].[BenhNhan] ([id])
GO
ALTER TABLE [dbo].[HangCho]  WITH CHECK ADD FOREIGN KEY([idBenhNhan])
REFERENCES [dbo].[BenhNhan] ([id])
GO
ALTER TABLE [dbo].[HangCho]  WITH CHECK ADD FOREIGN KEY([idNhanVien])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([idBenhNhan])
REFERENCES [dbo].[BenhNhan] ([id])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([idNhanVien])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[HoaDonNhapHang]  WITH CHECK ADD FOREIGN KEY([idNhaSanXuat])
REFERENCES [dbo].[NhaSanXuat] ([id])
GO
ALTER TABLE [dbo].[HoaDonNhapHang]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhapHang_NhanVien] FOREIGN KEY([idNhanVien])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[HoaDonNhapHang] CHECK CONSTRAINT [FK_HoaDonNhapHang_NhanVien]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([idNhanVien])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[Thuoc]  WITH CHECK ADD FOREIGN KEY([idDonViTinh])
REFERENCES [dbo].[DonViTinh] ([id])
GO
ALTER TABLE [dbo].[Thuoc]  WITH CHECK ADD FOREIGN KEY([idLoaiThuoc])
REFERENCES [dbo].[LoaiThuoc] ([id])
GO
ALTER TABLE [dbo].[Thuoc]  WITH CHECK ADD FOREIGN KEY([idNhaSanXuat])
REFERENCES [dbo].[NhaSanXuat] ([id])
GO
USE [master]
GO
ALTER DATABASE [QuanLyPhongKham] SET  READ_WRITE 
GO
