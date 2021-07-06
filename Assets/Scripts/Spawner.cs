using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1;   // Ne s�kl�kla nesne ��kar�lacak
    [SerializeField] private ObjectPool objectPool = null;
    void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }
    private IEnumerator SpawnRoutine()
    {
        int counter = 0;
        while (true)    // Sonsuz d�ng� 
        {
            GameObject newObj=objectPool.GetPooledObject(counter++ %2);    // "ObjectPool" scriptinden yeni nesne �eker            
            
            newObj.transform.position = Vector3.zero;   // Gelen yeni nesnenin pozisyonu s�f�rlar

            yield return new WaitForSeconds(spawnInterval); // Fonk �al��ma s�resi
        }
    }
}
