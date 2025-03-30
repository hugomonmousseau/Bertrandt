using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldOreScript : MonoBehaviour
{
    [SerializeField] List<GameObject> oreCells;
    [SerializeField] GameObject originalOre;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    [ContextMenu("Expel")]
    public void Recolt()
    {
        Destroy(gameObject);
        GetComponent<BoxCollider>().enabled = false;
        originalOre.SetActive(false);
        foreach (GameObject _cell in oreCells)
        {
            //on les active
            _cell.SetActive(true);
            StartCoroutine(_cell.GetComponent<GoldCellsScript>().FadeOut());

        }
        anim.SetTrigger("Expel");
        
    }
}
