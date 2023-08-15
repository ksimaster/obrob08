using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{

    public GameObject panelSave;
    private GameObject ancor;

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
                PlayerPrefs.SetFloat("SaveTime", PlayerPrefs.GetFloat("Time"));
                panelSave.SetActive(true);
                StartCoroutine(ClosePanelSave());
            }
            ancor = transform.parent.GetChild(2).transform.gameObject;
            col.gameObject.transform.LookAt(ancor.transform);
            //col.gameObject.transform.parent.GetChild(1).LookAt(ancor.transform);
            //col.gameObject.CompareTag("Player")
            Debug.Log(PlayerPrefs.GetInt("SpawnPoint"));
        }
    }

    IEnumerator ClosePanelSave()
    {
        yield return new WaitForSeconds(2f);
        panelSave.SetActive(false);
    }
}
