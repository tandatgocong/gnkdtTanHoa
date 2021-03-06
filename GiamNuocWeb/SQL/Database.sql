CREATE TABLE g_SanLuongDHT
(
	[TimeStamp] [datetime] NOT NULL,
	[MaDMA]  varchar(255),
	[CSCU] float,
	[CSMOI] float,
	[TIEUTHU] float,
	
)


SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA, [ChannelId]
      ,[LoggerId]
      ,[ChannelName]
      ,[Unit]
      ,[Description]
      ,[Pressure1]
      ,[Pressure2]
      ,[ForwardFlow]
      ,[ReverseFlow]
      ,[TimeStamp]
      ,[LastValue]
      ,[IndexTimeStamp]
      ,[LastIndex]
  FROM [tanhoa].[dbo].[t_Channel_Configurations] WHERE  IndexTimeStamp is not null and REPLACE( LEFT([Description],6),' ','') <> ''  order by [Description] asc
  
   RIGHT([Description],3)='DHT' AND ChannelName='Flow' order by MaDMA
  
  
 
 SELECT  REPLACE( LEFT([Description],6),' ','') as MaDMA, [ChannelId]
      ,[LoggerId]
      ,[ChannelName]
      ,[Unit]
      ,[Description]
      ,[Pressure1]
      ,[Pressure2]
      ,[ForwardFlow]
      ,[ReverseFlow]
      ,[TimeStamp]
      ,[LastValue]
      ,[IndexTimeStamp]
      ,[LastIndex]
  FROM [tanhoa].[dbo].[t_Channel_Configurations] order by [Description] desc
  
  
CREATE TABLE w_BaoBe
( 
	 ID int IDENTITY(1,1),
	 IdNhom int,
	 TenNhom nvarchar(150),
	 SoNha  nvarchar(150),
	 TenDuong  nvarchar(MAX),
	 MaPhuong  varchar(50),
	 TenPhuong	nvarchar(150),
	 MaQuan		int,
	 TenQuan	nvarchar(150),
	 MaDMA		nvarchar(100),
	 GhiChu		nvarchar(100),
	 KetCauLe	nvarchar(100),
	 KetCauDuong nvarchar(100),
	 HinhAnh	nvarchar(100),
	 CreateDate   DateTime,
     CreateBy nvarchar(100),
	 AutoDel	bit default 0,	
	 Chuyen		bit default 0,	
	 ChuyenNgay	DateTime
)
GO