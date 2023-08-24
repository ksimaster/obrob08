using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADRewardCount : MonoBehaviour
{
    private string lastIsAdsOpen = null;

    public Button selectButton;
    public GameObject buttonMan;
    public GameObject buttonGirl;
    public GameObject buttonSpiderMan;
    public GameObject buttonGlassGirl;
    public GameObject buttonJacob;
    public GameObject buttonSparks;
    public GameObject buttonDevxero;

    void Start()
    {
        ShowAdInterstitial();

    }

    void Update()
    {
        CheckAds();
        InteractableButton();
        //if (compCanvasResult.enabled) isCanvasResult = 1;
        //isImageReticle = compImageReticle.enabled ? 1 : 0;
        /*
        if (compImageReticle.enabled || compCanvasResult.enabled) 
        {
            rewardPanelText.SetActive(false);
            //Time.timeScale = 1;
        }
        else
        {
            rewardPanelText.SetActive(true);
            //Time.timeScale = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !compImageReticle.enabled && !compCanvasResult.enabled && !rewardPanel.activeSelf)
        {
            
            if (!compCanvasResult.enabled)
            {
                ForReward();

                ShowAdRewardForLife();
                rewardPanel.SetActive(true);
                messageText.SetActive(false);
                Debug.Log("MainBody_HP увеличено на 50 %");
            }
           
            
            
        }
        */
    }

    public void SetPerk(string pref)
    {
        PlayerPrefs.SetInt(pref, 1);
    }

    public void InteractableButton()
    {
        /*
        if(buttonGirl.GetComponent<Image>().enabled || buttonSpiderMan.GetComponent<Image>().enabled || buttonGlassGirl.GetComponent<Image>().enabled || buttonJacob.GetComponent<Image>().enabled || buttonSparks.GetComponent<Image>().enabled || buttonDevxero.GetComponent<Image>().enabled)
        {
            selectButton.interactable = false;
        } */
        /*else
        {
            selectButton.interactable = true;
        }*/
        if(buttonMan.activeSelf) selectButton.interactable = true;
    }

    public void ShowAdInterstitial()
    {

#if UNITY_WEBGL && !UNITY_EDITOR
    	            WebGLPluginJS.InterstitialFunction();
#endif
    }
    public void ShowAdReward()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
    	WebGLPluginJS.RewardFunction();
#endif
        
    }
    public void ForReward()
    {
        Time.timeScale = 0;
       // rewardPanelText.SetActive(false);
        //rewardPanelText.SetActive(true);
    }
    public void AdsClosed()
    {
        // timer = 0f;
        Time.timeScale = 1;
       // rewardPanelText.SetActive(true);
    }

    public void CheckAds()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        var adsOpen = WebGLPluginJS.GetAdsOpen();
        if (lastIsAdsOpen == null) {
            lastIsAdsOpen = adsOpen;
        }

        if (adsOpen == "yes")
        {
            PlayerPrefs.SetInt("AdsOpen", 1);
            AudioListener.pause = true;
            lastIsAdsOpen = "yes";
        }
        else
        {
            //Коничлась реклама
            PlayerPrefs.SetInt("AdsOpen", 0);
           // if (PlayerPrefs.GetInt("Sound") == 1) AudioListener.pause = false;
            if (lastIsAdsOpen == "yes") {
               // AdsClosed();
                lastIsAdsOpen = "no";
            }
        }
#endif
    }


}
