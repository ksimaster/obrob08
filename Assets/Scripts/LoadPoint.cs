using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPoint : MonoBehaviour
{
    public GameObject[] points;
    public GameObject player;

    private int i = 0;

    private void Awake()
    {
        //if (!PlayerPrefs.HasKey("SpawnPoint")) PlayerPrefs.SetInt("SpawnPoint", -1);
        if (!PlayerPrefs.HasKey("SpawnPoint")) PlayerPrefs.SetInt("SpawnPoint", 0);
       // Spawn();
    }
    void Start()
    {
        
       // Spawn();

        /*
        var cam = GameObject.FindGameObjectWithTag("MainCamera");
        Debug.Log(cam.transform.localRotation);
        cam.transform.localRotation = Quaternion.identity;
        cam.transform.rotation = Quaternion.identity;

        var offset = player.transform.rotation * new Vector3(0, 0, -10);
        */
        // player.transform.position += new Vector3((anchorPosition.x - spawnPointPosition.x) * f, (anchorPosition.y - spawnPointPosition.y) * f, (anchorPosition.z - spawnPointPosition.z) * f);

    }
    /*
    private void LateUpdate()
    {
        if (i < 1)
        {
            Spawn();
            i += 1;
        }
    }
    */
    public void Spawn()
    {
        //Time.timeScale = 1;
        Debug.Log("Номер точки спауна " + PlayerPrefs.GetInt("SpawnPoint"));
        var spawnPointPosition = points[PlayerPrefs.GetInt("SpawnPoint")].transform.position;
        var anchorPosition = points[PlayerPrefs.GetInt("SpawnPoint")].transform.parent.GetChild(3).position;
        player.transform.position = new Vector3(spawnPointPosition.x, spawnPointPosition.y, spawnPointPosition.z);
        player.transform.LookAt(anchorPosition);
       // var cam = GameObject.FindGameObjectWithTag("CinemachineTarget");
       // cam.transform.LookAt(anchorPosition);
        player.GetComponent<CharacterController>().enabled = true;
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("SaveTime"));
    }

}
