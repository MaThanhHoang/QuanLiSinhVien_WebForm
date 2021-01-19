<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userDK.ascx.cs" Inherits="quanlythongtinSV.userDK" %>
<style type="text/css">
    .auto-style1 {
        height: 26px;
    }
</style>
    <h1 align="center"><b>Đăng ký</b></h1>
<table border="0" align="center">
            <tr>
                <td class="auto-style1">
                    <p>Tên đăng nhập  </p>
                </td>
                <td class="auto-style1">
                    <asp:Textbox ID="txttaikhoan" runat="server"></asp:Textbox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <p>Mật khẩu </p>
                </td>
                <td>
                     <asp:Textbox ID="txtmatkhau" runat="server" TextMode="Password"></asp:Textbox>
                </td>
                <tr>
                    <td>
                    <p class="auto-style1">Xác nhận mật khẩu </p>
                </td>
                <td>
                     <asp:Textbox ID="txtxacnhanmk" runat="server" TextMode="Password"></asp:Textbox>
                </td>
                   <tr />
                <td>
                    <p class="auto-style1">Quê quán </p>
                </td>
                <td>
                     <asp:Textbox ID="txtquequan" runat="server"></asp:Textbox>
                </td>
                <tr>
                    <td colspan="2" align="center">
                           <asp:Button ID="bt_dangky" runat="server" Text="Đăng ký" OnClick="bt_dangky_Click" />
                    </td>
                </tr>
                 <tr>
                     <td colspan="2" align="center">
                          <a href="dangnhap.aspx">Quay lại đăng nhập</a>
                    </td>
                 </tr>
            </tr>
        <tr>
                    <td colspan="2" align="center">
                           <asp:Label ID="lb_thongbaodk" runat="server" />
                    </td>
                </tr>
</table>

