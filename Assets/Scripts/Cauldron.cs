using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{

    bool m_isUsable;

    List<Ingredient> m_ingredients;
    public List<Ingredient> GetIngredients()
    {
        return m_ingredients;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        m_ingredients.Add(ingredient);
    }

    public void setUsable(bool usable)
    {
        m_isUsable = usable;
    }
}
