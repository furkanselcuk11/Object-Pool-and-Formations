using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1;   // Ne sýklýkla nesne çýkarýlacak
    [SerializeField] private ObjectPool objectPool = null;
    void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }
    private IEnumerator SpawnRoutine()
    {
        int counter = 0;
        while (true)    // Sonsuz döngü 
        {
            GameObject newObj=objectPool.GetPooledObject(counter++ %2);    // "ObjectPool" scriptinden yeni nesne çeker            
            
            newObj.transform.position = Vector3.zero;   // Gelen yeni nesnenin pozisyonu sýfýrlar

            yield return new WaitForSeconds(spawnInterval); // Fonk çalýþma süresi
        }
    }
}
