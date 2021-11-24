using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        Bottle bottle = other.GetComponent<Bottle>();

        if (ingredient)
        {
            AddIngredient(ingredient);
        }
        else if (bottle)
        {
            bottle.createPotion(this);
        }
    }

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
