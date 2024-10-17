using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IHealth>() != null)
        {
            collision.gameObject.GetComponent<IHealth>().TakeDamage(3);
        }
    }
}
