<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home_admin.aspx.vb" Inherits="admin_promotion_home_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>

    <script type="text/javascript" src="../../Scripts/jquery-1.7.1.js"></script> 
    <script type="text/javascript" src="../../Scripts/jquery.form.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui.min.js "></script>

    <link rel="stylesheet" href="../../Styles/style.css" type="text/css" media="screen"/>
    
    <script type="text/javascript" language="javascript" src="../../Scripts/jquery.dataTables.js"></script>

    <title></title>
            <script type="text/javascript">
                // wait for the DOM to be loaded

                var ndata = null;
                $(document).ready(function () {
                    getContactos();

                    /* var oTable = $('#tabla2').dataTable({
                    "bProcessing": true,
                        
                    });*/
                });

                function editPromotion($id)
                 { 
                
                 }
                function getContactos() {
                    $.post("http://localhost:51823/test1/admin/core/promotion/all.aspx", {},
                      function (data) {
                          //alert(data); // John
                          //console.log(data.time); //  2pm
                          var contactos = data;
                          ndata = data;
                          $('#tablaContactos').empty();
                          $('#tablaContactos').append('<tr><td><b>CODIGO</b></td><td><b>NOMBRE</b></td><td><b>ESTADO</b></td><td><b>DESCRIPTION</b></td>' +
                                                 '<td></td><td></td></tr>');

                          for (var i = 0; i < contactos.length; i++) {
                              // alert(contactos[i]);
                              $('#tablaContactos').append('<tr>' +
                                            '<td>' + contactos[i].cod + '</td>' +
                                            '<td>' + contactos[i].nombre + '</td>' +
                                            '<td>' + contactos[i].estado + '</td>' +
                                            '<td>' + contactos[i].description + '</td>' +
                                            '<td><span class="modi"><a href="edit_promotion.aspx?cod=' + contactos[i].cod + '"><img src="../../Pictures/database_edit.png" title="Editar" alt="Editar" /></a></span></td>' +
                                            '<td></td>'+
                                          '</tr>');
                          }

                      },
                      "json");
                }
            </script>
</head>
<body>
     <form id="form1" runat="server">
        <div>
    
            Sistema de Promociones<br />
            <asp:HyperLink  runat="server" 
                NavigateUrl="~/admin/home/new_promotion.aspx">Nueva Promoción</asp:HyperLink>
            <br />
           <!-- <asp:HyperLink ID="hlNew" runat="server" 
                NavigateUrl="~/promotion/new_promotion.aspx">Nuevo</asp:HyperLink>
            <br />  
                <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/admin/core/promotion/all.aspx">Listado Promociones</asp:HyperLink>   -->
        </div>
    </form>

    <div>
        <table id='tablaContactos' class="table2"></table> <br />
    </div>
</body>
</html>
