using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject chest;
    [SerializeField] private ARRaycastManager arRaycastManager;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
