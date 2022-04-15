using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePositions : MonoBehaviour
{
    public GameObject[] BallPositions;
    private bool[] sphereColorsChanged = {false, false, false, false};
    private int _colorsChanged = 0;

    private void Update()
    {
        ColorChanged();
    }

    private void ColorChanged()
    {
        for (int i = 0; i < BallPositions.Length; i++)
        {
            if (BallPositions[i].gameObject.GetComponent<MeshRenderer>().material.GetColor("_Color")!=Color.black && sphereColorsChanged[i]==false)
            {
                sphereColorsChanged[i] = true;
                _colorsChanged++;
            }
        }
    }

    public bool CanVerify()
    {
        if (_colorsChanged >= 4)
        {
            return true;
        }
        return false;
    }

}
