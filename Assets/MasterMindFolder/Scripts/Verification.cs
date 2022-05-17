using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Verification : MonoBehaviour
{
 public delegate void ButtonTouched();

 public static event ButtonTouched LineSwitcher;

 [SerializeField] private Button _verificationButton;

 [SerializeField] private Lines _playerValidationManager;
 [SerializeField] private SoloPlayerColorChoosing _solutionColorManager;
 private Color[] _solutionColors = new Color[4];
 private Color[] _playerValidation = new Color[4];
 private bool _victory = false;
 private bool[] colorChecked;

private void Start()
 {
  SolutionColorConverter();
 }

 public void ButtonPressed()
 {
  var colorChangeCount = _playerValidationManager.lineRows[_playerValidationManager.currentLine].GetComponent<LinePositions>().colorsChanged;

  if (colorChangeCount==4)
  { 
   PlayerColorConverter();
   GoodColorPlaced();
   Winner();
  }
 
  /*if (victory==false)
  {
   LineSwitcher?.Invoke();
  }*/

 }


 private void PlayerColorConverter()
 {
  for (int i = 0; i < _playerValidation.Length; i++)
  {
   _playerValidation[i] = _playerValidationManager.lineRows[_playerValidationManager.currentLine]
    .GetComponent<LinePositions>().BallPositions[i].GetComponent<MeshRenderer>().material
    .GetColor("_Color");
  }
 }

 private void SolutionColorConverter()
 {
  for (int i = 0; i < _solutionColors.Length; i++)
  {
   _solutionColors[i] = _solutionColorManager.randomSolution[i];
  }
 }

 private void GoodColorPlaced()
 {
  colorChecked = new bool[]{false,false,false,false} ;
  int goodColorPlaced = 0;
  int goodColorFound = 0;
  var lineRow = _playerValidationManager.lineRows[_playerValidationManager.currentLine];
  var linePositions = lineRow.GetComponent<LinePositions>();


  for (int i = 0; i < _solutionColors.Length; i++)
  {
   if (_solutionColors[i] == _playerValidation[i])
   {
    goodColorFound++;
    goodColorPlaced++;
    colorChecked[i] = true;
   }
  }
  for (int i = 0; i < _solutionColors.Length; i++)
  {

   for (int j = 0; j < colorChecked.Length; j++)
   {
    if (colorChecked[j] == false && _playerValidation[i] == _solutionColors[j])
    {
     goodColorFound++;
     colorChecked[j] = true;
    }
   }
  }
  print(goodColorPlaced +"bien placé");

   if (goodColorFound>0 && goodColorFound>goodColorPlaced)
   {
     linePositions.Pins[goodColorFound-1].GetComponent<MeshRenderer>().material.SetColor("_Color",Color.white);
   }

   if (goodColorPlaced>0)
   {
    linePositions.Pins[goodColorPlaced-1].GetComponent<MeshRenderer>().material.SetColor("_Color",Color.black);
   }
  
  if (goodColorPlaced == 4)
  {
   _victory = true;
  }
  //else
     {
      LineSwitcher?.Invoke();
     }
 }

   private void Winner()
   {
    if (_victory== true)
    {
     print("GameOver you Win !");
    }
   }


   private void VisualIndicator()
   {
    
   }
}
