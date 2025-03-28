using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneARManager : MonoBehaviour
{
    public static SceneARManager INSTANCE;
    [HideInInspector] public GameObject currentChest;

    private void Awake()
    {
        INSTANCE = this;
    }
}
