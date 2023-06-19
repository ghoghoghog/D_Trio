using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mancopy : MonoBehaviour
{
    public GameObject objectToCopy; // ������ ������Ʈ
    public Transform copyPosition; // ���� ��ġ
    public float copyInterval = 1f; // ���� ���� (��)

    private float timer; // �ð� ������ Ÿ�̸�

    private void Start()
    {
        timer = copyInterval; // Ÿ�̸� �ʱ�ȭ
    }

    private void Update()
    {
        timer -= Time.deltaTime; // �ð� ����

        if (timer <= 0f) // Ÿ�̸Ӱ� 0 �����̸�
        {
            CopyObject(); // ������Ʈ ����
            timer = copyInterval; // Ÿ�̸� �缳��
        }
    }

    private void CopyObject()
    {
        GameObject copiedObject = Instantiate(objectToCopy, copyPosition.position, copyPosition.rotation); // ������Ʈ ���� �� ��ġ, ȸ�� ����
        // ����� ������Ʈ�� �ʿ��� �߰����� ������ �� �� �ֽ��ϴ�.
    }
}



