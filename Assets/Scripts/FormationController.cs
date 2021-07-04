using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{
    public GameObject prefabObj;

    public int newObjSize = 10;    // Eklenecek prefabObj say�s�
    public float distanceBetweenObj = 1.1f;    // Yeni eklenecek nesneler aras� uzakl�k mesafesi 

    public bool circleFormationBool = false;
    void Start()
    {
        if (circleFormationBool)
        {
            CircleFormation();
        }
    }

    private void CircleFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Hedef nesnenin pozisyonunu 0 yapar

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Olu�turulacak yeni nesneler

            float angle = i * (2 * 3.14159f / newObjSize);    // A�� tan�mlan�r - Eklenecek nesne say�s�na b�l�n�r
            float x = Mathf.Cos(angle) * distanceBetweenObj;  // Cos a��s�(angle) 
            float y = Mathf.Sin(angle) * distanceBetweenObj;  // Sin a��s�(angle)  

            targetPos = new Vector3(targetPos.x+x,targetPos.y+y,0); // Olu�turulacak olan yeni nesnenin pozisyonlar� belirlenir
            newObj.transform.position = targetPos;  // "newObj" adl� yeni olu�turulacak nesnenin pozisyonu "targetPos"un vector de�erlerini al�r
        }
    }
}
