<%@ Page Language="VB" AutoEventWireup="false" CodeFile="new_promotion.aspx.vb" Inherits="admin_promotion_new_promotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

 <!--  /* <script type="text/javascript" src="../../Scripts/jquery-1.7.1.js"></script> 
    <script type="text/javascript" src="../../Scripts/jquery.form.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui.min.js "></script> */-->
        <!-- footer -->
    <% Response.WriteFile("header.inc") %>

        <script type="text/javascript">
            // wait for the DOM to be loaded
            $(document).ready(function () 
            {
                var options = {
                    success: showResponse  // post-submit callback 
                }

                $('#contactform').submit(function () {
                    $(this).ajaxSubmit(options);
                    return false;
                });

                $("#datepicker1").datepicker({dateFormat:'yy-mm-dd'}); //yy-mm-dd
                $("#datepicker2").datepicker({ dateFormat: 'yy-mm-dd' });

            });

            function showResponse(responseText, statusText, xhr, $form) 
            {
                alert('status: ' + statusText + '\n\nresponseText: \n' + responseText +
                    '\n\nThe output div should have already been updated with the responseText.');
            }  

            function getContactos() 
            { 
             alert ("getcontactos");
             $.ajax({
                 type: "POST",
                 url: "../admin/core/promotion/all.aspx",
                 data: "{}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {

                     var contactos = response;
                     alert("contactos " + contactos);

                     $('#tablaContactos').empty();
                     $('#tablaContactos').append('<tr><td><b>ID</b></td><td><b>Nombre</b></td><td><b>Telefono</b></td><td><b>EMail</b></td>' +
                                                 '</tr>');

                     for (var i = 0; i < contactos.length; i++) {
                         $('#tablaContactos').append('<tr>' +
                                            '<td>' + contactos[i].cod + '</td>' +
                                            '<td>' + contactos[i].nombre + '</td>' +
                                            '<td>' + contactos[i].estado + '</td>' +
                                            '<td>' + contactos[i].description + '</td>' +
                                          '</tr>');
                     }
                 },
                 error: function (result) {
                     alert('ERROR ' + result.status + ' ' + result.statusText);
                 }
             }); 
              } 
        </script> 

    <title></title>
</head>
<body>
    <div id="header">
        <div class="container_12">
            <div class="grid_2">
                <div class="container">

                    <form id="contactform" class="rounded" method="post" action="../../admin/core/promotion/new.aspx">
                        <h3>Nueva Promoción</h3>
                        <div class="field">
	                        <label for="name">Nombre:</label>
  	                        <input type="text" class="input" name="name" id="" />
	                        <p class="hint">Nombre de la Promoción .</p>
                        </div>

                        <div class="field">
	                        <label for="state">Estado:</label>
                              <select name="state">
                              <option value="Activo"> ACTIVO </option>
                              <option value="Inactivo"> INACTIVO </option>
                            </select>
	                        <p class="hint">Estado.</p>
                        </div>

                        <div class="field">
	                        <label for="date_init">Fecha Inicio:</label>
  	                        <input type="text" class="input" name="date_init" id="datepicker1" />
	                        <p class="hint">Fecha Inicio.</p>
                        </div>

                        <div class="field">
	                        <label for="date_end">Fecha Fin:</label>
  	                        <input type="text" class="input" name="date_end" id="datepicker2" />
	                        <p class="hint">Fecha Fin.</p>
                        </div>
                        <div class="field">
	                        <label for="state">Imágen:</label>
  	                        <input name="img" class="input" size="30" type="file" />
	                        <p class="hint">Imágen.</p>
                        </div>

                        <div class="field">
	                        <label for="description">Descripción:</label>
  	                        <textarea class="input textarea" name="description" id=""></textarea>
	                        <p class="hint">Descripción.</p>
                        </div>

                        <input type="submit" name="Submit"  class="button" value="Crear" />
                    </form>

                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/admin/home/home_admin.aspx">Regresar</asp:HyperLink>
                <div>
                    <table id='tablaContactos'></table> 
                </div>
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
