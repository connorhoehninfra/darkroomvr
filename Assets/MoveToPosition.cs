using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + new Vector3(0, 0, 0.5f);
            transform.rotation = target.rotation;
        }
    }
}