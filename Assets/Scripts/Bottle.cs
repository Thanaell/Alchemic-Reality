using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    Effect m_effectToApply;
   public void createPotion(Cauldron cauldron)
    {
        List<Ingredient> ingredients = cauldron.GetIngredients();
        mixIngredients(ingredients);
        cauldron.setUsable(false);
    }

    public void mixIngredients(List<Ingredient> ingredients)
    {
        //TODO : set m_effectToApply depending on ingredients
    }
}
