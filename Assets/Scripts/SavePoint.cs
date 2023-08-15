using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{

    public GameObject panelSave;

    private void Start()
    {
        panelSave.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Игрок вступил на точку сохранения!");
            if(int.Parse(gameObject.name) > PlayerPrefs.GetInt("SpawnPoint"))
            {
                PlayerPrefs.SetInt("SpawnPoint", int.Parse(gameObject.name));
                PlayerPrefs.SetInt("SaveTime", PlayerPrefs.GetInt("Time"));
                panelSave.SetActive(true);
                StartCoroutine(ClosePanelSave());
            }
            
            Debug.Log(PlayerPrefs.GetInt("SpawnPoint"));
        }
    }

    IEnumerator ClosePanelSave()
    {
        yield return new WaitForSeconds(2f);
        panelSave.SetActive(false);
    }
}
