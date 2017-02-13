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
    public Statut statut;

    public Cat(Statut statut)
    {
        this.statut = statut;
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
            anxious = false;
            actualAnxiety = maxAnxiety - 10.0f;
            TryUnCatch();
        }

    }

    protected void TryUnCatch()
    {
        if ((float) Random.value > 0.5f)
        {
            catched = false;
        }
    }

    /// <summary>
    /// Call this method when you want to take or drop a cat.
    /// </summary>
    public virtual void Catch()
    {
        catched = !catched;
    }
}
