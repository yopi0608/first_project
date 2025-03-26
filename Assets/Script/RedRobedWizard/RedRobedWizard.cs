using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRobedWizard : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private bool isGrounded = false; // 지면에 있는 상태 체크
    public float JumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
            float move = 0f;
            if(Input.GetKey(KeyCode.J)) 
            {
                move = -moveSpeed;
            }
            else if(Input.GetKey(KeyCode.L))
            {
                move = moveSpeed;
            }

            rigid.velocity = new Vector2(move, rigid.velocity.y);

            if(move < 0) 
            {
                transform.localScale = new Vector3(3, 3, 3);
            }
            else if(move > 0)
            {
                transform.localScale = new Vector3(-3, 3, 3);
            }

            if (Input.GetKey(KeyCode.I) && isGrounded) {
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                isGrounded = false;
            }

    }
            private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Ground" 태그를 가진 객체와 충돌했을 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 지면에 있음
        }
    }
}
