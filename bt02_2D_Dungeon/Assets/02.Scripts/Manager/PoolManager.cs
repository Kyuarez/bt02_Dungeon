using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public Dictionary<string, IPool> pools = new Dictionary<string, IPool>();

    public IPool PoolObject(string path)
    {
        if (false == pools.ContainsKey(path))
        {
            AddPool(path);
        }

        if (pools[path].pool.Count <= 0)
        {
            AddQueue(path);
        }

        return pools[path];
    }

    public GameObject AddPool(string path)
    {
        var obj = new GameObject(path + "Pool");
        ObjectPool objectPool = new ObjectPool();
        pools.Add(path, objectPool);

        objectPool.Parent = obj.transform;
        return obj;
    }

    public void AddQueue(string path)
    {
        var obj = GameManager.Instance.CreateFromPath(path);
        obj.transform.parent = pools[path].Parent;
        pools[path].ReturnGameObject(obj);
    }
}
