<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="mBaoBe.aspx.cs" Inherits="WebMobile.mBaoBe" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="WebMobile.Class" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script language="javascript" type="text/javascript">
      window.document.getElementById("HOME").className = "";
      window.document.getElementById("BAOBE").className = "active";
      window.document.getElementById("HOANCONG").className = "";
      window.document.getElementById("BAOCAO").className = "";
 

  </script>
  <style>
            div.title_page {
        border-bottom: 2px solid #663300;
        color: #006600;
        font-family: Tahoma,Arial,Helvetica,sans-serif;
        font-size: 14px;
        font-weight: bold;
        text-transform: uppercase;
}
div.title_page2 {
      
        color: #006600;
        font-family: Tahoma,Arial,Helvetica,sans-serif;
        font-size: 14px;
        font-weight: bold;
        text-transform: uppercase;
}
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 100%;
      }
      /* Optional: Makes the sample page fill the window. */
      
      #description {
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
      }

      #infowindow-content .title {
        font-weight: bold;
      }

      #infowindow-content {
        display: none;
      }

      #map #infowindow-content {
        display: inline;
      }

      .pac-card {
        margin: 10px 10px 0 0;
        border-radius: 2px 0 0 2px;
        box-sizing: border-box;
        -moz-box-sizing: border-box;
        outline: none;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
        background-color: #fff;
        font-family: Roboto;
      }

      #pac-container {
        padding-bottom: 12px;
        margin-right: 12px;
      }

      .pac-controls {
        display: inline-block;
        padding: 5px 11px;
      }

      .pac-controls label {
        font-family: Roboto;
        font-size: 13px;
        font-weight: 300;
      }

      #pac-input {
        background-color: #fff;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        margin-left: 12px;
        padding: 0 11px 0 13px;
        text-overflow: ellipsis;
        width: 400px;
        height:25px;
        margin-top:11px;
      }

      #pac-input:focus {
        border-color: #4d90fe;
      }

      #title {
        color: #fff;
        background-color: #4d90fe;
        font-size: 25px;
        font-weight: 500;
        padding: 6px 12px;
      }
      #target {
        width: 345px;
      }
    .style1
    {
        width: 95px;
        height: 49px;
    }
    .style5
    {
        height: 30px;
    }
    .style6
    {
        height: 27px;
    }
    .style7
    {
        width: 140px;
    }
    </style>
 <asp:Panel ID="Panel1" runat="server" >  
       <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1"  />     
 
 <table cellpadding="0" cellspacing="0" style="font-family:Times New Roman; margin-top:5px; margin-left:5px; margin-bottom:5px;" >
        <tbody>
           <tr>
               <td style="border-bottom:2px #99cc99 solid; " >&nbsp;Từ ngày:&nbsp;</td>
               <td style="border-bottom:2px #99cc99 solid; "><asp:TextBox ID="tungay" 
                       runat="server" autocomplete="off" Height="20px" Width="78px" />
               </td>
                <td style="border-bottom:2px #99cc99 solid; " >&nbsp;đến:&nbsp;</td>
                
               <td style="border-bottom:2px #99cc99 solid; ">
                   <asp:TextBox ID="denngay" runat="server" autocomplete="off" Height="20px" 
                       Width="78px" />
               </td>
               <td  
                   style="border-bottom:2px #99cc99 solid; font-size:10px; font-weight:normal;  ">
                   <asp:Button ID="btXemBangKe" runat="server" CssClass="button1" Height="27px" 
                       onclick="btXemBangKe_Click" Text="XEM" Width="52px" />
               </td>
               <td class="style7" 
                   
                   style="border-bottom:2px #99cc99 solid; font-size:10px; font-weight:normal; margin-left: 160px;">
                   <asp:CheckBox ID="chekHien" runat="server" AutoPostBack="True" Font-Bold="True" 
                       Font-Size="Small" oncheckedchanged="chekHien_CheckedChanged" 
                       Text="Chuyển" />
               </td>
             </tr>
             
            <tr>
                <td colspan="6" style="height:25px;"><center><div class="title_page2">
                    <asp:Label ID="lbTong" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label></div></center>
                </td>
            </tr>
             
          </tbody>
    </table>

       <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tungay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
         <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="denngay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
