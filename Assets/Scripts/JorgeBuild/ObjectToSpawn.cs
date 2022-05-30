using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
public class ObjectToSpawn : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager _trackImage;
    [SerializeField] private Canvas _canvasDisplay;
    [SerializeField] private Button _spawnButtonTree;
    [SerializeField] private Button _spawnMasterMindButton; 
    [SerializeField] private GameObject[] _objectsToSpawn;
    private GameObject _objectSpawned;
    private GameObject _previousObject;
    private int _nombreDeClicks=-1;
    private bool _wasSpawned = false;
    private bool _masterMindStarted=false;
    private bool _imageFound=false;
    private bool _imageUpdated=false;
    private bool _imageRemoved=false;


    private void OnEnable()
    {
        _trackImage.trackedImagesChanged += OnAddedImages;
        _trackImage.trackedImagesChanged += OnUpdatedImages;
        _trackImage.trackedImagesChanged += OnRemovedImages;
    }

    private void OnDisable()
    {
        _trackImage.trackedImagesChanged -= OnAddedImages;
        _trackImage.trackedImagesChanged -= OnUpdatedImages;
        _trackImage.trackedImagesChanged -= OnRemovedImages;
    }

    private void OnAddedImages(ARTrackedImagesChangedEventArgs args)
    {
        _imageFound = true;
        if (args.added.Count > 0)
        {
            for (int i = 0; i < args.added.Count; i++)
            {
                _spawnMasterMindButton.gameObject.SetActive(true);
                _objectSpawned = Instantiate(_objectsToSpawn[0]);
                _masterMindStarted = true;
            }
        }
    }
    private void OnUpdatedImages(ARTrackedImagesChangedEventArgs args)
    {
        _imageUpdated = true;
        if (args.updated.Count > 0 && _wasSpawned == true)
        {
            _objectSpawned.transform.position = args.updated[0].transform.position;
            _objectSpawned.transform.rotation = args.updated[0].transform.rotation;
        }
    }
    private void OnRemovedImages(ARTrackedImagesChangedEventArgs arg)
    {
        for (int i = 0; i < arg.removed.Count; i++)
        {
            if (arg.removed.Count>0)
            {
                _canvasDisplay.GetComponent<Canvas>().enabled = false;
                _wasSpawned = false;
            }
        }
        _imageFound = false;
        _imageUpdated = false;
    }

    public void ButtonSpawn()
    { 
        if (_nombreDeClicks>=2)
        {
            _nombreDeClicks = -1;
        }
        _nombreDeClicks++;
        if (_wasSpawned==true)
        {
            Destroy(_objectSpawned);
            _wasSpawned = false;
        }
    }
    
    /*
    public void MasterMindButtonSpawn()
    {
        _spawnMasterMindButton.gameObject.SetActive(false);
        _spawnButtonTree.gameObject.SetActive(false);
    }*/
}
