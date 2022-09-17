using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
public class Permissions : MonoBehaviour
{
    private void Awake()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
        InvokeRepeating("CheckPermissions", 0f,1f);
#endif
    }
     void CheckPermissions()
    {
        Debug.Log("checked" + Time.time);
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation) || !Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            //check for permissions
            if (!Application.isEditor)
            {
                // ask user permission to use the GPS
                if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
                {
                    Permission.RequestUserPermission(Permission.FineLocation);
                }
                // ask user permission to use the Camera
                if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
                {
                    Permission.RequestUserPermission(Permission.Camera);
                }
            }
        }
    }
    public void loadscene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
