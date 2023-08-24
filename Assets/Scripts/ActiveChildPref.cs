using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveChildPref : MonoBehaviour
{
    public Button buttonSelect;
    void Update()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 1) 
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            buttonSelect.interactable = true;
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            buttonSelect.interactable = false;
        }
    }
}
