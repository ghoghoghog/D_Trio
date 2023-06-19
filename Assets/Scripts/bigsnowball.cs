using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigsnowball : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    
   
    public float cooltime = 10;


    private void Start()
    {
        cooltime = 0;
    }
    private void Update()
    {
        cooltime -= Time.deltaTime;
        if (cooltime <= 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnObject();
            
        }
    }
    private void SpawnObject()
    {
        GameObject newObject = Instantiate(objectPrefab);
        cooltime = 10;
    }
}
