using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
    public bool alive = true;

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

    protected virtual void TryUnCatch()
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

    /// <summary>
    /// Call this when the cat collide a fellow meow.
    /// </summary>
    /// <param name="otherCat"></param>
    public virtual void CollideACat(Cat otherCat)
    {
        //see hacker cat.
    }
}

[System.Serializable]
public class BatCat : Cat
{
    private int timeFlee = 0;

    public BatCat(Statut statut) : base(statut)
    {
        //I'm batman
    }

    protected override void Meow()
    {
        Debug.Log("I'm batman");
    }

    public override void UpdateCat()
    {
        base.UpdateCat();
        if (timeFlee >= 2)
        {
            JumpOverAWindow();
        }
    }

    protected override void TryUnCatch()
    {
        if ((float)Random.value > 0.5f)
        {
            catched = false;
            JumpOverAWindow();
        }
    }

    private void JumpOverAWindow()
    {
        alive = false;
    }
}

[System.Serializable]
public class ZenCat : Cat
{
    public ZenCat(Statut statut) : base(statut)
    {
        anxietySpeed /= 2.0f;
    }
}

[System.Serializable]
public class StressedCat : Cat
{
    public StressedCat(Statut statut) : base(statut)
    {
        moveSpeed *= 2.0f;
        anxietySpeed *= 2.0f;
    }
}

[System.Serializable]
public class WarCat : Cat
{
    public WarCat(Statut statut) : base(statut)
    {
        //War never dies
    }

    public override void Catch()
    {
        base.Catch();
        if (catched)
        {
            Veto.instance.hp -= 1.0f;
        }
    }
}

[System.Serializable]
public class AlmostACat : Cat
{
    public AlmostACat(Statut statut) :base(statut)
    {
        //I'm just a poor boy...
    }

    protected override void Meow()
    {
        Debug.Log("Miouf");
    }
}

[System.Serializable]
public class HackerCat : Cat
{
   public HackerCat (Statut statut) : base (statut)
    {
        //We do not forgive. We do not forget. Expect us.
    }

    public override void CollideACat(Cat otherCat)
    {
        otherCat.statut.asking = CorruptAsk(otherCat.statut.asking);
    }

    private Statut.ask CorruptAsk(Statut.ask ask)
    {
        Statut.ask result = ask;
        while (ask == result)
        {
            result = (Statut.ask) Random.Range(0, 2);
        }
        return result;
    }
}
