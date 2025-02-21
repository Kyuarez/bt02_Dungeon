using UnityEngine;
using System.Collections.Generic;
using System;

public interface IPool 
{
    Transform Parent { get; set; }

    Queue<GameObject> pool { get; set; }

    GameObject GetGameObject(Action<GameObject> action = null);

    void ReturnGameObject(GameObject obj, Action<GameObject> action = null);
}
