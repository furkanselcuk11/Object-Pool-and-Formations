using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{   
    [Serializable]
    public struct Pool
    {   // Pool Birden fazla farkl� nesne ekler
        // Quene= S�ran�n sonuna ekleyip, Ba��ndan ��kar�r�r
        public Queue<GameObject> pooledObjects; // Olu�turulacak nesneler bir s�rada tutulur - Quene,Liste veya dizide tutulablir
        public GameObject objectPrefab;   // Olu�turulacak nesne prefab�
        public int poolSize;  // Olu�turulacak nesne say�s�
    }

    [SerializeField] private Pool[] pools = null;  

    private void Awake()
    {
        // --- Havuz olu�turma �oklu Obje ---   
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>(); // Yeni bir s�ra olu�turulur
            for (int i = 0; i < pools[j].poolSize; i++)
            {
                // for d�ng�s� ile"poolSize" Olu�turulacak nesne say�s� kadar yeni nesne olu�turur
                GameObject newObj = Instantiate(pools[j].objectPrefab);  // Yeni olu�turulan nesneleri "newObj" ismi ile olu�turur
                newObj.SetActive(false);    // Ba�lang��ta t�m nesnenin aktifli�i false yapar

                pools[j].pooledObjects.Enqueue(newObj);  // Olu�turulan yeni nesneler s�raya eklenir "poolSize" de�eri kadar nesne eklenir
            }
        }
    }    
    
    public GameObject GetPooledObject(int objectType)
    {
        if (objectType>=pools.Length)
        {
            return null;
        }
        GameObject newObj = pools[objectType].pooledObjects.Dequeue();    // S�ran�n ba��ndan ilk nesneyi ��kar�r
        newObj.SetActive(true); // ��kar�lan nesnenin aktifli�i true yapar

        pools[objectType].pooledObjects.Enqueue(newObj);  // ��kar�lan nesneyi tekrar s�ran�n sonune ekler ve havuzda d�ng� olu�turur 
        // (newObj1,newObj2,newObj3,newObj1,newObj2,newObj3) �eklinde d�ner
        return newObj;
    }
    
}
