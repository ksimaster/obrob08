using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSwitchDevices : MonoBehaviour
{
    public GameObject TouchControls;
    public GameObject MenuButton;
    //private int i = 0;

    private void Start()
    {
        //if (!PlayerPrefs.HasKey("desktop"))
        //{
        //    PlayerPrefs.SetInt("desktop", 0);
            CheckDevice();
        //}

        TouchControls.SetActive(!IsDesktop());
        MenuButton.SetActive(!IsDesktop());
    }

    public bool IsDesktop()
    {
        return PlayerPrefs.GetInt("desktop") == 1;
    }

    private void Update()
    {

    }

    public void CheckDevice()
    {
        // ToDo: remove
#if UNITY_WEBGL && !UNITY_EDITOR
        if(WebGLPluginJS.GetTypeDevice() == "yes")
        {
            //desktop
            TouchControls.SetActive(false);
            PlayerPrefs.SetInt("desktop", 1);

        }
        else
        {
            //mobile, tablet, TV
            //TouchControls.SetActive(true);
        }

#else
        // CHANGE HERE FOR EDITOR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        PlayerPrefs.SetInt("desktop", 0);
#endif
    }
}