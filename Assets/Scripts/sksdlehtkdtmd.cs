using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sksdlehtkdtmd : MonoBehaviour
{
    public float sksdlehtkdtmdtlrks = 15;
    public GameObject man;
    
    void Update()
    {
        sksdlehtkdtmdtlrks -= Time.deltaTime;
        if (sksdlehtkdtmdtlrks<=0)
        { 
            man.gameObject.GetComponent<manmove>().speed *=2;
        }
    }
}
