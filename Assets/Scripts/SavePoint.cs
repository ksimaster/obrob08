using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{


    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Игрок вступил на точку сохранения!");
            if(int.Parse(gameObject.name) >= PlayerPrefs.GetInt("SpawnPoint"))
            {
                PlayerPrefs.SetInt("SpawnPoint", int.Parse(gameObject.name));
                PlayerPrefs.SetInt("SaveTime", PlayerPrefs.GetInt("Time"));
            }
            
            Debug.Log(PlayerPrefs.GetInt("SpawnPoint"));
        }
    }
}
