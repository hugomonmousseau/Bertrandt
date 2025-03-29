using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneARManager : MonoBehaviour
{
    public static SceneARManager INSTANCE;
    [HideInInspector] public GameObject currentChest;
    [SerializeField] GameObject scanSurfaceUI;
    [SerializeField] List<GameObject> arExperienceUIList;

    [Header("Spawn golds")]
    [SerializeField] private Button timerButton;
    [SerializeField] float delayBetweenSpawns = 1;
    [SerializeField] float minDistance = 1.0f;
    [SerializeField] float maxDistance = 5.0f;
    [SerializeField] GameObject goldenOre;
    [SerializeField] LayerMask collisionLayer;
    [HideInInspector] public bool spawnOres = false; // si oui > phase de spawn; si non > phase de placement du coffre
    private void Awake()
    {
        INSTANCE = this;
    }
    void Start()
    {
        timerButton.onClick.AddListener(StartOneMinuteTimer);
    }

    public void DetectedSurface()
    {
        scanSurfaceUI.SetActive(false);

        foreach (GameObject _ui in arExperienceUIList) _ui.SetActive(true);
    }
    private void StartOneMinuteTimer()
    {
        StartCoroutine(InstantiateGoldOre());
        StartCoroutine(OneMinuteTimer());
    }
    IEnumerator OneMinuteTimer()
    {
        foreach (GameObject _ui in arExperienceUIList) _ui.SetActive(false);
        yield return new WaitForSeconds(60);
        foreach (Transform child in transform) Destroy(child.gameObject);
        foreach (GameObject _ui in arExperienceUIList) _ui.SetActive(true);
        spawnOres = false;
    }
    IEnumerator InstantiateGoldOre()
    {
        (Vector3, Vector3) spawn = GetValidSpawnPosition();
        if (spawn.Item1 != Vector3.zero)
        {
            Instantiate(goldenOre, spawn.Item1, Quaternion.Euler(spawn.Item2), transform);
        }
        yield return new WaitForSeconds(delayBetweenSpawns);
        if (spawnOres) StartCoroutine(InstantiateGoldOre());
    }

    private (Vector3, Vector3) GetValidSpawnPosition()
    {
        int maxAttempts = 100;
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float randomDistance = Random.Range(minDistance, maxDistance);
            Vector3 potentialPosition = currentChest.transform.position + new Vector3(randomDirection.x, 0, randomDirection.y) * randomDistance;
            Vector3 potentialRotation = new Vector3(0, Random.Range(-45, 45), 0);
            if (!Physics.CheckBox(potentialPosition, goldenOre.GetComponentInChildren<BoxCollider>().size / 2, Quaternion.Euler(potentialRotation), collisionLayer))
            {
                return (potentialPosition , potentialRotation);
            }
        }
        return (Vector3.zero, Vector3.zero); // Retourne zéro si aucune position valide n'est trouvée après plusieurs tentatives
    }
}
