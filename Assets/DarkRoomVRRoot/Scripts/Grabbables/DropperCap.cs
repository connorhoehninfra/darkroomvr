using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;
public class DropperCap : MonoBehaviour
{

    private bool isGrabbed = false;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private LiquidVolume lv;
    [SerializeField] private GameObject spillPrefab;
    [SerializeField] private Transform spillPoint;
    private bool isRightHand;

    private void Start()
    {
        if (!rigidbody) rigidbody = GetComponent<Rigidbody>();
        if (!lv) lv = GetComponentInChildren<LiquidVolume>();
    }

    private void Update()
    {
        if (!isGrabbed) return;

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            ReleaseDrop();
    }

    public void UserGrabbedDropperCap(bool value)
    {
        isGrabbed = value;

        if (isGrabbed)
        {
            transform.parent = null;
            rigidbody.isKinematic = false;
        }
    }


    public void ReleaseDrop()
    {

        Debug.Log("Spawned drop");
        GameObject oneSpill = Instantiate(spillPrefab, spillPoint.position, Quaternion.identity) as GameObject;
        // oneSpill.transform.localScale *= Random.Range(0.45f, 0.65f);
        oneSpill.GetComponent<Renderer>().material.color = lv.liquidColor1;

        // Rigidbody rb = oneSpill.GetComponent<Rigidbody>();
        // rb.transform.position = spillPos + Random.insideUnitSphere * 0.01f;
        // rb.AddForce(new Vector3(Random.value - 0.5f, Random.value * 0.1f - 0.2f, Random.value - 0.5f));
        //rb.AddForce(new Vector3(0f, Random.value * 0.1f - 0.2f, 0f));
        // StartCoroutine(DestroySpill(oneSpill));

    }

    // IEnumerator DestroySpill(GameObject spill)
    // {
    //     yield return new WaitForSeconds(1f);
    //     Destroy(spill);
    // }
}
