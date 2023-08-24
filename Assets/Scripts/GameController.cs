using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using StarterAssets;

public class GameController : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text pointText;
    public GameObject mainMenu;
    public GameObject panelDeath;
    public GameObject panelWin;
    public StarterAssetsInputs input;

    private float time = 0f;
    private float hours = 0f;
    private float minutes = 0f;
    private float seconds = 0f;
    private float timer;
    public int i = 0;

    private void Awake()
    {
        StopCoroutine(Timer());
        StopTime();
        if (PlayerPrefs.GetInt("SpawnPoint") == 0) PlayerPrefs.SetFloat("SaveTime", 0);
    }
    void Start()
    {
        Debug.Log("Cохраненное время в начале: " + PlayerPrefs.GetFloat("SaveTime"));
        if (!PlayerPrefs.HasKey("SaveTime")) PlayerPrefs.SetFloat("SaveTime", 0);
        if (!PlayerPrefs.HasKey("Time")) PlayerPrefs.SetFloat("Time", 0);
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("SaveTime"));
        CheckUI();
        //CursorOn();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        ShowTime();
        ShowGetPoint();
        CheckUI();
        //Debug.Log(Time.timeScale);
       // if (panelDeath.activeSelf || panelWin.activeSelf) StopCoroutine(Timer());
    }

    public void CursorOn()
    {
        input.SetCursorState(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CursorOff()
    {
        input.SetCursorState(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("Game");
        // gameObject.GetComponent<LoadPoint>().Spawn();
    }

    public void StartGame()
    {
        StartTime();
        StartCoroutine(Timer());
    }

    public void Reset()
    {
       // var t = PlayerPrefs.GetFloat("OldBest");
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetFloat("OldBest", t);

        PlayerPrefs.DeleteKey("Time");
        PlayerPrefs.DeleteKey("SaveTime");
        PlayerPrefs.DeleteKey("SpawnPoint");
    }

    public IEnumerator Timer()
    {
        timer = PlayerPrefs.GetFloat("SaveTime");
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("SaveTime"));
        Debug.Log("Значение таймера перед запуском: " + timer);
        while (!panelDeath.activeSelf)// || !panelWin.activeSelf)
        {
            yield return new WaitForSeconds(1f);
            timer += 1;
            PlayerPrefs.SetFloat("Time", timer);
            Debug.Log("Преф время: " + PlayerPrefs.GetFloat("Time"));
        }
    }

    public void ShowTime()
    {
        time = PlayerPrefs.GetFloat("Time");
        //int totalSeconds = 3600; // Пример входных секунд

        hours = (int)time / 3600;
        minutes = (int)(time % 3600) / 60;
        seconds = (int)(time % 3600) % 60;

        //Debug.Log(hours + " часов " + minutes + " минут");

        if (hours >= 1)
        {
            
            if (minutes < 10)
            {
                if (seconds < 10)
                {
                    timerText.text = "Время " + hours + " : 0" + minutes + " : 0" + seconds;
                }
                else
                {
                    timerText.text = "Время " + hours + " : 0" + minutes + " : " + seconds;
                }
            }
            else
            {
                if (seconds < 10)
                {
                    timerText.text = "Время " + hours + " : " + minutes + " : 0" + seconds;
                }
                else
                {
                    timerText.text = "Время " + hours + " : " + minutes + " : " + seconds;
                }
            }
        }
        else if(minutes >= 1)
        {
            if (minutes < 10)
            {
                if (seconds < 10)
                {
                    timerText.text = "Время  0" + minutes + " : 0" + seconds;
                }
                else
                {
                    timerText.text = "Время 0" + minutes + " : " + seconds;
                }
            }
            else
            {
                if (seconds < 10)
                {
                    timerText.text = "Время " + minutes + " : 0" + seconds;
                }
                else
                {
                    timerText.text = "Время " + minutes + " : " + seconds;
                }
            }

        }
        else
        {
            timerText.text = "Время " + seconds.ToString();
        }
    }
    public void ShowGetPoint()
    {
        pointText.text = PlayerPrefs.GetInt("SpawnPoint").ToString() + "/45";
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }
    public void StartTime()
    {
        Time.timeScale = 1;
    }

    public void CheckUI()
    {
        if (mainMenu.activeSelf)
        {
            timerText.gameObject.SetActive(false);
            pointText.gameObject.SetActive(false);
        }
        else
        {
            timerText.gameObject.SetActive(true);
            pointText.gameObject.SetActive(true);
        }
    }

}
