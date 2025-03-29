using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldExpulsion : MonoBehaviour
{
    [SerializeField] List<GameObject> oreCells;
    [SerializeField] float expelForce = 10f;
    [SerializeField] GameObject originalOre;

    [ContextMenu("Expel")]
    public void Expel()
    {
        //on commence par cacher l'original
        originalOre.SetActive(false);

        foreach (GameObject _cell in oreCells)
        {
            //on les active
            _cell.SetActive(true);
            StartCoroutine(_cell.GetComponent<GoldCellsScript>().FadeOut());

        }
    }
}
