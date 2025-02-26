using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime;
    public float createTime = 3.0f;
    public GameObject enemyFactory;

    private float offsetY = 5.0f;
    private float factorX = 2.5f;

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= createTime)
        {
            float x = UnityEngine.Random.Range(-factorX, factorX);
            GameObject obj = Instantiate(enemyFactory, new Vector3(x, offsetY, 0f), Quaternion.identity, transform);
            currentTime = 0;
        }
    }
}
