using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyBook
{

    static Dictionary<Effect, string> ColorBook = new Dictionary<Effect, string>();
    static Dictionary<Effect, ActionOnTestSubject> ActionOnTestSubjectBook = new Dictionary<Effect, ActionOnTestSubject>();

    static List<KeyValuePair<List<Ingredient>, Effect>> RecipeBook = new List<KeyValuePair<List<Ingredient>, Effect>>();

    public delegate void ActionOnTestSubject(TestSubject testSubject);

    static AlchemyBook()
    {
        registerColors();
        registerActionOnTestSubject();
        registerRecipes();
    }

    private static void registerColors()
    {
        //The string is the key in the bottle color dictionnary. Must be synchronized
        ColorBook.Add(Effect.NO_EFFECT, "water");
    }

    private static void registerActionOnTestSubject()
    {
        ActionOnTestSubject action = DelDoNothing;
        ActionOnTestSubjectBook.Add(Effect.NO_EFFECT, action);

        // action change color
        action = delegate (TestSubject testSubject)
        {
            changeColorTo(testSubject.gameObject, Color.red);
        };
        ActionOnTestSubjectBook.Add(Effect.CHANGE_COLOR_TO_RED, action);

        action = delegate (TestSubject testSubject)
        {
            changeColorTo(testSubject.gameObject, Color.yellow);
            Debug.Log("changed to yellow");
        };
        ActionOnTestSubjectBook.Add(Effect.CHANGE_COLOR_TO_YELLOW, action);

        action = delegate (TestSubject testSubject)
        {
            changeColorTo(testSubject.gameObject, Color.blue);
        };
        ActionOnTestSubjectBook.Add(Effect.CHANGE_COLOR_TO_BLUE, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("size_0_25");
        };
        ActionOnTestSubjectBook.Add(Effect.CHANGE_SIZE_TO_0_25, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("size_0_5");
        };
        ActionOnTestSubjectBook.Add(Effect.CHANGE_SIZE_TO_0_5, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("size_2");
        };
        ActionOnTestSubjectBook.Add(Effect.CHANGE_SIZE_TO_2, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("fly");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_FLYING, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("jump");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_JUMP, action);

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

    public static ActionOnTestSubject SearchActionOnTestSubject(Effect effect)
    {
        ActionOnTestSubject action;
        if (ActionOnTestSubjectBook.TryGetValue(effect, out action))
        {
            return action;
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
        if(list1.Capacity != list2.Capacity)
        {
            return false;
        }
        foreach(Ingredient ingredient1 in list1)
        {
            if(! IngredientContains(ingredient1, list2))
            {
                return false;
            }
        }
        return true;
    }

    private static bool IngredientContains(Ingredient ingredient, List<Ingredient> list)
    {
        foreach(Ingredient ing in list)
        {
            if (ing.Equals(ingredient))
            {
                return true;
            }
        }
        return false;
    }


    /*________________________Actions on testSubject page_______________________________________________________*/


    public static void DelDoNothing(TestSubject testSubject){}
    public static void ChangeColorToRed(TestSubject testSubject) {
        //need to get the child of the TestSubject object (=Capsule at the moment)
        //var testSubjectRenderer = testSubject.transform.GetChild(0).GetComponent<Renderer>();
        /*var testSubjectRenderer = testSubject.GetModel().GetComponent<Renderer>();
        testSubjectRenderer.material.color= Color.red;*/

        Debug.Log("test subject color changed to red");
        changeColorTo(testSubject.gameObject, Color.red);
    }

    public static void ChangeColorToYellow(TestSubject testSubject)
    {
        changeColorTo(testSubject.gameObject, Color.yellow);
    }

    public static void ChangeColorToBlue(TestSubject testSubject)
    {
        changeColorTo(testSubject.gameObject, Color.blue);
    }

    private static void changeColorTo(GameObject obj, Color color) // recursively change color of all children of test subject
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            if (child.GetComponent<Renderer>())
            {
                child.GetComponent<Renderer>().material.color = color; //change color
            }
            changeColorTo(child.gameObject, color);
        }
    }
}
