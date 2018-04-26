<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="pageDongHoTong.aspx.cs" Inherits="GiamNuocWeb.pageDongHoTong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript" type="text/javascript">
     window.document.getElementById("HOME").className = "";
     window.document.getElementById("SANLUONG").className = "";
     window.document.getElementById("LUULUONG").className = "";
     window.document.getElementById("DHT").className = "active";
     window.document.getElementById("APLUC").className = "";
  </script>

    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <table class='table_list' style="width:100%;">           

            <tr  >
                <td class="style3">
                    &nbsp;</td>
                <td class="style3" colspan="3">
                    <div class="title_page2"> MÃ DMA : 
                        <asp:DropDownList ID="listDMA" runat="server" Height="27px" Width="115px" 
                            AutoPostBack="True" onselectedindexchanged="listDMA_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3" colspan="3"  >
                    <div class="title_page">
                        THÔNG TIN đỒNG HỒ</div>
                </td>
            </tr>
            <tr>
                <td class="style30" style="height: 37px">
                </td>
                <td class="style30" style="width: 53px; height: 37px;">
                    </td>
                <td class="style65" 
                    style="border-bottom: 1px #99cc99 solid; width: 71px; height: 37px;">
                    <asp:Label ID="Label4" runat="server" 
                        Text="Vị Trí:"></asp:Label>
                </td>
                <td class="style32" style="border-bottom: 1px #99cc99 solid; height: 37px;">
                    <asp:TextBox ID="txtViTri" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style33" style="height: 37px">
                    </td>
            </tr>
            <tr>
                <td class="style41" style="height: 39px">
                    </td>
                <td class="style41" style="width: 53px; height: 39px;">
                    </td>
                <td colspan=2 class="style67" 
                    style="border-bottom: 1px #99cc99 solid; height: 39px;">
                    <table border="0" cellpadding="0" cellpadding="0" style="width:100%;">
                        <tr>
                            <td class="style61" style="width: 68px">
                                Phường</td>
                            <td class="style62" style="width: 154px">
                    <asp:TextBox ID="txtPhuong" runat="server" Height="27px" Width="152px"></asp:TextBox>
                            </td>
                            <td class="style62" style="width: 45px">
                                Quận</td>
                            <td>
                    <asp:TextBox ID="txtQuan" runat="server" Height="27px" Width="188px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style43" style="height: 39px" >
                    
                </td>
                <td class="style44" style="height: 39px">
                    </td>
            </tr>
            <tr>
                <td class="style41" style="height: 38px">
                    </td>
                <td class="style41" style="width: 53px; height: 38px;">
                    </td>
                <td colspan=2 class="style67" 
                    style="border-bottom: 1px #99cc99 solid; height: 38px;">
                    <table border="0" cellpadding="0" cellpadding="0" style="width:100%;">
                        <tr>
                            <td class="style61" style="width: 75px">
                    <asp:Label ID="Label12" runat="server" 
                        Text="Cở ĐHN:"></asp:Label>
                            </td>
                            <td class="style62" style="width: 44px">
                    <asp:TextBox ID="txtCoDHN" runat="server" Height="27px" Width="59px"></asp:TextBox>
                            </td>
                            <td class="style62" style="width: 52px">
                    <asp:Label ID="Label13" runat="server" 
                        Text="Hiệu :"></asp:Label>
                            </td>
                            <td style="width: 59px">
                    <asp:TextBox ID="txtHieuDHN" runat="server" Height="27px" Width="87px"></asp:TextBox>
                            </td>
                            <td style="width: 69px">
                    <asp:Label ID="Label14" runat="server" 
                        Text="Thiết bị:"></asp:Label>
                            </td>
                            <td style="width: 4px">
                    <asp:TextBox ID="txtThietBi" runat="server" Height="27px" Width="81px"></asp:TextBox>
                            </td>
                            <td style="width: 89px">
                                Pin Nguồn</td>
                            <td>
                    <asp:TextBox ID="txtPinNguon" runat="server" Height="27px" Width="91px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style43" style="height: 38px" >
                    
                    </td>
                <td class="style44" style="height: 38px">
                    </td>
            </tr>
            <tr>
                <td class="style41" style="height: 35px">
                    </td>
                <td class="style41" style="width: 53px; height: 35px;">
                    </td>
                <td colspan=2 class="style67" 
                    style="border-bottom: 1px #99cc99 solid; height: 35px;">
                  <table border="0" cellpadding="0" cellpadding="0" style="width:100%;">
                        <tr>
                            <td class="style61" style="width: 51px">
                    <asp:Label ID="Label1" runat="server" 
                        Text="PRV :"></asp:Label>
                            &nbsp;</td>
                            <td class="style62" style="width: 56px">
                                <asp:DropDownList ID="prv" runat="server" Height="31px" Width="56px">
                                    <asp:ListItem Value="True">Có</asp:ListItem>
                                    <asp:ListItem Value="False">Không</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style62" style="width: 81px">
                    <asp:Label ID="Label2" runat="server" 
                        Text="Hầm ĐHT :"></asp:Label>
                            </td>
                            <td style="width: 56px">
                                <asp:DropDownList ID="hamdht" runat="server" Height="31px" Width="56px">
                                    <asp:ListItem Value="Có">Có</asp:ListItem>
                                    <asp:ListItem Value="Không">Không</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 68px">
                                &nbsp;</td>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="style43" style="height: 35px" >
                    
                    </td>
                <td class="style44" style="height: 35px">
                    </td>
            </tr>
            <tr>
                <td class="style41" style="height: 42px">
                    </td>
                <td class="style41" style="width: 53px; height: 42px;">
                    </td>
                <td colspan=2 class="style67" 
                    style="border-bottom: 1px #99cc99 solid; height: 42px;">
                    <table border="0" cellpadding="0" cellpadding="0" style="width:100%;">
                        <tr>
                            <td class="style61" style="width: 129px; height: 19px;">
                                Tình trạng ĐHT :</td>
                            <td class="style62" style="width: 111px; height: 19px;">
                    <asp:TextBox ID="txtTinhTrangDHT" runat="server" Height="27px" Width="152px"></asp:TextBox>
                            </td>
                            <td class="style62" style="width: 148px; height: 19px;">
                                Tình trạng Blogger :</td>
                            <td style="height: 19px">
                    <asp:TextBox ID="txtTinhTrangBlogger" runat="server" Height="27px" Width="152px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style43" style="height: 42px" >
                    
                    </td>
                <td class="style44" style="height: 42px">
                    </td>
            </tr>
            <tr>
                <td class="style45" style="height: 38px">
                    </td>
                <td class="style45" style="width: 53px; height: 38px;">
                    </td>
                <td class="style68" 
                    style="border-bottom: 1px #99cc99 solid; width: 71px; height: 38px;">
                    <asp:Label ID="Label15" runat="server" 
                        Text="Số Sim:"></asp:Label>
                            </td>
                <td class="style47" style="border-bottom: 1px #99cc99 solid; height: 38px;">
                    <asp:TextBox ID="txtSoSim" runat="server" 
                        Height="27px" Width="343px"></asp:TextBox>
                
                </td>
                <td class="style48" style="height: 38px">
                     
