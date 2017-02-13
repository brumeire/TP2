using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat
{
    protected const float maxAnxiety = 100.0f;
    protected float actualAnxiety = 0.0f;
    protected float anxietySpeed = 0.1f;

    public bool anxious = false;
    public bool catched = false;
    public float moveSpeed = 5.0f;
    

    public Cat()
    {

    }

    /// <summary>
    /// Execute this the normal update of a monobehaviour class.
    /// </summary>
    public virtual void UpdateCat()
    {
        if (!anxious)
        {
            actualAnxiety += anxietySpeed * Time.deltaTime;
            if (actualAnxiety >= maxAnxiety)
            {
                anxious = true;
            }
        }
        else if (catched)
        {

        }

    }

    public virtual void Catch()
    {
        catched = !catched;
    }
}
