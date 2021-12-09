using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField]
    private readonly int caudldronCapacity = 3;

    List<Ingredient> m_ingredients = new List<Ingredient>();
    private void OnTriggerEnter(Collider other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        //Bottle bottle = other.GetComponent<Bottle>();

        if (ingredient)
        {
            AddIngredient(ingredient);
        }
        /*else if (bottle)
        {
            bottle.createPotion(this);
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        if (ingredient)
        {
            if (m_ingredients.Contains(ingredient))
            {
                m_ingredients.Remove(ingredient);
                //TODO optionnal : remove selection effect
            }
        }
    }

    public List<Ingredient> GetIngredients()
    {
        return m_ingredients;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if(m_ingredients.Capacity < caudldronCapacity) //Dont add ingredients after max capacity
        {
            m_ingredients.Add(ingredient);
            //TODO optionnal : Make a selection effect around the card
        }
    }


    public Effect mixIngredients()
    {
        return AlchemyBook.SearchRecipe(m_ingredients);
    }

    public void ResetIngredients()
    {
        foreach(Ingredient ingredient in m_ingredients){
            ingredient.Reset();
        }
        
    }
}
