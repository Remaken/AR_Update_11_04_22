using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentColorSelected : MonoBehaviour
{
    
    [SerializeField] private Image _selectedColorDisplayer;
    [SerializeField] private ColorPlacement _colorReference;


    private void Update()
    {
        _selectedColorDisplayer.color = _colorReference.selectedColor;
    }
}
