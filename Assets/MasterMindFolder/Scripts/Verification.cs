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
 [SerializeField] private GameObject _solutionHider;
 private Color[] _solutionColors = new Color[4];
 private Color[] _playerValidation = new Color[4];
 private bool _victory = false;
 private bool[] colorChecked;

 private void Awake()
 {
 // _solutionHider.SetActive(true);
 }
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
  int goodColorBadPlacement = 0;
  var lineRow = _playerValidationManager.lineRows[_playerValidationManager.currentLine];
  var linePositions = lineRow.GetComponent<LinePositions>();
  
  for (int i = 0; i < _solutionColors.Length; i++)
  {
   if (_playerValidation[i] == _solutionColors[i])
   {
    colorChecked[i] = true;
    goodColorPlaced++;
   }
  }
  for (int i = 0; i < _solutionColors.Length; i++)
  {
   if (!colorChecked[i])
   {
    for (int j = 0; j < colorChecked.Length; j++)
    {
     if ( _playerValidation[i] == _solutionColors[j])
     {
      colorChecked[i] = true;
      goodColorBadPlacement++;
     }
    }
   }
  }
  print(goodColorPlaced + " " + goodColorBadPlacement);

  for (int i = 0; i < linePositions.Pins.Length; i++)
  {
   int PinWithGoodColorButBadPlaced = goodColorPlaced + goodColorBadPlacement;
 
   if (i<goodColorPlaced)
   {
    linePositions.Pins[i].SetActive(true);
    linePositions.Pins[i].GetComponent<MeshRenderer>().material.SetColor("_Color",Color.black);
   }
   else
   {
    if (i<PinWithGoodColorButBadPlaced)
    {
     if (!linePositions.Pins[i].activeInHierarchy)
     {
      linePositions.Pins[i].SetActive(true);
     }
     linePositions.Pins[i].GetComponent<MeshRenderer>().material.SetColor("_Color",Color.white);
    }
   }
  }
  
  if (_victory==false)
  {
   LineSwitcher?.Invoke();
  }
  if (goodColorPlaced == 4)
  {
   _victory = true;
   _solutionHider.SetActive(false);
  }
  if (_playerValidationManager.currentLine>=12)
  {
   _solutionHider.SetActive(false);
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
