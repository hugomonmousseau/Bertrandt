using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetChest : MonoBehaviour
{
    [SerializeField] private Button resetButton;
    void Start()
    {
        resetButton.onClick.AddListener(ResetCurrentChest);
    }

    public void ResetCurrentChest()
    {
        if (SceneARManager.INSTANCE.currentChest == null) return;
        DestroyImmediate(SceneARManager.INSTANCE.currentChest);
        SceneARManager.INSTANCE.currentChest = null;
    }
}
