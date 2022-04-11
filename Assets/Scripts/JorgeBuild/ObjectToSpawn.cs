using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
public enum ImageState
{
    None,
    WaitForImage,
    Added,
    Updated,
    Removed,
}
public class ObjectToSpawn : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager _trackImage;
    [SerializeField] private Canvas _canvasDisplay;
    [SerializeField] private Button _spawnButtonTree;
    [SerializeField] private Button _spawnButton; 
    [SerializeField] private GameObject[] _objectsToSpawn;
    private GameObject _objectSpawned;
    private GameObject _previousObject;
    private int _nombreDeClicks=-1;
    private bool _wasSpawned = false;
    public ImageState state = ImageState.None;
    public ImageState nextState = ImageState.None;
    private bool _masterMindStarted=false;
    private bool _imageFound=false;
    private bool _imageUpdated=false;
    private bool _imageRemoved=false;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        _trackImage.trackedImagesChanged += OnAddedImages;
        _trackImage.trackedImagesChanged += OnUpdatedImages;
        _trackImage.trackedImagesChanged += OnRemovedImages;
    }
    private void Start()
    {
        state = ImageState.WaitForImage;
    }
    
    /*
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
            case ImageState.None:
                break;
            case ImageState.WaitForImage:
                if (_imageFound==true)
                {
                    nextState = ImageState.Added;
                    return true;
                }
                break;
            case ImageState.Added:
                if (_imageUpdated==true)
                {
                    _imageFound = false;
                    nextState = ImageState.Updated;
                    return true;

                }
                break;
            case ImageState.Updated:
                //passage removed
                break;
            case ImageState.Removed:
                //si gameobject destroyed passage en waitforimage
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
            case ImageState.None:
                break;
            case ImageState.WaitForImage:
                break;
            case ImageState.Added:
                break;
            case ImageState.Updated:
                break;
            case ImageState.Removed:
                break;
        }

    }
    private void StartState()
    {
        switch (state)
        {
            case ImageState.None:
                break;
            case ImageState.WaitForImage:
                break;
            case ImageState.Added:
                //Instaciation de l'objet
                break;
            case ImageState.Updated:
                break;
            case ImageState.Removed:
                //destroy gameobject
                break;
        }

    }
    private void StateBehaviour()
    {
        switch (state)
        {
            case ImageState.None:
                break;
            case ImageState.WaitForImage:
                break;
            case ImageState.Added:
                break;
            case ImageState.Updated:
                //Mise à jour de la position de l'objet

                break;
            case ImageState.Removed:
                break;
        }
    }
    */


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
                _spawnButtonTree.gameObject.SetActive(true);
                _spawnButton.gameObject.SetActive(true);
            }
        }
    }
    private void OnUpdatedImages(ARTrackedImagesChangedEventArgs args)
    {
        _imageUpdated = true;
        /*if (args.updated.Count>0)
        { 
            for (int i = 0; i < args.added.Count; i++)
            {
                _objectSpawned.transform.position = args.updated[i].transform.position;
                _objectSpawned.transform.rotation = args.updated[i].transform.rotation;
            }
        }*/

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
        SpawningThings();
        /*if (_wasSpawned == false)
        {
            _wasSpawned = true;
            _spawnButton.gameObject.SetActive(true);
            _spawnButtonTree.gameObject.SetActive(false);
        }*/
    }

    private void SpawningThings()
    {
        if (_masterMindStarted==false)
        { 
            if (_wasSpawned==false)
            {
                _objectSpawned = Instantiate(_objectsToSpawn[_nombreDeClicks]);
                _wasSpawned = true;
            }
        }
       
    }

    public void Baboushka()
    {
        _masterMindStarted = true;
        _objectSpawned = Instantiate(_objectsToSpawn[3]);
        _spawnButton.gameObject.SetActive(false);
        _spawnButtonTree.gameObject.SetActive(false);
    }
}
