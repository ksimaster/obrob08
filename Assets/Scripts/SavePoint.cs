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
            PlayerPrefs.SetInt("SpawnPoint", int.Parse(gameObject.name));
            Debug.Log(PlayerPrefs.GetInt("SpawnPoint"));
        }
    }
}
