using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text pointText;
    public GameObject mainMenu;

    private float time = 0f;
    private float hours = 0f;
    private float minutes = 0f;
    private float seconds = 0f;
    void Start()
    {
        Debug.Log("C���������� ����� � ������: " + PlayerPrefs.GetFloat("SaveTime"));
        if (!PlayerPrefs.HasKey("SaveTime")) PlayerPrefs.SetFloat("SaveTime", 0);
        if (!PlayerPrefs.HasKey("Time")) PlayerPrefs.SetFloat("Time", 0);
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("SaveTime"));
        CheckUI();
    }

    void Update()
    {
        ShowTime();
        ShowGetPoint();
        CheckUI();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        // gameObject.GetComponent<LoadPoint>().Spawn();
    }

    public void StartGame()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        var i = 0;
        var timer = PlayerPrefs.GetFloat("SaveTime");
        while (i == 0)
        {
            yield return new WaitForSeconds(1f);
            timer += 1;
            PlayerPrefs.SetFloat("Time", timer);
            Debug.Log("���� �����: " + PlayerPrefs.GetFloat("Time"));
        }
    }

    public void ShowTime()
    {
        time = PlayerPrefs.GetFloat("Time");
        //int totalSeconds = 3600; // ������ ������� ������

        hours = (int)time / 3600;
        minutes = (int)(time % 3600) / 60;
        seconds = (int)(time % 3600) % 60;

        //Debug.Log(hours + " ����� " + minutes + " �����");

        if (hours >= 1)
        {
            
            if (minutes < 10)
            {
                if (seconds < 10)
                {
                    timerText.text = "����� " + hours + " : 0" + minutes + " : 0" + seconds;
                }
                else
                {
                    timerText.text = "����� " + hours + " : 0" + minutes + " : " + seconds;
                }
            }
            else
            {
                if (seconds < 10)
                {
                    timerText.text = "����� " + hours + " : " + minutes + " : 0" + seconds;
                }
                else
                {
                    timerText.text = "����� " + hours + " : " + minutes + " : " + seconds;
                }
            }
        }
        else if(minutes >= 1)
        {
            if (minutes < 10)
            {
                if (seconds < 10)
                {
                    timerText.text = "�����  0" + minutes + " : 0" + seconds;
                }
                else
                {
                    timerText.text = "����� 0" + minutes + " : " + seconds;
                }
            }
            else
            {
                if (seconds < 10)
                {
                    timerText.text = "����� " + minutes + " : 0" + seconds;
                }
                else
                {
                    timerText.text = "����� " + minutes + " : " + seconds;
                }
            }

        }
        else
        {
            timerText.text = "����� " + seconds.ToString();
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
