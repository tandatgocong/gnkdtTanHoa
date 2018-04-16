<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="mBaoCao.aspx.cs" Inherits="WebMobile.mBaoCao" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="WebMobile.Class" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"  %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
      window.document.getElementById("HOME").className = "";
      window.document.getElementById("BAOBE").className = "";
      window.document.getElementById("HOANCONG").className = "";
      window.document.getElementById("BAOCAO").className = "active";
  </script>
 <asp:Panel ID="Panel1" runat="server" >  
       <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManager1"  />     
 
 <table cellpadding="0" cellspacing="0" style="font-family:Times New Roman; margin-top:5px; margin-left:5px; margin-bottom:5px;" >
        <tbody>
           <tr>
               <td style="border-bottom:2px #99cc99 solid; " >&nbsp;Từ ngày:&nbsp;</td>
               <td style="border-bottom:2px #99cc99 solid; "><asp:TextBox ID="tungay" 
                       runat="server" autocomplete="off" Height="20px" Width="78px" />
               </td>
                <td style="border-bottom:2px #99cc99 solid; " >&nbsp;đến:&nbsp;</td>
                
               <td style="border-bottom:2px #99cc99 solid; ">
                   <asp:TextBox ID="denngay" runat="server" autocomplete="off" Height="20px" 
                       Width="78px" />
               </td>
               <td  
                   style="border-bottom:2px #99cc99 solid; font-size:10px; font-weight:normal;  ">
                   <asp:Button ID="btXemBangKe" runat="server" CssClass="button1" Height="27px" 
                       onclick="btXemBangKe_Click" Text="XEM" Width="61px" />
               </td>
               <td class="style7" 
                   
                   style="border-bottom:2px #99cc99 solid; font-size:10px; font-weight:normal; margin-left: 160px;">
                   
               </td>
             </tr>
             
            <tr>
                <td colspan="6" style="height:25px;">
                    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large" 
                        GridLines="Horizontal" Height="50px" style="margin-right: 5px" 
                        Width="323px">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <Fields>
                            <asp:TemplateField HeaderText="Tổng Điểm Bể ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Label1" runat="server" Text='<%# Bind("TONGCONG") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle BackColor="#CCFFCC" Font-Bold="True" Font-Size="X-Large" 
                                    ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm Bể Nổi">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Label2" runat="server" Text='<%# Bind("BENOI") %>' 
                                        ForeColor="Red"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Font-Size="X-Large" ForeColor="Red" HorizontalAlign="Center" 
                                    VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm Bể Ngầm">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Label3" runat="server" Text='<%# Bind("BENGAM") %>' 
                                        ForeColor="Red"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Font-Bold="True" Font-Size="X-Large" ForeColor="Red" 
                                    HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chưa Giao Sửa Bể">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Label4" runat="server" Text='<%# Bind("CHUAGIAO") %>' 
                                        ForeColor="Red"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Font-Size="X-Large" ForeColor="Red" HorizontalAlign="Center" 
                                    VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hoàn Tất Sửa Bể">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Label5" runat="server" Text='<%# Bind("DASUA") %>' 
                                        ForeColor="Red"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Font-Size="X-Large" ForeColor="Red" HorizontalAlign="Center" 
                                    VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chưa Sửa Bể">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Label6" runat="server" Text='<%# Bind("CHUASUA") %>' 
                                        ForeColor="Red"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Font-Size="X-Large" ForeColor="Red" HorizontalAlign="Center" 
                                    VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Điểm Bể Tồn">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Label7" runat="server" Text='<%# Bind("BETON") %>' 
                                        ForeColor="Red"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle BackColor="#FFFFCC" Font-Size="X-Large" ForeColor="Red" 
                                    HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                            </asp:TemplateField>
                        </Fields>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    </asp:DetailsView>
                </td>
            </tr>
             
          </tbody>
    </table>

       <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tungay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
         <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="denngay" Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>

</asp:Panel>
    
</asp:Content>
