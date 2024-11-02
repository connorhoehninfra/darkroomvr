using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class UVBox : MonoBehaviour
{
    [SerializeField] private Material uvLightMaterial;
    [SerializeField] private GameObject pointLight;
    private bool lightisOn = false;

    private void Start()
    {
        // uvLightMaterial.SetColor("_EmissionColor", Color.black);
        uvLightMaterial.DisableKeyword("_EMISSION");
        pointLight.SetActive(false);
    }




    public void OnOpenBox()
    {
        if (lightisOn) return;

        // uvLightMaterial.SetColor("_EmissionColor", Color.blue);
        uvLightMaterial.EnableKeyword("_EMISSION");
        pointLight.SetActive(true);
        lightisOn = true;
    }



}
