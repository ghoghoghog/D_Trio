using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 1;
    public float tmzlfthreh = 0.1f;
    public float launchForce = 10f;
    public float cooltime = 10;
    private float spawnTimer;
    public float wlthrtlrks = 5f;
    
    

    private void Start()
    {
        spawnTimer = spawnInterval;
        cooltime = 0;
        wlthrtlrks = 0;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        cooltime -= Time.deltaTime;
        wlthrtlrks -= Time.deltaTime;

        if (cooltime <= 0f && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("지속시간: " + wlthrtlrks);
            Debug.Log("쿨타임: " + cooltime);
            wlthrtlrks = 5;
            cooltime = 10;
        }

        if (wlthrtlrks>=0&& spawnTimer<=0)
        {
            SpawnObject();
            spawnTimer = 0.1f;
            spawnTimer = tmzlfthreh;
        }
        
        if (spawnTimer <= 0f&& wlthrtlrks<=0)
        {
            SpawnObject();
            spawnTimer = 1;
        }

       

        
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

