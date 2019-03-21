<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GiamNuocWeb.Home1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script language="javascript" type="text/javascript">
    window.document.getElementById("HOME").className = "active";
</script>

<script type="text/javascript">
    init_reload();
    function init_reload() {
        setInterval(function () {
            window.location.reload();

        }, 900000);
    }
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
            top:138px;
            z-index:999;
   
        }

    </style>


  <body> <div class="dhnLoi">
   <table width="340px;"><tr><td> <div style="margin-left:7px;"> DMA : 
                        <asp:DropDownList ID="listDMA" runat="server" Height="24px" 
           Width="80px" onselectedindexchanged="listDMA_SelectedIndexChanged" 
           AutoPostBack="True">
                        </asp:DropDownList>
                    </div></td><td>
                        <asp:CheckBox ID="chekApLuc" runat="server" Text="Áp Lực CMP" AutoPostBack="True" 
                            oncheckedchanged="chekApLuc_CheckedChanged" /> </td><td>
                        <asp:CheckBox ID="chekLuuLuong" runat="server" Text="Lưu Lượng" 
                            AutoPostBack="True" oncheckedchanged="chekLuuLuong_CheckedChanged" /> </td></tr></table> </div>

    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
     <div id="map" style="width: 100%; height:75vh"></div>
     <div class=box>
        
        <input type="button" id="btn1" value="Ẩn"/>
        <input type="button" id="btn2" value="Hiện"/>
 
        <script language="javascript">

            document.getElementById("btn1").onclick = function () {
                document.getElementById("content").style.display = 'none';
            };

            document.getElementById("btn2").onclick = function () {
                document.getElementById("content").style.display = 'block';
            };
 
        </script>
        <div id="content">
     <table style="text-align:center">
            <tr>
                <td style="background-color:#02579D	; color:White">
                    Lưu lượng (m3/h) 
                   
                  
                   </td>                 
            </tr>
            <tr>
                <td style="background-color:White; color:White">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="3px" 
                        CellPadding="3" ShowHeader="False" Width="158px">
                        <Columns>
                            <asp:TemplateField HeaderText="MaDMA">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" ForeColor="Red" runat="server" Text='<%# Bind("MaDMA") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Font-Bold="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="dd">
                                <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton1" ForeColor="Red" runat="server" 
                                        PostBackUrl='<%# Eval("MaDMA","pageChart.aspx?value={0}") %>' Text='<%# Bind("vLuuLuong") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Font-Bold="True" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" Height="20px" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    </td>
            </tr>
            <tr>
                <td style="background-color:#02579D; color:White">
                   Áp Lực (bar) </td>                 
            </tr>
            <tr>
                <td style="background-color:White; color:White">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="None" BorderWidth="0px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" ShowHeader="False" 
                        Width="158px">
                        <Columns>
                            <asp:TemplateField HeaderText="MaDMA">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" ForeColor="Red" runat="server" Text='<%# Bind("MaDMA") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:LinkButton  ForeColor="Red" ID="LinkButton1" runat="server" 
                                        PostBackUrl='<%# Eval("MaDMA","pageChart.aspx?value={0}") %>' Text='<%# Bind("vCMP") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" 
                                    ForeColor="Blue" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" Height="20px" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    </td>
            </tr>
             <tr>
                <td style="background-color:#02579D; color:White">
                   Không gửi tín hiệu </td>                 
            </tr>
            <tr>
                <td style="background-color:White; color:White">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="None" BorderWidth="0px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" ShowHeader="False" 
                        Width="158px">
                        <Columns>
                            <asp:TemplateField HeaderText="MaDMA">
                                <ItemTemplate>
                                  <asp:LinkButton ID="LinkButton1" ForeColor="Red" runat="server" 
                                        PostBackUrl='<%# Eval("DMA","pageChart.aspx?value={0}") %>' Text='<%# Bind("DMA") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" Height="20px" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    </td>
            </tr>
        </table>
        </div>
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
                zoom: <%=Session["zoom"]%>,
                mapTypeId: 'roadmap'
            });

           ////////////////////////
            <% 
                    int f=1;
                    DataTable   table = new DataTable();
                       if(Session["dsDHTong"]!=null)
                       {
                        table = (DataTable)Session["dsDHTong"];
                        for(int j=0;j<table.Rows.Count;j++)
                        {
                            f++;
                        %>
                           var x = parseFloat(<%=table.Rows[j]["DHTLat"]%>);
                           var y = parseFloat(<%=table.Rows[j]["DHTLng"]%>);
                          // var latlng2 = new google.maps.LatLng(x, y);

                             var latlng2 = new google.maps.LatLng(x, y);

                             var name<%=f%> =<%=table.Rows[j]["STT"]%>;

                             var icon_='/Image/dhTong2.png';
                             var lb='<%=table.Rows[j]["MaDMA"]%>';
                                                            
                           var marker<%=f%> = new google.maps.Marker({
				              position: latlng2,
                              icon: icon_, 
                              label: {text: lb, color: "Red", fontWeight: "bold",fontSize: "25px"},
				              map: map,
				              title: name<%=f%>
				              });
                           
                            marker<%=f%>.setMap(map);
             
                            var  infowindow3 = new google.maps.InfoWindow();


                              var iwContent="<table border=0 cellpadding=0 cellspacing=0> ";
                                 iwContent+="<tr><td style='border-bottom:1px; border-bottom-style:dotted;'> <a href='pageChart.aspx?value=<%=table.Rows[j]["MaDMA"]%>'> <b><%=table.Rows[j]["vLuuLuong"]%> </b> m3/h </a> </td></tr> ";
                                 iwContent+="<tr><td><b><%=table.Rows[j]["vApOut"]%> </b> bar </td></tr> ";
                                 
                                iwContent+="</table>";
                              infowindow3.setContent(iwContent);

				
                            infowindow3.open(map,marker<%=f%>);

                        <%
                        }
                       }
            %>


              <% 
                    
                       table = new DataTable();
                       if(Session["dsCMP"]!=null)
                       {
                        table = (DataTable)Session["dsCMP"];
                        for(int j=0;j<table.Rows.Count;j++)
                        {
                            f++;
                        %>
                           var x = parseFloat(<%=table.Rows[j]["CMPLat"]%>);
                           var y = parseFloat(<%=table.Rows[j]["CMPLng"]%>);
                          // var latlng2 = new google.maps.LatLng(x, y);

                             var latlng2 = new google.maps.LatLng(x, y);

                             var name<%=f%> =<%=table.Rows[j]["STT"]%>;

                             var icon_='/Image/cmp.png';
                             var lb='<%=table.Rows[j]["MaDMA"]%>';
                                                            
                           var marker<%=f%> = new google.maps.Marker({
				              position: latlng2,
                              icon: icon_, 
                              label: {text: lb, color: "blue", fontWeight: "bold",fontSize: "25px"},
				              map: map,
				              title: name<%=f%>
				              });
                           
                            marker<%=f%>.setMap(map);
             
                            var  infowindow4 = new google.maps.InfoWindow();


                              var iwContent="<table border=0 cellpadding=0 cellspacing=0> ";
                                  iwContent+="<tr><td style='color:red;'><b><%=table.Rows[j]["vCMP"]%> </b> bar </td></tr> ";
                                 
                                iwContent+="</table>";
                              infowindow4.setContent(iwContent);

				
                            infowindow4.open(map,marker<%=f%>);

                           
                        <%
                        }
                       }
            %>

            ////////////////////
           var layer = new google.maps.FusionTablesLayer({
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
           

                ////////////////////////
            <% 
                  
                       if(Session["dsDHtt"]!=null)
                       {
                        table = (DataTable)Session["dsDHtt"];
                        for(int j=0;j<table.Rows.Count;j++)
                        {
                            f++;
                        %>
                           var x = parseFloat(<%=table.Rows[j]["Lat"]%>);
                           var y = parseFloat(<%=table.Rows[j]["Lng"]%>);
                          // var latlng2 = new google.maps.LatLng(x, y);

                             var latlng2 = new google.maps.LatLng(x, y);

                             var name<%=f%> ='';

                             //var icon_='/Image/dhTong2.png';
                             var lb='<%=table.Rows[j]["MaDMA"]%>';
                                                            
                           var marker<%=f%> = new google.maps.Marker({
				              position: latlng2,
                              icon: {
                                    path: google.maps.SymbolPath.CIRCLE,
                                    fillColor: '#00F',
                                    fillOpacity: 0.6,
                                    strokeColor: '#00A',
                                    strokeOpacity: 0.9,
                                    strokeWeight: 1,
                                    scale: 2
                                }, 
                              label: {text: lb, color: "Red", fontWeight: "bold",fontSize: "12px"},
				              map: map,
				              title: name<%=f%>
				              });
                           
                            marker<%=f%>.setMap(map);


                           
                        <%
                        }
                       }
            %>


            ////////////////////

            // Try HTML5 geolocation.
       /*      var infoWindow = new google.maps.InfoWindow({map: map});
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

//                    var pos = {
//                      lat: position.coords.latitude,
//                      lng: position.coords.longitude
//                    };

//                    infoWindow.setPosition(pos);
//                    infoWindow.setContent('Location');
//                    map.setCenter(pos);


                  }, function() {
                    handleLocationError(true, infoWindow, map.getCenter());
                  });
                } else {
                  // Browser doesn't support Geolocation
                  handleLocationError(false, infoWindow, map.getCenter());
                }

                  */
             
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
                   
                   var newUrl="pageAddLocaiton.aspx?lat="+lagx+ "&lng=" + lagy+ "&madma=" + madma + "&loai=" + loai ; 
                   // alert(latlng);
                   document.location.href = newUrl;
                                    
                   // var newUrl="addBaoBee.aspx?lat="+lagx+ "&lng=" + lagy ;
                   // alert(latlng);
                   //document.location.href = newUrl;
                      
              }

    </script>
    
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBnK4XMpV0do1pWTYFGUydQvA_EyMkJ9xU&libraries=places&callback=initAutocomplete"         async defer></script>
  </body>

</asp:Content>
