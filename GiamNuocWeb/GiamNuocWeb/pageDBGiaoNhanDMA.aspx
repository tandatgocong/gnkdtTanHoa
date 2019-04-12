<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDBGiaoNhanDMA.aspx.cs" Inherits="GiamNuocWeb.pageDBGiaoNhanDMA" %>
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
</style>
<div class='title_page'>GIAO DMA DÒ BỂ</div>
    <asp:Panel ID="Panel1" runat="server" Visible=false>
    
<div style="margin-left:10px; margin-top:10px;">
          
          <table>
            <tr>
                <td class="style33">                    
                    Nhóm Dò Bể                    
                </td>
                <td class="style3" >
                    <asp:DropDownList ID="cbNhomDB" runat="server">                      
                    </asp:DropDownList>                   
                </td>
            </tr>
            
            <tr>
                <td class="style3">
                    Mã DMA</td>
                <td class="style3" >               
                 <asp:DropDownList ID="cbMaDMA" runat="server" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Ngày bắt đầu</td>
                <td class="style3" >               
                 <asp:TextBox ID="NgayBatDau" runat="server" Width="150px" Height="20px" TextMode="Date"/>
                </td>
            </tr>
         
              <tr>
                  <td class="style2" colspan="2">
                      <asp:Button ID="btThen" runat="server" CssClass="button" Height="25px" 
                          onclick="btThen_Click" Text="Cập Nhật" Width="103px" />                     
                      <br />
                      <asp:Label ID="lbThanhCong" runat="server" ForeColor="Blue"></asp:Label>
                      <asp:Label ID="uploadfile" runat="server" ForeColor="Blue"></asp:Label>
                      </td>
              </tr>
        </table>
        </asp:Panel>
        </br>

  <div style="margin-left:10px;">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="STT" HeaderText="STT">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="TenNhom" HeaderText="Tên Nhóm">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="DMA" HeaderText="DMA Đang Dò">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="NgayBatDau" HeaderText="Ngày Nhận ">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" Height="35px" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:Button ID="btLogin" runat="server"  
                        CssClass="button"  Text="Login" 
                        ValidationGroup="adsfdsafd" Height="20px" PostBackUrl="~/pageLogin.aspx"  />
</div>
</asp:Content>