</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3" style="width: 53px">
                    &nbsp;</td>
                <td class="style64" style="border-bottom: 1px #99cc99 solid; width: 71px;">
                    &nbsp;</td>
                <td class="style25" style="border-bottom: 1px #99cc99 solid">                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style3" style="width: 53px">
                    &nbsp;</td>
                <td class="style64" style="border-bottom: 1px #99cc99 solid; width: 71px;">
                    &nbsp;</td>
                <td class="style25" style="border-bottom: 1px #99cc99 solid">
                                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style50">
                    </td>
                <td class="style50" style="width: 53px">
                    &nbsp;</td>
                <td class="style69" style="border-bottom: 1px #99cc99 solid; width: 71px;">
                    &nbsp;</td>
                <td class="style52" style="border-bottom: 1px #99cc99 solid">
                    <br />
                </td>
                <td class="style53">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style58">
                </td>
                <td class="style58" style="width: 53px">
                    &nbsp;</td>
                <td class="style59" style="width: 71px">
                    <asp:Label ID="Label10" runat="server" 
                        Text="Hình"></asp:Label>
                    </td>
                <td class="style60" colspan="2">
                    <asp:Image ID="imgFile" runat="server" Height="208px" 
                        Width="349px" Visible="False" />
                    <div class="criteria_scroll">
                   
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style3" style="width: 53px">
                    &nbsp;</td>
                <td class="style64" style="width: 71px">
                    Chọn Hình</td>
                <td class="style25">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:HiddenField ID="imagePath" runat="server" />
                </td>
                <td class="style17">
                    <asp:Label ID="upload" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style54">
                    </td>
                <td class="style54" style="width: 53px">
                    &nbsp;</td>
                <td class="style70" style="width: 71px">
                    </td>
                <td class="style56">
                    <asp:Button ID="btSearch" runat="server" CssClass="button" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="12pt" Height="30px" 
                        onclick="btSearch_Click" Text="CẬP NHẬT" Width="115px" />
                </td>
                <td class="style57">
                    </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style3" style="width: 53px">
                    &nbsp;</td>
                <td class="style64" style="width: 71px">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Label ID="lbThanhCong" runat="server" ForeColor="Blue" Font-Bold="True" 
                        Font-Size="13pt"></asp:Label>
                    </td>
            </tr>
        </table>
</asp:Content>
