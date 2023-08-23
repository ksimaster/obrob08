using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeActive : MonoBehaviour
{
    public GameObject objectForActive;
    private int i = 0;


    public void LiveObject()
    {
        objectForActive.SetActive(true);
    }
    private void Update()
    {
        if (objectForActive.activeSelf) i += 1;
        if (i > 150) 
        {
            objectForActive.SetActive(false);
            i = 0;
        } 
    }



}
