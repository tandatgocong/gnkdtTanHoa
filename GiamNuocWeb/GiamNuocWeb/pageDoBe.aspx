<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDoBe.aspx.cs" Inherits="GiamNuocWeb.pageDoBe" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
  <script language="javascript" type="text/javascript">
      window.document.getElementById("HOME").className = "";
      window.document.getElementById("SANLUONG").className = "";
      window.document.getElementById("LUULUONG").className = "";
      window.document.getElementById("APLUC").className = "";
      window.document.getElementById("DHT").className = "";
      window.document.getElementById("THATTHOAT").className = ""; 
      window.document.getElementById("DOBE").className = "active";  
  </script>

<style>
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
     .box {
            position:absolute;
            left:20px;
            top:100px;
            z-index:999;
            color:Red;
   
        }
    .style1
    {
        height: 30px;
        width: 75px;
    }
    .style2
    {
        height: 38px;
    }
    </style>
    <script type="text/javascript">
    function DownloadDMDB() {
        window.location = "/QuanLyDiemBe.xlsx";
    }
</script>
    </script>
  <body>
  <div class="dhnLoi">
  
      <asp:RadioButtonList ID="radioCheck" runat="server" 
          RepeatDirection="Horizontal" AutoPostBack="True" 
          onselectedindexchanged="radioCheck_SelectedIndexChanged">
          <asp:ListItem Value="0" Selected="True">Tổng Điểm Bể</asp:ListItem>
          <asp:ListItem Value="2" >Dò DMA</asp:ListItem>
          <asp:ListItem Value="1" >Dò Bể</asp:ListItem>
      </asp:RadioButtonList>
  
  </div>
  <asp:Panel ID="panelDMA" runat="server"   Visible=false >
     <table><tr><td> <div class="title_page2"> DMA : 
                        <asp:DropDownList ID="listDMA2" runat="server" Height="24px" 
           Width="67px" onselectedindexchanged="listDMA2_SelectedIndexChanged" 
           AutoPostBack="True">
                        </asp:DropDownList>
                    </div></td></tr></table>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="334px" Font-Size="X-Large">
                        <Columns>
                            <asp:BoundField DataField="TenNHom" HeaderText="Nhóm Dò" />
                            <asp:TemplateField HeaderText="Ngày">
                              <ItemTemplate >
                                   <asp:Label ID="lblFromDate" runat="server" 
                                             
                                              HtmlEncode="false"  
                                              Text='<%#Eval("NgayBatDau", "{0:dd/MM/yyyy}") %>' />
                                    </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                  </asp:GridView>
 
  </asp:Panel>
  <asp:Panel ID="panelTongKet" runat="server" >
     <div class="title_page2"> NHÓM DÒ BỂ  : 
                        <asp:DropDownList ID="cbNhomDoBe" runat="server" Height="34px" 
           Width="144px"  
           AutoPostBack="True" onselectedindexchanged="cbNhomDoBe_SelectedIndexChanged">
                        </asp:DropDownList>
   </div>
    <table border="1" style="margin-top:10px;">
            <tr ><td class="style1">Từ Ngày  </td><td><asp:TextBox ID="tTuNgay" runat="server" TextMode="Date" Width="130px"></asp:TextBox></td><td></td></tr>
            <tr><td class="style1">Đến Ngày </td><td><asp:TextBox ID="tDenNgay" runat="server" TextMode="Date" Width="130px"></asp:TextBox></td><td>
                <asp:CheckBox ID="chekChuaSua" runat="server" Text="Chưa Sửa" /></td></tr>
            <tr><td class="style2" colspan=3> 
                &nbsp;<asp:Button ID="Button3" runat="server" CssClass="button1" 
                    onclick="Button3_Click" Text="Danh sách Điểm bể" Width="149px" />
                <asp:Button ID="Button1" runat="server" CssClass="button" 
                    onclick="Button1_Click" Text="&nbsp;Xem&nbsp;" />
                </td></tr>
    </table>

      

                      <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
           <rsweb:ReportViewer Height="600px" Width="100%" ID="ReportViewer1" runat="server" ZoomMode="PageWidth">
         </rsweb:ReportViewer>
   
      </asp:Panel>

  <asp:Panel ID="panelDiemBe" runat="server"  Visible=false>
       
     <div class="dhnLoi2">
   <table><tr><td> <div class="title_page2"> DMA : 
                        <asp:DropDownList ID="listDMA" runat="server" Height="24px" 
           Width="67px" onselectedindexchanged="listDMA_SelectedIndexChanged" 
           AutoPostBack="True">
                        </asp:DropDownList>
                    </div></td>
                    <td> 
                    <%if (Session["login"] == null)
                      { %>
                     <asp:Button ID="Button2" runat="server"  Text="Đăng Nhập" Visible=false Width="114px" 
                    onclick="login_Click" CssClass="button" Height="30px"/>
                    <%}
                      else {
                          Response.Write(Session["tennhom"].ToString());
                    }
        %>
                    
                    </td></tr>
    </table>
  </div>

    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
    <div id="map" style="width: 100%; height:75vh"></div>
    <%-- <div class="box">
     <table border="1" style="text-align:center" class=table_list >
            <tr class=head>
                <td>STT</td><td style="width:250px;">Vị Trí Bể</td><td style="width:100px;">Loại Bể</td><td style="width:100px;">Tình Trạng</td><td style="width:200px;">Ghi Chú</td>
            </tr>
            <tr class=row1>
                <td>1</td><td>64/30/4 Phổ Quang</td><td>Bể Ngầm</td><td>Đã sửa</td><td> Bể </td>
            </tr>
            <tr>
                <td>2</td><td>73 Tân Hải</td><td>Bể Nổi</td><td>Đã sửa</td><td> </td>
            </tr>
            <tr>
                <td>3</td><td>14/3 Nguyễn Văn Dương </td><td>Bể Ngầm</td><td>Chưa sửa</td><td> </td>
            </tr>
            
        </table>--%>
     </div>
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
            var latlng = new google.maps.LatLng(<%=Session["center"] %>);
            var marker;
            var infowindow;
            var map = new google.maps.Map(document.getElementById('map'), {
                center: latlng,
                zoom: 17,
                mapTypeId: 'roadmap'
            });

            ////////////////////////
              <%if (Session["login"] != null)
              { %>

            infowindow = new google.maps.InfoWindow();
            var html = " <meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><div class='title_page'>Nhập Điểm Bể  </div> <br/> <table  >" +
                         "<tr style=' height: 25px;' valign='middle'><td style='border-bottom:1px; border-bottom-style:dotted; hight:100px; width:60px;' >Loại Bể: </td> <td><select  style='width:100px;' id='loai'>" +
                         "<option value='1' SELECTED> Bể ngầm</option>" +
                         "<option value='2' > Bể Nổi </option>" +
                         "</select> </td></tr>" +
                         "<tr style='height:25px; '  valign='middle'><td style='border-bottom:1px; border-bottom-style:dotted;width:60px;' >Ống Bể: </td> <td><select style='width:100px;'  id='ong'>" +
                         "<option value='1' SELECTED> Ống ngánh </option>" +
                         "<option value='2' > Ống cái </option>" +
                         "</select> </td></tr>" +
                         "<tr style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:60px;'>DMA</td> <td><select  style='width:100px;' id='madma'>" +
                          <% 
                        int f=1;
                        DataTable   table = new DataTable();
                           if(Session["dsDHTong"]!=null)
                           {
                            table = (DataTable)Session["dsDHTong"];
                            for(int j=0;j<table.Rows.Count;j++)
                            {
                                if(table.Rows[j]["IDNhom"]+""==Session["manhom"]+"")
                                {%>"<option value='<%=table.Rows[j]["STT"]%>' SELECTED><%=table.Rows[j]["MaDMA"]%></option>" +<%}
                                else{
                                %>"<option value='<%=table.Rows[j]["STT"]%>'><%=table.Rows[j]["MaDMA"]%></option>" +<%
                                }
                            }
                        }%>
                         "</select> </td></tr>" +
                         "<tr style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:60px;'>Số Nhà</td> <td> <input type='text' id='sonha'/> </td></tr>" +
                         "<tr style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:60px;'>Đường</td> <td> <input type='text' id='duong'/> </td></tr>" +
                         "<tr style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:60px;'>Ghi Chú</td> <td style='border-bottom:1px; border-bottom-style:dotted; width:60px;'> <input type='text' id='ghichu'/> </td></tr>" +
                         "<tr style=' height: 30px; '><td style='hight:100px; width:80px;'></td><td><input type='button' class='button' value='Save' onclick='save()'/></td></tr></table>";

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
                            lagx = marker.getPosition().lat(),
                            lagy = marker.getPosition().lng()
                });
            });

            <%} %>

            ////////////////////


            layer = new google.maps.FusionTablesLayer({
                map: map,
                heatmap: { enabled: false },
                query: {
                    select: "col2",
                    from: "<%=Session["maps"]%>"                    
                },
                options: {
                    styleId: 2,
                    templateId: 2
                }
            });

        layer.setMap(map);

         var icon_='/Image/s.png';
         var lb="<%=Session["dobe"]%>";
        var marker5555 = new google.maps.Marker({
				              position: latlng,
                              icon: icon_, 
                              label: {text: lb, color: "Blue", fontWeight: "bold",fontSize: "20px"},
				              map: map,
				              title: "fdsfds"
				              });
                           
                            marker5555.setMap(map);

            ////////////////////
         /*   var layer = new google.maps.FusionTablesLayer({
              query: {
                select: 'col2',
                from: '1gosPIEZPWjr_sBAEGwWzTB7ZU5BQuR7q91oLbRy5'
			    },
			      options: {
				    styleId: 3,
				    templateId: 4
			    },
                styles: [{
                        polygonOptions: { 
                            fillOpacity: 0.1
                        }
                    }]
            });
            layer.setMap(map);
            */

                  
                  
               // Try HTML5 geolocation.
             var infoWindow = new google.maps.InfoWindow({map: map});
                if (navigator.geolocation) {
                  navigator.geolocation.getCurrentPosition(function(position) {
                 
                 var latlng99999 = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);

                 var icon_='/Image/nursery.png';
                 var marker99999= new google.maps.Marker({
				              position: latlng99999, 
                              icon: icon_, 
				              map: map 
				              });
                           
                marker99999.setMap(map);
                var  infowindow99999 = new google.maps.InfoWindow();
                var iwContent="<table border=1 cellpadding=0 cellspacing=0> "; 
                    iwContent+="<tr><td> Location </td></tr> ";
                    iwContent+="</table>";
                infowindow99999.setContent(iwContent);
                infowindow99999.open(map,marker99999);

                map.setCenter(marker99999.getPosition());
                  }, function() {
                    handleLocationError(true, infoWindow, map.getCenter());
                  });
                } else {
                  // Browser doesn't support Geolocation
                  handleLocationError(false, infoWindow, map.getCenter());
                }



             
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
                        size: new google.maps.Size(100, 100),
                        origin: new google.maps.Point(0, 0),
                        anchor: new google.maps.Point(17, 34),
                        scaledSize: new google.maps.Size(67, 65)
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
             function save() {  
                   var madma = document.getElementById("madma").value;
                   var loai = document.getElementById("loai").value;
                   var ong = document.getElementById("ong").value;
                   var sonha = document.getElementById("sonha").value;
                   var duong = document.getElementById("duong").value;
                   var ghichu = document.getElementById("ghichu").value;
                   
                   var newUrl="pageAddDiemBe.aspx?lat="+lagx+ "&lng=" + lagy+ "&madma=" + madma + "&loai=" + loai+ "&ong=" + ong + "&sonha=" + sonha+ "&duong=" + duong + "&ghichu=" + ghichu ; 
                   // alert(latlng);
                   document.location.href = newUrl;
                                    
                   // var newUrl="addBaoBee.aspx?lat="+lagx+ "&lng=" + lagy ;
                   // alert(latlng);
                   //document.location.href = newUrl;
                      
              }

                </script>
    
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBnK4XMpV0do1pWTYFGUydQvA_EyMkJ9xU&libraries=places&callback=initAutocomplete"         async defer></script>
  
      </asp:Panel>

  </body>

</asp:Content>
