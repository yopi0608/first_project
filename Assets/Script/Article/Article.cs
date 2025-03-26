using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Article : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; //움직이는 속도도
    private bool isGrounded = false; // 지면에 있는 상태 체크
    public float JumpPower;
    Rigidbody2D rigid;
//=============================================================
    public float dashSpeed; //대쉬 속도
    public float defaultTime;
    public float speed;
    private bool isdash;
    private float dashTime;
//=============================================================
    public Animator animator; // Animator를 연결할 변수
    public GameObject skillPrefab; // 스킬의 프리팹을 연결할 변수
    public Transform skillSpawnPoint; // 스킬 생성 위치
//=============================================================
    public float skillCooldown = 3f; // 스킬 쿨타임 (초 단위)
    private float cooldownTimer = 0f; // 쿨타임 타이머
//=============================================================

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        moveSpeed = speed;
    }
    void Update()
    {
         if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        float move = 0f;

        if(Input.GetKey(KeyCode.A)) 
        {
            move = -moveSpeed; //move는 기본값값
        }
        else if(Input.GetKey(KeyCode.D))
        {
            move = moveSpeed;
        }
//=============================================================
        rigid.velocity = new Vector2(move, rigid.velocity.y);
//=============================================================
        if(move < 0) 
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if(move > 0)
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }
//=============================================================
            
        if (Input.GetKey(KeyCode.W) && isGrounded) {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            isGrounded = false;
        } 
//=============================================================
        
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            isdash = true;
            TriggerSkill();
            cooldownTimer = skillCooldown;
        }   

        if (dashTime <= 0)
        {
            moveSpeed = speed;
            if(isdash)
            {
                dashTime = defaultTime;
            }

        }

        else
        {
            dashTime -= Time.deltaTime;
            moveSpeed = dashSpeed;  

        }
        isdash = false;
        
    }
//=============================================================
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Ground" 태그를 가진 객체와 충돌했을 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 지면에 있음
        }
    }
//=============================================================
    void TriggerSkill()
    {
        // 애니메이션 실행
        animator.SetTrigger("ArticleSkill"); // Animator에서 NormalSkill 트리거 발동

        // 스킬 생성
        Instantiate(skillPrefab, skillSpawnPoint.position, skillSpawnPoint.rotation);
    }
}
