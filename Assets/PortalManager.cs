using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject Sponza;
    private List<Material> SponzaMaterials;
    private void Start()
    {
        SponzaMaterials = new List<Material>();

        // SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
        Renderer[] childRends = Sponza.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < childRends.Length; i++)
        {
            SponzaMaterials.Add(childRends[i].sharedMaterial);
        }
        SetShaderVisible(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "MainCamera") return;
        SetShaderVisible(true);

    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag != "MainCamera") return;
        SetShaderVisible(false);
    }
    private void SetShaderVisible(bool isVisible)
    {
        if (isVisible)
        {
            for (int i = 0; i < SponzaMaterials.Count; i++)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
        }
        else
        {
            for (int i = 0; i < SponzaMaterials.Count; i++)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
        }
    }
}
