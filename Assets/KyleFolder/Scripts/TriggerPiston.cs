using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPiston : MonoBehaviour
{
    [SerializeField]
    private PistonController _piston; 
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _piston._canMove = true;
            
        }
    }
}
