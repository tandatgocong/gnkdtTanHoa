<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="mBaoBeAdd.aspx.cs" Inherits="WebMobile.mBaoBeAdd" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="WebMobile.Class" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
      window.document.getElementById("HOME").className = "";
      window.document.getElementById("BAOBE").className = "active";
      window.document.getElementById("HOANCONG").className = "";
      window.document.getElementById("BAOCAO").className = "";
  </script>
  <style>
 div.title_page 
    {
        margin-top:10px;
        margin-left:10px;
        border-bottom: 2px solid #663300;
        color: #006600;
        font-family: Tahoma,Arial,Helvetica,sans-serif;
        font-size: 14px;
        font-weight: bold;
        text-transform: uppercase;
    }
    
        .style1
        {
            height: 25px;
        }
        
    
      .style2
      {
          height: 43px;
      }
        
    
      .style3
      {
          height: 29px;
      }
      .style4
      {
          height: 30px;
      }
      .style5
      {
          height: 31px;
      }
        
    
  </style>
    <script src="JavaScript/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="JavaScript/jquery-ui.min.js" type="text/javascript"></script>
    <link href="JavaScript/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtDuong]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/mBaoBeAdd.aspx/GetCustomers") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfTenDuong]").val(i.item.val);
                },
                minLength: 1
            });
        });   
    </script>   
 
<asp:Panel ID="Panel2" runat="server"   Width="100%">    
  <div class='title_page'>THÊM MỚI ĐIỂM BỂ</div>
  <div style="margin-left:10px;">
          <table>
            <tr>
                <td> &nbsp;</td>
            </tr>
          </table>

          <table style="width:100%;" >
            <tr>
                <td class="style5">
                    Loại Bể
                    
                </td>
                <td class="style5" >
                    <asp:DropDownList ID="cbLoaiBe" runat="server">
                        <asp:ListItem>Bể Ngầm</asp:ListItem>
                        <asp:ListItem>Bể Nổi</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="txtLat" runat="server"/>
                    <asp:HiddenField ID="txtLng" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Số nhà</td>
                <td class="style5"  >
                    <asp:TextBox ID="txtSoNha" runat="server" Height="25px" Width="204px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Đường</td>
                <td class="style3" >
                    <asp:TextBox ID="txtDuong" runat="server" Height="25px" Width="203px"></asp:TextBox>

                   
                    <asp:HiddenField ID="hfTenDuong" runat="server" />

                   
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Phường</td>
                <td class="style4"  >
                    <asp:DropDownList ID="cbPhuong" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Quận</td>
                <td class="style4">
                    <asp:DropDownList ID="cbQuan" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Mã DMA</td>
                <td class="style4">
                    <asp:DropDownList ID="cbMaDMA" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
              <tr>
                  <td class="style4">
                      SĐT</td>
                  <td class="style4">
                      <asp:TextBox ID="txtSoDT" runat="server" Height="25px" Width="204px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td class="style3">
                      Hình Ảnh</td>
                  <td class="style3">
                      <asp:FileUpload ID="FileUpload1" runat="server" />
                      <asp:HiddenField ID="imagePath" runat="server" />
                  </td>
              </tr>
            <tr>
                <td class="style1">
                    Ghi Chú</td>
                <td>
                    <asp:TextBox ID="txtGhiChu" runat="server" Height="78px" TextMode="MultiLine" 
                        Width="216px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                  <td class="style2" colspan="2">
                      <br />
                      <asp:Button ID="btThen" runat="server" CssClass="button" Height="25px" 
                          onclick="btThen_Click" Text="Thêm Mới" Width="103px" />
                      <asp:Button ID="btBack" runat="server" CssClass="button" Height="25px" 
                          onclick="btBack_Click" Text="Trở Lại" Width="103px" />
                      <br />
                      <asp:Label ID="lbThanhCong" runat="server" ForeColor="Blue"></asp:Label>
                      <asp:Label ID="uploadfile" runat="server" ForeColor="Blue"></asp:Label>
                      </td>
              </tr>
        </table>
  </div>
</asp:Panel>
    
</asp:Content>
