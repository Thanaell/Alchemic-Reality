using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum IngredientType
{
    MUSHROOM, FLOWER, ROOT
}

/*[System.Serializable]
public struct BurnedMaterials
{
    public Material burnedFull;
    public Material burnedSliced;
    public Material burnedPowder;
}
*/
public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private IngredientType m_type;
    List<IngredientState> m_states = new List<IngredientState>();

    /// <summary>
    /// The first game object, the one added in the editor.
    /// Is needed to be able to delete it later, when the state of the ingredient change
    /// </summary>
    [SerializeField]
    private GameObject baseGameObject;

    /// <summary>
    /// Prefabs of the ingredient states. Used to change between states, will intanciate & destroy every time there is a change.
    /// Each of them must have the MaterialManager script
    /// </summary>
    [SerializeField]
    protected GameObject m_Full, m_Sliced, m_Powder;

    protected GameObject m_currentModel;

    public Ingredient(IngredientType type)
    {
        setIngredientType(type);
    }


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

    protected void addBurnTexture()
    {
        if (m_currentModel)
        {
            MaterialManager ingredientMaterial = m_currentModel.GetComponentInChildren<MaterialManager>();
            if (ingredientMaterial)
            {
                ingredientMaterial.applyBurn();
            }
            else
            {
                Debug.Log("The script MaterialManager was not found in the prefab of the current state");
            }
        }

        


        /*if (StateContains(IngredientState.POWDER))
        {
            if (m_Burned.burnedPowder)
            {
                Material currentMat = m_currentModel.GetComponentInChildren<Material>();
                currentMat = m_Burned.burnedPowder; //To test
            }
        } else if (StateContains(IngredientState.SLICED))
        {
            if (m_Burned.burnedSliced)
            {
                Material currentMat = m_currentModel.GetComponentInChildren<Material>();
                currentMat = m_Burned.burnedSliced; //To test
            }
        } else
        {
            if (m_Burned.burnedFull)
            {
                Material currentMat = m_currentModel.GetComponentInChildren<Material>();
                currentMat = m_Burned.burnedFull; //To test
            }
        }
        */
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

    protected void setIngredientType(IngredientType ingredientType)
    {
        m_type = ingredientType;
    }
}
