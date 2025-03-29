using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneARManager : MonoBehaviour
{
    public static SceneARManager INSTANCE;
    [HideInInspector] public GameObject currentChest;
    [SerializeField] GameObject scanSurfaceUI;

    private void Awake()
    {
        INSTANCE = this;
    }

    public void DetectedSurface()
    {
        scanSurfaceUI.SetActive(false);
    }
}
