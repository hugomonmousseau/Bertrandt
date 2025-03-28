using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager INSTANCE;
    [HideInInspector] public GameObject currentChest;
    public ChestState currentChestState = ChestState.Add;
    [Header("UI")]
    public UIManager uiManager;


    private void Awake()
    {
        INSTANCE = this;
    }
    public void NewChest(GameObject _chest, Vector3 _position)
    {
        currentChest = Instantiate(_chest, _position, Quaternion.identity);
        currentChestState = ChestState.Move;
        uiManager.UpdateUIButtons(currentChestState);
    }

    public enum ChestState
    {
        Add, Move //actuellement : soit on le déplace / detruit, soit on le rajoute
    }
}
