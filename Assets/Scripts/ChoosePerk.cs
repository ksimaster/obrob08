using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePerk : MonoBehaviour
{
    public GameObject[] perks;
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
        perk.transform.GetChild(i).gameObject.SetActive(true);
    }

    public void Pre()
    {
        perk.transform.GetChild(i).gameObject.SetActive(false);
        i -= 1;
        perk.transform.GetChild(i).gameObject.SetActive(true);
    }

}
