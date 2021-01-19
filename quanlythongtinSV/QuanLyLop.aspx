<%@ Page Title="" Language="C#" MasterPageFile="~/client.Master" AutoEventWireup="true" CodeBehind="QuanLyLop.aspx.cs" Inherits="quanlythongtinSV.quanlyLop1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="L.css" rel="stylesheet" type="text/css" />
    <asp:Label ID="lb_1" runat="server" Text="Mã lớp"  CssClass="lb1"/>
    <asp:TextBox ID="txt_malop" runat="server" CssClass="t1" />
    
    <asp:Label ID="Label2" runat="server" Text="Ngành học" CssClass="lb2" />
    <asp:DropDownList ID="dr_nganh" runat="server" CssClass="t2" /> 

     <asp:TextBox ID="txt_tim" runat="server" placeholder=" Nhập tên hoặc mã lớp "  CssClass="lb3"/>
    <asp:Button ID="btn_tim" runat="server" Text="Tìm kiếm" OnClick="btn_tim_Click" CssClass="lb3" />  <br />

    <asp:Label ID="Label1" runat="server" Text="Tên lớp"  CssClass="lb1" />
    <asp:TextBox ID="txt_tenlop" runat="server" CssClass="t3" />

    <asp:Label ID="Label3" runat="server" Text="Khóa" CssClass="lb2" />
    <asp:DropDownList ID="dr_khoahoc" runat="server" CssClass="t4" /> 

    
   

    <asp:Button ID="btn_lammoi" runat="server" Text="Làm mới" OnClick="btn_lammoi_Click" CssClass="lb3" />
    <asp:Button ID="btn_capnhat" runat="server" Text="Thêm" OnClick="btn_capnhat_Click"  CssClass="lb3"/>
    <asp:Button ID="btn_Sua" runat="server" Text="Sửa" OnClick="btn_Sua_Click"  CssClass="lb3"/><br />
     
       <asp:Label ID="lb_thongbao" runat="server" style="margin-left:580px" />
    <br />
    <asp:GridView ID="grid_lop" runat="server" OnSelectedIndexChanged="grid_lop_SelectedIndexChanged" AutoGenerateColumns="False" CssClass="grid_lop">
        <Columns>               
            <asp:CommandField ButtonType="Button" SelectText="Chọn" ShowSelectButton="True" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btn_xoa1" runat="server" OnClientClick='return confirm("Bạn có muốn xóa không ?");' Text="Xóa" OnClick="btn_xoa1_Click" CommandArgument='<%# Eval("malop") %>'  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="malop" HeaderText="Mã lớp" />
            <asp:BoundField DataField="tenlop" HeaderText="Tên lớp" />
            <asp:BoundField DataField="machuyennganh" HeaderText="Mã chuyên ngành" />
            <asp:BoundField DataField="makhoahoc" HeaderText="Khóa" />
        </Columns>
    </asp:GridView>
</asp:Content>
