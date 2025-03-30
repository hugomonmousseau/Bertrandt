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
            Touch _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                List<ARRaycastHit> _hits = new List<ARRaycastHit>();
                if (arRaycastManager.Raycast(_touch.position, _hits, TrackableType.PlaneWithinPolygon))
                {
                    Ray _ray = Camera.main.ScreenPointToRay(_touch.position);
                    RaycastHit _hit;

                    if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, oreLayer))
                    {
                        _hit.collider.gameObject.GetComponentInParent<GoldOreScript>().Recolt();
                        SceneARManager.INSTANCE.IncremanteScore();
                    }
                }
            }
        }
    }
}
