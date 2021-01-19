<%@ Page Title="" Language="C#" MasterPageFile="~/Search.Master" AutoEventWireup="true" CodeBehind="SearchSV.aspx.cs" Inherits="quanlythongtinSV.SearchSV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="TK.css" type="text/css" rel="stylesheet" />
    <asp:Label ID="lbl_1" runat="server" Text="Khoa" cssclass="lb1" />
    <asp:DropDownList ID="dr_khoa" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dr_khoa_SelectedIndexChanged"  cssclass="lb2">
    </asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Text="Chuyên ngành" cssclass="lb3" />
    <asp:DropDownList ID="dr_chuyennganh" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dr_chuyennganh_SelectedIndexChanged" cssclass="lb2" />
    <asp:Label ID="Label3" runat="server" Text="Khóa" cssclass="lb3" />
    <asp:DropDownList ID="dr_khoahoc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dr_khoahoc_SelectedIndexChanged" cssclass="lb2" />
    <asp:Label ID="Label2" runat="server" Text="Lớp" cssclass="lb3" />
    <asp:DropDownList ID="dr_lop" runat="server"  cssclass="lb3"/>
    <asp:Button ID="btn_loc" runat="server" Text="Lọc" OnClick="btn_loc_Click" /><br />
    <asp:TextBox ID="txt_tim" runat="server" placeholder=" Nhập tên hoặc mã sinh viên " cssclass="lb7" />
    <asp:Button ID="btn_tim" runat="server" Text="Tìm kiếm" OnClick="btn_tim_Click"  cssclass ="lb3"/>
    <br />
    <asp:GridView ID="grid_seacrhSV" runat="server" AutoGenerateColumns="False" style="margin-left:30px" >
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
    <asp:Button ID="btn_export" runat="server" Text="Export Excel" OnClick="btn_export_Click" cssclass="exSV" />

</asp:Content>
