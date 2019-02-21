function CallService() {
    var webServiceURL = "http://thatman.connercodes.com/ZipService.asmx?op=GetZip";
    var soapMessage = `<?xml version="1.0" encoding="utf-8"?><soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://www.w3.org/2003/05/soap-envelope"><soap12:Body><GetZip xmlns="http://thatman.connercodes.com/ZipService"><zip>${ document.getElementById("zip").value }</zip></GetZip></soap12:Body></soap12:Envelope>`;

    $.ajax({
        url: webServiceURL,
        type: "POST",
        dataType: "xml",
        data: soapMessage,
        processData: false,
        contentType: "text/xml; charset=\"utf-8\"",
        success: OnSuccess,
        error: OnError
    });
}

function OnSuccess(data, status) {
    var zipResponseTag = data.getElementsByTagName("GetZipResponse").item(0);
    var zipResultTag = zipResponseTag.getElementsByTagName("GetZipResult").item(0);
    document.getElementById("resultZip").innerText = zipResultTag.innerHTML;
}

function OnError(request, status, error) {
    alert('error');
}

$(document).ready(function () {
    jQuery.support.cors = true;
});