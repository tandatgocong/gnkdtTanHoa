<%@ Page Title="-jhj" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDoBeDMA.aspx.cs" Inherits="GiamNuocWeb.pageDMADoBe" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "";
     window.document.getElementById("SANLUONG").className = "";
     window.document.getElementById("LUULUONG").className = "";
     window.document.getElementById("DHT").className = "active";
     window.document.getElementById("APLUC").className = "";
     window.document.getElementById("THATTHOAT").className = ""; 

</script>
<style>
.aaa{
    /*width: 431px;
    height: 317px; */
    width: 317px;
    height: 431px;  
  
    /*-ms-transform: rotate(90deg);  
    -webkit-transform: rotate(90deg);  
    transform: rotate(90deg);*/
}
  
    
    .style1
    {
        width: 58px;
    }
    .style2
    {
        width: 59px;
    }
    .style3
    {
        width: 435px;
    }
    .style4
    {
        width: 41px;
    }
    .style5
    {
        width: 543px;
    }
    .style7
    {
        width: 30px;
        height: 30px;
    }
    .style10
    {
        width: 30px;
        height: 34px;
    }
    .style11
    {
        height: 34px;
        width: 17px;
    }
    .style12
    {
        width: 30px;
    }
    .style15
    {
        width: 30px;
        height: 31px;
    }
    .style16
    {
        height: 31px;
        width: 133px;
    }
    .style17
    {
        height: 31px;
        width: 646px;
    }
    .style18
    {
        width: 30px;
        height: 20px;
    }
    .style19
    {
        height: 30px;
    }
    .style20
    {
        height: 30px;
        width: 646px;
    }
    .style22
    {
        width: 646px;
    }
  
    
    .style23
    {
        width: 60px;
    }
    .style24
    {
        width: 73px;
    }
  
    
    .style25
    {
        height: 30px;
        width: 133px;
    }
    .style26
    {
        width: 133px;
    }
  
    
</style>
<style>
        img {
            cursor: pointer;
            transition: -webkit-transform 0.1s ease
        }
    img:focus {
        -webkit-transform: scale(3);
        -ms-transform: scale(3);
        text-align:center;
        vertical-align:middle;
        margin:300px;
    }
    front {
  border:3px solid #c00;
  background-color:#fff;
  width:300px;
  position:absolute;
  z-index:10;
  top:30px;
  left:50px;
 }
 
</style>

     <table style="height:30px;"><tr><td> <div class="title_page2">CHỌN DMA : 
                        <asp:DropDownList ID="listDMA" runat="server" Height="24px" 
           Width="67px" onselectedindexchanged="listDMA_SelectedIndexChanged" 
           AutoPostBack="True">
                        </asp:DropDownList>
                    </div></td></tr></table>
      <asp:Panel ID="Panel1" runat="server" Height="600px" ScrollBars="Both">

                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="334px" Font-Size="X-Large">
                        <Columns>
                            <asp:BoundField DataField="TenNHom" HeaderText="Nhóm Dò" />
                            <asp:TemplateField HeaderText="Ngày">
                              <ItemTemplate >
                                   <asp:Label ID="lblFromDate" runat="server" 
                                             
                                              HtmlEncode="false"  
                                              Text='<%#Eval("NgayBatDau", "{0:dd/MM/yyyy}") %>' />
                                    </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                  </asp:GridView>
</asp:Panel>
</asp:Content>
