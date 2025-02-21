using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static int hp = 3;

    public float speed = 3.0f;

    public List<string> animList = new List<string> 
    {
        "anim_player_down",
        "anim_player_up",
        "anim_player_left",
        "anim_player_right",
        "anim_player_dead",
    };

    private SpriteRenderer spr;

    private Animator anim;
    string currentAnim = string.Empty;
    string previousAnim = string.Empty;


    private CircleCollider2D col;
    private Rigidbody2D rigid;      
    float axisH;
    float axisV;
    float rotateAngle = -90.0f; //회전각

    bool isMove = false;
    bool isDamage = false;

    public float RotateAngle
    {
        get
        {
            return rotateAngle;
        }
    }


    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        previousAnim = animList[0];
    }

    private void Update()
    {
        if(isDamage == true)
        {
            return;
        }

        if (false == isMove)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
        }

        SetRotate();

        if (currentAnim != previousAnim)
        {
            previousAnim = currentAnim;
            anim.Play(currentAnim);
        }
    }

    private void FixedUpdate()
    {
        if (isDamage == true)
        {
            return;
        }

        rigid.linearVelocity = new Vector2(axisH, axisV) * speed;
    }

    private void SetRotate()
    {
        Vector2 from = transform.position;
        Vector2 to = new Vector2(from.x + axisH, from.y + axisV);

        rotateAngle = (axisH != 0 || axisV != 0) ? UnityHelper.GetAngleFromTo(from, to) : rotateAngle;

        if (rotateAngle >= -45 && rotateAngle < 45)
        {
            //오른쪽
            currentAnim = animList[3];
        }
        else if (rotateAngle >= 45 && rotateAngle <= 135)
        {
            //위쪽
            currentAnim = animList[1];
        }
        else if (rotateAngle >= -135 && rotateAngle <= -45)
        {
            //아래쪽
            currentAnim = animList[0];
        }
        else
        {
            //위쪽
            currentAnim = animList[2];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (true == collision.gameObject.CompareTag("Enemy"))
        {
            GetDamage(collision.gameObject);
        }
    }

    private void GetDamage(GameObject enemy)
    {
        hp--;

        if(hp > 0)
        {
            rigid.linearVelocity = Vector2.zero;
            Vector2 reboundDirection = (transform.position - enemy.transform.position).normalized;
            rigid.AddForce(reboundDirection * 4, ForceMode2D.Impulse);

            isDamage = true;
            Invoke("OnDamageExit", 0.25f);
        }
        else
        {
            OnDead();
        }
    }

    private void OnDamageExit()
    {
        isDamage = false;
        spr.enabled = true;
    }

    private void OnDead()
    {
        currentAnim = animList[4];
        col.enabled = false;
        rigid.linearVelocity = Vector2.zero;
        rigid.gravityScale = 1f;
        rigid.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        gameObject.SetActive(false);
    }


}
