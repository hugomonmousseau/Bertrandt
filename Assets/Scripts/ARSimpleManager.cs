using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class ARSimpleManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public Button deleteButton;
    private GameObject spawnedObject;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField]
    XRInputValueReader<Vector2> m_TapStartPositionInput = new XRInputValueReader<Vector2>("Tap Start Position");

    public XRInputValueReader<Vector2> tapStartPositionInput
    {
        get => m_TapStartPositionInput;
        set => XRInputReaderUtility.SetInputProperty(ref m_TapStartPositionInput, value, this);
    }

    [SerializeField]
    XRInputValueReader<Vector2> m_DragCurrentPositionInput = new XRInputValueReader<Vector2>("Drag Current Position");

    public XRInputValueReader<Vector2> dragCurrentPositionInput
    {
        get => m_DragCurrentPositionInput;
        set => XRInputReaderUtility.SetInputProperty(ref m_DragCurrentPositionInput, value, this);
    }

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        deleteButton.onClick.AddListener(DeleteObject);
    }

    void Update()
    {
        if (tapStartPositionInput.TryReadValue(out Vector2 tapStartPosition))
        {
            if (spawnedObject == null)
            {
                if (arRaycastManager.Raycast(tapStartPosition, hits, TrackableType.PlaneWithinBounds))
                {
                    Pose hitPose = hits[0].pose;
                    spawnedObject = Instantiate(objectPrefab, hitPose.position, hitPose.rotation);
                }
            }
        }
        else if (dragCurrentPositionInput.TryReadValue(out Vector2 dragCurrentPosition) && spawnedObject != null)
        {
            if (arRaycastManager.Raycast(dragCurrentPosition, hits, TrackableType.PlaneWithinBounds))
            {
                Pose hitPose = hits[0].pose;
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }

    public void DeleteObject()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
            spawnedObject = null;
        }
    }
}