using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openImage;
    public GameObject itemPrefab;
    public bool isOpen = false;
    public int arrangeID = 0;

    private SpriteRenderer spr;

    private void OnEnable()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(false == isOpen && true == collision.gameObject.CompareTag("Player"))
        {
            spr.sprite = openImage;
            isOpen = true;
            if(itemPrefab != null)
            {
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
