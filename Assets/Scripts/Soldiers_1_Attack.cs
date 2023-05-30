using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers_1_Attack : MonoBehaviour
{
    public GameObject People_1;
    public GameObject Snowball1;
    public Transform pos;
    public float cooltime;
    private float curtime;

    private Transform People;

    private void Start()
    {
        People_1 = GameObject.FindGameObjectWithTag("People_1");
        curtime = cooltime;
    }

    void Update()
    {
        if(People_1 != null)
        {
            if (People_1.GetComponent<People_1_Ctrl>().Current_Hp > 0)   //사람이 죽지 않았을때
            {
                if (curtime <= 0)
                {
                    Instantiate(Snowball1, pos.position, transform.rotation);
                    curtime = cooltime;
                }
                curtime -= Time.deltaTime;
            }
        }
        else if(People_1 == null)
        {
            // if (curtime <= 0)
            // {
            //     Instantiate(Snowball1, pos.position, transform.rotation);
            //     curtime = cooltime;
            // }
            curtime -= Time.deltaTime;
        }
    }
}
