using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVBox : MonoBehaviour
{
    [SerializeField] private Material uvLightMaterial;


    private void Start()
    {
        uvLightMaterial.DisableKeyword("_EMISSION");
    }

    public void OnOpenBox()
    {
        uvLightMaterial.EnableKeyword("_EMISSION");
    }

}
