using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class Frame : MonoBehaviour
{

    [SerializeField] private Transform uvBox;
    [SerializeField] private Grabbable grabbable;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Collider myCollider;
    [SerializeField] private float threshold;

    private bool isGrabbed = false, doOnce = true;
    private bool isBeingProcessed = false;




    private void Update()
    {
        if (!isGrabbed) return;
        if (!doOnce) return;
        if (Vector3.Distance(uvBox.position, transform.position) > threshold) return;

        isBeingProcessed = true;
        doOnce = false;
        grabbable.enabled = false;
        rigidBody.isKinematic = true;
        myCollider.enabled = false;
        //TODO: Tween animation

    }

    public void UserGrabbedBox(bool value)
    {
        isGrabbed = value;
    }




}
