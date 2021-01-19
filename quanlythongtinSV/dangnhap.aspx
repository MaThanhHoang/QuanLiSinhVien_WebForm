<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dangnhap.aspx.cs" Inherits="quanlythongtinSV.dangnhap" %>

<%@ Register Src="~/userDN.ascx" TagPrefix="uc1" TagName="userDN" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
       form{
           margin-top:65px;
           border-radius: 5px;
           width:350px;

           margin-left:430px;
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
        <img src="picture/logo.jpg" id="image" style="margin-left:125px;margin-top:10px" />
          
            <div>
        <uc1:userDN runat="server" id="userDN" />
    </div>
    
    </form>
</body>
</html>
