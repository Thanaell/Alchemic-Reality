using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField]
    //private readonly int caudldronCapacity = 3;
    private readonly int caudldronCapacity = 30; //capacity doesn't matter anymore
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
        if(m_ingredients.Count < caudldronCapacity) //Dont add ingredients after max capacity
        {
            m_ingredients.Add(ingredient);
            //TODO optionnal : Make a selection effect around the card
        }
    }


    public Effect mixIngredients()
    {
        if (m_ingredients.Count==0) { return Effect.NO_EFFECT; }
        int m_effectToApply = Random.Range(1, 20);
        ResetIngredients();
        Debug.Log("reset ingredients 1st way + mixing ingrdients");
        switch (m_effectToApply)
        {
            case 1:
                return Effect.CHANGE_COLOR_TO_RED;
            case 2:
                return Effect.CHANGE_COLOR_TO_BLUE;
            case 3:
                return Effect.CHANGE_COLOR_TO_YELLOW;
            case 4:
                return Effect.CHANGE_SIZE_TO_2;
            case 5:
                return Effect.CHANGE_SIZE_TO_0_5;
            case 6:
                return Effect.ANIM_JUMP;
            case 7:
                return Effect.ANIM_FALL;
            case 8:
                return Effect.ANIM_NOD;
            case 9:
                return Effect.ANIM_LOOK_AT_STOMACH;
            case 10:
                return Effect.ANIM_SPINNING;
            case 11:
                return Effect.ANIM_FLYING;
            case 12:
                return Effect.ANIM_FLAPPING;
            case 13:
                return Effect.ANIM_JUMP_FLAPPING;
            case 14:
                return Effect.ANIM_LOOK_AT_STOMACH_GREEN;
            case 15:
                return Effect.ANIM_FALL_RED;
            case 16:
                return Effect.ANIM_SPINNING_YELLOW;
            case 17:
                return Effect.ANIM_SPINNING_FLAPPING;
            case 18:
                return Effect.ANIM_ROLLING;
            case 19:
                return Effect.ANIM_FLYING_SIZE_2;
            default: // no effect
                return Effect.NO_EFFECT;
        }
        //return AlchemyBook.SearchRecipe(m_ingredients);
    }

    public void ResetIngredients()
    {
        foreach(Ingredient ingredient in m_ingredients){
            ingredient.Reset();
        }
        
    }
}
