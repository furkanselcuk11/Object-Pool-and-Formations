using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{
    public GameObject prefabObj;

    public int newObjSize = 10;    // Eklenecek prefabObj sayýsý
    public float distanceBetweenObj = 1.1f;    // Yeni eklenecek nesneler arasý uzaklýk mesafesi 

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
            GameObject newObj = Instantiate(prefabObj); // Oluþturulacak yeni nesneler

            float angle = i * (2 * 3.14159f / newObjSize);    // Açý tanýmlanýr - Eklenecek nesne sayýsýna bölünür
            float x = Mathf.Cos(angle) * distanceBetweenObj;  // Cos açýsý(angle) 
            float y = Mathf.Sin(angle) * distanceBetweenObj;  // Sin açýsý(angle)  

            targetPos = new Vector3(targetPos.x+x,targetPos.y+y,0); // Oluþturulacak olan yeni nesnenin pozisyonlarý belirlenir
            newObj.transform.position = targetPos;  // "newObj" adlý yeni oluþturulacak nesnenin pozisyonu "targetPos"un vector deðerlerini alýr
        }
    }
}
