using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Verification : MonoBehaviour
{
 public delegate void ButtonTouched();

 public static event ButtonTouched LineSwitcher;

 [SerializeField] private Button _verificationButton;
 

   public void ButtonPressed()
    {
     LineSwitcher?.Invoke();
    }
}
