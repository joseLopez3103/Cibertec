<head>
    <meta charset="utf-8" />
    <title>Promociones</title>
    <link rel="stylesheet" href="../Styles/css/reset.css" />
    <link rel="stylesheet" href="../Styles/css/text.css" />
    <link rel="stylesheet" href="../Styles/css/960.css" />
    <link rel="stylesheet" href="../Styles/css/screen.css" />
    <link rel="stylesheet" href="../Styles/css/style.css" />
    <link rel="stylesheet" href="../Styles/css/demo.css" />

    <script type="text/javascript" src="../Scripts/modernizr.custom.53451.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.7.1.js"></script>

    <link rel="stylesheet" type="text/css" href="../Styles/style.css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script src="http://connect.facebook.net/en_US/all.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.form.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui.min.js "></script>
    <script type="text/javascript" src="../Scripts/utils.js "></script>
    
    <!-- /*<link rel="stylesheet" href="css/demo.css" /> */-->
    
    <script type="text/javascript" >

        $(document).ready(function () 
        {
        //FACEBOOK --------------------------------
        // initialize the library with the API key
        FB.init({ apiKey: '292549197453271' });

        // fetch the status on load
        FB.getLoginStatus(handleSessionResponse);

        $('#login').bind('click', function () {

        FB.login(function (response) {
        if (response.authResponse) {
        //console.log('Welcome!  Fetching your information.... ');

        FB.api('/me', function (response) {
       // console.log('Good to see you, ' + response.name + '.' + response);
        for (i in response) {
        //console.log('>>> ' + i + " " + response[i]);
        }
        var _id = response.id.toString();

        $('#user-register').show();

        $('#_id_facebook').val(_id);
        $('#_name_user').val(response.name);
        $('#_email').val(response.email);
        $('#_sexo').val(response.gender);

        $('#user-info').html('id ' + response.id + ' name ' + response.name + '<br/>' + '<img src=\"' + 'http://graph.facebook.com/' + response.id + '/picture' + '"\ />').show('fast');

        $('#contactform').submit();
        });
        } else {
        //console.log('User cancelled login or did not fully authorize.');
        }
        }, { scope: 'email,read_stream,publish_stream' });

        // FB.login(handleSessionResponse, { scope: 'email,read_stream,publish_stream' });
        });

        // no user, clear display
        function clearDisplay() {
        $('#user-info').hide('fast');
        }

        // handle a session response from any of the auth related calls
        function handleSessionResponse(response) {
        // if we dont have a session, just hide the user info
        if (!response.session) {
        clearDisplay();
        return;
        }

        // if we have a session, query for the user's profile picture and name
        FB.api(
        {
        method: 'fql.query',
        query: 'SELECT name, pic FROM profile WHERE id=' + FB.getSession().uid
        },
        function (response) {
        var user = response[0];
        $('#user-info').html('<img src="' + user.pic + '">' + user.name).show('fast');
                      }
                    );
            }
            //form ------------------------------
            var options = {
                success: showResponse  // post-submit callback 
            }

            $('#contactform').submit(function () {
                $(this).ajaxSubmit(options);
                return false;
            });

        });

        function showResponse(responseText, statusText, xhr, $form) {
           /* alert('status: ' + statusText + '\n\nresponseText: \n' + responseText +
                    '\n\nThe output div should have already been updated with the responseText.');*/
        } 
           
    </script>
</head>
<body>
    <div id="header">
        <div class="container_12">
            <div class="grid_2">
                <div class="container">
                    <div>
                        <button id="login" style="background-color:transparent" >
                            <img src="../Pictures/fb-connect-large.png" width="261" height="35" alt="" />
                        </button>
                    </div>
                    <div id="user-info" style="display: none;"></div>

                    <div class="containerf" id="frm-register">
                        <!-- style="display: none;" -->

                        <!--<form id="Form1" class="rounded" method="post" action="../admin/core/user/new.aspx"> -->
                        <form id="contactform" class="rounded" method="post" action="../admin/core/user/validate_user.aspx">
                            <h3>Registro de Usuario</h3>
                            <div class="field">
                                <input type="hidden" class ="input" name="id_facebook" id="_id_facebook" />
                            </div>
                            <div class="field">
                                <label for="name">Nombre :</label>
                                <input type="text" class="input" name="name_user" id="_name_user" />
                                <p class="hint">Escribe tu Nombre </p>
                            </div>

                            <div class="field">
                                <label for="state">Email:</label>
                                <input type="text" class="input" name="email" id="_email" />
                                <p class="hint">Escribe tu email </p>
                            </div>

                            <div class="field">
                                <label for="description">Sexo:</label>
                                <input type="text" class="input" name="sexo" id="_sexo" />
                                <p class="hint">...</p>
                            </div>

                            <input type="submit" name="Submit"  class="button" value="Registrar" />
                        </form>

                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/home.aspx">Regresar  </asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server"
                            NavigateUrl="~/promotion/game.aspx">  Ir al Juego</asp:HyperLink>
                    </div>
                    <div id="fb-root"></div>
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