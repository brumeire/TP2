using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat
{
    protected const float maxAnxiety = 100.0f;
    protected float actualAnxiety = 0.0f;
    protected float anxietySpeed = 0.1f;
    protected float timeBeforeMeow = 5.0f;
    protected float actualMeowTimer = 0.0f;
    protected bool anesthesia = false;
    protected float timeOfAnesthesia = 3.0f;
    protected float actualAnsethesiaTimer = 0.0f;

    /// <summary>
    /// Tell if this cat is anxious or not.
    /// </summary>
    public bool anxious = false;


    public bool catched = false;
    public float moveSpeed = 5.0f;
    protected float baseMoveSpeed;
    public Statut statut;

    public Cat(Statut statut)
    {
        this.statut = statut;
    }

    /// <summary>
    /// Execute this in the Start function of a monobehaviour class.
    /// </summary>
    public virtual void StartCat()
    {
        baseMoveSpeed = moveSpeed;
    }

    /// <summary>
    /// Execute this the normal update of a monobehaviour class.
    /// </summary>
    public virtual void UpdateCat()
    {
        if (!anxious && !anesthesia)
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
        
        if (anesthesia)
        {
            actualAnsethesiaTimer += Time.deltaTime;
            if (actualAnsethesiaTimer >= timeOfAnesthesia)
            {
                anesthesia = false;
                moveSpeed = baseMoveSpeed;
            }
        }

        if (actualMeowTimer < timeBeforeMeow)
        {
            actualMeowTimer += Time.deltaTime;
        }
        else
        {
            Meow();
            actualMeowTimer = 0.0f;
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
        if (catched)
        {
            Meow();
        }
    }

    protected virtual void Meow()
    {
        Debug.Log("Miaou");
    }

    /// <summary>
    /// Call this method when you want to anesthetize your cat.
    /// </summary>
    public void Anesthetize()
    {
        anesthesia = true;
        actualAnxiety = 0.0f;
        anxious = false;
        moveSpeed = 0.0f;
    }
}
