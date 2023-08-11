using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPoint : MonoBehaviour
{
    public GameObject[] points;
    public GameObject player;

    void Start()
    {
        player.transform.position = points[PlayerPrefs.GetInt("SpawnPoint")].transform.position;
    }

}
