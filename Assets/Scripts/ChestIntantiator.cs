using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ChestIntantiator : MonoBehaviour
{
    [SerializeField] GameObject chest;
    private ARPlaneManager arPlaneManager;
    private ARRaycastManager arRaycastManager;

    private void Start()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (SceneARManager.INSTANCE.currentChest == null) InstantiateChest();
        
    }

    void InstantiateChest()
    {
        var _hits = new List<ARRaycastHit>();
        Vector3 _screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        if(arRaycastManager.Raycast(_screenCenter, _hits, TrackableType.PlaneWithinPolygon))
        {
            Vector3 _spawnChestPosition = _hits[0].pose.position;
            SceneARManager.INSTANCE.currentChest = Instantiate(chest, _spawnChestPosition, Quaternion.identity);
        }

    }
}
