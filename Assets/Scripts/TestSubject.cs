using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSubject : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;

    public void Start()
    {
        //Save data
    }



    public void Reset()
    {
        //TODO, in case the test subject die. Reset from the cage
    }

    public void applyEffect(Effect effect)
    {
        AlchemyBook.ActionOnTestSubject action = AlchemyBook.SearchActionOnTestSubject(effect);
        if (action != null)
        {
            action(this);
        }
    }
}
