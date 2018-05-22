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
   <table><tr><td> <div class="title_page2"> MÃ DMA : 
                        <asp:DropDownList ID="listDMA" runat="server" Height="27px" Width="115px" 
                            AutoPostBack="True" onselectedindexchanged="listDMA_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div></td></tr></table> 

    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
     <div id="map" style="width: 100%; height:80vh"></div>

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


                              var iwContent="<table border=1 cellpadding=0 cellspacing=0> ";
                                 iwContent+="<tr><td style='border-bottom:1px; border-bottom-style:dotted;'><b><%=table.Rows[j]["vLuuLuong"]%> </b> <img src='Image/m3h.gif'/></td></tr> ";
                                 iwContent+="<tr><td><b><%=table.Rows[j]["vApOut"]%> </b> kg </td></tr> ";
                                 
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


                              var iwContent="<table border=1 cellpadding=0 cellspacing=0> ";
                                  iwContent+="<tr><td><b><%=table.Rows[j]["vCMP"]%> </b> kg </td></tr> ";
                                 
                                iwContent+="</table>";
                              infowindow4.setContent(iwContent);

				
                            infowindow4.open(map,marker<%=f%>);

                           
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
