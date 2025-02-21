using System;
using UnityEngine;

[Serializable]
public abstract class TKObject 
{
    [Header("Stat")]
    [SerializeField] protected float hp;
    [SerializeField] protected float MoveSpeed;
}
