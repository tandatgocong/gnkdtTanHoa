<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDongHoTong.aspx.cs" Inherits="GiamNuocWeb.pageDongHoTong" %>
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
    -ms-transform: rotate(90deg); /* IE 9 */
    -webkit-transform: rotate(90deg); /* Safari 3-8 */
    transform: rotate(90deg);
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
    .style6
    {
        border: 1px #669966 dotted;
        width: 824px;
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
    .style21
    {
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

    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <table >           

            <tr  >
                <td class="style3" colspan="3">
                    <div class="title_page2"> MÃ DMA : 
                        <asp:DropDownList ID="listDMA" runat="server" Height="27px" Width="115px" 
                            AutoPostBack="True" onselectedindexchanged="listDMA_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>

            <tr>
                <td class="style3" colspan="3"  >
                    <div class="title_page">
                        THÔNG TIN đỒNG HỒ</div>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    </td>
                <td class="style25" 
                    style="border-bottom: 1px #99cc99 solid; ">
                    Vị Trí DHT</td>
                <td class="style20" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtViTri" runat="server" Height="27px" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style25" 
                    style="border-bottom: 1px #99cc99 solid; ">
                    Vị Trí CMP</td>
                <td class="style20" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtViTriCMP" runat="server" Height="27px" Width="248px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style25" 
                    style="border-bottom: 1px #99cc99 solid; ">
                                Phường</td>
                <td class="style20" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtPhuong" runat="server" Height="27px" Width="152px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style25" 
                    style="border-bottom: 1px #99cc99 solid; ">
                                Quận</td>
                <td class="style20" style="border-bottom: 0px #99cc99 solid; ">
                    <asp:TextBox ID="txtQuan" runat="server" Height="27px" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style65" 
                    style="border-bottom: 1px #99cc99 solid; height: 30px;" colspan="2">
                    <table border="0" cellpadding="0" cellpadding="0" style="width:100%;">
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label16" runat="server" Text="Cở ĐHN:"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="txtCoDHN0" runat="server" Height="27px" Width="90px"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Label ID="Label17" runat="server" Text="Hiệu :"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="txtHieuDHN0" runat="server" Height="27px" Width="91px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style19" 
                    style="border-bottom: 1px #99cc99 solid; " colspan="2">
                    <table border="0" cellpadding="0" cellpadding="0" style="width:100%;">
                        <tr>
                            <td class="style23">
                                <asp:Label ID="Label14" runat="server" Text="Thiết bị:"></asp:Label>
                            </td>
                            <td style="width: 4px">
                                <asp:TextBox ID="txtThietBi" runat="server" Height="27px" Width="81px"></asp:TextBox>
                            </td>
                            <td class="style24">
                                Pin Nguồn</td>
                            <td>
                                <asp:DropDownList ID="cmpPinNguon" runat="server" Height="36px" Width="107px">
                                    <asp:ListItem Value="Pin ắc quy">Pin ắc quy</asp:ListItem>
                                    <asp:ListItem Value="Pin ABB">Pin ABB</asp:ListItem>
                                    <asp:ListItem>Pin Isomag</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    </td>
                <td colspan=2 class="style67" 
                    style="border-bottom: 1px #99cc99 solid; height: 34px;">
                     <table border="0" cellpadding="0" cellpadding="0" >
                        <tr>
                            <td>
                    <asp:Label ID="Label3" runat="server" 
                        Text="PRV :"></asp:Label>
                            &nbsp;</td>
                            <td class="style62" style="width: 56px">
                                <asp:DropDownList ID="prv" runat="server" Height="31px" Width="71px">
                                    <asp:ListItem Value="True">Có</asp:ListItem>
                                    <asp:ListItem Value="False">Không</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style62" style="width: 88px">
                    <asp:Label ID="Label4" runat="server" 
                        Text="Hầm ĐHT :"></asp:Label>
                            </td>
                            <td style="width: 56px">
                                <asp:DropDownList ID="hamdht" runat="server" Height="31px" Width="69px">
                                    <asp:ListItem Value="Có">Có</asp:ListItem>
                                    <asp:ListItem Value="Không">Không</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            </table>
                </td>
                <td class="style11">
                    </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style25" 
                    style="border-bottom: 1px #99cc99 solid; ">
                                Tình trạng PRV</td>
                <td class="style20" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtTinhTrangPRV" runat="server" Height="27px" Width="152px"></asp:TextBox>
                
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style25" 
                    style="border-bottom: 1px #99cc99 solid; ">
                                Tình trạng ĐHT :</td>
                <td class="style20" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtTinhTrangDHT" runat="server" Height="27px" Width="152px"></asp:TextBox>
                
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style25" 
                    style="border-bottom: 1px #99cc99 solid; ">
                    Tình trạng Blogger
                            </td>
                <td class="style20" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtTinhTrangBlogger" runat="server" Height="27px" Width="152px"></asp:TextBox>
                
                </td>
            </tr>
            <tr>
                <td class="style7">
                    </td>
                <td class="style25" 
                    style="border-bottom: 1px #99cc99 solid; ">
                    <asp:Label ID="Label15" runat="server" 
                        Text="Số Sim:"></asp:Label>
                            </td>
                <td class="style20" style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtSoSim" runat="server" 
                        Height="27px" Width="153px"></asp:TextBox>
                
                </td>
            </tr>
               <tr>
                <td class="style18">
                    </td>
                <td class="title_mobile"  colspan="2"  
                    style="border-bottom: 1px  #FF0000 solid; background-color: #FFFF99; " colspan="2"> Hình Ảnh ĐHT</td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;</td>
                <td   colspan="2"> <div>
                   
                  <%
                            if (Session["imgfile"] != null)
                            {
                                string filelis = Session["imgfile"].ToString();
                                string[] words = Regex.Split(filelis, ",");
                                for (int i = 0; i < words.Length; i++)
                                {
                                    if (!words[i].Equals(""))
                                    {
                                        Response.Write("<img class='aaa'   src=" + words[i] + " /> <br/> ");
                                    }

                                }
                            }
                  %>
                   

              <asp:Image ID="imgFile" runat="server"  Visible="False" />
              </div>                 
              </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style26">
                    Chọn Hình</td>
                <td class="style22">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    <asp:Button ID="btUpload" runat="server" onclick="Button1_Click" 
                        CssClass="button"  Text="Upload" 
                        ValidationGroup="adsfdsafd" Visible="False" />
                    <asp:Button ID="btClear" runat="server" onclick="Button2_Click1" 
                        CssClass="button"  Text="Clear" 
                        ValidationGroup="adsfdsafd" Visible="False" />
                    <asp:HiddenField ID="imagePath" runat="server" />
                    <asp:Label ID="upload" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="border-bottom: 1px #99cc99 solid; ">
                <td class="style15">
                    </td>
                <td class="style16"  
                    style="border-bottom: 1px #99cc99 solid; ">
                    Sự cố</td>
                <td class="style17"  style="border-bottom: 1px #99cc99 solid; ">
                    <asp:TextBox ID="txtNoiDung" runat="server" Height="69px" TextMode="MultiLine" 
                        Width="235px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style26">
                    </td>
                <td class="style22">
                    <asp:Button ID="btSearch" runat="server" CssClass="button" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="12pt" Height="30px" 
                        onclick="btSearch_Click" Text="CẬP NHẬT" Width="115px" Visible="False" />
                    <br />
                    <asp:Label ID="lbThanhCong" runat="server" ForeColor="Blue" Font-Bold="True" 
                        Font-Size="13pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style22">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style18">
                    </td>
                <td class="title_mobile"  colspan="2"  
                    style="border-bottom: 1px  #FF0000 solid; background-color: #FFFF99; " 
                    colspan="2"> Lịch sử kiểm tra  ĐHT</td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style64" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="391px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CREATEDATE" HeaderText="Ngày Kiểm Tra">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="20px" 
                                Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOIDUNG" HeaderText="Nội Dung">
                            <ItemStyle Width="500px" Height="30px" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td class="style64" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
