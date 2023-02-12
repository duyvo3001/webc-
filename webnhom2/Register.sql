-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE store_insertuser
	
	@hoten nvarchar(50),
	@diachi nvarchar(50),
	@sdt nvarchar(10),
	@email char(30),
	@user nvarchar(50),
	@password char(30)
AS
BEGIN
	INSERT INTO KhachHang(HoTen,DiaChi,SDT,Email,Username,PassWord)
	VALUES (@hoten,@diachi,@sdt,@email,@user,@password)
END
GO
