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
 
 /*[SerializeField] private Lines _playerValidationManager;
 [SerializeField] private SoloPlayerColorChoosing _solutionColorManager;
 private Color[] _solutionColors;
 private Color[] _playerValidation;*/
 
   public void ButtonPressed()
    {
     LineSwitcher?.Invoke();
    }

   /*private void Update()
   {
    PlayerColorConverter();
    SolutionColorConverter();
    print("CouleurJ " + _playerValidation.Length + "Couleur PC" + _solutionColors.Length);
   }

   private void PlayerColorConverter()
   {
    for (int i = 0; i < _playerValidationManager.LineRows[_playerValidationManager.currentLine].GetComponent<LinePositions>().BallPositions.Length; i++)
    {
     _playerValidation[i] = _playerValidationManager.LineRows[_playerValidationManager.currentLine]
      .GetComponent<LinePositions>().BallPositions[i].GetComponent<MeshRenderer>().material
      .GetColor("_Color");
    }
   }

   private void SolutionColorConverter()
   {
    for (int i = 0; i < _solutionColorManager.ballPlacement.Length; i++)
    {
     _solutionColors[i] =
      _solutionColorManager.ballPlacement[i].GetComponent<MeshRenderer>().material.GetColor("_Color");
    }
   }*/
}
