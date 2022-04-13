using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation.Samples;

public class Lines : MonoBehaviour
{
  public GameObject[] LineRows;
  [SerializeField] private LinePositions ballManager;
  private int _currentLine = 0 ;
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
    LineRows[_currentLine].SetActive(true);
    
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
    if (_currentLine<_maxLines)
    {
      for (int i = 0; i < ballManager.BallPositions.Length; i++)
      {
        _ballCollider = LineRows[_currentLine].GetComponent<LinePositions>().BallPositions[i].GetComponent<Collider>();
        _ballCollider.enabled = true;
      }
      _currentLine++;
      Switcher();
    }
  }

  private void Switcher()
  {
    LineRows[_currentLine].SetActive(true);
    if (_currentLine>=1 && _currentLine<_maxLines)
    {
      Occult();
    }
  }

  private void Occult()
  {
    for (int i = 0; i < ballManager.BallPositions.Length; i++)
    {
      _ballCollider = LineRows[_currentLine-1].GetComponent<LinePositions>().BallPositions[i].GetComponent<SphereCollider>();
      _ballCollider.enabled = false;
    }
    
  }
}
