<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DataEntryCliente.aspx.vb" Inherits="DataEntryCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%">
        
        <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblencabezado" runat="server" Font-Bold="True" 
                        Font-Size="X-Large" BackColor="#66FFCC"></asp:Label></td>
              
               
            </tr>
        
            <tr>
                <td style="height: 21px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Razón Social"></asp:Label></td>
                <td style="height: 21px">
                    <asp:TextBox ID="txtrazon" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtrazon" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
               
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Dirección"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtdireccion" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtdireccion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                 </td>
               
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Teléfono"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txttelefono" runat="server"></asp:TextBox></td>
               
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="RUC"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtruc" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtruc" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                 </td>
               
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Distrito"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddldistrito" runat="server">
                    </asp:DropDownList></td>
               
            </tr>
             <tr>
                <td style="height: 21px">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tipo"></asp:Label></td>
                <td style="height: 21px">
                    <asp:DropDownList ID="ddltipo" runat="server">
                        <asp:ListItem Value="1">Normal</asp:ListItem>
                        <asp:ListItem Value="2">VIP</asp:ListItem>
                    </asp:DropDownList></td>
               
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Contacto"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtcontacto" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtcontacto" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                 </td>
               
            </tr>
             <tr>
                <td>
                    <asp:Button ID="btnprocesar" runat="server" Text="Procesar" /></td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/Mantenimiento.aspx">Regresar</asp:HyperLink>
                 </td>
               
            </tr>
            
           
        </table>
    
    </div>
    </form>
</body>
</html>
