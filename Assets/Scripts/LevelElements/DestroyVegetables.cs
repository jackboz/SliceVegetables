using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVegetables : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("vegetables") || other.CompareTag("wood"))
        {
            Destroy(other.gameObject);
        }
    }
}
