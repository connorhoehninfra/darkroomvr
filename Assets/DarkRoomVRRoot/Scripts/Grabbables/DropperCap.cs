using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperCap : MonoBehaviour
{

    private bool isGrabbed = false;
    private Rigidbody rigidbody;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    public void UserGrabbed(bool value)
    {
        isGrabbed = value;

        if (isGrabbed)
        {
            transform.parent = null;
            rigidbody.isKinematic = false;
        }
    }
}
