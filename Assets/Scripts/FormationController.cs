using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{    
    [Header("Objects to add")]
    public GameObject prefabObj;
    public int newObjSize = 10;    // Eklenecek prefabObj say�s�

    private enum Formation { Circle, Square, Spiral, Trangle, Sphere };   // ��genin hangi y�ne bakaca��
    [Header("Formations Selection")]
    [SerializeField] private Formation formationSelect;    

    [Header("Circle Settings")]
    public float circleOffset = 1.25f;    // Yeni eklenecek nesneler aras� uzakl�k mesafesi 

    [Header("Square Settings")]
    public float squareOffsetX = -1f;    // Yeni eklenecek nesnelerinin X eksenindeki uzakl�k mesafesi 
    public float squareOffsetY = 1.25f;    // Yeni eklenecek nesnelerinin Y eksenindeki uzakl�k mesafesi 

    [Header("Spiral Settings")]
    public float spiralOffset = 1.25f;    // Yeni eklenecek nesneler aras� uzakl�k mesafesi 
    public float spiralOffsetY = 0.5f;    // Yeni eklenecek nesnelerinin Y eksenindeki uzakl�k mesafesi 

    [Header("Triangle Settings")]
    public int rows = 3;    // ��genin en alt k�s�ma eklenecek ��gen say�s�-1
    public float rowOffset = -0.5f; // Yeni eklenecek nesneler aras� uzakl�k mesafesi 
    public float heightOffset = -1f;  // Yeni eklenecek nesnelerinin Y eksenindeki uzakl�k mesafesi 
    public float widthOffset = 1f;   // Yeni eklenecek nesnelerinin X eksenindeki uzakl�k mesafesi 
    private enum Direction { Up,Down,Left,Right};   // ��genin hangi y�ne bakaca��
    [SerializeField] private Direction triangleDirection;

    [Header("Sphere Settings")]
    public int sphereNumberOfPoints = 5;
    public int sphereRadius = 2;
    public int sphereMeridians = 5;

    
    void Start()
    {
        FormationSelect(formationSelect);

    }
    private void FormationSelect(Formation formation)
    {
        switch (formation)
        {
            case Formation.Circle:
                CircleFormation();
                break;
            case Formation.Square:
                SquareFormation();
                break;
            case Formation.Spiral:
                SpiralFormation();
                break;
            case Formation.Trangle:
                TriangleFormation(triangleDirection);
                break;
            case Formation.Sphere:
                SphereFormation(sphereNumberOfPoints, sphereRadius, sphereMeridians);
                break;
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
    private void TriangleFormation(Direction direction)
    {
        //Vector3 targetPos = Vector3.left;
        Vector3 targetPos = (direction == Direction.Up || direction == Direction.Down) ? new Vector3(-1, 0, 0) : new Vector3(0, -1, 0);

        GameObject triangle = new GameObject("Triangle");    // Oyun sahnesinde "Triangle" adl� yeni bir nesne olu�turur
        triangle.transform.position = Vector3.zero;    // "Triangle" nesnesini pozisyonunu s�f�rlar

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < i; j++)
            {
                GameObject newObj = Instantiate(prefabObj);
                //targetPos = new Vector3(targetPos.x+rowOffsetX, targetPos.y, 0f);
                //targetPos = new Vector3(targetPos.x, targetPos.y + rowOffsetX, 0f);
                targetPos = (direction == Direction.Up || direction == Direction.Down) ? new Vector3(targetPos.x + widthOffset, targetPos.y, 0f) : new Vector3(targetPos.x, targetPos.y + widthOffset, 0f);
                newObj.transform.position = targetPos;
                newObj.transform.SetParent(triangle.transform);    // Olu�turulan "newObj" yeni nesneler "Triangle" nesnesinin alt nesnesi olur
            }        
            
            switch (direction)
            {
                case Direction.Up:
                    targetPos = new Vector3((rowOffset*i)-1f,targetPos.y+ heightOffset, 0f);    // Up Direction
                    break;
                case Direction.Down:
                    targetPos = new Vector3((rowOffset * i) - 1f, targetPos.y - heightOffset, 0f);    // Down Direction
                    break;
                case Direction.Left:
                    targetPos = new Vector3(targetPos.x - heightOffset, (rowOffset * i) - 1f, 0f);    // Down Direction
                    break;
                case Direction.Right:
                    targetPos = new Vector3(targetPos.x + heightOffset, (rowOffset * i) - 1f, 0f);    // Down Direction
                    break;
            }
        }

    }
    private void SphereFormation(int numberOfPoints, int radius,int numberOfMeridians)
    {
        List<GameObject> spheres = HalfCircle(numberOfPoints, radius);  // Bo� nesne olu�turulur
        GameObject sphere = GameObject.Find("Sphere");    // Oyun sahnesinde "Sphere" adl� nesneyi arar

        for (int i = 0; i < numberOfMeridians; i++) // �izilecek meridyen say�s�n� ayarlar
        {
            float phi = 2 * Mathf.PI * ((float)i / (float)numberOfMeridians);
            for (int j = 1; j < numberOfPoints; j++)
            {
                GameObject newObj = Instantiate(prefabObj);

                float X = spheres[j].transform.position.x;
                float Y = spheres[j].transform.position.y * Mathf.Cos(phi) - spheres[j].transform.position.z * Mathf.Sin(phi);
                float Z = spheres[j].transform.position.z * Mathf.Cos(phi) + spheres[j].transform.position.y * Mathf.Sin(phi);

                newObj.transform.position = new Vector3(X, Y, Z);
                newObj.transform.SetParent(sphere.transform);
            }
        }
    }
    private List<GameObject> HalfCircle(int numberOfPoints,int radius)
    {  
        // Yar�m �ember �eklinde olu�rulan nesneler
        int pieces = numberOfPoints - 1;

        List<GameObject> spheres = new List<GameObject>();  // Bo� nesne olu�turulur
        GameObject sphere = new GameObject("Sphere");    // Oyun sahnesinde "Sphere" adl� yeni bir nesne olu�turur
        sphere.transform.position = Vector3.zero;    // "Sphere" nesnesini pozisyonunu s�f�rlar

        for (int i = 0; i < numberOfPoints; i++)
        {
            GameObject newObj = Instantiate(prefabObj);

            float theta = Mathf.PI * i / pieces;
            float X = Mathf.Cos(theta) * radius;
            float Y = Mathf.Sin(theta) * radius;

            newObj.transform.position = new Vector3(X, Y, 0f);  // Olu�turulan nesnelerin pozisyonu belirlenir
            newObj.transform.SetParent(sphere.transform);    // Olu�turulan "newObj" yeni nesneler "Sphere" nesnesinin alt nesnesi olur  
            spheres.Add(newObj);    // Olu�turlan her yeni nesne "spheres" listesine eklenir
        }
        return spheres; // Liste d�nd�r�l�r
    }
}
