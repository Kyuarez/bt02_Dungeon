using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float moveSpeed = 2.5f;
    Vector3 dir;

    public GameObject explosionFactory;

    bool isGuided = false;
    GameObject target;

    private void Start()
    {
        int rand = Random.Range(0, 9);

        if(rand < 3)
        {
            isGuided = true;
            target = GameObject.FindGameObjectWithTag("Player");

            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            isGuided = false;
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        if (isGuided == true)
        {
            transform.position += (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += dir * moveSpeed * Time.deltaTime; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ("Bullet" == collision.gameObject.tag)
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
