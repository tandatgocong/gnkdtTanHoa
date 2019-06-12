<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDBBaoBeXuatFile.aspx.cs" Inherits="GiamNuocWeb.pageDBBaoBeXuatFile" %>
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
        .style7
      {
          margin-left:5px;
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

        $(function () {
            $("[id$=txtSearch]").autocomplete({
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

<div style="border-right:1px #FF0000 solid; background-color:#FFFFCC; font-size:small; border-bottom: 2px #FF0000 solid; width:100%"> 

</div>



   <asp:Panel ID="PTheoDoi" runat="server" >   
  <table border="0" style="margin-top:10px;">
   <tr ><td class="style1">Nhóm Dò Bể </td><td>&nbsp;<asp:DropDownList ID="tdNhomDB" Width="150px" runat="server">                      
                    </asp:DropDownList>   </td></tr>
    <tr ><td class="style1">Từ Ngày  </td><td>&nbsp;<asp:TextBox ID="tNgay" runat="server" Width="150px" Height="20px" TextMode="Date"></asp:TextBox></td></tr>
    <tr><td class="style1">Đến Ngày </td><td>&nbsp;<asp:TextBox ID="dNgay" runat="server" Width="150px" Height="20px" TextMode="Date"></asp:TextBox></td></tr>
    <tr><td class="style1">Tình Trạng </td><td>&nbsp;<asp:DropDownList ID="tdTinhTrang" runat="server"  Width="150px" RepeatDirection="Horizontal">
                <asp:ListItem  Value="0">Tất Cả</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">ĐĐS</asp:ListItem>
                <asp:ListItem Value="2">KTB</asp:ListItem>
                <asp:ListItem Value="3">Hết Hạn KTB</asp:ListItem>
                <asp:ListItem Value="4">Điểm bể Ngầm</asp:ListItem>
                <asp:ListItem Value="5">Điểm bể Nổi</asp:ListItem>
              </asp:DropDownList>
    </td></tr>
    <tr><td class="style1"> </td><td>&nbsp;<asp:Button ID="THeoDoiDemB" runat="server" CssClass="button" Height="25px" onclick="THeoDoiDemB_Click" Text="Tra Cứu" Width="103px" />&nbsp;&nbsp;<asp:Button ID="btXuatFile" runat="server" CssClass="button" Height="25px" onclick="THeoDoiDemB2_Click" Text="Xuất File" Width="103px" /></td></tr>
</table>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Font-Size="Small" onrowdatabound="GridView2_RowDataBound"          
            style="text-align: center" Width="100%">
            <Columns>
                <asp:BoundField DataField="STT" HeaderText="STT">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="TenNhom" HeaderText="Nhóm " />
                <asp:TemplateField HeaderText="Địa Chỉ">
                    <ItemTemplate>
                        <b>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            CommandArgument='<%# Bind("ID") %>' CommandName="updateeee" 
                            Text='<%# Bind("DiaChi") %>'></asp:LinkButton>
                        </b>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="LoaiBe" HeaderText="Loại Bể" />
                <asp:TemplateField HeaderText="Tình Trạng">
                    <ItemTemplate>
                        <asp:Label ID="lbTinhTrang" runat="server"  Text='<%# Bind("TinhTrang") %>'></asp:Label>                        
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="KetCauLe" HeaderText="Kết Cấu Lề">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="KetCauDuong" HeaderText="Kết Cấu Đường">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="NgayBao" HeaderText="Ngày Báo">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Chuyển Thông Báo">
                    <ItemTemplate>
                       <asp:Label ID="lbChuyenTBB" runat="server"  Text='<%# Bind("Chuyen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ChuyenNgay" HeaderText="Ngày Chuyển" />
                 <asp:TemplateField HeaderText="Tự động xóa">
                    <ItemTemplate>
                       <asp:Label ID="AutoDel" runat="server"  Text='<%# Bind("AutoDel") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GhiChuu" HeaderText="Ghi Chú">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" Height="25px" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
 
 </asp:Panel>

</asp:Content>
