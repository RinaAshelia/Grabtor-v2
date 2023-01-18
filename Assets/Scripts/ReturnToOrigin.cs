using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnToOrigin : MonoBehaviour
{
    [SerializeField] XRBaseInteractable grabbedObject;
    private Pose _originPoint;
    private Rigidbody rb;


    private void OnEnable() 
    {
        grabbedObject.selectExited.AddListener(ObjectReleased);
    }

    private void OnDiasable() 
    {
        grabbedObject.selectExited.RemoveListener(ObjectReleased);
    }


    private void Awake() {
        {
            _originPoint.position = this.transform.position;
            _originPoint.rotation = this.transform.rotation;
            rb = GetComponent<Rigidbody>();

        }
    }

    private void ObjectReleased(SelectExitEventArgs arg0)
    {
        //turn of the rigidbody
        rb.Sleep();

        //turn off collider
        GetComponent<Collider>().enabled = false;

        //return object to origin
        Debug.Log("Object Released");
        this.transform.position = _originPoint.position;
        this.transform.rotation = _originPoint.rotation;

        //turn rb on
        rb.WakeUp();

        //turn on collider
        GetComponent<Collider>().enabled = true;
        
    }
}
