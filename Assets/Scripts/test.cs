using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 1;
    public float launchForce = 10f;
    public float cooltime = 10;
    private float spawnTimer;
    public float wlthrtlrks = 5f;
    
    private bool isCooldown = false;

    private void Start()
    {
        spawnTimer = spawnInterval;
        cooltime = 0;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (cooltime <= 0f && Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isCooldown)
            {
                // ��Ÿ���� ������ 1�� Ű�� ���� ���
                spawnTimer = 0.1f; // ���� ������ ����
                wlthrtlrks -= Time.deltaTime; // ���ӽð� ����
                if (wlthrtlrks <= 0f)
                {
                    spawnTimer = 1f; // �����ð��� 1�� ����
                    cooltime = 10f; // ��Ÿ���� �ٽ� ����
                    isCooldown = true; // ��ٿ� ���·� ����
                    wlthrtlrks = 5f; // ���ӽð��� �ٽ� ����
                }
            }
            else
            {
                // ��Ÿ���� ���� ���� ���
                Debug.Log("Cooling down...");
            }
        }

        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }

        // ��Ÿ�� ����
        if (isCooldown)
        {
            cooltime -= Time.deltaTime;
            if (cooltime <= 0f)
            {
                isCooldown = false;
                Debug.Log("Cooldown finished.");
            }
        }

        Debug.Log("���ӽð�: " + wlthrtlrks);
        Debug.Log("��Ÿ��: " + cooltime);
    }

    private void SpawnObject()
    {
        GameObject newObject = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 launchDirection = (mousePos - spawnPoint.position).normalized;
            rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
        }
    }
}

