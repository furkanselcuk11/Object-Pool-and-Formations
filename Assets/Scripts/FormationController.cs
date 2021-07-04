using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{    
    [Header("Objects to add")]
    public GameObject prefabObj;
    public int newObjSize = 10;    // Eklenecek prefabObj say�s�
    [Header("Circle Settings")]
    public float circleOffset = 1.25f;    // Yeni eklenecek nesneler aras� uzakl�k mesafesi 
    [Header("Square Settings")]
    public float squareOffsetX = -1f;    // Yeni eklenecek nesnelerinin X eksenindeki uzakl�k mesafesi 
    public float squareOffsetY = 1.25f;    // Yeni eklenecek nesnelerinin Y eksenindeki uzakl�k mesafesi 
    [Header("Spiral Settings")]
    public float spiralOffset = 1.25f;    // Yeni eklenecek nesneler aras� uzakl�k mesafesi 
    public float spiralOffsetY = 0.5f;    // Yeni eklenecek nesneler aras� uzakl�k mesafesi 

    [Header("Formations Bool")]
    public bool circleFormationBool = false;
    public bool squareFormationBool = false;
    public bool spiralFormationBool = false;
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
        if (spiralFormationBool)
        {
            SpiralFormation();
        }
    }

    private void CircleFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Olu�turulacak nesnenin ilk  pozisyonunu s�f�rlar

        GameObject circle = new GameObject("Circle");    // Oyun sahnesinde "Circle" adl� yeni bir nesne olu�turur
        circle.transform.position = Vector3.zero;    // "Circle" nesnesini pozisyonunu s�f�rlar

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Olu�turulacak yeni nesneler

            float angle = i * (2 * 3.14159f / newObjSize);    // A�� tan�mlan�r - Eklenecek nesne say�s�na b�l�n�r
            float x = Mathf.Cos(angle) * circleOffset;  // Cos a��s�(angle) 
            float y = Mathf.Sin(angle) * circleOffset;  // Sin a��s�(angle)  

            targetPos = new Vector3(targetPos.x+x,targetPos.y+y,0f); // Olu�turulacak olan yeni nesnenin pozisyonlar� belirlenir
            newObj.transform.position = targetPos;  // "newObj" adl� yeni olu�turulacak nesnenin pozisyonu "targetPos"un vector de�erlerini al�r
            newObj.transform.SetParent(circle.transform);    // Olu�turulan "newObj" yeni nesneler "Circle" nesnesinin alt nesnesi olur
        }
    }
    private void SquareFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Olu�turulacak nesnenin ilk  pozisyonunu s�f�rlar

        GameObject square = new GameObject("Square");    // Oyun sahnesinde "Square" adl� yeni bir nesne olu�turur
        square.transform.position = Vector3.zero;    // "Square" nesnesini pozisyonunu s�f�rlar

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
            newObj.transform.SetParent(square.transform);    // Olu�turulan "newObj" yeni nesneler "Square" nesnesinin alt nesnesi olur
        }
    }
    private void SpiralFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Olu�turulacak nesnenin ilk  pozisyonunu s�f�rlar

        GameObject spiral = new GameObject("Spiral");    // Oyun sahnesinde "Spiral" adl� yeni bir nesne olu�turur
        spiral.transform.position = Vector3.zero;    // "Spiral" nesnesini pozisyonunu s�f�rlar

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Olu�turulacak yeni nesneler

            float angle = i * (2 * 3.14159f / newObjSize);    // A�� tan�mlan�r - Eklenecek nesne say�s�na b�l�n�r
            float x = Mathf.Cos(angle) * spiralOffset;  // Cos a��s�(angle) 
            float z = Mathf.Sin(angle) * spiralOffset;  // Sin a��s�(angle)  

            targetPos = new Vector3(targetPos.x + x, targetPos.y + spiralOffsetY, targetPos.z+z); // Olu�turulacak olan yeni nesnenin pozisyonlar� belirlenir
            newObj.transform.position = targetPos;  // "newObj" adl� yeni olu�turulacak nesnenin pozisyonu "targetPos"un vector de�erlerini al�r
            newObj.transform.SetParent(spiral.transform);    // Olu�turulan "newObj" yeni nesneler "Spiral" nesnesinin alt nesnesi olur
        }
    }
}
