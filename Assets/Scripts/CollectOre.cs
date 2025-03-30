using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class CollectOre : MonoBehaviour
{
    public Button destroyOreButton;
    private ARRaycastManager arRaycastManager;
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        destroyOreButton.onClick.AddListener(CollectGold);
    }



    void CollectGold()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                if(hit.collider != SceneARManager.INSTANCE.currentChest)
                {
                    hit.collider.GetComponent<GoldOreScript>().Recolt();
                    SceneARManager.INSTANCE.IncremanteScore();
                }
            }
        }
    }
}
