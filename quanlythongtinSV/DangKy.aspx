<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="quanlythongtinSV.DangKy" %>

<%@ Register Src="~/userDK.ascx" TagPrefix="uc1" TagName="userDK" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        form{
            border-radius:5px;
           margin-top:45px;
           width:400px;
           height:500px;
           margin-left:420px;
           background-color:white;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
       }
       
       body{
           background-color:#EEEEEE;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <img src="picture/logo.jpg" style="margin-left:150px;margin-top:10px" />
    <div>
        <uc1:userDK runat="server" id="userDK" />
    </div>
    </form>
</body>
</html>
