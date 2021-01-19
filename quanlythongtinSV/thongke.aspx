<%@ Page Title="" Language="C#" MasterPageFile="~/Search.Master" AutoEventWireup="true" CodeBehind="thongke.aspx.cs" Inherits="quanlythongtinSV.thongke" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label4" runat="server" Text="Tình trạng" />
    <asp:DropDownList ID="dr_tinhtrang" runat="server" />
    <asp:Button ID="btn_tinhtrang" runat="server" Text="Lọc" OnClick="btn_tinhtrang_Click" />
    <asp:GridView ID="grid_tinhtrangSV" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="masinhvien" HeaderText="Mã sinh viên" />
            <asp:BoundField DataField="tensinhvien" HeaderText="Họ và tên" />
            <asp:BoundField DataField="ngaysinh" HeaderText="Ngày sinh" />
            <asp:BoundField DataField="gioitinh" HeaderText="Giới tính" />
            <asp:BoundField DataField="diachi" HeaderText="Địa chỉ" />
            <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
            <asp:BoundField DataField="mota" HeaderText="Tình trạng" />
            <asp:BoundField DataField="tenlop" HeaderText="Lớp" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btn_export" runat="server" Text="Export Excel" OnClick="btn_export_Click"/>
</asp:Content>
