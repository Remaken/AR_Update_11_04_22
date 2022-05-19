using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.TouchPhase;

public enum PlayingState
{
    None,
    WaitForTouch,
    ColorSelected,
    ColorDropped,
}

public class ColorPlacement : MonoBehaviour
{

    public PlayingState state = PlayingState.None;
    public PlayingState nextState = PlayingState.None;
    [SerializeField] private Lines _rowManager;

    private GameObject ballFound;
    private String _btnName;
    public Color selectedColor = Color.white;
    private GameObject _ballDetected;
    private bool colorChose = false;

    private void Start()
    {
        state = PlayingState.WaitForTouch;
    }

    private void Update()
    {
        if (CheckForTransition())
        {
            TransitionOrChangeState();
        }

        StateBehaviour();
    }

    private bool CheckForTransition()
    {
        switch (state)
        {
            case PlayingState.None:
                break;
            case PlayingState.WaitForTouch:
                if (TouchDetected())
                {
                    nextState = PlayingState.ColorSelected;
                    return true;
                }

                break;
            case PlayingState.ColorSelected:
                if (colorChose )
                {
                    nextState = PlayingState.ColorDropped;
                    return true;
                }

                break;
            case PlayingState.ColorDropped:
                if (TouchLost())
                {
                    nextState = PlayingState.WaitForTouch;
                    return true;

                }
                break;
        }

        return false;
    }

    private void TransitionOrChangeState()
    {
        EndState();

        state = nextState;

        StartState();
    }


    private void EndState()
    {
        switch (state)
        {
            case PlayingState.None:
                break;
            case PlayingState.WaitForTouch:
                break;
            case PlayingState.ColorSelected:
                break;
            case PlayingState.ColorDropped:
                break;
        }
    }

    private void StartState()
    {
        switch (state)
        {
            case PlayingState.None:
                break;
            case PlayingState.WaitForTouch:
                break;
            case PlayingState.ColorSelected:
                break;
            case PlayingState.ColorDropped:
                break;
        }
    }

    private void StateBehaviour()
    {
        switch (state)
        {
            case PlayingState.None:
                break;
            case PlayingState.WaitForTouch:
                break;
            case PlayingState.ColorSelected:
                break;
            case PlayingState.ColorDropped:
                ColorPlacing();
                break;
        }
    }



    private bool TouchDetected()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Mouse0))
        {
            return true;
        }

        return false;
    }

    private bool TouchLost()
    {
        if (Input.touchCount == 0)
        {
            return true;
        }

        return false;
    }

    public void ColorSelecting(string color)
    {
        switch (color)
        {
            case "Blue":
                selectedColor = Color.blue;
                break;
            case "Green":
                selectedColor = Color.green;
                break;
            case "Yellow":
                selectedColor = Color.yellow;
                break;
            case "Red":
                selectedColor = Color.red;
                break;
        }

        colorChose = true;
    }

    private void ColorPlacing()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit))
        {
            _ballDetected = Hit.collider.gameObject;
            if (_ballDetected.CompareTag("Sphere"))
            {
                _ballDetected.GetComponent<MeshRenderer>().material.SetColor("_Color",selectedColor);
            }
        }
    }
}
