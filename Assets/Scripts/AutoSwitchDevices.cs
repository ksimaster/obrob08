using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSwitchDevices : MonoBehaviour
{
    public GameObject TouchControls;
    public GameObject MenuButton;

    public GameObject mainMenu;
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject deathPanel;
    public GameObject shopPanel;
    public GameObject rewardPanel;
    public GameObject settingPanel;
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
        if (PlayerPrefs.GetInt("desktop") == 0)
        {
            if (mainMenu.activeSelf || pausePanel.activeSelf || winPanel.activeSelf || deathPanel.activeSelf || shopPanel.activeSelf || rewardPanel.activeSelf || settingPanel.activeSelf)
            {
                TouchControls.SetActive(false);
            }
            else
            {
                TouchControls.SetActive(true);
            }
        }
        
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
            TouchControls.SetActive(true);
            PlayerPrefs.SetInt("desktop", 0);
        }

#else
        // CHANGE HERE FOR EDITOR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //PlayerPrefs.SetInt("desktop", 0);
#endif
    }
}