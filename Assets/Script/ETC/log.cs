using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
    // 물리적 충돌 시 호출
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 Enemy 태그인지 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Collision with Enemy: {collision.gameObject.name}, Tag: {collision.gameObject.tag}");
        }
    }

}
