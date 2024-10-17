using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFallTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject _falseBlock;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _falseBlock.SetActive(false);
        }
    }
}
