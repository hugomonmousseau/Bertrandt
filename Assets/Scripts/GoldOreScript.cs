using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldOreScript : MonoBehaviour
{
    [SerializeField] List<GameObject> oreCells;
    [SerializeField] GameObject originalOre;

    [ContextMenu("Expel")]
    public void Recolt()
    {
        originalOre.SetActive(false);

        foreach (GameObject _cell in oreCells)
        {
            //on les active
            _cell.SetActive(true);
            StartCoroutine(_cell.GetComponent<GoldCellsScript>().FadeOut());

        }
    }
}
