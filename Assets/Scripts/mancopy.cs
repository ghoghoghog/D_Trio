using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mancopy : MonoBehaviour
{
    public GameObject objectToCopy; // 복사할 오브젝트
    public Transform copyPosition; // 복사 위치
    public float copyInterval = 1f; // 복사 간격 (초)

    private float timer; // 시간 측정용 타이머

    private void Start()
    {
        timer = copyInterval; // 타이머 초기화
    }

    private void Update()
    {
        timer -= Time.deltaTime; // 시간 감소

        if (timer <= 0f) // 타이머가 0 이하이면
        {
            CopyObject(); // 오브젝트 복사
            timer = copyInterval; // 타이머 재설정
        }
    }

    private void CopyObject()
    {
        GameObject copiedObject = Instantiate(objectToCopy, copyPosition.position, copyPosition.rotation); // 오브젝트 복사 및 위치, 회전 설정
        // 복사된 오브젝트에 필요한 추가적인 조작을 할 수 있습니다.
    }
}



