<%@ Page Title="" Language="C#" MasterPageFile="~/Search.Master" AutoEventWireup="true" CodeBehind="searchGV.aspx.cs" Inherits="quanlythongtinSV.searchGV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="GV.css"  rel="stylesheet" type="text/css" />
    <asp:Label ID="lb1" runat="server" Text="Khoa" CssClass="lb"/>
    <asp:DropDownList ID="dr_khoa" runat="server" CssClass="t2" />
       <asp:Button ID="btn_loc" runat="server" Text="Lọc" OnClick="btn_loc_Click"  style="margin-right:10px"/>
    
   
     <asp:TextBox ID="txt_tim" runat="server" placeholder=" Nhập tên hoặc mã giảng viên " style="margin-left:70px" />  <br />
    
    <asp:Button ID="btn_tim" runat="server" Text="Tìm kiếm" OnClick="btn_tim_Click" style="margin-left:607px"/><br />
 

    <asp:GridView ID="grid_searchGV" runat="server" AutoGenerateColumns="False"  style="margin-left:105px"  >
        <Columns>
            <asp:BoundField DataField="magiangvien" HeaderText="Mã giảng viên" />
            <asp:BoundField DataField="tengiangvien" HeaderText="Họ và tên" />
            <asp:BoundField DataField="hocvi" HeaderText="Học vị" />
            <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
            <asp:BoundField DataField="tenkhoa" HeaderText="Khoa" />
        </Columns>
</asp:GridView>
    <asp:Button ID="btn_export" runat="server" Text="Export Excel" OnClick="btn_export_Click" style ="margin-left:585px"/>
</asp:Content>
