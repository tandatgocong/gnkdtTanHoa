 
  UPDATE g_ThongTinDHT set ChannelCMP=t_Channel_Configurations.ChannelId
  FROM t_Channel_Configurations
  where ChannelName='Pressure' and g_ThongTinDHT.MaDMA= Replace(LEFT([Description],6),' ','')
  
  select *
  FROM t_Channel_Configurations
  where ChannelName='Pressure' 
 order by    Replace(LEFT([Description],6),' ','') asc
 
 
 
 select * from t_Channel_Configurations where LoggerId=20254