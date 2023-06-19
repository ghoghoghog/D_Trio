using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowall : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision) //사람_1과 충돌시 삭제
    {
        if (collision.gameObject.tag == "People_1")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnBecameInvisible()    //화면 밖으로 나가면 파괴
    {
        Destroy(gameObject);
    }
}
