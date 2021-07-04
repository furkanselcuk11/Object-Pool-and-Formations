using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{    
    [Header("Objects to add")]
    public GameObject prefabObj;
    public int newObjSize = 10;    // Eklenecek prefabObj sayýsý
    [Header("Circle Settings")]
    public float circleOffset = 1.1f;    // Yeni eklenecek nesneler arasý uzaklýk mesafesi 
    [Header("Square Settings")]
    public float squareOffsetX = -1f;    // Yeni eklenecek nesnelerinin X eksenindeki uzaklýk mesafesi 
    public float squareOffsetY = 1.25f;    // Yeni eklenecek nesnelerinin Y eksenindeki uzaklýk mesafesi 

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
        Vector3 targetPos = Vector3.zero;   // Oluþturulacak nesnenin ilk  pozisyonunu 0 yapar

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Oluþturulacak yeni nesneler

            float angle = i * (2 * 3.14159f / newObjSize);    // Açý tanýmlanýr - Eklenecek nesne sayýsýna bölünür
            float x = Mathf.Cos(angle) * circleOffset;  // Cos açýsý(angle) 
            float y = Mathf.Sin(angle) * circleOffset;  // Sin açýsý(angle)  

            targetPos = new Vector3(targetPos.x+x,targetPos.y+y,0f); // Oluþturulacak olan yeni nesnenin pozisyonlarý belirlenir
            newObj.transform.position = targetPos;  // "newObj" adlý yeni oluþturulacak nesnenin pozisyonu "targetPos"un vector deðerlerini alýr
        }
    }
    private void SquareFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Oluþturulacak nesnenin ilk  pozisyonunu 0 yapar

        int counter = -1;
        float sqrt = Mathf.Sqrt(newObjSize);    
        // Oluþturulacak nesnelerin dizilimi eklencenek nesne sayýsýnýn karesi þeklinde kare þeklini alýr
        float startX = targetPos.x; // Oluþturulacak nesnenin X eksenindeki  deðeri alýr

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Oluþturulacak yeni nesneler

            counter++;
            squareOffsetX++;    // Her oluþturulan nesnede X ekseni 1 birim artar
            if (squareOffsetX > 1)
            {
                squareOffsetX = 1;
            }
            targetPos = new Vector3(targetPos.x + (squareOffsetX * 2f), targetPos.y, 0f);  // Oluþturulacak olan yeni nesnenin pozisyonlarý belirlenir

            if (counter == Mathf.Floor(sqrt))
            {
                counter = 0;
                targetPos.x = startX;
                targetPos.y+= squareOffsetY; // Yeni eklenecek nesnelerinin Y eksenindeki uzaklýk mesafesi 
            }
            newObj.transform.position = targetPos;   // "newObj" adlý yeni oluþturulacak nesnenin pozisyonu "targetPos"un vector deðerlerini alýr
        }
    }
}
