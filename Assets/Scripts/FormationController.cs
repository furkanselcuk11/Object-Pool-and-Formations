using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{    
    [Header("Objects to add")]
    public GameObject prefabObj;
    public int newObjSize = 10;    // Eklenecek prefabObj sayýsý
    [Header("Circle Settings")]
    public float circleOffset = 1.25f;    // Yeni eklenecek nesneler arasý uzaklýk mesafesi 
    [Header("Square Settings")]
    public float squareOffsetX = -1f;    // Yeni eklenecek nesnelerinin X eksenindeki uzaklýk mesafesi 
    public float squareOffsetY = 1.25f;    // Yeni eklenecek nesnelerinin Y eksenindeki uzaklýk mesafesi 
    [Header("Spiral Settings")]
    public float spiralOffset = 1.25f;    // Yeni eklenecek nesneler arasý uzaklýk mesafesi 
    public float spiralOffsetY = 0.5f;    // Yeni eklenecek nesneler arasý uzaklýk mesafesi 

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
        Vector3 targetPos = Vector3.zero;   // Oluþturulacak nesnenin ilk  pozisyonunu sýfýrlar

        GameObject circle = new GameObject("Circle");    // Oyun sahnesinde "Circle" adlý yeni bir nesne oluþturur
        circle.transform.position = Vector3.zero;    // "Circle" nesnesini pozisyonunu sýfýrlar

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Oluþturulacak yeni nesneler

            float angle = i * (2 * 3.14159f / newObjSize);    // Açý tanýmlanýr - Eklenecek nesne sayýsýna bölünür
            float x = Mathf.Cos(angle) * circleOffset;  // Cos açýsý(angle) 
            float y = Mathf.Sin(angle) * circleOffset;  // Sin açýsý(angle)  

            targetPos = new Vector3(targetPos.x+x,targetPos.y+y,0f); // Oluþturulacak olan yeni nesnenin pozisyonlarý belirlenir
            newObj.transform.position = targetPos;  // "newObj" adlý yeni oluþturulacak nesnenin pozisyonu "targetPos"un vector deðerlerini alýr
            newObj.transform.SetParent(circle.transform);    // Oluþturulan "newObj" yeni nesneler "Circle" nesnesinin alt nesnesi olur
        }
    }
    private void SquareFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Oluþturulacak nesnenin ilk  pozisyonunu sýfýrlar

        GameObject square = new GameObject("Square");    // Oyun sahnesinde "Square" adlý yeni bir nesne oluþturur
        square.transform.position = Vector3.zero;    // "Square" nesnesini pozisyonunu sýfýrlar

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
            newObj.transform.SetParent(square.transform);    // Oluþturulan "newObj" yeni nesneler "Square" nesnesinin alt nesnesi olur
        }
    }
    private void SpiralFormation()
    {
        Vector3 targetPos = Vector3.zero;   // Oluþturulacak nesnenin ilk  pozisyonunu sýfýrlar

        GameObject spiral = new GameObject("Spiral");    // Oyun sahnesinde "Spiral" adlý yeni bir nesne oluþturur
        spiral.transform.position = Vector3.zero;    // "Spiral" nesnesini pozisyonunu sýfýrlar

        for (int i = 0; i < newObjSize; i++)
        {
            GameObject newObj = Instantiate(prefabObj); // Oluþturulacak yeni nesneler

            float angle = i * (2 * 3.14159f / newObjSize);    // Açý tanýmlanýr - Eklenecek nesne sayýsýna bölünür
            float x = Mathf.Cos(angle) * spiralOffset;  // Cos açýsý(angle) 
            float z = Mathf.Sin(angle) * spiralOffset;  // Sin açýsý(angle)  

            targetPos = new Vector3(targetPos.x + x, targetPos.y + spiralOffsetY, targetPos.z+z); // Oluþturulacak olan yeni nesnenin pozisyonlarý belirlenir
            newObj.transform.position = targetPos;  // "newObj" adlý yeni oluþturulacak nesnenin pozisyonu "targetPos"un vector deðerlerini alýr
            newObj.transform.SetParent(spiral.transform);    // Oluþturulan "newObj" yeni nesneler "Spiral" nesnesinin alt nesnesi olur
        }
    }
}