<asp:Panel ID="Panel2" runat="server"   Width="100%">    
  
    <table cellpadding="0" cellspacing="0"  style="font-family:Times New Roman;width:100%;">
                     <tr class="head1">
                          <td class="style5" 
                              style="border-right:1px #FF0000 solid; background-color:#CCFFFF; font-size:large; border-bottom: 2px #FF0000 solid">
                              
                           </td>
                      </tr>
                     <tr >
                          <td  style="border-right:1px #FF0000 solid; font-size:large; border-bottom: 2px #FF0000 solid" 
                              class="style6">
                              <table cellpadding="0" cellspacing="0" class="table_list" 
                                  style="font-family:Times New Roman; font-size:15px; margin-left:20px;">
                                  <tr class="head1">
                                      <td class="style26" 
                                          style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                          SỐ CÔNG VĂN :</td>
                                      <td class="style26" 
                                          style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                          <asp:TextBox ID="TextBox1" runat="server" Width="100px" Height="22px"></asp:TextBox>
                                      </td>
                                      <td class="style26" 
                                          style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                          &nbsp;</td>
                                  </tr>
                                  <tr class="head1">
                                      <td class="style26" 
                                          
                                          style="border-right:2px #FF0000 solid; text-align: center; border-bottom-style: solid; border-bottom-color: inherit; border-bottom-width: 1px;">
                                          ĐƠN VỊ NHẬN
                                          <br />
                                          SỬA BỂ</td>
                                      <td class="style26" 
                                          style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                          <asp:DropDownList ID="cbDonViSuaBe" runat="server" Height="23px" Width="102px">
                                          </asp:DropDownList>
                                          
                                      </td>
                                      <td class="style26" 
                                          style="border-right:2px #FF0000 solid; border-bottom: 1px solid;">
                                          <asp:Button ID="btChuyen" runat="server" CssClass="button1" Height="27px" 
                                              onclick="btChuyen_Click" Text="CHUYỂN" Width="88px" />
                                      </td>
                                  </tr>
                              </table>
                           
                          </td>
                      </tr>
                     <tr >
                          <td class="style1" align="center" >
                          <asp:Panel ID="Panel3"  runat="server" ScrollBars="Both" Width="320px"  >
                                <asp:Panel ID="Panel4"   runat="server"  Width="900px">
                              <asp:GridView ID="gChuyen" runat="server" AutoGenerateColumns="False" 
                                  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                  CellPadding="4" Width="100%">
                                  <Columns>
                                      <asp:TemplateField>
                                          <ItemTemplate>
                                              <asp:CheckBox ID="chkRow" runat="server" />
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="ID" Visible="False">
                                          <EditItemTemplate>
                                              <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                                          </EditItemTemplate>
                                          <ItemTemplate>
                                              <asp:Label ID="lbID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:BoundField DataField="STT" HeaderText="STT" >
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="LoaiBao" HeaderText="Loại Bể">
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="MaDMA" HeaderText="Mã DMA" >
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="SoNha" HeaderText="Số Nhà" >
                                      <ItemStyle VerticalAlign="Middle" Width="150px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="TenDuong" HeaderText="Tên Đường" >
                                      <ItemStyle VerticalAlign="Middle" Width="250px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="TenPhuong" HeaderText="Phường" >
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="TenQuan" HeaderText="Quận" >
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="TenDonVi" HeaderText="Đơn Vị Sửa Bể" >
                                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
                                      </asp:BoundField>
                                      <asp:BoundField DataField="SoBangKe" HeaderText="Số CV" />
                                  </Columns>
                                  <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                  <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                  <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                  <RowStyle BackColor="White" ForeColor="#330099" />
                                  <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                  <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                  <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                  <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                  <SortedDescendingHeaderStyle BackColor="#7E0000" />
                              </asp:GridView>
                              </asp:Panel>
                          </asp:Panel>
                              
                          </td>
                      </tr>
                 </table>


