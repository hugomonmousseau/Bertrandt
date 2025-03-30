using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class CollectOre : MonoBehaviour
{
    [SerializeField] LayerMask oreLayer;
    private ARRaycastManager arRaycastManager;

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!SceneARManager.INSTANCE.spawnOres) return; // on ne peut prendre les minerais deja present apres la minute passée
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, oreLayer))
                    {
                        hit.collider.GetComponent<GoldOreScript>().Recolt();
                        SceneARManager.INSTANCE.IncremanteScore();
                    }
                }
            }
        }
    }
}
