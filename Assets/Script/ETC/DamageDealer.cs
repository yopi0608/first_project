using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 10; // 공격 데미지

    void OnTriggerEnter(Collider other)
    {
        CharacterHealth target = other.GetComponent<CharacterHealth>(); // 체력 시스템 가져오기
        if (target != null)
        {
            target.TakeDamage(damage); // 데미지 적용
        }
    }
}