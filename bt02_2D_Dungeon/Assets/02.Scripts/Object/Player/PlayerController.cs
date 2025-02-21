using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public List<string> animList = new List<string> 
    {
        "anim_player_down",
        "anim_player_up",
        "anim_player_left",
        "anim_player_right",
        "anim_player_dead",
    };
    
    private Animator anim;
    string currentAnim = string.Empty;
    string previousAnim = string.Empty;


    private Rigidbody2D rigid;      
    float axisH;
    float axisV;
    float rotateAngle = -90.0f; //회전각

    bool isMove = false;

    public float RotateAngle
    {
        get
        {
            return rotateAngle;
        }
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        previousAnim = animList[0];
    }

    private void Update()
    {
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
}
