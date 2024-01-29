using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]   //Автоматически добавляет указанные свойства к объекту
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement")]
    public float speed = 2f;
    public float xMove;

    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //Считывает ввод
    private void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        if(xMove !=0)
        anim.SetBool("isMoving", true);
    }

    //Двигает персонажа
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xMove * speed, rb.velocity.y);   
        Flip(xMove);
        anim.SetBool("isMoving", false);
    }

    private void Flip(float _dir)
    {
        if (_dir < 0)
        {
            facingRight = false;
            transform.localScale = new Vector2(_dir, 1);
        }
        else if (_dir > 0)
        {
            facingRight = true;
            transform.localScale = new Vector2(_dir, 1);
        }
    }    
}
