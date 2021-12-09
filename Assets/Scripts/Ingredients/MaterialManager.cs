using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To add to each prefab of the state of the ingredient
/// </summary>
public class MaterialManager : MonoBehaviour
{


    /// <summary>
    /// The component of the prefab. Full will only have 1 component, but slice will have all its cubes
    /// </summary>
    [SerializeField]
    private List<GameObject> ingredientComponent = new List<GameObject>();

    [SerializeField]
    private Material burnedMaterial;

    public void Start()
    {
        if (ingredientComponent.Capacity == 0)
        {
            ingredientComponent.Add(gameObject);
        }
    }

    public void applyBurn()
    {
        if (burnedMaterial)
        {
            foreach (GameObject component in ingredientComponent)
            {
                Material currentMat = component.GetComponentInChildren<Material>();
                currentMat = burnedMaterial;
            }
        }
    }
}
