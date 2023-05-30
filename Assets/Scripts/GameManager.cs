using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject snowflake;   //변수 선언

    void Start()
    {
        StartCoroutine(CreatesnowflakeRoutione());
    }
    void Update()
    {
        
    }

    IEnumerator CreatesnowflakeRoutione()   //1초마다 snowflake 생성
    {
        while(true) //지속적으로 생성되도록
        {
            CreatSnowflake();
            yield return new WaitForSeconds(0.25f); //대기시간
        }
    }

    private void CreatSnowflake()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0.0f;
        //ViewportToWorldPoint = 카메라 안에서만 생성되도록
        Instantiate(snowflake, pos, Quaternion.identity);    //snowflake 오브젝트 생성
        //Quaternion.identity = 오브젝트의 회전을 막는
    }
}
