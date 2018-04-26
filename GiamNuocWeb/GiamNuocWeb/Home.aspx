<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GiamNuocWeb.Home1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    </style>

  <body>
    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
     <div id="map" style="width: 100%; height:100vh"></div>

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
                zoom: 15,
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
                           var x = parseFloat(<%=table.Rows[j]["lat"]%>);
                           var y = parseFloat(<%=table.Rows[j]["lng"]%>);
                          // var latlng2 = new google.maps.LatLng(x, y);

                             var latlng2 = new google.maps.LatLng(x, y);

                             var name<%=f%> =<%=table.Rows[j]["ID"]%>;

                             var icon_='/Image/dhTong2.png';
                             var lb='<%=table.Rows[j]["MaDma"]%>';
                                                            
                           var marker<%=f%> = new google.maps.Marker({
				              position: latlng2,
                              icon: icon_, 
                              label: {text: lb, color: "Red", fontWeight: "bold" },
				              map: map,
				              title: name<%=f%>
				              });
                           
                            marker<%=f%>.setMap(map);
             
                            var  infowindow3 = new google.maps.InfoWindow();


                              var iwContent="<table border=1 cellpadding=0 cellspacing=0> ";
                                 iwContent+="<tr> ";
                                 //iwContent+="<td  style='width:88px;height: 30px;' rowspan=2> Áp Lực&nbsp;</td>";
                                 <% 
                                    if((string)table.Rows[j]["F"]=="1")
                                    {%>
                                        iwContent+=" <td rowspan=2 style='width:60px;height: 30px; text-align: center;'><img width='50px' height='24px'  src='../Image/error.gif' /></td> ";
                                     <%}
                                     else  if((string)table.Rows[j]["F"]=="0")
                                     {%>
                                         iwContent+=" <td rowspan=2 style='width:60px;height: 30px; text-align: center;background-color:Yellow;font-size:x-large;color:Blue;font-weight:bold'><b><a target='_blank'  href='QuanLyDMA_Chart.aspx?value=<%=table.Rows[j]["IDApLuc"]%>'><%=table.Rows[j]["ApLuc"]%> </a></b></td> ";
                                     <%}
                                    else   
                                    {%>
                                      iwContent+=" <td rowspan=2 style='width:60px;height: 30px; text-align: center;font-size:x-large;color:Blue;font-weight:bold'><a target='_blank'  href='QuanLyDMA_Chart.aspx?value=<%=table.Rows[j]["IDApLuc"]%>'><%=table.Rows[j]["ApLuc"]%></td> ";
                                    <%}
                                 
                                 %>
                                 
                                // iwContent+=" <td style='width:60px;height: 15px; text-align: center;font-weight:bold'><%=table.Rows[j]["ApLucMin"]%></td> ";
                               //  iwContent+="</tr> ";
                              //   iwContent+="<tr><td style='width:60px;height: 15px; text-align: center;font-weight:bold'><%=table.Rows[j]["ApLucMax"]%></td> ";
                                 iwContent+=" </tr> ";
                           //      iwContent+=" <tr> ";
                           //      iwContent+="   <td style='width:88px;height: 30px;'>Lưu Lượng</td><td colspan=2 ";
                            //     iwContent+="        style='text-align: center'></td> ";
                            //     iwContent+="  </tr> ";
                                iwContent+="</table>";
                              infowindow3.setContent(iwContent);

				
                            infowindow3.open(map,marker<%=f%>);

                           
                        <%
                        }
                       }
            %>





            ////////////////////

                var  infoWindow2 = new google.maps.InfoWindow();

                       // Event that closes the Info Window with a click on the map
                       google.maps.event.addListener(map, 'click', function() {
                          infoWindow2.close();
                       });

                     <% 
                        table = new DataTable();                       
                       if(Session["dsDongnuoc"]!=null)
                       {
                        table = (DataTable)Session["dsDongnuoc"];
                        for(int i=0;i<table.Rows.Count;i++)
                        {
                          f++;
                        %>
                           var x = parseFloat(<%=table.Rows[i]["lat"]%>);
                           var y = parseFloat(<%=table.Rows[i]["lng"]%>);
                          // var latlng2 = new google.maps.LatLng(x, y);

                             var latlng2 = new google.maps.LatLng(x, y);
                             var name<%=f%> =<%=table.Rows[i]["ID"]%>;
                              var col='#FF0000';                            
                             <% if("False".Equals(table.Rows[i]["Loai"].ToString()))
                                {
                                 %> 
                                  col='#FFFF00';  
                                 <%
                                }           
                                %>

                             var cityCircle = new google.maps.Circle({
                                strokeColor: '#FF0000',
                                strokeOpacity: 0.8,
                                strokeWeight: 2,
                                fillColor: col,
                                fillOpacity: 0.35,
                                map: map,
                                center: latlng2,
                                radius: 200
                              });

                              var marker<%=f%> = new google.maps.Marker({
				              position: latlng2,
				              map: map,
				              title: name<%=f%>
				              });

                          google.maps.event.addListener(marker<%=f%>, 'click', function() {
                              // Creating the content to be inserted in the infowindow
                          var iwContent="<div class='title_page'>Thông Tin  <%=table.Rows[i]["F"]%> </div> <br/> " ;
                          iwContent+="<table  style='height:100px; colspan='2' align='center'><tr><td colspan='2' align='center'> </td></tr>";
                          iwContent+="<tr style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; hight:100px; width:400px;'>&nbsp;Địa chỉ :<b>  <%=table.Rows[i]["DiaChi"]%> </b></> &nbsp; </b> &nbsp;</td></tr>";
                          iwContent+="<tr  style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;Đóng nước Từ Ngày :<b>  <%=table.Rows[i]["TuNgay"]%> </b></> &nbsp;   Đến Ngày : <b><%=table.Rows[i]["DenNgay"]%></b> &nbsp;</td></tr>";
                          iwContent+="<tr  style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;Từ Giờ : <b><%=table.Rows[i]["TuGio"]%></b> &nbsp;  Đến Giờ : <b><%=table.Rows[i]["DenGio"]%></b>    &nbsp;</td></tr>";
                          iwContent+="<tr  style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp; Nội Dung : <%=table.Rows[i]["NoiDung"]%> &nbsp;</td></tr>";
                          iwContent+="<tr  style=' height: 35px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;<input type='button' class='button'  value='Mở Nước' onclick='monuoc(<%=table.Rows[i]["ID"]%>);'/> </td></tr>";
                          iwContent+="</table>";
                              // including content to the Info Window.
                              infoWindow2.setContent(iwContent);

                              // opening the Info Window in the current map and at the current marker location.
                              infoWindow2.open(map, marker<%=f%>);
                           }); 
                           
                        <%
                        }
                       }
                    %>

           
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
    

    </script>
    
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBnK4XMpV0do1pWTYFGUydQvA_EyMkJ9xU&libraries=places&callback=initAutocomplete"         async defer></script>
  </body>

</asp:Content>
