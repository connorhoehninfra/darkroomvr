using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using DG.Tweening;

public class Paper : MonoBehaviour
{
    [SerializeField] private Transform frame;
    [SerializeField] private Transform tray;
    [SerializeField] private Grabbable grabbable;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Collider myCollider;
    [SerializeField] private float threshold;

    private bool isGrabbed = false;
    private bool doOnceCheckDistanceToFrame = true;
    private bool doOnceCheckDistanceToTray = true;
    private bool isBeingProcessed = false;




    private void Update()
    {
        if (!isGrabbed) return;
        if (doOnceCheckDistanceToFrame)
        {
            if (Vector3.Distance(frame.position, transform.position) <= threshold)
            {
                isBeingProcessed = true;
                doOnceCheckDistanceToFrame = false;
                grabbable.enabled = false;
                rigidBody.isKinematic = true;
                myCollider.enabled = false;
                transform.parent = frame;
                transform.DOMove(frame.position, 2f);
                transform.DORotate(frame.eulerAngles, 2f).OnComplete(() =>
                {
                    isBeingProcessed = false;
                    grabbable.enabled = true;
                    // rigidBody.isKinematic = false;
                    myCollider.enabled = true;
                    // transform.parent = null;
                });
            }
        }
        if (doOnceCheckDistanceToTray)
        {
            if (Vector3.Distance(tray.position, transform.position) <= threshold)
            {
                isBeingProcessed = true;
                doOnceCheckDistanceToTray = false;
                grabbable.enabled = false;
                rigidBody.isKinematic = true;
                myCollider.enabled = false;
                // transform.parent = tray;
                transform.DOMove(tray.position, 2f);
                transform.DORotate(tray.eulerAngles, 2f).OnComplete(() =>
                {
                    isBeingProcessed = false;
                    grabbable.enabled = true;
                    // rigidBody.isKinematic = false;
                    myCollider.enabled = true;
                    // transform.parent = null;
                });
            }
        }

    }


    public void UserGrabbedPaper(bool value)
    {
        isGrabbed = value;
        if (value) transform.parent = null;

    }


}
