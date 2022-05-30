using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterMindStarter : MonoBehaviour
{
    public delegate void MasterMind();

    public static event MasterMind StartGame;

    [SerializeField] private GameObject _masterMindButton;
   
    public void MasterMindStart()
    {
       StartGame?.Invoke();
       _masterMindButton.SetActive(false);
    }

}
