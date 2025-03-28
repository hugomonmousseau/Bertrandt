using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldExpulsion : MonoBehaviour
{
    public List<GameObject> oreCells;
    public float expelForce = 10f;

    public void Expel()
    {
        foreach (GameObject obj in oreCells)
        {
            if (obj != null)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = (obj.transform.position - transform.position).normalized;
                    rb.AddForce(direction * expelForce, ForceMode.Impulse);
                }
            }
        }
    }
}
