using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : IPool
{
    public Transform Parent { get; set; }
    public Queue<GameObject> pool { get; set; }

    public GameObject GetGameObject(Action<GameObject> action = null) //@tk : action¿« ¿«µµ
    {
        var obj = pool.Dequeue();
        obj.gameObject.SetActive(true);
        action?.Invoke(obj);
        return obj;
    }

    public void ReturnGameObject(GameObject obj, Action<GameObject> action = null)
    {
        pool.Enqueue(obj);
        obj.gameObject.SetActive(false);
        obj.transform.parent = Parent;
        action?.Invoke(obj);
    }
}
