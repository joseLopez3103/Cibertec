<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home.aspx.vb" Inherits="promotion_home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8" />
<!-- /*
  Referencia 
  http://5by5.tv/
  http://tympanus.net/codrops/2012/02/06/3d-gallery-with-css3-and-jquery/

*/ -->
<title>Pagina Principal Promociones </title>
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
        var ndata = null;
        $(document).ready(
            function () 
            {
                getPromotions();
            }
        );

            function getPromotions() {
                $.post("http://localhost:51823/test1/admin/core/promotion/all.aspx", {},
                    function (data) 
                    {
                       // alert("complete ");
                        var promociones = data;
                        ndata = data;
                        var s = ""
                        s += '<div class="clear"></div>';
                        var count = 0;

                        for (var i = 0; i < promociones.length; i++) 
                        {
                            count++
                            s += '<div class="grid_4 episode thumbnail">' +
                             '<a href="promotion.aspx" title="' + promociones[i].nombre + '">' +
                             '<img alt="" class="picture shadow" height="162" src="' + 'http://localhost:51823/test1/admin' + promociones[i].url_img + '" width="288">'+
                             '</a>' +
                            '<h3>path '+promociones[i].nombre+'<span></span>'+
                            '</h3>'+
                            '<h4></h4>'+
                            '<p>' + promociones[i].description + '</p>' +
                            '</div>';

                            if (count%3== 0 && i != 0) {
                                s += '<div class="clear"></div>'
                            }
                        }
                        $('#home_grid').html(s)

                    },
                    "json");
                }
</script>
</head>
<body>
<div id="header">
  <div class="container_12">
    <div class="grid_2">
      <a href="/" title="5by5"><img alt="5by5" height="62" src="../Pictures/headers/5by5.png" width="150">
      </a>
    </div>
    <div class="container">
      <header>
        <h1></h1>
      </header>
      <section id="dg-container" class="dg-container">
          <div class="dg-wrapper">
              <a href="#"><img src="../Pictures/1.jpg" alt="image01"><div>http://www.colazionedamichy.it/</div></a>
              <a href="#"><img src="../Pictures/2.jpg" alt="image02"><div>http://www.percivalclo.com/</div></a>
              <a href="#"><img src="../Pictures/3.jpg" alt="image03"><div>http://www.wanda.net/fr</div></a>
              <a href="#"><img src="../Pictures/4.jpg" alt="image04"><div>http://lifeingreenville.com/</div></a>
              <a href="#"><img src="../Pictures/5.jpg" alt="image05"><div>http://circlemeetups.com/</div></a>
              <a href="#"><img src="../Pictures/6.jpg" alt="image06"><div>http://www.castirondesign.com/</div></a>
              <a href="#"><img src="../Pictures/7.jpg" alt="image07"><div>http://www.foundrycollective.com/</div></a>
              <a href="#"><img src="../Pictures/8.jpg" alt="image08"><div>http://www.mathiassterner.com/home</div></a>
              <a href="#"><img src="../Pictures/9.jpg" alt="image09"><div>http://learnlakenona.com/</div></a>
              <a href="#"><img src="../Pictures/10.jpg" alt="image10"><div>http://www.neighborhood-studio.com/</div></a>
              <a href="#"><img src="../Pictures/11.jpg" alt="image11"><div>http://www.beckindesign.com/</div></a>
              <a href="#"><img src="../Pictures/12.jpg" alt="image12"><div>http://kicksend.com/</div></a>
        </div>
        <nav> 
          <span class="dg-prev">&lt;</span>
          <span class="dg-next">&gt;</span>
        </nav>
      </section>
        </div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.gallery.js"></script>
    <script type="text/javascript">
      $(function() {
        $('#dg-container').gallery();
      });
    </script/>

  </div>
