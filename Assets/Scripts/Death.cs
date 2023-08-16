using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject panelDeath; 

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Laser"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            Time.timeScale = 0;
            panelDeath.SetActive(true);
            if (panelDeath.activeSelf) 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } 
            // дописать отключалки времени, взаимодействия и т.п.
        }
    }
}
