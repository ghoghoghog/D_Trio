using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowall : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision) //���_1�� �浹�� ����
    {
        if (collision.gameObject.tag == "People_1")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnBecameInvisible()    //ȭ�� ������ ������ �ı�
    {
        Destroy(gameObject);
    }
}
