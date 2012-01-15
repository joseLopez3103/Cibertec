<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SeleccionMasiva.aspx.vb" Inherits="SeleccionMasiva" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" BackColor="#66FF66" Font-Bold="True" 
                        Font-Size="X-Large" Text="Selección masiva de elementos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvdatos" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="COD_CLI" HeaderText="Código" />
                            <asp:BoundField DataField="RAZ_SOC_CLI" HeaderText="Razón Social " />
                            <asp:BoundField DataField="RUC_CLI" HeaderText="RUC" />
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkseleccionar" runat="server" />
                                    &nbsp;<asp:Label ID="lblcliente" runat="server" Text='<%#Container.DataItem("RAZ_SOC_CLI")%>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnmarcados" runat="server" Text="Seleccionar marcados" />
&nbsp;&nbsp;
                    <asp:Button ID="btntodos" runat="server" Text="Seleccionar todos" />
&nbsp;&nbsp;
                    <asp:Button ID="btndeseleccionar" runat="server" Text="Deseleccionar todos" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblmensaje" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
