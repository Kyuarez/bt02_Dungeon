using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject CreateFromPath(string path)
    {
        return Instantiate(Resources.Load<GameObject>(path));
    }
}