</div>
<div id="content" class="episodes" > 
  <div id="home_grid" class="container_12">
    <div id="home" class="grid_12">
      <!-- /*  <div class="clear"></div>
        <div class="grid_4 episode thumbnail">
            <a href="#" title="Workflows with Colleen Wainwright"><img alt="Workflows with Colleen Wainwright" class="picture shadow" height="162" src="../Pictures/items/mpu-thumb.jpg" width="288">
            </a>
            <h3><a href="/mpu/72">Mac Power Users #72</a><span>Feb 6 • 11:45am</span>
            </h3>
            <h4><a href="/mpu/72" title="Workflows with Colleen Wainwright">Workflows with Colleen Wainwright</a>
            </h4>
            <p>With <a href="/person/david-sparks">David Sparks</a> &amp; <a href="/person/katie-floyd">Katie Floyd</a>.
            </p>
        </div> */ -->
    </div>
  </div>
</div>
<div id="footer">
  <div class="container_12">
    <div class="grid_2">
          <h4>Shows</h4>
          <ul>
            <li><a href="/talkshow" title="The Talk Show">The Talk Show</a></li>
            <li><a href="/b2w" title="Back to Work with Merlin Mann">Back to Work</a></li>
            <li><a href="/criticalpath" title="The Critical Path">The Critical Path</a></li>
            <li><a href="/buildanalyze" title="The Pipeline">Build &amp; Analyze</a></li>
            <li><a href="/hypercritical" title="Hypercritical with John Siracusa">Hypercritical</a></li>
            <li><a href="/broadcasts" title="More Broadcasts">More →</a></li>
          </ul>
    </div>
    <div class="grid_2">
          <h4>Shows</h4>
          <ul>
            <li><a href="/talkshow" title="The Talk Show">The Talk Show</a></li>
            <li><a href="/b2w" title="Back to Work with Merlin Mann">Back to Work</a></li>
            <li><a href="/criticalpath" title="The Critical Path">The Critical Path</a></li>
            <li><a href="/buildanalyze" title="The Pipeline">Build &amp; Analyze</a></li>
            <li><a href="/hypercritical" title="Hypercritical with John Siracusa">Hypercritical</a></li>
            <li><a href="/broadcasts" title="More Broadcasts">More →</a></li>
          </ul>
    </div>
    <div class="grid_2">
          <h4>Shows</h4>
          <ul>
            <li><a href="/talkshow" title="The Talk Show">The Talk Show</a></li>
            <li><a href="/b2w" title="Back to Work with Merlin Mann">Back to Work</a></li>
            <li><a href="/criticalpath" title="The Critical Path">The Critical Path</a></li>
            <li><a href="/buildanalyze" title="The Pipeline">Build &amp; Analyze</a></li>
            <li><a href="/hypercritical" title="Hypercritical with John Siracusa">Hypercritical</a></li>
            <li><a href="/broadcasts" title="More Broadcasts">More →</a></li>
          </ul>
    </div>
    <div class="grid_2">
          <h4>Shows</h4>
          <ul>
            <li><a href="/talkshow" title="The Talk Show">The Talk Show</a></li>
            <li><a href="/b2w" title="Back to Work with Merlin Mann">Back to Work</a></li>
            <li><a href="/criticalpath" title="The Critical Path">The Critical Path</a></li>
            <li><a href="/buildanalyze" title="The Pipeline">Build &amp; Analyze</a></li>
            <li><a href="/hypercritical" title="Hypercritical with John Siracusa">Hypercritical</a></li>
            <li><a href="/broadcasts" title="More Broadcasts">More →</a></li>
          </ul>
    </div>
        <div class="clear"></div>
        <div class="grid_12">
          <p>Copyright © 2009–2012 by 5by5 Corporation. All Rights Reserved · Hosted by <a href="http://joyent.com">Joyent</a> · Video hosting by <a href="http://wistia.com/5by5" title="Video hosting and analytics by Wistia">Wistia</a> · Fonts by <a href="http://typekit.com">Typekit</a> · Coded by <a href="http://danbenjamin.com" title="Your Internet Pal Dan Benjamin">Your Internet Pal</a></p>
        </div>
        <div class="clear"></div>
  </div>
</div>
</body>
</html>
