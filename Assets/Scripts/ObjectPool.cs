using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{   
    [Serializable]
    public struct Pool
    {   // Pool Birden fazla farklý nesne ekler
        // Quene= Sýranýn sonuna ekleyip, Baþýndan çýkarýrýr
        public Queue<GameObject> pooledObjects; // Oluþturulacak nesneler bir sýrada tutulur - Quene,Liste veya dizide tutulablir
        public GameObject objectPrefab;   // Oluþturulacak nesne prefabý
        public int poolSize;  // Oluþturulacak nesne sayýsý
    }

    [SerializeField] private Pool[] pools = null;  

    private void Awake()
    {
        // --- Havuz oluþturma Çoklu Obje ---   
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>(); // Yeni bir sýra oluþturulur
            for (int i = 0; i < pools[j].poolSize; i++)
            {
                // for döngüsü ile"poolSize" Oluþturulacak nesne sayýsý kadar yeni nesne oluþturur
                GameObject newObj = Instantiate(pools[j].objectPrefab);  // Yeni oluþturulan nesneleri "newObj" ismi ile oluþturur
                newObj.SetActive(false);    // Baþlangýçta tüm nesnenin aktifliði false yapar

                pools[j].pooledObjects.Enqueue(newObj);  // Oluþturulan yeni nesneler sýraya eklenir "poolSize" deðeri kadar nesne eklenir
            }
        }
    }    
    
    public GameObject GetPooledObject(int objectType)
    {
        if (objectType>=pools.Length)
        {
            return null;
        }
        GameObject newObj = pools[objectType].pooledObjects.Dequeue();    // Sýranýn baþýndan ilk nesneyi çýkarýr
        newObj.SetActive(true); // Çýkarýlan nesnenin aktifliði true yapar

        pools[objectType].pooledObjects.Enqueue(newObj);  // Çýkarýlan nesneyi tekrar sýranýn sonune ekler ve havuzda döngü oluþturur 
        // (newObj1,newObj2,newObj3,newObj1,newObj2,newObj3) þeklinde döner
        return newObj;
    }
    
}
