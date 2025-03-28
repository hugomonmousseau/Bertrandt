using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Boutons")]
    [SerializeField] private Button AddChestButton;
    [SerializeField] private Button MoveChestButton;
    [SerializeField] private Button RemoveChestButton;

    public void UpdateUIButtons(SceneManager.ChestState _state)
    {
        //si on peut ajouter le coffre (on vient de le destroy)
        bool _isAddable = _state == SceneManager.ChestState.Add;
        AddChestButton.gameObject.SetActive(_isAddable);
        MoveChestButton.gameObject.SetActive(!_isAddable); //si on ne peut l'ajouter, c'est quon peut le déplacer
        RemoveChestButton.gameObject.SetActive(!_isAddable);// et le détruire 
    }
}
