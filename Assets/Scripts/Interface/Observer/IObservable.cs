using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    void Add(IObserver observer);
    void Remove(IObserver observer);
    void Notify();
}
