<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="thongkeAD.aspx.cs" Inherits="quanlythongtinSV.thongkeAD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="TK.css" rel="stylesheet" type="text/css"  />
    <asp:Label ID="lbl_1" runat="server" Text="Khoa" CssClass="lb1" />
    <asp:DropDownList ID="dr_khoa" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dr_khoa_SelectedIndexChanged" CssClass="lb2" />
    <asp:Label ID="Label1" runat="server" Text="Chuyên ngành" CssClass="lb3" />
    <asp:DropDownList ID="dr_chuyennganh" runat="server" CssClass="lb2"/>
     <asp:Label ID="Label3" runat="server" Text="Khóa" CssClass="lb3" />
    <asp:DropDownList ID="dr_khoahoc" runat="server" CssClass="lb2" /> 
    <asp:Button ID="btn_thongke" runat="server" Text="Thống kê" OnClick="btn_thongke_Click" CssClass="lb2" />
    <asp:GridView ID="grid_thongke" runat="server" style="margin-left:278px" />
</asp:Content>
