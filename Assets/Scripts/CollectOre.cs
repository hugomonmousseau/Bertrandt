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
            DetectObjectAtTouch(Input.GetTouch(0).position);
        }

        void DetectObjectAtTouch(Vector2 touchPosition)
        {
            Ray _ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit _hit;

            if (Physics.Raycast(_ray, out _hit))
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
