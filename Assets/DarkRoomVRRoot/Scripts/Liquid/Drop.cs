using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bowl")
            other.GetComponentInParent<Bowl>().AddLiquid();

        Destroy(gameObject);
    }
}
