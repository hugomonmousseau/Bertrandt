using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ChestIntantiator : MonoBehaviour
{
    [SerializeField] GameObject chest;
    private ARPlaneManager arPlaneManager;

    private void Start()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added.Count > 0)
        {
            ARPlane plane = args.added[0];
            //le coffre apparait à 1 metre de l'utilisateur
            Vector3 position = plane.transform.position + plane.transform.forward * 1.0f;
            position.y = plane.transform.position.y;

            if (chest != null && SceneARManager.INSTANCE.currentChest == null)
            {
                SceneARManager.INSTANCE.currentChest = Instantiate(chest, position, Quaternion.identity);
            }
        }
    }

    void OnDestroy()
    {
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }
}
