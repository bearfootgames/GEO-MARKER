using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*using Esri.ArcGISMapsSDK.Components;
using Esri.GameEngine.Camera;
using Esri.GameEngine.Location;
using Esri.GameEngine.View;
using Esri.GameEngine.View.Event;
using Esri.Unity;*/

public class Oauth : MonoBehaviour
{
    /*public DataBase db;


    private Esri.ArcGISMapsSDK.Security.OAuthAuthenticationChallengeHandler oauthAuthenticationChallengeHandler;


    public string clientID = "Enter Client ID";
    public string redirectURI = "Enter Redirect URI";
    public string serviceURL = "Enter Service URL";

    // Start is called before the first frame update
    void Start()
    {
#if (UNITY_ANDROID || UNITY_IOS || UNITY_WSA) && !UNITY_EDITOR
        oauthAuthenticationChallengeHandler = new MobileOAuthAuthenticationChallengeHandler();
#else
        oauthAuthenticationChallengeHandler = new DesktopOAuthAuthenticationChallengeHandler();
#endif
        map();
    }

    Esri.GameEngine.Security.ArcGISAuthenticationConfiguration authenticationConfiguration;


    void map()
    {
        Esri.ArcGISMapsSDK.Security.AuthenticationChallengeManager.OAuthChallengeHandler = oauthAuthenticationChallengeHandler;
        Esri.GameEngine.Security.ArcGISAuthenticationManager.AuthenticationConfigurations.Clear();
        
        authenticationConfiguration = new Esri.GameEngine.Security.ArcGISOAuthAuthenticationConfiguration(clientID.Trim(), "", redirectURI.Trim());

        Esri.GameEngine.Security.ArcGISAuthenticationManager.AuthenticationConfigurations.Add(serviceURL, authenticationConfiguration);
    }

    void OnDestroy()
    {
        if (oauthAuthenticationChallengeHandler != null)
        {
            oauthAuthenticationChallengeHandler.Dispose();
        }
    }*/
}
