using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle_Ctrl : MonoBehaviour
{
    public GameObject People_1;
    
    public string Castle_Name;  //���� �̸�

    public int Current_Hp;  //���� ���� ü��
    public int Hp;  //���� �� ü��

    public Text _Name;  //ȭ��� ��Ÿ���� �� �̸�
    public Text _Hp;    //ȭ��� ��Ÿ���� �� ü��

    private void Start()
    {
        _Name.text = Castle_Name;
        People_1 = GameObject.FindGameObjectWithTag("People_1");
    }

    private void Update()
    {
        _Hp.text = Current_Hp + " / " + Hp; //���� ü�� + " / " + �� ü��
    }
}
