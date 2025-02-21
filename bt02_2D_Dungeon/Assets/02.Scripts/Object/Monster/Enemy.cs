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
    string currentAnim = string.Empty;
    string previousAnim = string.Empty;

    float axisH;
    float axisV;
    float rotateAngle = -90.0f; //È¸Àü°¢
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
}
