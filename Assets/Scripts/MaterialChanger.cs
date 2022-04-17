using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private new MeshRenderer renderer;

    public void ChangeMaterial(Material material)
    {
        renderer.material = material;
    }
}
