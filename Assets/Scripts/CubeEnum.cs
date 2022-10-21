using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnum : MonoBehaviour
{
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material redMaterial;
    public enum ColorChange
    {
        Blue,
        Red
    }
    public ColorChange colorEnum;
    void Start()
    {
        ColorSelect();
    }    
   
    private void ColorSelect()
    {
        switch (colorEnum)
        {
            case ColorChange.Blue:
                transform.GetComponent<MeshRenderer>().material = blueMaterial;
                break;
            case ColorChange.Red:
                transform.GetComponent<MeshRenderer>().material = redMaterial;
                break;
        }
    }
}
