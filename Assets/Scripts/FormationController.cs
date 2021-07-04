using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{    
    [Header("Objects to add")]
    public GameObject prefabObj;
    public int newObjSize = 10;    // Eklenecek prefabObj say�s�
    [Header("Circle Settings")]
    public float circleOffset = 1.1f;    // Yeni eklenecek nesneler aras� uzakl�k mesafesi 
    [Header("Square Settings")]
    public float squareOffsetX = -1f;    // Yeni eklenecek nesnelerinin X eksenindeki uzakl�k mesafesi 
    public float squareOffsetY = 1.25f;    // Yeni eklenecek nesnelerinin Y eksenindeki uzakl�k mesafesi 

    [Header("Formations Bool")]
    public bool circleFormationBool = false;
    public bool squareFormationBool = false;
    void Start()
    {
        if (circleFormationBool)
        {
            CircleFormation();
        }
        if (squareFormationBool)
        {
            SquareFormation();
        }
    }

    private void CircleFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Olu�turulacak nesnenin ilk  pozisyonunu 0 yapar

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Olu�turulacak yeni nesneler

            float angle = i * (2 * 3.14159f / newObjSize);    // A�� tan�mlan�r - Eklenecek nesne say�s�na b�l�n�r
            float x = Mathf.Cos(angle) * circleOffset;  // Cos a��s�(angle) 
            float y = Mathf.Sin(angle) * circleOffset;  // Sin a��s�(angle)  

            targetPos = new Vector3(targetPos.x+x,targetPos.y+y,0f); // Olu�turulacak olan yeni nesnenin pozisyonlar� belirlenir
            newObj.transform.position = targetPos;  // "newObj" adl� yeni olu�turulacak nesnenin pozisyonu "targetPos"un vector de�erlerini al�r
        }
    }
    private void SquareFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Olu�turulacak nesnenin ilk  pozisyonunu 0 yapar

        int counter = -1;
        float sqrt = Mathf.Sqrt(newObjSize);    
        // Olu�turulacak nesnelerin dizilimi eklencenek nesne say�s�n�n karesi �eklinde kare �eklini al�r
        float startX = targetPos.x; // Olu�turulacak nesnenin X eksenindeki  de�eri al�r

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Olu�turulacak yeni nesneler

            counter++;
            squareOffsetX++;    // Her olu�turulan nesnede X ekseni 1 birim artar
            if (squareOffsetX > 1)
            {
                squareOffsetX = 1;
            }
            targetPos = new Vector3(targetPos.x + (squareOffsetX * 2f), targetPos.y, 0f);  // Olu�turulacak olan yeni nesnenin pozisyonlar� belirlenir

            if (counter == Mathf.Floor(sqrt))
            {
                counter = 0;
                targetPos.x = startX;
                targetPos.y+= squareOffsetY; // Yeni eklenecek nesnelerinin Y eksenindeki uzakl�k mesafesi 
            }
            newObj.transform.position = targetPos;   // "newObj" adl� yeni olu�turulacak nesnenin pozisyonu "targetPos"un vector de�erlerini al�r
        }
    }
}
