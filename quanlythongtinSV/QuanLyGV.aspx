<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="QuanLyGV.aspx.cs" Inherits="quanlythongtinSV.QuanLyGV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="GV.css" rel="stylesheet" type="text/css" />
     <asp:Label ID="lb_1" Text="Mã giảng viên" runat="server" style="margin-left:20px;" />
    <asp:TextBox ID="txt_magv" runat="server" />
    <asp:Label ID="Label3" Text="Tên giảng viên" runat="server" style="margin-left:90px;" />
    <asp:TextBox ID="txt_tengv" runat="server" style="margin-left:10px"/>
    <asp:Label ID="Label4" Text="Khoa" runat="server" style="margin-left:30px;"/>
    <asp:DropDownList ID="dr_khoa" runat="server" /><br />
    <asp:Label ID="Label1" Text="Học vị" runat="server" style="position:relative;top:10px;margin-left:20px;"/>
    <asp:TextBox ID="txt_hocvi" runat="server" style="position:relative; left:47px;top:10px;" />
    <asp:Label ID="Label2" Text="Điện thoại" runat="server" style="position:relative;top:10px;margin-left:140px; margin-bottom:-40px"/>
    <asp:TextBox ID="txt_sdt" runat="server" style="position:relative;top:10px;margin-left:37px;" /><br />

    
    <asp:Button ID="btn_lammoi" runat="server" Text="Làm mới" OnClick="btn_lammoi_Click" style="position:relative;top:20px;left:390px" />
    <asp:Button ID="btn_capnhat" runat="server" Text="Thêm" OnClick="btn_capnhat_Click" style="position:relative;top:20px;left:450px" />
    <asp:Button ID="btn_sua" runat="server" Text="Cập nhật" OnClick="btn_sua_Click" style="position:relative;top:20px;left:520px"/> <br />
    <asp:Label ID="lbl_thongbao"  runat="server"  style="position:relative;top:35px;left:450px" /><br />
    <asp:TextBox ID="txt_tim" runat="server" placeholder=" Nhập tên hoặc mã lớp "  CssClass="lb1"/>
    <asp:Button ID="btn_tim" runat="server" Text="Tìm kiếm" OnClick="btn_tim_Click" CssClass="lb1_2"/>
    <asp:GridView ID="grid_gv" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grid_gv_SelectedIndexChanged" CssClass="grid_gv" >
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Chọn" ShowSelectButton="True" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btn_xoa" runat="server" Text="Xóa" OnClick="btn_xoa_Click" OnClientClick='return confirm("Bạn có muốn xóa không ?");' CommandArgument='<%# Eval("magiangvien") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="magiangvien" HeaderText="Mã giảng viên" />
            <asp:BoundField DataField="tengiangvien" HeaderText="Họ và tên" />
            <asp:BoundField DataField="hocvi" HeaderText="Học vị" />
            <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
            <asp:BoundField DataField="makhoa" HeaderText="Mã khoa" />
        </Columns>
    </asp:GridView>
</asp:Content>
