<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDBBaoBe.aspx.cs" Inherits="GiamNuocWeb.pageDoBeBaoBe" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="GiamNuocWeb.Class" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="css/style22.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        window.document.getElementById("DOBE").className = "dropdown active ";

</script>
  <style>
 .title_mobile
          {
        border-bottom: 2px solid #663300;
        color: #006600;
        font-family: Tahoma,Arial,Helvetica,sans-serif;
        font-size: 13px;
        font-weight: bold;
        margin: 0 10px;
        padding: 5px 0;
        text-transform: uppercase;
    }      
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
          border-bottom: 1px #99cc99 solid; 
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
                        url: '<%=ResolveUrl("~/pageDBBaoBe.aspx/GetCustomers") %>',
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
 <asp:RadioButtonList ID="RadioButtonList1" runat="server"  Width="280px" AutoPostBack="true"
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">Thêm Mới</asp:ListItem>
                <asp:ListItem Value="1">Chuyển ĐB</asp:ListItem>
                <asp:ListItem Value="2">Theo dõi</asp:ListItem>
</asp:RadioButtonList>

 <asp:Panel ID="pThemMoi" runat="server" Height="500px" ScrollBars="Both">   
  <div class='title_page'>THÊM MỚI ĐIỂM BỂ</div>
  <div style="margin-left:10px;">
          
          <table  >
            <tr>
                <td class="style3">
                    <asp:Label ID="IDBB" runat="server" Text="" Visible=false></asp:Label>
                    Nhóm Dò Bể                    
                </td>
                <td class="style3" >
                    <asp:DropDownList ID="cbNhomDB" runat="server">                      
                    </asp:DropDownList>                   
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Tình trạng
                    
                </td>
                <td class="style3" >
                    <asp:DropDownList ID="cbTinhTrang" runat="server">
                        <asp:ListItem Value="KTB">KTB</asp:ListItem>
                        <asp:ListItem Value="ĐĐS">Bể ĐĐS</asp:ListItem>
                    </asp:DropDownList>                   
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Số nhà</td>
                <td class="style3" >
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
                <td class="style3">
                    Kết Cấu Lề </td>
                     <td class="style3" >
                     <asp:DropDownList ID="cbKetCauLe" runat="server"> 
                         <asp:ListItem Value="KH">Không</asp:ListItem>
                         <asp:ListItem Value="BTXM">BTXM</asp:ListItem>
                         <asp:ListItem Value="GACH">Gạch</asp:ListItem>
                         <asp:ListItem Value="DA">Đá Hoa Cương</asp:ListItem>
                     </asp:DropDownList> </td>
            </tr>
             <tr>
                <td class="style3">
                    Kết Cấu Đường &nbsp;&nbsp;&nbsp;</td>
                     <td class="style3" > <asp:DropDownList ID="cbKetCauDuong" runat="server"> 
                         <asp:ListItem Value="KH">Không</asp:ListItem>
                         <asp:ListItem Value="NHUA">Nhựa</asp:ListItem>
                         <asp:ListItem Value="BTXM">BTXM</asp:ListItem>
                         <asp:ListItem Value="DAT">Đất</asp:ListItem>
                        </asp:DropDownList> </td>
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
                    <asp:TextBox ID="txtGhiChu" runat="server" Height="40px" TextMode="MultiLine" 
                        Width="216px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                  <td class="style2" colspan="2">
                      <asp:Button ID="btThen" runat="server" CssClass="button" Height="25px" 
                          onclick="btThen_Click" Text="Thêm Mới" Width="103px" />
                      <asp:Button ID="btBack" Visible=false runat="server"  onclientclick="if(confirm('Bạn có chắc chắn xóa điểm bể ?') == false)return false;"  CssClass="button" Height="25px" 
                          onclick="btBack_Click" Text="Xóa" Width="103px" />
                      <br />
                      <asp:Label ID="lbThanhCong" runat="server" ForeColor="Blue"></asp:Label>
                      <asp:Label ID="uploadfile" runat="server" ForeColor="Blue"></asp:Label>
                      </td>
              </tr>
        </table>
             <div style="border-right:1px #FF0000 solid; background-color:#FFFFCC; font-size:small; border-bottom: 2px #FF0000 solid"> 
             <asp:RadioButtonList ID="RadioButtonList2" runat="server"  Width="220px" AutoPostBack="true"
                onselectedindexchanged="RadioButtonList2_SelectedIndexChanged" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                <asp:ListItem Value="1">ĐĐS</asp:ListItem>
                <asp:ListItem Value="2">KTB</asp:ListItem>
              </asp:RadioButtonList>
             </div>

           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" Font-Size="Small" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px"  Width="100%"
                CellPadding="3" 
                style="text-align: center" onrowdatabound="GridView1_RowDataBound"  onrowcommand="GridView1_RowCommand"  >
                <Columns>
                    <asp:BoundField DataField="STT" HeaderText="STT">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle Width="40px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TenNhom" HeaderText="Nhóm ">
                    </asp:BoundField>
                     <asp:TemplateField HeaderText="Địa Chỉ">
                         <ItemTemplate>
                            <b> <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("ID") %>' CommandName="updateeee" Text='<%# Bind("DiaChi") %>'></asp:LinkButton> </b>
                         </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <div ID="popup">
                                <a href="#">Image<span>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# BIND("HinhAnh") %>' />
                                </span></a>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tình Trạng">
                        <ItemTemplate>
                            <asp:Button ID="btChuyenTT" runat="server" CommandArgument='<%# Bind("ID") %>' 
                                CommandName="chuyenTT" CssClass="buttonGir" 
                                onclientclick="if(confirm('Bạn có muốn chuyển Tình Trạng ?') == false)return false;" 
                                Text='<%# Bind("TinhTrang") %>' Width="100%" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                     <asp:BoundField DataField="KetCauLe" HeaderText="Kết Cấu Lề">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="KetCauDuong" HeaderText="Kết Cấu Đường">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NgayBao" HeaderText="Ngày Báo" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GhiChu" HeaderText="Ghi Chú" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Chuyển Thông Báo">                      
                        <ItemTemplate>
                               <asp:Button ID="btChuyenTB" CssClass=buttonGir runat="server" Width="100%" Text='<%# Bind("Chuyen") %>' Visible=false  CommandArgument='<%# Bind("ID") %>' CommandName="chuyenTB"   onclientclick="if(confirm('Bạn có muốn chuyển Thông Báo?') == false)return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </asp:Panel>

 <asp:Panel ID="pChuyen" runat="server" Visible="false" Height="700px" ScrollBars="Both">   
  <div class='title_page'>CHUYỂN ĐIỂM BỂ</div>
  </asp:Panel>

   <asp:Panel ID="PTheoDoi" runat="server" Visible="false"  Height="700px" ScrollBars="Both">   
  <div class='title_page'>Theo Dõi Chuyển ĐIỂM BỂ</div>
  </asp:Panel>

</asp:Content>
