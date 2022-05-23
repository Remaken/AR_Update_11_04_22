using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LinePositions : MonoBehaviour
{
    public GameObject[] BallPositions = new GameObject[4];
    private bool[] sphereColorsChanged = {false, false, false, false};
    private Color _baseColor;
    public int colorsChanged = 0;
    public GameObject[] Pins = new GameObject[4];

    private void Start()
    { 
        _baseColor = BallPositions[0].gameObject.GetComponent<MeshRenderer>().material.GetColor("_Color");
    }
    private void Update()
    {
        ColorChanged();
    }

    private void ColorChanged()
    {
        for (int i = 0; i < BallPositions.Length; i++)
        {
            if (BallPositions[i].gameObject.GetComponent<MeshRenderer>().material.GetColor("_Color")!=_baseColor && sphereColorsChanged[i]==false)
            {
                sphereColorsChanged[i] = true;
                colorsChanged++;
            }
        }
    }

    public bool CanVerify()
    {
        if (colorsChanged >= 4)
        {
            return true;
        }
        return false;
    }

}
