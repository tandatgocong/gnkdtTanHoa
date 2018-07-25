<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" Inherits="GiamNuocWeb.Home2" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        window.document.getElementById("HOME").className = "";
        window.document.getElementById("Li2").className = "";
        window.document.getElementById("SANLUONG").className = "";
        window.document.getElementById("LUULUONG").className = "";
        window.document.getElementById("DHT").className = "";
        window.document.getElementById("APLUC").className = "";
        window.document.getElementById("THATTHOAT").className = ""; 

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
    </style>

  <body>
  <table><tr><td>fdsa</td></tr></table>
    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
     <div id="map" style="width: 100%; height:75vh"></div>

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
            infowindow = new google.maps.InfoWindow();
                        var html = " <meta http-equiv='Content-Type' content='text/html; charset=utf-8' /><div class='title_page'>Nhập Thông Tin  </div> <br/> <table  >" +                                            
                         "<tr style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; hight:100px; width:80px;' >Loại</td> <td><select id='loai'>" +
                         "<option value='01' SELECTED> DHT </option>" +
                         "<option value='02' > CMP </option>" +                        
                          "</select> </td></tr>" +
                         "<tr style=' height: 30px; '><td style='border-bottom:1px; border-bottom-style:dotted; hight:100px; width:80px;'>DMA</td> <td><select id='madma'>" +
                         "<option value='01-01' SELECTED>01-01</option>" + "<option value='01-02'>01-02</option>" + "<option value='01-03'>01-03</option>" + "<option value='01-04'>01-04</option>" +
                         "<option value='02-01'>02-01</option>" + "<option value='02-02'>02-02</option>" + "<option value='02-03'>02-03</option>" + "<option value='02-04'>02-04</option>" + "<option value='02-05'>02-05</option>" +
                         "<option value='02-06'>02-06</option>" + "<option value='03-01'>03-01</option>" + "<option value='03-02'>03-02</option>" + "<option value='03-03'>03-03</option>" + "<option value='03-04'>03-04</option>" +
                         "<option value='03-05'>03-05</option>" + "<option value='03-06'>03-06</option>" + "<option value='03-07'>03-07</option>" + "<option value='03-08'>03-08</option>" + "<option value='03-09'>03-09</option>" +
                         "<option value='03-10'>03-10</option>" + "<option value='03-11'>03-11</option>" + "<option value='03-12'>03-12</option>" + "<option value='03-13'>03-13</option>" + "<option value='03-14'>03-14</option>" +
                         "<option value='04-01'>04-01</option>" + "<option value='04-02'>04-02</option>" + "<option value='04-03'>04-03</option>" + "<option value='04-04'>04-04</option>" + "<option value='04-05'>04-05</option>" +
                         "<option value='04-06'>04-06</option>" + "<option value='04-07'>04-07</option>" + "<option value='06-01'>06-01</option>" + "<option value='06-01A'>06-01A</option>" + "<option value='06-02'>06-02</option>" +
                         "<option value='06-03'>06-03</option>" + "<option value='06-04'>06-04</option>" + "<option value='07-01'>07-01</option>" + "<option value='07-02'>07-02</option>" + "<option value='07-03'>07-03</option>" +
                         "<option value='07-04'>07-04</option>" + "<option value='07-05'>07-05</option>" + "<option value='07-06'>07-06</option>" + "<option value='07-07'>07-07</option>" + "<option value='07-08'>07-08</option>" +
                         "<option value='07-09'>07-09</option>" + "<option value='07-09A'>07-09A</option>" + "<option value='07-10'>07-10</option>" + "<option value='08-01'>08-01</option>" + "<option value='08-02'>08-02</option>" +
                         "<option value='08-03'>08-03</option>" + "<option value='08-04'>08-04</option>" + "<option value='08-05'>08-05</option>" + "<option value='08-06'>08-06</option>" + "<option value='08-07'>08-07</option>" +
                         "<option value='08-08'>08-08</option>" + "<option value='08-09'>08-09</option>" + "<option value='08-10'>08-10</option>" + "<option value='08-11'>08-11</option>" + "<option value='08-12'>08-12</option>" +
                         "<option value='09-01'>09-01</option>" + "<option value='09-01A'>09-01A</option>" + "<option value='09-02'>09-02</option>" + "<option value='09-03'>09-03 </option>" + "<option value='09-04'>09-04</option>" +
                         "<option value='09-05'>09-05</option>" + "<option value='09-06'>09-06</option>" + "<option value='10-01'>10-01</option>" + "<option value='10-02'>10-02</option>" + "<option value='10-03'>10-03</option>" +
                         "<option value='10-04'>10-04</option>" + "<option value='10-05'>10-05</option>" + "<option value='10-06'>10-06</option>" + "<option value='10-07'>10-07</option>" + "<option value='11-01'>11-01</option>" +
                         "<option value='11-02'>11-02</option>" + "<option value='11-03'>11-03 </option>" + "<option value='11-04'>11-04</option>" + "<option value='11-05'>11-05</option>" + "<option value='11-06'>11-06</option>" +
                         "<option value='11-07'>11-07</option>" + "<option value='11-08'>11-08</option>" + "<option value='11-09'>11-09</option>" + "<option value='11-10'>11-10</option>" + "<option value='11-11'>11-11</option>" +
                         "<option value='11-12'>11-12</option>" + "<option value='11-13'>11-13</option>" + "<option value='11-14'>11-14</option>" + "<option value='11-15'>11-15</option>" + "<option value='12-01'>12-01</option>" +
                         "<option value='12-02'>12-02</option>" + "<option value='12-03'>12-03</option>" + "<option value='12-04'>12-04</option>" + "<option value='12-05'>12-05</option>" + 
                         "</select> </td></tr>" + 
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
                            lagx=marker.getPosition().lat(),
                            lagy=marker.getPosition().lng()
                        });
                    });
                     


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
