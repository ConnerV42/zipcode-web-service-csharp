<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZipConsumer.aspx.cs" Inherits="ZipConsumer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Service Consumer</title>
    <script src="https://code.jquery.com/jquery-3.3.1.js"
            integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60="
            crossorigin="anonymous"></script>
    <script src="./js/JavaScript.js"></script>
</head>

<body>
    <h1>Zip Code Web Service Consumer</h1>

    <form id="form2">
        <div>
            Enter Zip: <input type="text" id="zip"/>
            <input type="button" value="Submit" onclick="CallService()" />
        </div>
    </form>

    <p id="resultZip"></p>

</body>
</html>