</asp:Panel>
</asp:Panel>
    <asp:Panel ID="panelChuyen" runat="server">
    
 
    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
     <div id="map" style="width: 100%; height: 800px"></div>

    <script>
        var lagx;
        var lagy;
        // This example adds a search box to a map, using the Google Place Autocomplete
        // feature. People can enter geographical searches. The search box will return a
        // pick list containing a mix of places and predicted search terms.

        // This example requires the Places library. Include the libraries=places
        // parameter when you first load the API. For example:
        // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

        function initAutocomplete() {
            var latlng = new google.maps.LatLng(10.801433295748337, 106.65252816547981);
            var marker;
            var infowindow;
            var map = new google.maps.Map(document.getElementById('map'), {
                center: latlng,
                zoom: 18,
                mapTypeId: 'roadmap'
            });
 
          var layer = new google.maps.FusionTablesLayer({
                      query: {
                        select: 'col2',
                        from: '1eXgHvhPw8I3YbH3oGi0Z58qcjHnIOJZ5X0KOt358'
			            },
			              options: {
				            styleId: 2,
				            templateId: 2
			            }
                    });
                    layer.setMap(map);


                infowindow = new google.maps.InfoWindow();
                   var html = " <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />" +                         
                         "<input type='button' class='button' value='Thêm Điểm Bể' onclick='save()'/>";

                    infowindow = new google.maps.InfoWindow({
                        content: html 
                    });

                    google.maps.event.addListener(map, "click", function (event) {
                        marker = new google.maps.Marker({
                            position: event.latLng,
                            map: map
                        });
                        google.maps.event.addListener(marker, "click", function () {
                            infowindow.open(map, marker),
                            lagx=marker.getPosition().lat(),
                            lagy=marker.getPosition().lng()
                        });
                    });
                 
                   
                var  infoWindow2 = new google.maps.InfoWindow();

                       // Event that closes the Info Window with a click on the map
                       google.maps.event.addListener(map, 'click', function() {
                          infoWindow2.close();
                       });

                     <% 
                       DataTable table = new DataTable();
                       if(Session["dsBaoBe"]!=null)
                       {
                        table = (DataTable)Session["dsBaoBe"];
                        for(int i=0;i<table.Rows.Count;i++)
                        {
                          string filelis ="";
                            string[] words = Regex.Split(table.Rows[i]["Img"].ToString(), ",");
                            for (int j= 0; j < words.Length; j++)
                            {
                                 if (!words[j].Equals("")) {
                                         filelis+=" <a target='_blank' href='" + words[j] + "'> <img  src='" + words[j] + "' width='200' height='150' /> </a> ";
                                 }
                         
                           }
                        %>
                              var x= parseFloat(<%=table.Rows[i]["lat"]%>);
                              lagx= parseFloat(<%=table.Rows[i]["lat"]%>);
                              var y = parseFloat(<%=table.Rows[i]["lng"]%>);
                              lagy= parseFloat(<%=table.Rows[i]["lng"]%>);
                          
                            var tinhtrang= parseInt(<%=table.Rows[i]["THUCHIEN"]%>);
                             var icon_='/Image/Marker.png';
                             var mau="#FF0000";
                             
                             /*if(tinhtrang==2)
                               { mau="#00FFFF"; icon_='/Image/MarkerSuaTam.png';} */
                            
                             if(tinhtrang==2)
                                { mau="#00FFFF"; icon_='/Image/MarkerSuaTam.png';}
                       
                            if(tinhtrang==3)
                                { mau="##0000FF"; icon_='/Image/chuagiao.png';}
                             
                              var beton= parseInt(<%=table.Rows[i]["BETON"]%>);                             
                             if (beton==1)
                                { mau="#FFCC00"; icon_='/Image/warning.png';}


                             var latlng2 = new google.maps.LatLng(x, y);
                             var name<%=i%> =<%=table.Rows[i]["ID"]%>;
                                                            
                          
                            var cityCircle = new google.maps.Circle({
                                strokeColor: mau,
                                strokeOpacity: 0.8,
                                strokeWeight: 2,
                                fillColor: mau,
                                fillOpacity: 0.35,
                                map: map,
                                center: latlng2,
                                radius: 20
                              });

                              var marker<%=i%> = new google.maps.Marker({
				              position: latlng2,
                              icon: icon_,
				              map: map,
				              title: name<%=i%>
				              });


                            google.maps.event.addListener(marker<%=i%>, 'click', function() {
                              // Creating the content to be inserted in the infowindow
                              var iwContent="<div class='title_page'>Thông Tin  Báo Bể</div> <br/> " ;
                              iwContent+="<table  style='height:100px; colspan='2' align='center'><tr><td colspan='2' align='center'> </td></tr>";
                          iwContent+="<tr style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; hight:100px; width:400px;'>&nbsp;Địa chỉ :<b> <%=table.Rows[i]["SoNha"]%> &nbsp;  <%=table.Rows[i]["TenDuong"]%> </b></> &nbsp; </b> &nbsp;</td></tr>";
                          iwContent+="<tr  style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;Báo Bể Ngày :<b>  <%=table.Rows[i]["NgayBao"]%> </b></> &nbsp;  </td></tr>";
                          
                          iwContent+="<tr  style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp; Ghi Chú : <%=table.Rows[i]["GhiChu"]%> &nbsp;</td></tr>";
                         iwContent+=" <tr><td colspan='2' align='center' style='border-bottom:1px; border-bottom-style:dotted; height:120px; width:100px;'> <marquee behavior='scroll' SCROLLAMOUNT='20' direction='left' onmouseover='this.stop();' onmouseout='this.start();'> <%=filelis%> </marquee></td></tr>";
                          iwContent+="<tr  style=' height: 35px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'> <center><input type='button' class='button'  value='Xóa Điểm Bể' onclick='monuoc(<%=table.Rows[i]["ID"]%>);'/> </center></td></tr>";
                          iwContent+="</table>";
      
                              // including content to the Info Window.
                              infoWindow2.setContent(iwContent);

                              // opening the Info Window in the current map and at the current marker location.
                              infoWindow2.open(map, marker<%=i%>);
                           });


                        <%
                        }
                       }
                    %>
            ////////////////////
          var infoWindow = new google.maps.InfoWindow({map: map});
                 var pos = {
                      lat: lagx,
                      lng: lagy
                    };
                    
                    map.setCenter(pos);

             
            
                // Try HTML5 geolocation.
                if (navigator.geolocation) {
                  navigator.geolocation.getCurrentPosition(function(position) {
                    var pos = {
                      lat: position.coords.latitude,
                      lng: position.coords.longitude
                    };

                    infoWindow.setPosition(pos);
                    infoWindow.setContent('Location');
                    map.setCenter(pos);
                  }, function() {
                    handleLocationError(true, infoWindow, map.getCenter());
                  });
                } else {
                                  // Browser doesn't support Geolocation
                 
                  handleLocationError(false, infoWindow, map.getCenter());
                }
                 



            ////////////////////
           

            // Create the search box and link it to the UI element.
            var input = document.getElementById('pac-input');
            var searchBox = new google.maps.places.SearchBox(input);
            map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

            // Bias the SearchBox results towards current map's viewport.
            map.addListener('bounds_changed', function () {
                searchBox.setBounds(map.getBounds());
            });


            var markers = [];
            // Listen for the event fired when the user selects a prediction and retrieve
            // more details for that place.
            searchBox.addListener('places_changed', function () {
                var places = searchBox.getPlaces();

                if (places.length == 0) {
                    return;
                }

               

                /* Clear out the old markers.
                markers.forEach(function (marker) {
                    marker.setMap(null);
                }); */
                markers = [];

                // For each place, get the icon, name and location.
                var bounds = new google.maps.LatLngBounds();
                places.forEach(function (place) {
                    if (!place.geometry) {
                        console.log("Returned place contains no geometry");
                        return;
                    }
                    var icon = {
                        url: '/Image/icon2.png',
                        size: new google.maps.Size(71, 71),
                        origin: new google.maps.Point(0, 0),
                        anchor: new google.maps.Point(17, 34),
                        scaledSize: new google.maps.Size(67, 67)
                    };

                    // Create a marker for each place.
                    markers.push(new google.maps.Marker({
                        map: map,
                        icon: icon,
                        title: place.name,
                        position: place.geometry.location
                    }));

                    
                    if (place.geometry.viewport) {
                        // Only geocodes have viewport.
                        bounds.union(place.geometry.viewport);
                    } else {
                        bounds.extend(place.geometry.location);
                    }
                });
                map.fitBounds(bounds);
            });
            
 }
            function monuoc(id) {                
                var newUrl="mBaoBeAdd.aspx?id="+id ;
                   // alert(latlng);
                  document.location.href = newUrl;
               }

                function save() {                                                
                   var newUrl="mBaoBeAdd.aspx?lat="+lagx+ "&lng=" + lagy;
                   // alert(latlng);
                   document.location.href = newUrl;
                                    
                   // var newUrl="addBaoBee.aspx?lat="+lagx+ "&lng=" + lagy ;
                   // alert(latlng);
                   //document.location.href = newUrl;
                      
              }

    </script>
    
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBnK4XMpV0do1pWTYFGUydQvA_EyMkJ9xU&libraries=places&callback=initAutocomplete"   async defer></script>
    </asp:Panel>
</asp:Content>
