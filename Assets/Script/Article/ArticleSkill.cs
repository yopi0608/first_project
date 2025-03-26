using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleSkill : MonoBehaviour
{
    public Animator animator; // Animator를 연결할 변수
    public GameObject skillPrefab; // 스킬의 프리팹을 연결할 변수
    public Transform skillSpawnPoint; // 스킬 생성 위치

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            TriggerSkill();
        }
    }
    void TriggerSkill()
    {
        // 애니메이션 실행
        animator.SetTrigger("ArticleSkill"); // Animator에서 NormalSkill 트리거 발동

        // 스킬 생성
        Instantiate(skillPrefab, skillSpawnPoint.position, skillSpawnPoint.rotation);
    }
}