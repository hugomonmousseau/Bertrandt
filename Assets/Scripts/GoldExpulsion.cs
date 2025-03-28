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

            //puis on les pousse
            if (_cell != null)
            {
                Rigidbody _rb = _cell.GetComponent<Rigidbody>();
                if (_rb != null)
                {
                    Vector3 direction = (_cell.transform.position - transform.position).normalized;
                    _rb.AddForce(direction * expelForce + (Vector3.up *expelForce), ForceMode.Impulse);
                }
            }
        }
    }
}
