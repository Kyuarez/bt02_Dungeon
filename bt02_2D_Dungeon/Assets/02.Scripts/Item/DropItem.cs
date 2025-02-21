using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class DropItem : MonoBehaviour
{
    public int codeID;
    public ItemType itemType;
    public int count;

    private Rigidbody2D rigid;
    private CircleCollider2D col;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(true == collision.CompareTag("Player"))
        {
            switch (itemType)
            {
                case ItemType.Arrow:
                    ItemKeeper.curentArrows += count;
                    break;
                case ItemType.Key:
                    ItemKeeper.currentKeys += count;
                    break;
                case ItemType.Heart:
                    if(PlayerController.hp < 3)
                    {
                        PlayerController.hp += count;
                    }
                    break;
                default:
                    break;
            }
        }

        OnActionGetItem();
    }

    private void OnActionGetItem()
    {
        col.enabled = false;
        rigid.gravityScale = 2.5f;
        rigid.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
        Destroy(gameObject, 0.5f);
    }
}
