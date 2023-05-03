using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float HP;
    public float MoveSpeed;
    public float MaxSpeed;
    Rigidbody rigid;
    Animator anim;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        InitAnim();
    }
    void Movement()
    {
        Vector2 inputvec 
            = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigid.AddForce(new Vector3(inputvec.x, 0, inputvec.y).normalized * MoveSpeed * 10 * Time.deltaTime);
        rigid.velocity = new Vector3(Mathf.Clamp(rigid.velocity.x, -MaxSpeed,MaxSpeed), 0,
            Mathf.Clamp(rigid.velocity.z, -MaxSpeed, MaxSpeed));
    }
    void InitAnim()
    {
        if (rigid.velocity.magnitude >= 0.7f)
        {
            anim.SetInteger("MoveAnim",1);
        }
        else
        {
            anim.SetInteger("MoveAnim", 0);
        }
    }
}
