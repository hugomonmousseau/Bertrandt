using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;


public class CollectOre : MonoBehaviour
{
    private TouchControls controls;
    private bool isPressed;
    [SerializeField] LayerMask oreLayer;

    private void Awake()
    {
        controls = new TouchControls();

        controls.control.touch.performed += _ => isPressed = true;
        controls.control.touch.canceled += _ => isPressed = false;
    }
    private ARRaycastManager arRaycastManager;
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {

        if (isPressed && SceneARManager.INSTANCE.spawnOres)
        {
            var touchPosition = Pointer.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, oreLayer))
            {
                if (hit.collider.gameObject != SceneARManager.INSTANCE.currentChest)
                {
                    hit.collider.gameObject.GetComponent<GoldOreScript>().Recolt();
                    SceneARManager.INSTANCE.IncremanteScore();
                }
            }
        }
        
    }

    private void OnEnable()
    {
        controls.control.Enable();
    }
    private void OnDisable()
    {
        controls.control.Disable();
    }
}
