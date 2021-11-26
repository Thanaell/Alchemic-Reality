using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredient : MonoBehaviour
{

    List<IngredientState> m_states = new List<IngredientState>();

    [SerializeField]
    protected Object m_Full, m_Sliced, m_Powder; //3D models
    /// <summary>
    /// Texture for the burned models
    /// </summary>
    [SerializeField]
    protected Material m_Burned; //Burn textue. Maybe 1 for each 3D model ? Or just change the color

    protected Object m_currentModel;

    public void Start()
    {
        if (m_Full)
        {
            m_currentModel = m_Full;
        }
    }

    public void setState(IngredientState ingredientState)
    {
        m_states.Add(ingredientState);
    }

    public virtual void Reset()
    {
        m_states.Clear();
        setState(IngredientState.FULL);
    }

    public virtual bool Slice()
    {
        //Debug.Log("base");
        if (!m_states.Contains(IngredientState.POWDER))
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
    public bool Correspond(Ingredient ingredient)
    {
        return false;
    }
}
