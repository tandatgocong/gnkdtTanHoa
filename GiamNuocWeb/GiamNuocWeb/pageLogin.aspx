<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageLogin.aspx.cs" Inherits="GiamNuocWeb.pageLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    <table border="0"  style="width:30%; border-bottom: #ff0033 thick double;">
        <tr>
            <td colspan="2">
                <table class="dangkytop" border="0" cellpadding="0" cellspacing="0" id="TABLE1">
                    <tr>
                        <td class="dkt1" style="height: 32px">
                        </td>
                        <td class="dkt2" style="width: 524px; height: 32px">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="THÔNG TIN ĐĂNG NHẬP"></asp:Label></td>
                        <td  class="dkt3" style="height: 32px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 15px; height: 21px" valign="top">
                <asp:Label ID="Label2" runat="server" Text="Tên đăng nhập :" Width="112px" 
                    style="text-align: right"></asp:Label></td>
            <td style="height: 30px; width: 1366px; text-align: left;" valign="top">
                <asp:TextBox ID="txtusername" runat="server" Width="159px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="(*)" ControlToValidate="txtusername" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 15px; text-align: right;" valign="top">
                <asp:Label ID="Label3" runat="server" Text="Mật khẩu  :" Width="80px"></asp:Label></td>
            <td style="width: 1366px; text-align: left;" valign="top">
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"
                    Width="159px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 35px">
                <asp:Button ID="Button1" runat="server"  Text="&nbsp;Đăng Nhập&nbsp;" Width="103px" 
                    onclick="Button1_Click" CssClass="button" Height="25px"/>
                &nbsp;&nbsp;&nbsp;
                <input id="Reset1" style="width: 95px" type="reset" value="Hủy bỏ" 
                    class="button" /><br />
                <br />
                <asp:Label ID="mess" runat="server" ForeColor="Red" 
                    Text="(*) Đăng Nhập Thất Bại" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
   </center>
</asp:Content>
