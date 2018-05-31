<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageThatThoat.aspx.cs" Inherits="GiamNuocWeb.pageThatThoat" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script language="javascript" type="text/javascript">
      window.document.getElementById("HOME").className = "";
      window.document.getElementById("SANLUONG").className = "";
      window.document.getElementById("LUULUONG").className = "";
      window.document.getElementById("APLUC").className = "";
      window.document.getElementById("DHT").className = "";
      window.document.getElementById("THATTHOAT").className = "active"; 
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
            top:80px;
            z-index:999;
   
        }
    </style>

  <body>
   <asp:Panel ID="pBieuDoThatThoat" runat="server">
         <input id="pac-input" class="controls" type="text" placeholder="Search Box">
    <div id="map" style="width: 100%; height:75vh"></div>
    <div class=box>
     <table style="text-align:center">
            <tr>
                <td style="background-color:#00ffff; color:White">
                   < 10%&nbsp;</td>                 
                <td style="color:Blue; border-bottom: 1px ">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="background-color:#fce5cd; color:White">
                    10 -> 20%&nbsp;</td>
              <td>
                    &nbsp;</td>
                
            </tr>
            <tr>
                  <td style="background-color:#f6b26b; color:White">
                    20 -> 30%&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                  <td style="background-color:#b45f06; color:White">
                    30 -> 40%&nbsp;</td>
                <td>
                    &nbsp;</td>
               
            </tr>
             <tr>
                  <td style="background-color:#783f04; color:White">
                    40 -> 50%&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                  <td style="background-color:#ff00ff; color:White">
                   &nbsp;> 50%&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
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
            var latlng = new google.maps.LatLng(10.801433295748337, 106.65252816547981);
            var marker;
            var infowindow;
            var map = new google.maps.Map(document.getElementById('map'), {
                center: latlng,
                zoom: 14,
                mapTypeId: 'roadmap'
            });


            var layer = new google.maps.FusionTablesLayer({
            map: map,
            heatmap: { enabled: false },
            query: {
                select: "col2",
                from: "1Po-FrHOHDvBPvAFh4602Fy3CJXQbdrLmx8uQehiR",
                where: ""
            },
            options: {
                styleId: 2,
                templateId: 2
            }
        });
        layer.setMap(map);

         ////////////////////////
            <% 
                    int f=1;
                    DataTable   table = new DataTable();
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
                              label: {text: lb, color: "Red", fontWeight: "bold",fontSize: "13px"},
				              map: map,
				              title: name<%=f%>
				              });
                           
                            marker<%=f%>.setMap(map);


                           
                        <%
                        }
                       }
            %>


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
 
   </asp:Panel>
   
  </body>

</asp:Content>
