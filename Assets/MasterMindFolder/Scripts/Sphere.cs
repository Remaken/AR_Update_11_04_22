using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public int couleurActuelle ;
    public int numSphere;
    [HideInInspector]
    public int[] couleurSphereActuelle;

    private void Start()
    {
        couleurSphereActuelle = new int[4];
        couleurActuelle = 0;
    }


    public Color CouleurDeBase()
    {
       return gameObject.GetComponent<MeshRenderer>().material.GetColor("_Color");
    }

    public void ChangementCouleur(Color NewColor)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color",NewColor);
    }

    
    
}
