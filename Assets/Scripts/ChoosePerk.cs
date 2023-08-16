using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePerk : MonoBehaviour
{
    
    public GameObject perk;

    private int i = 0;

    private void Start()
    {
        perk.transform.GetChild(i).gameObject.SetActive(true);
    }

    public void Next()
    {
        perk.transform.GetChild(i).gameObject.SetActive(false);
        i += 1;
        if (i > perk.transform.childCount - 1) i = 0;
        perk.transform.GetChild(i).gameObject.SetActive(true);
    }

    public void Pre()
    {
        perk.transform.GetChild(i).gameObject.SetActive(false);
        i -= 1;
        if (i < 0 ) i = perk.transform.childCount - 1;
        perk.transform.GetChild(i).gameObject.SetActive(true);
    }

}
