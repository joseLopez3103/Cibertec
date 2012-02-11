<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home_admin.aspx.vb" Inherits="admin_promotion_home_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" language="javascript" src="../../Scripts/jquery.dataTables.js"></script>

    <title></title>
    <% Response.WriteFile("header.inc") %>

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

    <div id="header">
        <div class="container_12">
            <div class="grid_2">
                <div class="container">

                 <form id="form1" runat="server">
                    <div>
    
                        Sistema de Promociones<br />
                        <asp:HyperLink ID="HyperLink1"  runat="server" 
                            NavigateUrl="~/admin/home/new_promotion.aspx">Nueva Promoción</asp:HyperLink>
                        <br />
                    </div>
                  </form>
                  <div>
                        <table id='tablaContactos' class="table2"></table> <br />
                  </div>

                  <asp:HyperLink ID="hlink4" runat="server" 
                     NavigateUrl="~/home.aspx">Regresar</asp:HyperLink>
                </div>
            </div>   
        </div>
    </div>
        <div id="content" class="episodes" >
            <div id="home_grid" class="container_12">
                <div id="home" class="grid_12">
                    
                </div>
            </div>
        </div>
    
    <!--  footer  -->
    <% Response.WriteFile("footer.inc") %>

    </body>
</html>
