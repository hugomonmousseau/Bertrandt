using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class CollectOre : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && SceneARManager.INSTANCE.spawnOres)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject != SceneARManager.INSTANCE.spawnOres)
                    {
                        hit.collider.gameObject.GetComponent<GoldOreScript>().Recolt();
                        SceneARManager.INSTANCE.IncremanteScore();
                    }
                }
            }
        }
    }
}
