using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRobedWizardDamage : MonoBehaviour
{
    public int damage = 20; // 공격 데미지

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Enemy 태그 또는 Ground 태그와 충돌 시 클론 제거
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Ground")|| collision.collider.CompareTag("Article"))
        {
            Destroy(gameObject); // 공격 오브젝트 제거
        }

        // 캐릭터 자신을 제외하기 위해 태그 확인
        if (collision.collider.CompareTag("RedRobedWizard")) // 캐릭터 태그가 "Player"라면
        {
            return; // 충돌 처리 중단
        }

        // 체력 스크립트가 있다면 데미지 전달
        CharacterHealth targetHealth = collision.collider.GetComponent<CharacterHealth>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage); // 체력 감소
            Debug.Log("타격으로 체력이 감소했습니다! 현재 체력: " + targetHealth.GetCurrentHealth());
        }
    }
}

