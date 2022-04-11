using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MasterColor : MonoBehaviour
{
    public GameObject[] colors;
    public GameObject[] boulePositions;
    //public InterfaceManager interManager;
    public GameObject[] randomSolution = new GameObject[4] ;
    
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
        Instantiate(randomSolution[0],this.boulePositions[0].transform) ;
        Instantiate(randomSolution[1],this.boulePositions[1].transform) ;
        Instantiate(randomSolution[2],this.boulePositions[2].transform) ;
        Instantiate(randomSolution[3],this.boulePositions[3].transform) ;
    }
   
}
