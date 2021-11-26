using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyBook
{

    static Dictionary<Effect, string> ColorBook = new Dictionary<Effect, string>();
    static Dictionary<Effect, string> AnimationTriggerBook = new Dictionary<Effect, string>();

    static List<KeyValuePair<List<Ingredient>, Effect>> RecipeBook = new List<KeyValuePair<List<Ingredient>, Effect>>();

    static AlchemyBook()
    {
        registerColors();
        registerAnimationTriggers();
        registerRecipes();
    }

    private static void registerColors()
    {
        //The string is the key in the bottle color dictionnary. Must be synchronized
        ColorBook.Add(Effect.NO_EFFECT, "blue? I dont know change the color maybe");
    }

    private static void registerAnimationTriggers()
    {
        AnimationTriggerBook.Add(Effect.NO_EFFECT, "none");
    }

    private static void registerRecipes()
    {
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>(), Effect.NO_EFFECT));
    }


    /*_____________________________________________________________________________________________________________________________*/


    public static string SearchColor(Effect effect)
    {
        string color;
        if(ColorBook.TryGetValue(effect, out color)){
            return color;
        }
        return null;
    }

    public static string SearchAnimationTrigger(Effect effect)
    {
        string animationTrigger;
        if (AnimationTriggerBook.TryGetValue(effect, out animationTrigger))
        {
            return animationTrigger;
        }
        return null;
    }

    public static Effect SearchRecipe(List<Ingredient> ingredientsList)
    {
        Effect result = Effect.NO_EFFECT;
        foreach (KeyValuePair<List<Ingredient>, Effect> recipe in RecipeBook)
        {
            if(isIngredientListIdentic(ingredientsList, recipe.Key))
            {
                return recipe.Value;
            }
        }

        return result;
    }

    private static bool isIngredientListIdentic(List<Ingredient> list1, List<Ingredient> list2)
    {
        bool identical = true;
        foreach(Ingredient ingredient1 in list1)
        {
            foreach(Ingredient ingredient2 in list2)
            {
                if(!ingredient1.Correspond(ingredient2))
                {
                    identical = false;
                }
            }
        }
        return identical;
    }
}
