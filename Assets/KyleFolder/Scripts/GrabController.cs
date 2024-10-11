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
    private GameObject _grabbedObject;
    private int layerIndex;

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("Enemy");
    }

    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(_rayPoint.position, transform.right, _rayDis);
        if(hitinfo.collider != null && hitinfo.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.E) && _grabbedObject == null)
            {
                _grabbedObject = hitinfo.collider.gameObject;
                _grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                _grabbedObject.transform.position = _grabPoint.position;
                _grabbedObject.transform.SetParent(transform);
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                _grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                _grabbedObject.transform.SetParent(null);
                _grabbedObject = null;
            }
            Debug.Log("Yes");
            Debug.DrawRay(_rayPoint.position, transform.right * _rayDis);
        
        } 
    }
}
