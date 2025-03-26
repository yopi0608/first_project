using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttackDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 Enemy 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); // MagicAttack 오브젝트 삭제
        }
    }
}
