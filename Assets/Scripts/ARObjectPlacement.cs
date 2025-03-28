using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class ARObjectPlacement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("AR")]
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private GameObject chest; //objectToPlace
    [Header("UI")]
    [SerializeField] private Button placeButton;

    private bool isDragging = false;



    void Update()
    {
        if (isDragging && TryGetPlacementPosition(out Vector3 position))
        {
            SceneManager.INSTANCE.currentChest.transform.position = position;
        }
    }

    //Renvoie vrai + la position v3 si l'utilisateur touche le plan au sol avec son doigt; sinon renvoie faux
    private bool TryGetPlacementPosition(out Vector3 position)
    {
        position = Vector3.zero;
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if(arRaycastManager.Raycast(new Vector2(Input.mousePosition.x, Input.mousePosition.y), hits, TrackableType.PlaneWithinPolygon))
        {
            position = hits[0].pose.position; //la position est maj en fonction de l'input utilisateur
            return true;
        }
        return false;
    }

    //fonction appelée quand l'utilisateur appuie sur le bouton de placement de coffre
    public void OnPointerDown(PointerEventData eventData)
    {
        if (SceneManager.INSTANCE.currentChest == null)
        {
            if (TryGetPlacementPosition(out Vector3 _position))
            {
                SceneManager.INSTANCE.NewChest(chest, _position);
            }
        }
        else
        {
            isDragging = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
