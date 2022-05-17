using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation.Samples;

public class Lines : MonoBehaviour
{
  public GameObject[] lineRows = new GameObject[12] ;
  [SerializeField] private LinePositions ballManager;
  private int _currentLine = 0 ;
  private int _maxLines = 11;
  private  Collider _ballCollider;

  private void Awake()
  {
    for (int i = 0; i < lineRows.Length; i++)
    {
      lineRows[i].SetActive(false);
    }
  }

  private void Start()
  {
<<<<<<< HEAD
    lineRows[currentLine].SetActive(true);
=======
    LineRows[_currentLine].SetActive(true);
>>>>>>> parent of 212c032 (TestCommit)
    
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
<<<<<<< HEAD
    if (currentLine<_maxLines && lineRows[currentLine].GetComponent<LinePositions>().CanVerify())
    {
        for (int i = 0; i < ballManager.BallPositions.Length; i++)
        {
          _ballCollider = lineRows[currentLine].GetComponent<LinePositions>().BallPositions[i].GetComponent<Collider>();
          _ballCollider.enabled = true;
        }

        currentLine++;
         Switcher();
=======
    if (_currentLine<_maxLines)
    {
      for (int i = 0; i < ballManager.BallPositions.Length; i++)
      {
        _ballCollider = LineRows[_currentLine].GetComponent<LinePositions>().BallPositions[i].GetComponent<Collider>();
        _ballCollider.enabled = true;
      }
      _currentLine++;
      Switcher();
>>>>>>> parent of 212c032 (TestCommit)
    }
  }

  private void Switcher()
  {
<<<<<<< HEAD
    lineRows[currentLine].SetActive(true);
    if (currentLine>=1 && currentLine<_maxLines)
=======
    LineRows[_currentLine].SetActive(true);
    if (_currentLine>=1 && _currentLine<_maxLines)
>>>>>>> parent of 212c032 (TestCommit)
    {
      Occult();
    }
  }

  private void Occult()
  {
    for (int i = 0; i < ballManager.BallPositions.Length; i++)
    {
<<<<<<< HEAD
      _ballCollider = lineRows[currentLine-1].GetComponent<LinePositions>().BallPositions[i].GetComponent<SphereCollider>();
=======
      _ballCollider = LineRows[_currentLine-1].GetComponent<LinePositions>().BallPositions[i].GetComponent<SphereCollider>();
>>>>>>> parent of 212c032 (TestCommit)
      _ballCollider.enabled = false;
    }
    
  }
}
