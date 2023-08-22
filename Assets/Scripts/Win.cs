using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class Win : MonoBehaviour
{
    public GameObject panelDeath;
    public GameObject gameController;
    
    //public GameObject playerArmature;


    private GameObject scene;

    private GameObject[] pointsDeath;

    private void Start()
    {
        //pointsDeath = gameController.GetComponent<LoadPoint>().points;
        //scene = 
    }

   

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Laser"))
        {
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            //gameController.GetComponent<LoadPoint>().Spawn();
            /*
            Debug.Log("Номер спаун пойнта: " + PlayerPrefs.GetInt("SpawnPoint"));
            var spawnPointPosition = pointsDeath[PlayerPrefs.GetInt("SpawnPoint")].transform.position;
            Debug.Log("Спаун пойнт позишион: " + spawnPointPosition);
            */

            //transform.position = new Vector3(spawnPointPosition.x, spawnPointPosition.y + 1, spawnPointPosition.z);
            //transform.parent.transform.position = new Vector3(1, 1, 1);
            // Instantiate(player, pointsDeath[PlayerPrefs.GetInt("SpawnPoint")].transform);
            // Destroy();
            // transform.GetChild(0).gameObject.SetActive(false);
            //transform.GetChild(0).position = new Vector3(spawnPointPosition.x, spawnPointPosition.y + 1, spawnPointPosition.z);
            //transform.position = new Vector3(spawnPointPosition.x, spawnPointPosition.y, spawnPointPosition.z);
            // CinemachineVirtualCamera vcam = transform.parent.transform.GetChild(2).GetComponent<CinemachineVirtualCamera>();
            //CinemachineTransposer transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
            //transposer.m_FollowOffset += new Vector3(0,1,0);
            //vcam.OnTargetObjectWarped(transform, pointsDeath[PlayerPrefs.GetInt("SpawnPoint")].transform.position);
            // transform.parent.transform.GetChild(2).gameObject.SetActive(true);
            // scene.transform.position += transform.position - spawnPointPosition;
            //SceneManager.LoadScene("Game");
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameController.GetComponent<LoadPoint>().Spawn();
            //gameController.GetComponent<GameController>().StopCoroutine(Timer());
            Time.timeScale = 0;
            panelDeath.SetActive(true);

            Debug.Log("Значение сохраненного времени: " + PlayerPrefs.GetFloat("SaveTime"));


            // SceneManager.LoadSceneAsync("Game");




            // Time.timeScale = 0;
            // panelDeath.SetActive(true);
            if (panelDeath.activeSelf) 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //gameObject.SetActive(true);
            } 
            // дописать отключалки времени, взаимодействия и т.п.
        }
    }
   
 
}
