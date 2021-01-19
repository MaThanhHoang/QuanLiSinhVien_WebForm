<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userDN.ascx.cs" Inherits="quanlythongtinSV.userDN" %>
<style type="text/css">
    .auto-style1 {
        height: 26px;
    }
</style>
    <h1 align="center"><b>Đăng nhập</b></h1>
<table border="0" align="center">
            <tr>
                <td class="auto-style1">
                    <p>Tên đăng nhập </p>
                </td>
                <td class="auto-style1">
                    <asp:Textbox ID="txttaikhoan" runat="server"></asp:Textbox>
                </td>
            </tr>
            <tr>
                <td>
                    <p>Mật khẩu </p>
                </td>
                <td>
                     <asp:Textbox ID="txtmatkhau" runat="server" TextMode="Password"></asp:Textbox>
                </td>
                <tr>
                <td colspan="2" align="center">
                    <asp:HyperLink ID="hpl_dangky" runat="server" Text="Bạn chưa có tài khoản ?" NavigateUrl="DangKy.aspx" />
                </td>
            </tr>
                <tr>
                    <td colspan="2" align="center">
                           <asp:Button ID="bt_dangnhap" runat="server" Text="Đăng nhập" OnClick="bt_dangnhap_Click" />
                    </td>
                </tr>
            </tr>
        <tr>
                    <td colspan="2" align="center">
                           <asp:Label ID="lb_thongbao" runat="server" />
                    </td>
                </tr>
</table>
