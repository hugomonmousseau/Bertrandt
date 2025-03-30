using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SceneARManager : MonoBehaviour
{
    public static SceneARManager INSTANCE;
    [HideInInspector] public GameObject currentChest;
    private int score;

    [Header("UI")]
    [SerializeField] GameObject scanSurfaceUI;
    [SerializeField] List<GameObject> arExperienceUIList;
    [SerializeField] GameObject timerUI;
    [SerializeField] GameObject scoreUI;
    [SerializeField] private Button timerButton;
    [SerializeField] private Button restartButton;

    [Header("Spawn golds")]
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
        restartButton.onClick.AddListener(RestartScene);
    }

    public void DetectedSurface()
    {
        scanSurfaceUI.SetActive(false);

        foreach (GameObject _ui in arExperienceUIList) _ui.SetActive(true);
    }
    private void StartOneMinuteTimer()
    {
        timerUI.SetActive(true);
        foreach (GameObject _ui in arExperienceUIList) _ui.SetActive(false);
        spawnOres = true;

        StartCoroutine(InstantiateGoldOre());
        StartCoroutine(GetComponent<Timer>().RunTimer());
    }


    public void EndTimer()
    {
        scoreUI.SetActive(true);
        restartButton.gameObject.SetActive(true);
        spawnOres = false;
    }

    private void CleanScene()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
    }

    //instancie les minerais
    IEnumerator InstantiateGoldOre()
    {
        (Vector3, Vector3) spawn = GetValidSpawnPosition();
        if (spawn.Item1 != Vector3.zero)
        {
            Instantiate(goldenOre, spawn.Item1, Quaternion.Euler(spawn.Item2), transform);
        }
        yield return new WaitForSeconds(1);
        if (spawnOres) StartCoroutine(InstantiateGoldOre());
    }
    //retourne une position et une rotation valide en moins de 100 essais
    private (Vector3, Vector3) GetValidSpawnPosition()
    {
        int _maxAttempts = 100;
        for (int _attempt = 0; _attempt < _maxAttempts; _attempt++)
        {
            Vector2 _randomDirection = Random.insideUnitCircle.normalized;
            float _randomDistance = Random.Range(minDistance, maxDistance);
            Vector3 _potentialPosition = currentChest.transform.position + new Vector3(_randomDirection.x, 0, _randomDirection.y) * _randomDistance;
            Vector3 _potentialRotation = new Vector3(0, Random.Range(-45, 45), 0);
            if (!Physics.CheckBox(_potentialPosition, goldenOre.GetComponentInChildren<BoxCollider>().size / 2, Quaternion.Euler(_potentialRotation), collisionLayer))
            {
                return (_potentialPosition , _potentialRotation);
            }
        }
        return (Vector3.zero, Vector3.zero); // Retourne zéro si aucune position valide n'est trouvée après plusieurs tentatives
    }

    public void IncremanteScore()
    {
        score++;
        scoreUI.GetComponentInChildren<TextMeshProUGUI>().text = "Score:\n" + score.ToString();
    }

    private void RestartScene()
    {
        timerUI.SetActive(false);
        scoreUI.SetActive(false);
        restartButton.gameObject.SetActive(false);
        foreach (GameObject _ui in arExperienceUIList) _ui.SetActive(true);
        CleanScene();
    }
}
