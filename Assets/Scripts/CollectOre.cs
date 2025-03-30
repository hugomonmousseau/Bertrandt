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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && SceneARManager.INSTANCE.spawnOres)
        {
            Vector2 _touchPosition = Input.GetTouch(0).position;
            List<ARRaycastHit> _hits = new List<ARRaycastHit>();

            if (arRaycastManager.Raycast(_touchPosition, _hits, TrackableType.PlaneWithinPolygon))
            {
                Ray _ray = Camera.main.ScreenPointToRay(_touchPosition);
                RaycastHit _hit;

                if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, oreLayer))
                {
                    if (_hit.collider.gameObject.layer == oreLayer)
                    {
                        _hit.collider.GetComponent<GoldOreScript>().Recolt();
                        SceneARManager.INSTANCE.IncremanteScore();
                    }
                }
            }
        }
    }
}
