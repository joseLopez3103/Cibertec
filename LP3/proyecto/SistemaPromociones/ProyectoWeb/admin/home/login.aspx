<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="admin_promotion_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <% Response.WriteFile("header.inc") %>
</head>
        <script type="text/javascript">
            // wait for the DOM to be loaded
            $(document).ready(function () {
                var options = {
                    success: showResponse , // post-submit callback 
                    dataType: "json"

                }

                $('#contactform').submit(function () {
                    $(this).ajaxSubmit(options);
                    return false;
                });

            });

            function showResponse(responseText, statusText, xhr, $form) {
                if (responseText.cod == -1) {
                   // $('#contactform').clear()
                    alert('Acceso Incorrecto ');
                } else {
                    window.location = "home_admin.aspx"
               }
              /* alert('status: ' + statusText + '\n\nresponseText: \n' + responseText +
                    '\n\nThe output div should have already been updated with the responseText.');*/
                //alert('cod ' + responseText.cod)
            }
             
        </script> 

    <title></title>
</head>
<body>
    <div id="header">
        <div class="container_12">
            <div class="grid_2">
                <div class="container">

                    <form id="contactform" class="rounded" method="post" action="../../admin/core/admin/validate_admin.aspx">
                        <h3>Acceso Administrador de Sistema </h3>
                        <div class="field">
	                        <label for="name">Usuario :</label>
  	                        <input type="text" class="input" name="usuario" id="" />
	                        <p class="hint">Usuario ...</p>
                        </div>
                        <div class="field">
	                        <label for="name">Passsword :</label>
  	                        <input type="password"  class="input" name="password" id="Text1" />
	                        <p class="hint">Password ...</p>
                        </div>

                        <input type="submit" name="Submit"  class="button" value="Acceder" />
                    </form>

                    <asp:HyperLink ID="HyperLink1" runat="server" 
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
