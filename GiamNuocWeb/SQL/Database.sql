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