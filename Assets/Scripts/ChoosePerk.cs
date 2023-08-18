using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePerk : MonoBehaviour
{
    
    public GameObject perk;
    public GameObject playerArmature;

    private int i = 0;
   

    private void Start()
    {
        perk.transform.GetChild(i).gameObject.SetActive(true);
    }

    public void Next()
    {
        perk.transform.GetChild(i).gameObject.SetActive(false);
        playerArmature.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(false);
        i += 1;
        if (i > perk.transform.childCount - 1) i = 0;
        perk.transform.GetChild(i).gameObject.SetActive(true);
    }

    public void Pre()
    {
        perk.transform.GetChild(i).gameObject.SetActive(false);
        playerArmature.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(false);
        i -= 1;
        if (i < 0 ) i = perk.transform.childCount - 1;
        perk.transform.GetChild(i).gameObject.SetActive(true);
    }

    public void Select()
    {
        playerArmature.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(true);
        playerArmature.GetComponent<Animator>().avatar = playerArmature.transform.GetChild(1).transform.GetChild(i).GetComponent<Animator>().avatar;
        
    }

}
