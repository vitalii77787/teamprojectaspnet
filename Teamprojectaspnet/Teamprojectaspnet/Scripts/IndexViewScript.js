var map;
var lastopeninfoWindow = new google.maps.InfoWindow;
var markers = [];
var directionsDisplay;
var directionsService = new google.maps.DirectionsService();
var geocoder;
var currentposition;

$(document).ready(function () {
    SetMap();
});
function SetMap() {
    directionsDisplay = new google.maps.DirectionsRenderer({ suppressMarkers: true });
    google.maps.visualRefresh = true;
    var Rivne = new google.maps.LatLng(50.6231, 26.2274);
    var mapOptions = {
        zoom: 13,
        center: Rivne,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };
    map = new google.maps.Map(document.getElementById("canvas"), mapOptions);
    directionsDisplay.setMap(map);
    geocoder = new google.maps.Geocoder();
}
function GetMarkerTypes() {
    $.getJSON('@Url.Action("GetAllTypes","Home")', function (data) {
        $.each(data, function (i, item) {
            $("#markertypes").append("<option value=" + item + ">" + item + "</option>");
        });
    });
}
function ShowMarker() {
    var x = document.getElementById("markertypes").value;
    document.getElementById("currentmarkertype").textContent = "You selected: " + x;
}
function FindMarkers() {
    clearMarkers();
    var type = document.getElementById("markertypes").value;
    $.ajax
        ({
            type: "POST",
            url: "/Home/GetMarkersOfType",
            dataType: "json",
            data: { type: type },
            success: function (result) {
                for (var i = 0; i < result.length; i++) {
                    addMarkerWithTimeout(result[i], i * 200);
                }
            }
        });
}
function addMarkerWithTimeout(item, timeout) {
    window.setTimeout(function () {
        var newmarker = new google.maps.Marker({
            position: { lat: item.Lat, lng: item.Lng },
            map: map,
            animation: google.maps.Animation.DROP
        });
        newmarker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png');
        google.maps.event.addListener(newmarker, 'click', function () {
            closeLastOpenedInfoWindow();
            infoWindow = new google.maps.InfoWindow({
                content: "<div class='markerInfo'><div class='row'><div class='col-md-4 d-flex justify-content-center'>Name:</div><div class='col-md-8 d-flex justify-content-center'>" + item.Name + "</div></div><hr/><div class='row'><div class='col-md-4 d-flex justify-content-center'>Description:</div><div class='col-md-8 d-flex justify-content-center'>"
                    + item.Description + "</div></div><hr/><div class='row'><div class='col-md-4 d-flex justify-content-center'>Contacts:</div><div class='col-md-8 d-flex justify-content-center'> " + item.Contacts + "</div></div></div>"
            });
            infoWindow.open(map, newmarker);
            lastopeninfoWindow = infoWindow;
            if (currentposition) {
                calcRoute(currentposition, newmarker);
            }
        });
        markers.push(newmarker);
    }, timeout);
}
function clearMarkers() {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }
    markers = [];
}
function closeLastOpenedInfoWindow() {
    if (lastopeninfoWindow) {
        lastopeninfoWindow.close();
    }
}
function codeAddress() {
    if (currentposition)
    {
        currentposition.setMap(null);
        currentposition = null;
    }
    var address = document.getElementById('address').value;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === 'OK') {
            map.setCenter(results[0].geometry.location);
            var newmarker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
            currentposition = newmarker;
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}
function calcRoute(currentposition, newmarker) {
    var selectedMode = "WALKING";
    var request = {
        origin: currentposition.position,
        destination: newmarker.position,
        travelMode: google.maps.TravelMode[selectedMode]
    };
    directionsService.route(request, function (response, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(response);
        }
    });
}