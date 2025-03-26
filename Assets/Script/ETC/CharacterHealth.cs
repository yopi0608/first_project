using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public Animator animator; // Animator를 연결할 변수
    public int maxHealth = 100; // 최대 체력
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // 초기 체력 설정
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 데미지 계산
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 체력 범위 제한

        Debug.Log("현재 체력: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // 캐릭터 죽음 처리
        }
    }
    
    public void SetHealth(int newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth); // 새 체력 설정 및 범위 제한
        Debug.Log("체력이 설정되었습니다: " + currentHealth);
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Debug.Log("캐릭터가 사망했습니다.");
        // 사망 시 실행할 로직 추가
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // 현재 체력을 반환
    }

}
