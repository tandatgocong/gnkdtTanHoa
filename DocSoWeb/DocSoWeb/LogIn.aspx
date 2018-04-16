<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebMobile.Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
    
   <head>
      <LINK REL="SHORTCUT ICON"  HREF="Image/th.png">
      <title>.:.BÁO BỂ.:.</title>
       <link href="StyleSheet/style.css" rel="stylesheet" type="text/css" />
     
      <link rel="stylesheet" type="text/css" href="css/font-awesome.css"/>
      <link rel="stylesheet" type="text/css" href="css/animate.css"/>
      <!-- <link rel="shortcut icon" href="img/fav.ico" type="image/x-icon"/> --->
      <link href="https://fonts.googleapis.com/css?family=Montserrat:700" rel="stylesheet"/>
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <meta name="description" content="" />
      <meta name="keywords" content=" "/>
      <meta name="author" content="Shrinath Nayak">
      <meta name="robots" content="index, follow" />
       <style type="text/css">
           .style1
           {
               width: 15px;
               height: 40px;
           }
           .style2
           {
               width: 1366px;
               height: 40px;
           }
           .style3
           {
               width: 15px;
               height: 37px;
           }
           .style4
           {
               width: 1366px;
               height: 37px;
           }
       </style>
   </head>

   <body  >
     <form id="Form1"  runat="server" > 
      <!--Card-->
      <div class="card animated fadeIn" style="margin-top:10%">
        <div class="location">THÔNG TIN  ĐĂNG NHẬP </div> 
       <div class="text"> 
      <center>
    <table border="0"  style="width:30%;font-size: 14px; border-bottom: #ff0033 thick double;">
      
        <tr>
            <td valign="top" class="style3">
                <asp:Label ID="Label2" runat="server" Text="Tên đăng nhập :" Width="112px" 
                    style="text-align: right"></asp:Label></td>
            <td style="text-align: left;" valign="top" class="style4">
                <asp:TextBox ID="txtusername" runat="server" Width="159px">giamnuoc</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="(*)" ControlToValidate="txtusername" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="text-align: right;" valign="top" class="style1">
                <asp:Label ID="Label3" runat="server" Text="Mật khẩu  :" Width="80px"></asp:Label></td>
            <td style="text-align: left;" valign="top" class="style2">
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"
                    Width="159px">123</asp:TextBox>
                </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 35px">
                <asp:Button ID="Button1" runat="server"  Text="&nbsp;Đăng Nhập&nbsp;" Width="103px" 
                    onclick="Button1_Click" CssClass="button" Height="25px"/>
                <input id="Reset1" style="width: 95px" type="reset" value="Hủy bỏ" 
                    class="button" /><br />
                <br />
                <asp:Label ID="mess" runat="server" ForeColor="Red" 
                    Text="(*) Đăng Nhập Thất Bại" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
   </center>
      </div>
      </div>
    <p></p>
      <p></p>
      <p></p>
      <p></p>
      <p></p>
   </form>
      
   </body>
</html>
