using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation.Samples;

public class Lines : MonoBehaviour
{
  public GameObject[] LineRows;
  [SerializeField] private LinePositions ballManager;
  public int currentLine = 0 ;
  private int _maxLines = 11;
  private  Collider _ballCollider;

  private void Awake()
  {
    for (int i = 0; i < LineRows.Length; i++)
    {
      LineRows[i].SetActive(false);
    }
  }


  private void Start()
  {
    LineRows[currentLine].SetActive(true);
    
  }

  private void OnEnable()
  {
    Verification.LineSwitcher += SwitchActiveLine;
  }
  private void OnDisable()
  {
    Verification.LineSwitcher -= SwitchActiveLine;
  }
  private void SwitchActiveLine()
  {
    if (currentLine<_maxLines && LineRows[currentLine].GetComponent<LinePositions>().CanVerify())
    {
        for (int i = 0; i < ballManager.BallPositions.Length; i++)
        {
          _ballCollider = LineRows[currentLine].GetComponent<LinePositions>().BallPositions[i].GetComponent<Collider>();
          _ballCollider.enabled = true;
        }
        currentLine++;
         Switcher();
    }
  }

  private void Switcher()
  {
    LineRows[currentLine].SetActive(true);
    if (currentLine>=1 && currentLine<_maxLines)
    {
      Occult();
    }
  }

  private void Occult()
  {
    for (int i = 0; i < ballManager.BallPositions.Length; i++)
    {
      _ballCollider = LineRows[currentLine-1].GetComponent<LinePositions>().BallPositions[i].GetComponent<SphereCollider>();
      _ballCollider.enabled = false;
    }
  }

}
