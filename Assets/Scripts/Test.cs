using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class Restart : MonoBehaviour
{
    public GameObject o;
    ARRaycastManager aRRaycastManager;
    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hits = new List<ARRaycastHit>();
            var touchPositionOnScreen = Input.mousePosition;
            if(aRRaycastManager.Raycast(touchPositionOnScreen, hits, TrackableType.PlaneWithinPolygon))
            {
                var spawnPosition = hits[0].pose.position;
                Instantiate(o, spawnPosition, Quaternion.identity);
            }
        }
    }
}
