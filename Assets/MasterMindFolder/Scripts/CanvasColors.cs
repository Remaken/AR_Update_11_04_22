using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasColors : MonoBehaviour
{
   public Button[] _imageColors;

   private void Start()
   {
      ImageColoring();
   }



   private void ImageColoring()
   {
      _imageColors[0].image.color = Color.blue;
      _imageColors[1].image.color = Color.green;
      _imageColors[2].image.color = Color.yellow;
      _imageColors[3].image.color = Color.red;

   }
}
