<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="mHoanCong.aspx.cs" Inherits="WebMobile.mHoanCong" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="WebMobile.Class" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script language="javascript" type="text/javascript">
      window.document.getElementById("HOME").className = "";
      window.document.getElementById("BAOBE").className = "";
      window.document.getElementById("HOANCONG").className = "active";
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
     <div id="map" style="width: 100%; height: 100vh"></div>

    <script>
        var lagx=10.801433295748337;
        var lagy=106.65252816547981;
       
        // This example adds a search box to a map, using the Google Place Autocomplete
        // feature. People can enter geographical searches. The search box will return a
        // pick list containing a mix of places and predicted search terms.

        // This example requires the Places library. Include the libraries=places
        // parameter when you first load the API. For example:
        // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

        function initAutocomplete() {
                      
            var latlng = new google.maps.LatLng(lagx, lagy);
            var marker;
            var infowindow;
            var map = new google.maps.Map(document.getElementById('map'), {
                center: latlng,
                zoom: 15,
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
                          
                            
                             //var typeSua= parseInt(<%=table.Rows[i]["LoaiThucHien"]%>);                            
                             
                             var tinhtrang= parseInt(<%=table.Rows[i]["THUCHIEN"]%>);
                             var icon_='/Image/Marker.png';
                             var mau="#FF0000";
                             
                             /*if(tinhtrang==2)
                               { mau="#00FFFF"; icon_='/Image/MarkerSuaTam.png';} */
                            
                            
                           
                             if(tinhtrang==2)
                                { mau="#00FFFF"; icon_='/Image/MarkerSuaTam.png';}
                             
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
                              var iwContent="<div class='title_page'>Thông Tin  Báo Bể</div> " ;
                              iwContent+="<table style='font-family:Times New Roman; font-size: 15px'>";
                              iwContent+="<tr style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; hight:100px; width:400px;'>&nbsp;&nbsp;&nbsp;Địa chỉ :<b>  <%=table.Rows[i]["SoNha"]%> &nbsp; <%=table.Rows[i]["TenDuong"]%></b></> &nbsp; </b> &nbsp;</td></tr>";
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;Ngày Báo Bể :<b>  <%=table.Rows[i]["NgayBao"]%> </b></> &nbsp;  </td></tr>";                          
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;Ghi Chú Báo Bể : <%=table.Rows[i]["GhiChu"]%> &nbsp;</td></tr>";
                              iwContent+="</table> ";

                              iwContent+=" <div class='title_page'>Hoàn Công Sửa <%=table.Rows[i]["LoaiBao"]%>  </div> " ;                          
                              iwContent+="<table style='font-family:Times New Roman; font-size: 15px'>";
                              iwContent+="<tr  style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;Đơn Vị Sửa Bể :<b>  <%=table.Rows[i]["TenDonVi"]%> </b></> &nbsp;  </td></tr>";                          
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;Sửa Bể Từ Ngày :<b>  <%=table.Rows[i]["TuGio"]%> </b></> &nbsp; <br/>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; Đến  Ngày :<b>  <%=table.Rows[i]["DenGio"]%> </b></td></tr>";  
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;Thời Gian Sửa bể :<b>  <%=table.Rows[i]["GIO"]%><sup>h</sup> <%=table.Rows[i]["PHUT"]%> </b></>    </b></td></tr>";
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;Thời Gian Hoàn Tất Sửa bể :<b>  <%=table.Rows[i]["HGIO"]%><sup>h</sup> <%=table.Rows[i]["HPHUT"]%> </b></>    </b></td></tr>";
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;Ghi Chú Sửa Bể :<b>  <%=table.Rows[i]["KetQua"]%> </b></> &nbsp;  </td></tr>";                          
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;NV Giám Sát :<b>  <%=table.Rows[i]["NVGiamSat"]%> </b></> &nbsp;  </td></tr>";   
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;NV Sửa Bể :<b>  <%=table.Rows[i]["NVSuaBe"]%> </b></> &nbsp;  </td></tr>";   
                              iwContent+="<tr  style=' height: 25px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'>&nbsp;&nbsp;&nbsp;File Hoàn Công:<b>  <a target='_blank' href='<%=table.Rows[i]["FilePdf"]%>'>download</a>  </b></> &nbsp;  </td></tr>"; 
                              iwContent+=" <tr><td colspan='2' align='center' style='border-bottom:1px; border-bottom-style:dotted; height:120px; width:100px;'> <marquee behavior='scroll' SCROLLAMOUNT='20' direction='left' onmouseover='this.stop();' onmouseout='this.start();'> <%=filelis%> </marquee></td></tr>";
                             iwContent+="<tr  style=' height: 35px; '><td style='border-bottom:1px; border-bottom-style:dotted; width:400px;'> &nbsp; &nbsp; <input type='button' class='button' value='Cập Nhật Hoàn Công' onclick='hoancong(<%=table.Rows[i]["ID"]%>);'/> &nbsp; &nbsp; </td></tr>";
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
           
                var pos = {
                          lat: lagx,
                          lng: lagy
                        };
            <%  if (Request.QueryString["lng"] != null) {
                %>
                   pos = {
                          lat: <%=Request.QueryString["lat"] %>,
                          lng: <%=Request.QueryString["lng"] %>
                        };
                <%
                } %>
                
                map.setCenter(pos);

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
            function hoancong(id) {                
                var newUrl="mHoanCongAdd.aspx?id="+id ;
                 //  alert(newUrl);
                  document.location.href = newUrl ;
               }
           
    </script>
    
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBnK4XMpV0do1pWTYFGUydQvA_EyMkJ9xU&libraries=places&callback=initAutocomplete" async defer></script>
  </body>
</asp:Content>
