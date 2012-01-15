<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mantenimiento.aspx.vb" Inherits="Mantenimiento" %>

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
    
    <script type="text/javascript">
    function abrir(){
        window.open('DataEntryCliente_Variante.aspx', null, 'width=300,height=300,scrollbars=NO') 
    } 

  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" BackColor="#00FFCC" Font-Bold="True" 
                        Font-Size="X-Large" Text="MANTENIMIENTO DE CLIENTES EN N CAPAS"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                        Text="Si desea registrar un cliente"></asp:Label>
&nbsp;
                    <asp:LinkButton ID="lbnuevo" runat="server">haga clic aquí</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvdatos" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:BoundField DataField="COD_CLI" HeaderText="Código" />
                            <asp:BoundField DataField="RAZ_SOC_CLI" HeaderText="Razón Social" />
                            <asp:BoundField DataField="RUC_CLI" HeaderText="RUC" />
                            <asp:TemplateField HeaderText="Edición">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Pictures/Edit.jpg" 
                                        Width="28px" />
                                    &nbsp;
                                    <asp:LinkButton ID="lbeditar" OnCommand="Editar" CommandName='<%# Container.DataItem("COD_CLI")%>' runat="server">Editar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminación">
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" Height="25px" 
                                        ImageUrl="~/Pictures/Delete.png" Width="22px" />
                                    &nbsp;<asp:LinkButton ID="lbeliminar" OnCommand="Eliminar" CommandName='<%# Container.DataItem("COD_CLI")%>'  runat="server">Eliminar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
