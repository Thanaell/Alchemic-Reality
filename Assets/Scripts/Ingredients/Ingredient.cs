using System.Collections.Generic;
using UnityEngine;
using System.Linq;

enum IngredientType
{
    MUSHROOM, FLOWER, ROOT
}

[System.Serializable]
public struct BurnedMaterials
{
    public Material burnedFull;
    public Material burnedSliced;
    public Material burnedPowder;
}

public abstract class Ingredient : MonoBehaviour
{
    [SerializeField]
    private IngredientType m_type;
    List<IngredientState> m_states = new List<IngredientState>();

    [SerializeField]
    private GameObject baseGameObject; //The first game object, the one added in the editor

    [SerializeField]
    protected GameObject m_Full, m_Sliced, m_Powder; //Prefabs

    [SerializeField]
    protected BurnedMaterials m_Burned;

    protected GameObject m_currentModel;

    public void Start()
    {
        if (baseGameObject)
        {
            m_currentModel = baseGameObject;
        } else
        {
            m_currentModel = GetComponent<GameObject>();
        }
    }

    public void setState(IngredientState ingredientState)
    {
        m_states.Add(ingredientState);
    }

    public bool StateContains(IngredientState state)
    {
        return m_states.Contains(state);
    }

    public virtual void Reset()
    {
        m_states.Clear();
        setState(IngredientState.FULL);
    }

    public virtual bool Slice()
    {
        //Debug.Log("base");
        if (!StateContains(IngredientState.POWDER) && ! StateContains(IngredientState.SLICED))
        {
            setState(IngredientState.SLICED);
            return true;
        }
        return false;
        
    }

    public virtual void Grind()
    {
        m_states.Remove(IngredientState.SLICED);
        setState(IngredientState.POWDER);
    }

    public virtual void Burn()
    {
        setState(IngredientState.BURNED);
    }



    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="ingredient"></param>
    /// <returns></returns>
    public bool Equals(Ingredient ingredient)
    {
        if (m_type != ingredient.m_type)
        {
            return false;
        }
        if( m_states.OrderBy(x => x).SequenceEqual(ingredient.m_states.OrderBy(y => y)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
