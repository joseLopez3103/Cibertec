<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Transacciones.aspx.vb" Inherits="Transacciones" %>

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
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" BackColor="Lime" Font-Bold="True" 
                        Font-Size="X-Large" Text="Transacciones en ADO.NET"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Size="Large" Text="Cabecera de la factura"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Factura"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfactura" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Cliente"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlcliente" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Vendedor"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlvendedor" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Fecha de emisión de la factura"></asp:Label>
                </td>
                <td>
                    <asp:Calendar ID="cal_emision" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Fecha de cancelación de la factura"></asp:Label>
                </td>
                <td>
                    <asp:Calendar ID="cal_cancelacion" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Size="Large" Text="Detalle de la factura"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Producto"></asp:Label>
&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlproducto" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                 </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Precio"></asp:Label>
                    <asp:TextBox ID="txtprecio" runat="server" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label11" runat="server" Text="Cantidad"></asp:Label>
&nbsp;&nbsp;
                    <asp:TextBox ID="txtcantidad" runat="server" Height="16px">1</asp:TextBox>
                    <asp:RangeValidator ID="rvcantidad" runat="server" 
                        ControlToValidate="txtcantidad" ErrorMessage="Debe ser entero" 
                        MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
&nbsp;<asp:Button ID="btnagregar" runat="server" Text="Agregar" />
                 </td>
            </tr>
             <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="gvdatos" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Código" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" />
                            <asp:TemplateField HeaderText="Eliminar">
                             <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" Height="25px" 
                                        ImageUrl="~/Pictures/Delete.png" Width="22px" />
                                    &nbsp;<asp:LinkButton ID="lbeliminar" OnCommand="Eliminar" CommandName='<%# Container.DataItem("Codigo")%>'  runat="server">Eliminar</asp:LinkButton>
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
                <td>
                    <asp:Label ID="Label12" runat="server" Text="SubTotal "></asp:Label>
                    <asp:TextBox ID="txtsubtotal" runat="server" Enabled="False"></asp:TextBox>
&nbsp;
                    <asp:Label ID="Label13" runat="server" Text="IGV"></asp:Label>
&nbsp;<asp:TextBox ID="txtigv" runat="server" Enabled="False">0.18</asp:TextBox>
                 </td>
                <td>
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Size="Large" Text="Total a pagar"></asp:Label>
&nbsp;&nbsp;
                    <asp:TextBox ID="txttotal" runat="server" Enabled="False"></asp:TextBox>
                 </td>
            </tr>
             <tr>
                <td>
                    <asp:Button ID="btngrabar" runat="server" Text="Grabar Factura" />
                 </td>
                <td>
                    <asp:Button ID="btnnuevo" runat="server" Text="Nueva factura" />
                 </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
