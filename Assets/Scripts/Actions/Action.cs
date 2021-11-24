using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    protected abstract void actOn(Ingredient ingredient);
}
