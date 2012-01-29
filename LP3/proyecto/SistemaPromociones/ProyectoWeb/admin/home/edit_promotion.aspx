<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit_promotion.aspx.vb" Inherits="promotion_edit_promotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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

        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/admin/home/home_admin.aspx">Regresar</asp:HyperLink>
    </div>
</body>
</html>
