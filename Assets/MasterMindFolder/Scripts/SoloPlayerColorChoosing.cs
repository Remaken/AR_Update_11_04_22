using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloPlayerColorChoosing : MonoBehaviour
{
    private Color[] colors = { Color.blue, Color.green, Color.yellow, Color.red, };
    [SerializeField] private Transform[] _solutionPositions;
    public Color[] randomSolution = new Color[3] ;
    [SerializeField] private GameObject _spherePrefab;
    public GameObject[] _ballPlacement;
    void Start()
    {
        ColorChoosing();
        ColorPlacing();
    }
    private void ColorChoosing()
    {
        for (int i = 0; i < randomSolution.Length; i++)
        {
            randomSolution[i] = colors[Random.Range(0, colors.Length)];
        }
    }

    private void ColorPlacing()
    {
        _ballPlacement[0] = Instantiate(_spherePrefab,this._solutionPositions[0].transform) ;
        _ballPlacement[0].GetComponent<MeshRenderer>().material.color = randomSolution[0];
        
        _ballPlacement[1] = Instantiate(_spherePrefab,this._solutionPositions[1].transform) ;
        _ballPlacement[1].GetComponent<MeshRenderer>().material.color = randomSolution[1];
        
        _ballPlacement[2] = Instantiate(_spherePrefab,this._solutionPositions[2].transform) ;
        _ballPlacement[2].GetComponent<MeshRenderer>().material.color = randomSolution[2];
        
        _ballPlacement[3] = Instantiate(_spherePrefab,this._solutionPositions[3].transform) ;
        _ballPlacement[3].GetComponent<MeshRenderer>().material.color = randomSolution[3];
    }
}
