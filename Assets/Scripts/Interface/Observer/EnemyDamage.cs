using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, IObservable
{
    List<IObserver> observers;
    float damage;
    public EnemyDamage()
    {
        observers = new List<IObserver>();
    }
    public void Add(IObserver observer)
    {
        this.observers.Add(observer);
    }

    public void Notify()
    {
        foreach(IObserver o in this.observers)
        {
            o.Update(damage);
        }
    }

    public void Remove(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }
}
