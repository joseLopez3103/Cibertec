<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home.aspx.vb" Inherits="home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>

    <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script> 
    <script type="text/javascript" src="Scripts/jquery.form.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui.min.js "></script>

    <link rel="stylesheet" href="Styles/style.css" type="text/css" media="screen"/>
    
    <script type="text/javascript" language="javascript" src="Scripts/jquery.dataTables.js"></script>

    <title></title>
            <script type="text/javascript">
                // wait for the DOM to be loaded

                var ndata = null;
                $(document).ready(function () {
                   // getContactos();

                   /* var oTable = $('#tabla2').dataTable({
                        "bProcessing": true,
                        
                    });*/
                });


                function getContactos() 
                {
                    $.post("http://localhost:51823/test1/admin/core/promotion/all.aspx", {},
                      function (data) {
                          //alert(data); // John
                          //console.log(data.time); //  2pm
                          var contactos = data;
                          ndata = data;
                          $('#tablaContactos').empty();
                          $('#tablaContactos').append('<tr><td><b>CODIGO</b></td><td><b>NOMBRE</b></td><td><b>ESTADO</b></td><td><b>DESCRIPTION</b></td>' +
                                                 '</tr>');

                          for (var i = 0; i < contactos.length; i++) {
                              // alert(contactos[i]);
                              $('#tablaContactos').append('<tr>' +
                                            '<td>' + contactos[i].cod + '</td>' +
                                            '<td>' + contactos[i].nombre + '</td>' +
                                            '<td>' + contactos[i].estado + '</td>' +
                                            '<td>' + contactos[i].description + '</td>' +
                                          '</tr>');
                          }

                      },
                      "json");
                }
                 
            /*// alert ("getcontactos");
             $.ajax({
                 type: "POST",
                 url: "admin/core/promotion/all.aspx",
                 data: "{}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (response) {*/
                /* $.post('http://localhost:54027/ProyectoWeb/admin/core/promotion/all.aspx', function(response)
                 {
                 alert(response);

                    // alert("response " + response + " " + response.d);
                     // var contactos = (typeof response.d) == 'string' ?
                     //  eval('(' + response.d + ')') :
                     //response.d;
                     var contactos = response;
                     //alert("contactos " + contactos);

                     $('#tablaContactos').empty();
                     $('#tablaContactos').append('<tr><td><b>CODIGO</b></td><td><b>NOMBRE</b></td><td><b>ESTADO</b></td><td><b>DESCRIPTION</b></td>' +
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
                }*/
            </script>
</head>
<body>

    <div>
        <table id='tablaContactos' class="table2"></table> <br />
      <!--  <table id='tabla2'>
        	<thead>
		        <tr>
			        <th width="20%">cod</th>
			        <th width="25%">name</th>
			        <th width="25%">state</th>
			        <th width="15%">date_init</th>
			        <th width="15%">date_end</th>
			        <th width="15%">description</th>
		        </tr>
	        </thead>
	        <tbody>
		
	        </tbody>
	        <tfoot>
		        <tr>
			        <th width="20%">cod</th>
			        <th width="25%">name</th>
			        <th width="25%">state</th>
			        <th width="15%">date_init</th>
			        <th width="15%">date_end</th>
			        <th width="15%">description</th>
		        </tr>
	        </tfoot>
        </table> -->
    </div>
     <form id="form1" runat="server">
    <div>
    
        Sistema de Promociones<br /><br />
       <!-- <asp:HyperLink ID="hlNew" runat="server" 
            NavigateUrl="~/promotion/new_promotion.aspx">Nuevo</asp:HyperLink>
        <br />  
            <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/admin/core/promotion/all.aspx">Listado Promociones</asp:HyperLink>   -->
    </div>
     <asp:HyperLink ID="HyperLink2" runat="server" 
         NavigateUrl="~/admin/home/login.aspx">Admin</asp:HyperLink><br />
     <asp:HyperLink ID="HyperLink3" runat="server" 
         NavigateUrl="~/promotion/home.aspx">Promoción</asp:HyperLink>
    </form>
</body>
</html>
