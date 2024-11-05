using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using DG.Tweening;

public class Paper : MonoBehaviour
{
    [SerializeField] private Transform frame;
    [SerializeField] private Transform target;
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
        if (Vector3.Distance(target.position, transform.position) > threshold) return;

        isBeingProcessed = true;
        doOnce = false;
        grabbable.enabled = false;
        rigidBody.isKinematic = true;
        myCollider.enabled = false;
        transform.parent = target;
        transform.DOMove(target.position, 2f);
        transform.DORotate(target.eulerAngles, 2f);

    }


    public void UserGrabbedPaper(bool value)
    {
        isGrabbed = value;
    }


}
