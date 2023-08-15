using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  
    void Start()
    {
        if (PlayerPrefs.HasKey("SaveTime")) PlayerPrefs.SetFloat("SaveTime", 0);
        if (PlayerPrefs.HasKey("Time")) PlayerPrefs.SetFloat("Time", 0);
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("SaveTime"));
    }

    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartGame()
    {
        StartCoroutine(Timer(PlayerPrefs.GetFloat("SaveTime")));
    }
    IEnumerator Timer(float time)
    {
        var i = 0;
        
        while (i > 0)
        {
            yield return new WaitForSeconds(1f);
            time += 1;
            PlayerPrefs.SetFloat("Time", time);
        }
    }
}
