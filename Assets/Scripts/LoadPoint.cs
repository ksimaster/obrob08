using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPoint : MonoBehaviour
{
    public GameObject[] points;
    public GameObject player;

    private void Awake()
    {
        //if (!PlayerPrefs.HasKey("SpawnPoint")) PlayerPrefs.SetInt("SpawnPoint", -1);
        if (!PlayerPrefs.HasKey("SpawnPoint")) PlayerPrefs.SetInt("SpawnPoint", 0);
    }
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("SpawnPoint"));
        player.transform.position = new Vector3(points[PlayerPrefs.GetInt("SpawnPoint")].transform.position.x, points[PlayerPrefs.GetInt("SpawnPoint")].transform.position.y, points[PlayerPrefs.GetInt("SpawnPoint")].transform.position.z);
    }

}
