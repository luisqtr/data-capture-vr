using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterials : MonoBehaviour
{
    public List<Material> materials;
    public List<GameObject> objects;

    private int numMaterials, counterMaterial = 0;
    private bool noMaterials = true;    

    void Start()
    {
        numMaterials = materials.Count;
        if(numMaterials != 0 ) noMaterials = false;

        ChangeMaterials();
    }

    private Material GetAnotherMaterial()
    {
        if(noMaterials) return null;

        counterMaterial++;
        if(counterMaterial >= numMaterials)
        {
            counterMaterial = Random.Range(0, numMaterials-1);
        }
        return materials[counterMaterial];
    }

    public void ChangeMaterials()
    {
        Debug.Log("Executing Button script");

        counterMaterial = Random.Range(0, numMaterials-1);

        foreach (GameObject go in objects)
        {
            go.GetComponent<Renderer>().material = GetAnotherMaterial();
        }
    }
}
