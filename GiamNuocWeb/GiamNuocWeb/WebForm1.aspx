<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GiamNuocWeb.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <style type="text/css">
        .style1
        {
            width: 70px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
    
        <table style="width:100%;">
            <tr>
                <td class="style1" rowspan="2">
                    &nbsp;</td>
                <td>
                    d</td>
                <td>
                    d</td>
            </tr>
            <tr>
                <td>
                    d</td>
                <td>
                    d</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="334px" Font-Size="X-Large">
                        <Columns>
                            <asp:BoundField DataField="TenNHom" HeaderText="Nhóm Dò" />
                            <asp:TemplateField HeaderText="Ngày">
                              <ItemTemplate >
                                   <asp:Label ID="lblFromDate" runat="server" 
                                              DataFormatString="{0:dd/MM/yyyy}" 
                                              HtmlEncode="false"  
                                              Text='<%# Eval("NgayBatDau") %>' />
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
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
        
    
    </div>
    </form>
</body>
</html>
