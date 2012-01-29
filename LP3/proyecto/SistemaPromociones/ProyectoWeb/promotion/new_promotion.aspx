<%@ Page Language="VB" AutoEventWireup="false" CodeFile="new_promotion.aspx.vb" Inherits="admin_promotion_new_promotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" type="text/css" href="../Styles/style.css" />

    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>

    <script type="text/javascript" src="../Scripts/jquery-1.7.1.js"></script> 
    <script type="text/javascript" src="../Scripts/jquery.form.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui.min.js "></script>
    

        <script type="text/javascript">
            // wait for the DOM to be loaded
            $(document).ready(function () 
            {

                var options = {
                    //target: '#output1',   // target element(s) to be updated with server response 
                    //beforeSubmit: showRequest,  // pre-submit callback 
                    success: showResponse  // post-submit callback 
                }

                // bind 'myForm' and provide a simple callback function 
                //$('#contactform').ajaxForm(options);
                /*$('#contactform').ajaxForm(function () {
                alert("Nueva Promoción ...");
                });*/

                $('#contactform').submit(function () {
                    // inside event callbacks 'this' is the DOM element so we first 
                    // wrap it in a jQuery object and then invoke ajaxSubmit 
                    $(this).ajaxSubmit(options);

                    // !!! Important !!! 
                    // always return false to prevent standard browser submit and page navigation 
                    return false;
                });

                $("#datepicker1").datepicker({dateFormat:'yy-mm-dd'}); //yy-mm-dd
                $("#datepicker2").datepicker({ dateFormat: 'yy-mm-dd' });

               // getContactos();
            });

            function showResponse(responseText, statusText, xhr, $form) 
            {
                // for normal html responses, the first argument to the success callback 
                // is the XMLHttpRequest object's responseText property 

                // if the ajaxForm method was passed an Options Object with the dataType 
                // property set to 'xml' then the first argument to the success callback 
                // is the XMLHttpRequest object's responseXML property 

                // if the ajaxForm method was passed an Options Object with the dataType 
                // property set to 'json' then the first argument to the success callback 
                // is the json data object returned by the server 

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

                     alert("response " + response + " " + response.d);
                     // var contactos = (typeof response.d) == 'string' ?
                     //  eval('(' + response.d + ')') :
                     //response.d;
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

                     window.location = "http://www.google.com"
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
   <div class="container">

        <form id="contactform" class="rounded" method="post" action="../admin/core/promotion/new.aspx">
            <h3>Nueva Promoción</h3>
            <div class="field">
	            <label for="name">Nombre:</label>
  	            <input type="text" class="input" name="name" id="" />
	            <p class="hint">Nombre de la Promoción .</p>
            </div>

            <div class="field">
	            <label for="state">Estado:</label>
  	            <input type="text" class="input" name="state" id="" />
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
	            <label for="description">Descripción:</label>
  	            <textarea class="input textarea" name="description" id=""></textarea>
	            <p class="hint">Descripción.</p>
            </div>

            <input type="submit" name="Submit"  class="button" value="Crear" />
        </form>

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/home.aspx">Regresar</asp:HyperLink>

    </div>
    <div>
        <table id='tablaContactos'></table> 
    </div>
</body>
</html>
