USE [quanlylinhkien]
GO
/****** Object:  StoredProcedure [dbo].[store_login]    Script Date: 20/02/2021 6:42:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[store_login]
	
	
	@user nvarchar(50),
	@pass char(30)
AS
BEGIN
	SELECT *
	FROM KhachHang
	WHERE Username=@user AND PassWord=@pass

END
