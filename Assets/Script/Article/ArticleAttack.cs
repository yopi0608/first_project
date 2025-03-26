using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleAttack : MonoBehaviour
{
    public Animator animator; // Animator를 연결할 변수
    public float skillCooldown = 3f; // 스킬 쿨타임 (초 단위)
    private float cooldownTimer = 0f; // 쿨타임 타이머
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            TriggerAttack();
             // 쿨타임 초기화
            cooldownTimer = skillCooldown;
        }
    }
    void TriggerAttack()
    {
        animator.SetTrigger("ArticleAttack");
    }
}
