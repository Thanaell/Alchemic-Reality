using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredient : MonoBehaviour
{

    List<IngredientState> m_states;

    public void setState(IngredientState ingredientState)
    {
        m_states.Add(ingredientState);
    }

    public virtual void Slice()
    {
        //default slicing
        this.transform.localScale = 0.5f * this.transform.localScale;
        setState(IngredientState.SLICED);
    }
}
