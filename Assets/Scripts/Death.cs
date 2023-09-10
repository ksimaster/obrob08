using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;
using StarterAssets;

public class Death : MonoBehaviour
{
    public GameObject panelWin;
    public GameObject panelDeath;
    public GameObject gameController;
    //public GameObject playerArmature;
    public TMP_Text adsWinText;
    public TMP_Text adsLoseText;
    public GameObject winStart;
    public GameObject winShop;
    public GameObject winSetting;
    //public GameObject winRestart;
    public GameObject loseStart;
    public GameObject loseShop;
    public GameObject loseSetting;
    public GameObject loseProgress;
    //public GameObject loseRestart;

    private GameObject scene;

    private GameObject[] pointsDeath;

    private void Start()
    {

    }
    public IEnumerator ForAds()
    {
        //Time.timeScale = 1;
        adsWinText.gameObject.SetActive(true);
        adsLoseText.gameObject.SetActive(true);
        winStart.SetActive(false);
        winShop.SetActive(false);
        winSetting.SetActive(false);
        loseStart.SetActive(false);
        loseShop.SetActive(false);
        loseSetting.SetActive(false);
        loseProgress.SetActive(false);
        adsWinText.text = "��� ���� �������!";
        adsLoseText.text = "�� ����� ��������������!";
        yield return new WaitForSeconds(1f);
        adsWinText.text = "������� �����?";
        adsLoseText.text = "����� ����������!";
        yield return new WaitForSeconds(1f);
#if UNITY_WEBGL && !UNITY_EDITOR
    	WebGLPluginJS.InterstitialFunction();
#endif
        adsWinText.gameObject.SetActive(false);
        adsLoseText.gameObject.SetActive(false);
        winStart.SetActive(true);
        winShop.SetActive(true);
        winSetting.SetActive(true);
        loseStart.SetActive(true);
        loseShop.SetActive(true);
        loseSetting.SetActive(true);
        loseProgress.SetActive(true);
        //Time.timeScale = 0;
    }


    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Laser"))
        {
            //gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.transform.parent.GetChild(3).GetComponent<UICanvasControllerInput>().Reset();
            gameObject.transform.parent.GetChild(3).GetComponent<UICanvasControllerInput>().enabled = false;
            gameController.GetComponent<LoadPoint>().Spawn();

            //Time.timeScale = 0;
            panelDeath.SetActive(true);
            Debug.Log("�������� ������������ �������: " + PlayerPrefs.GetFloat("SaveTime"));
            StartCoroutine(ForAds());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
                //gameObject.SetActive(true);
            // �������� ���������� �������, �������������� � �.�.
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            //gameObject.GetComponent<CharacterController>().enabled = false;
           // gameController.GetComponent<LoadPoint>().Spawn();
            //Time.timeScale = 0;
            panelWin.SetActive(true);
            Debug.Log("�������� ������������ �������: " + PlayerPrefs.GetFloat("SaveTime"));
           // PlayerPrefs.SetFloat("NewBest", PlayerPrefs.GetFloat("SaveTime"));
            StartCoroutine(ForAds());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //gameObject.SetActive(true);
            // �������� ���������� �������, �������������� � �.�.
        }
    }
   
 
}
