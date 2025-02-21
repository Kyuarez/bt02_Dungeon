using UnityEngine;

//@tk : 플레이어 위치에서 쏘는 것
public class ArrowShoot : MonoBehaviour
{
    public float speed = 12.0f;
    public float delay = 0.25f;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    private PlayerController player;
    bool isAttack = false;
    GameObject bowObject;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        Vector2 pos = transform.position;
        bowObject = Instantiate(bowPrefab, pos, Quaternion.identity, transform);
    }

    private void Update()
    {
        if (true == Input.GetButtonDown("Fire3"))
        {
            Attack();    
        }

        float bowZ = -1;
        if(player.RotateAngle > 30 && player.RotateAngle < 150)
        {
            bowZ = 1;
        }
        bowObject.transform.rotation = Quaternion.Euler(0, 0, player.RotateAngle);
        bowObject.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);
    }

    private void Attack()
    {
        if(ItemKeeper.curentArrows > 0 && isAttack == false)
        {
            ItemKeeper.curentArrows--;
            isAttack = true;

            var rotation = Quaternion.Euler(0, 0, player.RotateAngle);
            var arrowObject = Instantiate(arrowPrefab, transform.position, rotation);
            float x = Mathf.Cos(player.RotateAngle * Mathf.Deg2Rad);
            float y = Mathf.Sin(player.RotateAngle * Mathf.Deg2Rad);
            Vector2 vec = new Vector2(x, y) * speed;
            
            var rigid = arrowObject.GetComponent<Rigidbody2D>();
            rigid.AddForce(vec, ForceMode2D.Impulse);
            Invoke("AttackChange", delay);
        }
    }

    private void AttackChange() => isAttack = false;
}
