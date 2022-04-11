using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class GuessColor : MonoBehaviour

{
    public MasterColor masterColorManager;
    public Sphere sphereManager;
    public Lignes[] lignes;
    private int _ligneActuelle=0;
    private int _testActuel = 0;
    private bool _victoire = false;
    /*private GameObject _bouleMaterial;*/
    private int[] positionActuelle= {0,1,2,3} ;
    private bool[] bonEmplacement;
    private bool[] bonneCouleur;
    private int currentSphere;
    private int previousSphere=1;
    private Color couleurDeLaBoule;


    void Start()
    {
        Verifification();
    }

    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            OnHitColor();
        }
    }

    public void Verifification()

    {
        for (int i = 0; i < positionActuelle.Length; i++)
        {
            
            if ((lignes[_testActuel].boulepositions[i]==masterColorManager.randomSolution[i]))
            {
                bonEmplacement[i] = true;
            }
            /*if ((lignes[_testActuel].boulepositions[i]==masterColorManager.randomSolution[masterColorManager.randomSolution.Length]))
            {
                bonneCouleur[i] = true;
            }*/
        }
         if (bonneCouleur[0]||bonneCouleur[1]||bonneCouleur[2]||bonneCouleur[3]) 
         {
            print("une bonne couleur");
         }
         else
         {
             print("aucune bonne couleur");
         }
         
         if (bonEmplacement[0]||bonEmplacement[1]||bonEmplacement[2]||bonEmplacement[3]) 
         {
            print("une bien placée"); 
         }
        // if (bonEmplacement[0]==true&&bonEmplacement[1]==true&&bonEmplacement[2]==true&&bonEmplacement[3]==true)
        /*
        if (masterColorManager.randomSolution[3]==masterColorManager.randomSolution[3])
         {
            _victoire = true;
            YouWin();
            print("vous avez gagné");
         }
         else 
         {
            print("c'est pas la bonne réponse");
            LignSwitcher(); 
         }
         */
        
    }

    public void LignSwitcher()
    {
        lignes[_ligneActuelle].gameObject.SetActive(true);
        if (_ligneActuelle<lignes.Length-1)
        {
            _ligneActuelle++;
            _testActuel++;
        }

    }
    private void YouWin()
    {
        //Show Victory stuff
    }
    private void OnHitColor()
    {
     
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                currentSphere= hit.collider.gameObject.GetComponent<Sphere>().numSphere;

                if (( hit.collider.gameObject.GetComponent<Sphere>() !=null))//&&(currentSphere==previousSphere))
                {
                   
                    if ((currentSphere!=previousSphere)||(sphereManager.couleurActuelle>=masterColorManager.colors.Length))
                    {
                        if (sphereManager.couleurSphereActuelle[currentSphere-1]==3)
                        {
                            sphereManager.couleurSphereActuelle[currentSphere - 1] = 0;
                        }
                        sphereManager.couleurActuelle = sphereManager.couleurSphereActuelle[currentSphere-1];
                    }
                    
                    couleurDeLaBoule = masterColorManager.colors[sphereManager.couleurActuelle].gameObject.GetComponent<MeshRenderer>().sharedMaterial.GetColor("_Color");
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color",couleurDeLaBoule);

                 
                    previousSphere = currentSphere;
                    sphereManager.couleurSphereActuelle[currentSphere-1] = sphereManager.couleurActuelle;
                    sphereManager.couleurActuelle++;
                    print( sphereManager.couleurSphereActuelle[currentSphere-1]);
                    print(sphereManager.couleurSphereActuelle);
                }
            }
    }

    

    private void BiduleTestage()
    { 
        /*private bool bonEmplacement0 =false;
        private bool bonEmplacement1=false;
        private bool bonEmplacement2=false;
        private bool bonEmplacement3=false;
        private bool bonneCouleur0 = false;
        private bool bonneCouleur1 = false;
        private bool bonneCouleur2 = false;
        private bool bonneCouleur3 = false;*/ /* 
     comment se déplacer pour choisir un autre emplacement ? raytracing sur le click ?
     Où utiliser les scripts ? Prefab de boule noire (miniature qui swap avec les autres boules ?
     
     */   
        //TODO: Naviguer sur les lignes "essais"
        //TODO: choisir la couleur en fonction de la position
        //TODO: COMMUNICATION BETWEEN GUESS & MASTER
        //TODO: Number of Tries
        //TODO: [] Rows  length 12  == Line
        //TODO: [] Rows - Tries length 4
        //TODO: ON click right click color change
        //TODO: On click middle click reset Color
        
// verification 0,1,2,3 + boolean trues à chaque si touts booleans = true victoire
        
        /*if (lignes[_ligneActuelle].boulepositions[0]==masterColorManager.randomSolution[0])
        {
            bonEmplacement0 = true;
        }
        if (lignes[_ligneActuelle].boulepositions[1]==masterColorManager.randomSolution[1])
        {
            bonEmplacement1 = true;
        }
        if (lignes[_ligneActuelle].boulepositions[2]==masterColorManager.randomSolution[2])
        {
            bonEmplacement2 = true;
        }
        if (lignes[_ligneActuelle].boulepositions[3]==masterColorManager.randomSolution[3])
        {
            bonEmplacement3 = true;
        }

        if ((lignes[_ligneActuelle].boulepositions[0]==masterColorManager.randomSolution[masterColorManager.randomSolution.Length]))
        {
            bonneCouleur0 = true;
        } 
        if ((lignes[_ligneActuelle].boulepositions[1]==masterColorManager.randomSolution[masterColorManager.randomSolution.Length]))
        {
            bonneCouleur1 = true;
        } 
        if ((lignes[_ligneActuelle].boulepositions[2]==masterColorManager.randomSolution[masterColorManager.randomSolution.Length]))
        {
            bonneCouleur2 = true;
        } 
        if ((lignes[_ligneActuelle].boulepositions[3]==masterColorManager.randomSolution[masterColorManager.randomSolution.Length]))
        {
            bonneCouleur3 = true;
        }*/
    }
}
