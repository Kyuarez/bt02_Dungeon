using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int codeID;
    public int hp = 3;
    public float speed = 0.5f;
    public float patternDistance = 4.0f;

    public List<string> animList = new List<string>
    {
        "anim_monster_normal_down",
        "anim_monster_normal_up",
        "anim_monster_normal_left",
        "anim_monster_normal_right",
        "anim_monster_normal_dead",
    };

    private Animator anim;
    private Rigidbody2D rigid;
    private SpriteRenderer spr;
    string currentAnim = string.Empty;
    string previousAnim = string.Empty;

    private Transform target;

    float axisH;
    float axisV;
    float rotateAngle = -90.0f; //È¸Àü°¢
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
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        previousAnim = animList[0];
    }

    private void Update()
    {
        if (true == isDamage) 
        {
            return;
        }

        if(target == null)
        {
            target = Object.FindFirstObjectByType<PlayerController>().transform;
        }

        float magnitude = (target.position - transform.position).magnitude;
        
        if(magnitude < patternDistance)
        {
            float angle = UnityHelper.GetAngleFromTo(transform.position, target.position);

            if (angle > -45.0f && angle <= 45.0f)
            {
                currentAnim = animList[3];
            }
            else if (angle > 45.0f && angle <= 135.0f)
            {
                currentAnim = animList[1];
            }
            else if (angle > 135.0f && angle <= -45.0f)
            {
                currentAnim = animList[0];
            }
            else
            {
                currentAnim = animList[2];
            }

            if (currentAnim != previousAnim)
            {
                previousAnim = currentAnim;
                anim.Play(currentAnim);
            }

            Vector2 vec = UnityHelper.GetChaseTargetVec(transform.position, target.position);
            axisH = vec.x /* * speed*/;
            axisV = vec.y /* * speed*/;
        }
        else
        {
            axisH = 0;
            axisV = 0;
            currentAnim = animList[0];
        }

        if (currentAnim != previousAnim)
        {
            previousAnim = currentAnim;
            anim.Play(currentAnim);
        }
    }

    private void FixedUpdate()
    {
        if (true == isDamage)
        {
            float value = Mathf.Sin(Time.time * 50);
            if(value > 0)
            {
                spr.enabled = true;
            }
            else
            {
                spr.enabled = false;
            }


            return;
        }

        rigid.linearVelocity = new Vector2(axisH, axisV) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (true == collision.gameObject.CompareTag("Arrow"))
        {
            hp--;
            Destroy(collision.gameObject, 0.25f);

            if (hp <= 0)
            {

                rigid.linearVelocity = Vector2.zero;
                currentAnim = animList[4];
                Destroy(gameObject, 0.5f);

            }
        }
    }
}
