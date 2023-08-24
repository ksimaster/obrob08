using UnityEngine;


public class Lederboard : MonoBehaviour
{
    public GameObject panelWin;
    void Start()
    {
        //if(panelWin.activeSelf) SetHighScoreOnLederboard();
         if (!PlayerPrefs.HasKey("OldBest")) PlayerPrefs.SetFloat("OldBest", 0);
    }

    public void SetHighScoreOnLederboard()
    {
        
        int best = PlayerPrefs.GetInt("OldBest");
#if UNITY_WEBGL && !UNITY_EDITOR
    	WebGLPluginJS.SetLeder(best);
#endif
    }

    public void HighScore()
    {
        if(PlayerPrefs.GetFloat("NewBest") < PlayerPrefs.GetFloat("OldBest"))
        {
            PlayerPrefs.SetFloat("OldBest", PlayerPrefs.GetFloat("NewBest"));
            Debug.Log(PlayerPrefs.GetFloat("OldBest"));
            SetHighScoreOnLederboard();
        }
        else
        {
            SetHighScoreOnLederboard();
        }
    }

    private void Update()
    {
        if (panelWin.activeSelf) 
        {
            if (PlayerPrefs.GetFloat("OldBest") == 0) PlayerPrefs.SetFloat("OldBest", PlayerPrefs.GetFloat("SaveTime"));
            PlayerPrefs.SetFloat("NewBest", PlayerPrefs.GetFloat("SaveTime"));
            HighScore();
        }
            
    }



}
