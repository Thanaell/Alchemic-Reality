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
        ColorBook.Add(Effect.CHANGE_COLOR_TO_BLUE, "blue");
        ColorBook.Add(Effect.CHANGE_COLOR_TO_YELLOW, "souffre");
        ColorBook.Add(Effect.ANIM_SPINNING, "violet");
        ColorBook.Add(Effect.ANIM_LOOK_AT_STOMACH_GREEN, "green");
        ColorBook.Add(Effect.ANIM_ROLLING, "orange");
        ColorBook.Add(Effect.CHANGE_COLOR_TO_RED, "red");
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

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("fall");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_FALL, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("nod");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_NOD, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("stomach");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_LOOK_AT_STOMACH, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("spin");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_SPINNING, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("flapping");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_FLAPPING, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("jumpFlapping");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_JUMP_FLAPPING, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("stomach");
            changeColorTo(testSubject.gameObject, Color.green);
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_LOOK_AT_STOMACH_GREEN, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("fall");
            changeColorTo(testSubject.gameObject, Color.red);
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_FALL_RED, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("spin");
            changeColorTo(testSubject.gameObject, Color.yellow);
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_SPINNING_YELLOW, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("spinFlapping");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_SPINNING_FLAPPING, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("roll");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_ROLLING, action);

        action = delegate (TestSubject testSubject)
        {
            testSubject.GetAnimator().Play("flySize2");
        };
        ActionOnTestSubjectBook.Add(Effect.ANIM_FLYING_SIZE_2, action);

    }

    private static void registerRecipes()
    {
        Ingredient mushroom = new Ingredient(IngredientType.MUSHROOM);
        Ingredient flower = new Ingredient(IngredientType.FLOWER);
        Ingredient root = new Ingredient(IngredientType.ROOT);
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>(), Effect.NO_EFFECT));
        //Color
        flower.Grind(); root.Slice(); mushroom.Grind(); mushroom.Burn();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom}, Effect.CHANGE_COLOR_TO_RED));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        flower.Grind(); mushroom.Slice(); root.Grind(); root.Burn();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.CHANGE_COLOR_TO_BLUE));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        flower.Grind(); mushroom.Slice(); root.Slice();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.CHANGE_COLOR_TO_YELLOW));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);
        //Size
        mushroom.Grind(); flower.Slice();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.CHANGE_SIZE_TO_2));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Grind(); root.Slice();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.CHANGE_SIZE_TO_0_5));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);
        
        mushroom.Grind(); root.Grind();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.CHANGE_SIZE_TO_0_25));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);
        //Animations
        mushroom.Slice(); root.Grind();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_JUMP));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Slice(); flower.Grind(); root.Slice();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_FALL));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Slice(); mushroom.Burn(); flower.Slice(); flower.Burn(); root.Slice(); root.Burn();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_NOD));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Burn(); flower.Slice(); flower.Burn(); root.Slice(); root.Burn();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_LOOK_AT_STOMACH));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Grind(); flower.Slice(); root.Slice();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_SPINNING));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Grind(); flower.Grind(); flower.Burn(); root.Grind();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_FLYING));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Grind(); flower.Grind(); root.Slice();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_FLAPPING));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Grind(); flower.Slice(); root.Grind();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_JUMP_FLAPPING));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        flower.Slice(); flower.Burn(); root.Slice(); root.Burn();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_LOOK_AT_STOMACH_GREEN));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Slice(); flower.Grind();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_FALL_RED));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Grind(); flower.Slice(); flower.Burn(); root.Slice();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_SPINNING_YELLOW));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Grind(); flower.Slice(); root.Slice(); root.Burn();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_SPINNING_FLAPPING));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        flower.Slice(); flower.Burn();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_ROLLING));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);

        mushroom.Grind(); flower.Grind(); flower.Burn();
        RecipeBook.Add(new KeyValuePair<List<Ingredient>, Effect>(new List<Ingredient>() { flower, root, mushroom }, Effect.ANIM_FLYING_SIZE_2));
        flower = new Ingredient(IngredientType.FLOWER); mushroom = new Ingredient(IngredientType.MUSHROOM); root = new Ingredient(IngredientType.ROOT);
        
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
