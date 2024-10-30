using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bowl")
        {
            other.GetComponentInParent<Bowl>().AddLiquid();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "GarbageCollector")
            Destroy(gameObject);

    }
}
