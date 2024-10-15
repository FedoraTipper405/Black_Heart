using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    [SerializeField]
    private Transform _grabPoint;
    [SerializeField]
    private Transform _rayPoint;
    [SerializeField]
    private float _rayDis;

    private void Start()
    {

    }

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(_rayPoint.position, Vector2.right * transform.localScale, _rayDis);
        if (grabCheck.collider != null && grabCheck.collider.tag == "PickUp")
        {
            if (Input.GetKey(KeyCode.E))
            {
                grabCheck.collider.gameObject.transform.parent = _grabPoint;
                grabCheck.collider.gameObject.transform.position = _grabPoint.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                grabCheck.collider.gameObject.GetComponent<DeadPrisoner>().enabled = false;
                grabCheck.collider.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
            else if (Input.GetKey(KeyCode.T))
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabCheck.collider.gameObject.GetComponent<Collider2D>().isTrigger = false;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.localScale * 5);
            }

            Debug.DrawLine(_rayPoint.position, Vector2.right * transform.localScale * _rayDis);
        }
    }
}
