using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rigid;
    private CircleCollider2D col;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(true == collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if(true == collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            return;
        }

        transform.SetParent(collision.gameObject.transform);
        col.enabled = false;
        rigid.simulated = false;

        Destroy(gameObject, 2.0f);

    }
}
