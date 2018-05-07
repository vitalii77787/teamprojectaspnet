var map;
var markers = [];
$(document).ready(function () {
    SetMap();
});
function SetMap() {
    google.maps.visualRefresh = true;
    var Rivne = new google.maps.LatLng(50.6231, 26.2274);
    var mapOptions = {
        zoom: 13,
        center: Rivne,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };
    map = new google.maps.Map(document.getElementById("canvas"), mapOptions);
}
function GetMarkerTypes() {
    $.getJSON('@Url.Action("GetAllTypes","Home")', function (data) {
        $.each(data, function (i, item) {
            $("#markertypes").append("<option value=" + item + ">" + item + "</option>");
        });
    })
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
                //$.each(result, function (i, item) {
                //    var marker = new google.maps.Marker(
                //        {
                //            position: { lat: item.Lat, lng: item.Lng},
                //            map: map,
                //            animation: google.maps.Animation.DROP
                //        });
                //    markers.push(marker);
                //});
            },
        });
}
function addMarkerWithTimeout(item, timeout) {
    window.setTimeout(function () {
        var newmarker = new google.maps.Marker({
            position: { lat: item.Lat, lng: item.Lng },
            map: map,
            animation: google.maps.Animation.DROP
        });
        var infowindow = new google.maps.InfoWindow({
            content: "<div class='markerInfo'><div class='row'><div class='col-md-4 d-flex justify-content-center'>Name:</div><div class='col-md-8 d-flex justify-content-center'>" + item.Name + "</div></div><hr/><div class='row'><div class='col-md-4 d-flex justify-content-center'>Description:</div><div class='col-md-8 d-flex justify-content-center'>"
                + item.Description + "</div></div><hr/><div class='row'><div class='col-md-4 d-flex justify-content-center'>Contacts:</div><div class='col-md-8 d-flex justify-content-center'> " + item.Contacts + "</div></div></div>"
        });
        google.maps.event.addListener(newmarker, 'click', function () {
            infowindow.open(map, newmarker);
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