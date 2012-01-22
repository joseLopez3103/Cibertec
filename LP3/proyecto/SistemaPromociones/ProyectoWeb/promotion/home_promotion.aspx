<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home_promotion.aspx.vb" Inherits="promotion_home_promotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h2>Pantalla Principal</h2>
    <div>
      <button id="login">Login Facebook</button>
    </div>
    <div id="user-info" style="display: none;"></div>
    <div id="user-register" style="display: none;"> 
        <h2>Registro de usuario </h2>
          <form id="frm-register" action="core/register_user.aspx" method="post"> 
            Id: <input type="text" id="_id" name="id" /> <br />
            Name: <input type="text" id="_name" name ="name"/> <br />
            Email: <input type="text" id="_email" name="email"/> <br />
            <input type="submit" value="Registrar" /> 
        </form>
    </div>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>

    <div id="fb-root"></div>
    <script src="http://connect.facebook.net/en_US/all.js"></script>
    <script>

        $(init);
        function init() {
            alert("Init");
            $('#user-register').hide();
        }

        //FACEBOOK --------------------------------
        // initialize the library with the API key
        FB.init({ apiKey: '292549197453271' });

        // fetch the status on load
        FB.getLoginStatus(handleSessionResponse);

        $('#login').bind('click', function () {

            FB.login(function (response) {
                if (response.authResponse) {
                    console.log('Welcome!  Fetching your information.... ');

                    FB.api('/me', function (response) {
                        console.log('Good to see you, ' + response.name + '.' + response);
                        for (i in response) {
                            console.log('>>> ' + i + " " + response[i]);
                        }
                        var _id = response.id.toString();

                        $('#user-register').show();

                        $('#_id').val(_id);
                        $('#_name').val(response.name);
                        $('#_email').val(response.email);

                        $('#user-info').html('id ' + response.id + ' name ' + response.name + '<br/>' + '<img src=\"' + 'http://graph.facebook.com/' + response.id + '/picture' + '"\ />').show('fast');
                    });


                    /* function (response) {
                    var user = response;
                    $('#user-info').html('<img src="' + user.pic + '">' + user.name).show('fast');
                    }*/

                    /*FB.logout(function(response) {
                    console.log('Logged out.');
                    }
                    );*/

                    /*FB.api(
                    {
                    method: 'fql.query',
                    query: 'SELECT name, pic FROM profile WHERE id=' + response.id
                    },
                    function (response1) {
                    // var user = response1[0];
                    for (j in response1) {
                    console.log('>>> j' + j + " " + response1[j]);
                    }
                    // $('#user-info').html('<img src="' + user.pic + '">' + user.name).show('fast');
                    }
                    );*/
                } else {
                    console.log('User cancelled login or did not fully authorize.');
                }
            }, { scope: 'email,read_stream,publish_stream' });

            // FB.login(handleSessionResponse, { scope: 'email,read_stream,publish_stream' });
        });

        /*$('#logout').bind('click', function () {
        FB.logout(handleSessionResponse);
        });

        $('#disconnect').bind('click', function () {
        FB.api({ method: 'Auth.revokeAuthorization' }, function (response) {
        clearDisplay();
        });
        });*/

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
    </script>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
