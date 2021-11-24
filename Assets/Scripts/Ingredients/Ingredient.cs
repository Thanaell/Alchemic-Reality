using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredient : MonoBehaviour
{

    List<IngredientState> m_states = new List<IngredientState>();

    public void setState(IngredientState ingredientState)
    {
        m_states.Add(ingredientState);
    }

    public virtual void Slice()
    {
        Debug.Log("base");
        this.transform.localScale = 2f * this.transform.localScale;
        setState(IngredientState.SLICED);
    }
}
