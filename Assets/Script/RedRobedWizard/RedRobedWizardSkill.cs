using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRobedWizardSkill : MonoBehaviour
{
    public Animator animator; // Animator를 연결할 변수
    public GameObject MagicSkillPrefab; // 발사체의 프리팹
    public Transform SkillOrigin; // 스킬이 발사될 오브젝트의 위치
    public float MagicSkillSpeed; // 발사체 속도
    public float destroyAfterSeconds = 5f; // 생성된 발사체를 제거할 시간 (초)
    public float skillCooldown = 3f; // 스킬 쿨타임 (초 단위)

    private float cooldownTimer = 0f; // 쿨타임 타이머

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 쿨타임 타이머 감소
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // 스킬 발사 - 쿨타임이 0 이하일 때만 가능
        if (cooldownTimer <= 0f && Input.GetKeyDown(KeyCode.U))
        {
            TriggerSkill();
            FireMagicSkill();

            // 쿨타임 초기화
            cooldownTimer = skillCooldown;
        }
    }

    void TriggerSkill()
    {
        animator.SetTrigger("MagicSkill"); // MagicAttack 애니메이션 트리거
    }

    void FireMagicSkill()
    {
        if (SkillOrigin == null) 
        {
            Debug.LogWarning("발사 위치가 설정되지 않았습니다!");
            return;
        }

        // 발사체 생성
        GameObject MagicSkill = Instantiate(MagicSkillPrefab);
        MagicSkill.transform.position = SkillOrigin.position; // 원하는 오브젝트 위치에서 생성

        // Rigidbody2D 가져오기
        Rigidbody2D rb = MagicSkill.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // 캐릭터 또는 공격 원점의 방향에 따라 발사 방향 설정
            Vector2 fireDirection = transform.localScale.x > 0 ? Vector2.left : Vector2.right;
            rb.AddForce(fireDirection * MagicSkillSpeed, ForceMode2D.Impulse);
        }

        // 발사체가 올바른 방향을 향하도록 회전
        if (transform.localScale.x < 0) // 캐릭터 또는 공격 원점이 왼쪽을 바라볼 때
        {
            MagicSkill.transform.rotation = Quaternion.Euler(0, 0, 0); // 기본 방향
        }
        else
        {
            MagicSkill.transform.rotation = Quaternion.Euler(0, 180, 0); // 오른쪽으로 회전
        }

        // 일정 시간이 지난 후 발사체 제거
        Destroy(MagicSkill, destroyAfterSeconds);
    }
}