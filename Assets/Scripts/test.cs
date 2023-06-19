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
                // 쿨타임이 끝나고 1번 키를 누른 경우
                spawnTimer = 0.1f; // 스폰 간격을 줄임
                wlthrtlrks -= Time.deltaTime; // 지속시간 감소
                if (wlthrtlrks <= 0f)
                {
                    spawnTimer = 1f; // 생성시간을 1로 설정
                    cooltime = 10f; // 쿨타임을 다시 설정
                    isCooldown = true; // 쿨다운 상태로 설정
                    wlthrtlrks = 5f; // 지속시간을 다시 설정
                }
            }
            else
            {
                // 쿨타임이 아직 남은 경우
                Debug.Log("Cooling down...");
            }
        }

        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }

        // 쿨타임 감소
        if (isCooldown)
        {
            cooltime -= Time.deltaTime;
            if (cooltime <= 0f)
            {
                isCooldown = false;
                Debug.Log("Cooldown finished.");
            }
        }

        Debug.Log("지속시간: " + wlthrtlrks);
        Debug.Log("쿨타임: " + cooltime);
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

