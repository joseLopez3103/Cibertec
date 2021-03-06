﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="promotion_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle Promotion</title>
    <link rel="stylesheet" href="../Styles/css/reset.css" />
    <link rel="stylesheet" href="../Styles/css/text.css" />
    <link rel="stylesheet" href="../Styles/css/960.css" />
    <link rel="stylesheet" href="../Styles/css/screen.css" />
    <link rel="stylesheet" href="../Styles/css/style.css" />
    <link rel="stylesheet" href="../Styles/css/demo.css" />

    <script type="text/javascript" src="../Scripts/modernizr.custom.53451.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.7.1.js"></script>
    <!-- /*<link rel="stylesheet" href="css/demo.css" /> */-->
    <script type="text/javascript" >
    </script>

</head>
<body>
    <div id="header">
        <div class="container_12">
            <div class="grid_2">
            </div>
            <div class="container">
                <section id="dg-container" class="dg-container">
                <form id="form1" runat="server">
                    <div>
                        <b>Promoción :</b><asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label><br/>
                        <asp:TextBox ID="lblDescripcion" runat="server" Width="300"
                            TextMode="MultiLine" />
                        <asp:Image ID="imgPromocion" runat="server" Width="300" Height="250" /><br />
                        <b>Fecha Inicio :</b><asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label> &nbsp;&nbsp;
                        <b>Fecha Fin :</b> <asp:Label ID="lblFechaFin" runat="server" Text="Label"></asp:Label>
                    </div>
                </form>
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Black" 
                    NavigateUrl="~/promotion/home.aspx">Regresar </asp:HyperLink>
                </div>
           </div>
        </div>
        <div id="content" class="episodes" >
            <div id="home_grid" class="container_12">

            </div>
        </div>
    <div id="footer">
            <div class="container_12">
                <div class="grid_2">
                    <h4>Shows</h4>
                    <ul>
                        <li>
                            <a href="/talkshow" title="The Talk Show">The Talk Show</a>
                        </li>
                        <li>
                            <a href="/b2w" title="Back to Work with Merlin Mann">Back to Work</a>
                        </li>
                        <li>
                            <a href="/criticalpath" title="The Critical Path">The Critical Path</a>
                        </li>
                        <li>
                            <a href="/buildanalyze" title="The Pipeline">Build &amp; Analyze</a>
                        </li>
                        <li>
                            <a href="/hypercritical" title="Hypercritical with John Siracusa">Hypercritical</a>
                        </li>
                        <li>
                            <a href="/broadcasts" title="More Broadcasts">More →</a>
                        </li>
                    </ul>
                </div>
                <div class="grid_2">
                    <h4>Shows</h4>
                    <ul>
                        <li>
                            <a href="/talkshow" title="The Talk Show">The Talk Show</a>
                        </li>
                        <li>
                            <a href="/b2w" title="Back to Work with Merlin Mann">Back to Work</a>
                        </li>
                        <li>
                            <a href="/criticalpath" title="The Critical Path">The Critical Path</a>
                        </li>
                        <li>
                            <a href="/buildanalyze" title="The Pipeline">Build &amp; Analyze</a>
                        </li>
                        <li>
                            <a href="/hypercritical" title="Hypercritical with John Siracusa">Hypercritical</a>
                        </li>
                        <li>
                            <a href="/broadcasts" title="More Broadcasts">More →</a>
                        </li>
                    </ul>
                </div>
                <div class="grid_2">
                    <h4>Shows</h4>
                    <ul>
                        <li>
                            <a href="/talkshow" title="The Talk Show">The Talk Show</a>
                        </li>
                        <li>
                            <a href="/b2w" title="Back to Work with Merlin Mann">Back to Work</a>
                        </li>
                        <li>
                            <a href="/criticalpath" title="The Critical Path">The Critical Path</a>
                        </li>
                        <li>
                            <a href="/buildanalyze" title="The Pipeline">Build &amp; Analyze</a>
                        </li>
                        <li>
                            <a href="/hypercritical" title="Hypercritical with John Siracusa">Hypercritical</a>
                        </li>
                        <li>
                            <a href="/broadcasts" title="More Broadcasts">More →</a>
                        </li>
                    </ul>
                </div>
                <div class="grid_2">
                    <h4>Shows</h4>
                    <ul>
                        <li>
                            <a href="/talkshow" title="The Talk Show">The Talk Show</a>
                        </li>
                        <li>
                            <a href="/b2w" title="Back to Work with Merlin Mann">Back to Work</a>
                        </li>
                        <li>
                            <a href="/criticalpath" title="The Critical Path">The Critical Path</a>
                        </li>
                        <li>
                            <a href="/buildanalyze" title="The Pipeline">Build &amp; Analyze</a>
                        </li>
                        <li>
                            <a href="/hypercritical" title="Hypercritical with John Siracusa">Hypercritical</a>
                        </li>
                        <li>
                            <a href="/broadcasts" title="More Broadcasts">More →</a>
                        </li>
                    </ul>
                </div>
                <div class="clear"></div>
                <div class="grid_12">
                    <p>
                        Copyright © 2009–2012 by 5by5 Corporation. All Rights Reserved · Hosted by <a href="http://joyent.com">Joyent</a> · Video hosting by <a href="http://wistia.com/5by5" title="Video hosting and analytics by Wistia">Wistia</a> · Fonts by <a href="http://typekit.com">Typekit</a> · Coded by <a href="http://danbenjamin.com" title="Your Internet Pal Dan Benjamin">Your Internet Pal</a>
                    </p>
                </div>
                <div class="clear"></div>
            </div>
        </div>
</body>
</html>
