using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleDamage : MonoBehaviour
{
    public int damage = 20; // 공격 데미지
    public Collider2D colliderToIgnore; // 충돌을 무시할 다른 콜라이더
    private GameObject currentTarget; // 현재 타격 대상

    void Start()
    {
        Collider2D myCollider = GetComponent<Collider2D>();
        if (myCollider != null && colliderToIgnore != null)
        {
            Physics2D.IgnoreCollision(myCollider, colliderToIgnore); // 충돌 무시 설정
        }
        else
        {
            Debug.LogWarning("콜라이더가 올바르게 설정되지 않았습니다!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 캐릭터 자신을 제외하기 위해 태그 확인
        if (collision.collider.CompareTag("Article")) // 캐릭터 태그가 "Player"라면
        {
            return; // 충돌 처리 중단
        }

        // 충돌한 대상이 Enemy 태그를 가지고 있는지 확인
        if (collision.collider.CompareTag("Enemy"))
        {
            currentTarget = collision.collider.gameObject; // 현재 타격 대상 설정
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 타격 대상 초기화
        if (collision.collider.CompareTag("Enemy"))
        {
            currentTarget = null; // 타겟 초기화
        }
    }

    // 애니메이션 이벤트로 호출되는 메서드
    public void ApplyDamage()
    {
        if (currentTarget != null) // 현재 타겟이 있을 때만 실행
        {
            CharacterHealth targetHealth = currentTarget.GetComponent<CharacterHealth>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage); // 체력 감소
                Debug.Log("애니메이션 이벤트로 타격 데미지가 적용되었습니다! 현재 체력: " + targetHealth.GetCurrentHealth());
            }
            else
            {
                Debug.LogWarning("타겟에 CharacterHealth 스크립트가 없습니다.");
            }
        }
        else
        {
            Debug.Log("타격 대상이 없습니다!");
        }
    }
}