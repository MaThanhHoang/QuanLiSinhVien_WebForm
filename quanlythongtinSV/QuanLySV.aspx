<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="QuanLySV.aspx.cs" Inherits="quanlythongtinSV.QuanLySV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="SV.css" type="text/css" rel="stylesheet" />
    <asp:Label ID="lb_msv" runat="server" CssClass="lb">Mã sinh viên</asp:Label>
    <asp:TextBox ID="txt_msv" runat="server" CssClass="t1"/>
    <asp:Label ID="Label1" runat="server" CssClass="lb">Họ và tên</asp:Label>
    <asp:TextBox ID="txt_hoten" runat="server" CssClass="t1"/>
    <asp:Label ID="Label2" runat="server" CssClass="lb">Ngày sinh</asp:Label>
    <asp:Label ID="lbl_ngaysinh" runat="server" Text="dd/MM/yyyy" />
    <asp:ImageButton ID="btn_image" runat="server" Height="19px" ImageUrl="~/picture/calendar.png" OnClick="btn_image_Click" style="position:relative;top:3px;" />
    <asp:Calendar ID="calender" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px"  OnSelectionChanged="calender_SelectionChanged" style="margin-left:865px;" >
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
     </asp:Calendar> <br />
    <asp:Label ID="Label4" runat="server" CssClass="lb">Địa chỉ</asp:Label>
    <asp:TextBox ID="txt_diachi" runat="server" CssClass="t2"/>
    <asp:Label ID="Label5" runat="server" CssClass="lb">Số điện thoại</asp:Label>
    <asp:TextBox ID="txt_phone" runat="server"/>
    <asp:Label ID="Label6" runat="server" CssClass="lb">Lớp</asp:Label>
    <asp:DropDownList ID="dr_lop" runat="server" /><br />
    
    
   
    <table style="margin-left:100px">
        <tr><td><asp:Label ID="Label3" runat="server">Giới tính</asp:Label></td>
        <td> <asp:RadioButtonList ID="list_RD" runat="server" CssClass="t1">
        <asp:ListItem Value="Nam" Selected ="True" Text="Nam"></asp:ListItem>
        <asp:ListItem Value="Nữ" Text="Nữ"></asp:ListItem>
    </asp:RadioButtonList></td>
        <td><asp:Label ID="Label7" runat="server" CssClass="lb" Text="Tình trạng"></asp:Label></td>
        <td><asp:RadioButtonList ID="list_tinhtrang" runat="server"  CssClass="t1">
        <asp:ListItem Value="TN" Text="Tốt nghiệp"></asp:ListItem>
        <asp:ListItem Value="CH" Text="Còn học" Selected ="True" ></asp:ListItem>
        <asp:ListItem Value="TH" Text="Thôi học"></asp:ListItem>
    </asp:RadioButtonList></td></tr>
    </table>
    <asp:FileUpload ID="upload_file" runat="server"  CssClass="lb"/>
    <asp:Button ID="btn_up" runat="server" Text="Đổ dữ liệu" OnClick="btn_up_Click" CssClass="lb" /> <br />
    
    <asp:Button ID="btn_lammoi" runat="server" Text="Làm mới" OnClick="btn_lammoi_Click"  CssClass="lb"/>
    <asp:Button ID="btn_capnhat" runat="server" Text="Thêm" OnClick="btn_capnhat_Click"  CssClass="lb"/>
    <asp:Button ID="btn_sua" runat="server" Text="Cập nhật" OnClick="btn_sua_Click" CssClass="lb" />
    <asp:TextBox ID="txt_tim" runat="server" placeholder=" Nhập tên hoặc mã sinh viên " CssClass="t4" />
    <asp:Button ID="btn_tim" runat="server" Text="Tìm kiếm" OnClick="btn_tim_Click" /> <br />
    <asp:Label ID="lb_thongbao" runat="server" style="margin-left:600px"/><br />
    <asp:GridView ID="grid_SV" runat="server" OnSelectedIndexChanged="grid_SV_SelectedIndexChanged" AutoGenerateColumns="False" CssClass="grid_sv" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btn_xoa" runat="server" OnClientClick='return confirm("Bạn có muốn xóa không ?");' Text="Xóa" CommandArgument='<%# Eval("masinhvien") %>' OnClick="btn_xoa_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btn_select" runat="server" OnClick="btn_select_Click" Text="Chọn" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="masinhvien" HeaderText="Mã sinh viên" />
            <asp:BoundField DataField="tensinhvien" HeaderText="Họ và tên" />
            <asp:BoundField DataField="ngaysinh" HeaderText="Ngày sinh" />
            <asp:BoundField DataField="gioitinh" HeaderText="Giới tính" />
            <asp:BoundField DataField="diachi" HeaderText="Địa chỉ" />
            <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
            <asp:BoundField DataField="matinhtrang" HeaderText=" Mã tình trạng" />
            <asp:BoundField DataField="malop" HeaderText="Mã lớp" />
        </Columns>
     </asp:GridView>
</asp:Content>
