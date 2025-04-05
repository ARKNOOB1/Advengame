using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D Erb;

    // HP
    [Header("HP")]
    [SerializeField] public float Ehp = 3;

    // 애니메이션
    [Header("Animation")]
    [SerializeField] public Animator Scorpion;


    // 이동 변수
    [Header("Move")]
    [SerializeField] public float stopDistance = 1f;
    [SerializeField] public float mvSpd = 2f;
    [SerializeField] public bool isMove = true;


    // 플레이어 감지
    [Header("PlayerCheck")]
    [SerializeField] public Transform playerCheck;
    [SerializeField] private Vector2 playerCheckSize = new Vector2(10f, 10f);


    // 공격
    [Header("Attck")]
    [SerializeField] public Transform attackCheck;
    [SerializeField] private Vector2 attackCheckSize = new Vector2(1.5f, 0.4f);
    [SerializeField] private float curtime;
    [SerializeField] public float cooltime = 1.5f;
    [SerializeField] public bool isAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        Erb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AI();
    }

    public void E_Dameged(int Edm)
    {

        Ehp -= Edm;
        if(Ehp > 0)
        {
            Scorpion.SetTrigger("Dmg");
        }
        else if (Ehp <= 0)
        {
            isMove = false;
            isAttack = false;
            Scorpion.Play("ScorDead");
            Destroy(gameObject, 0.8f);

        }
    }

    void AI()
    {

        // 이동
        if (isMove)
        {
            Collider2D[] col = Physics2D.OverlapBoxAll(playerCheck.position, playerCheckSize, 0f);
            foreach (Collider2D Pcol in col)
            {
                if (Pcol.tag == "Player")
                {
                    Vector2 direction = (Pcol.transform.position - transform.position).normalized;
                    direction.y = 0;
                    if (Vector2.Distance(Pcol.transform.position, transform.position) > stopDistance)
                    {
                        Erb.velocity = direction * mvSpd;
                        if (direction.x < 0)
                        {
                            transform.localScale = new Vector2(1, 1);
                        }
                        if (direction.x > 0)
                        {
                            transform.localScale = new Vector2(-1, 1);
                        }
                    }
                    else
                    {
                        Erb.velocity = Vector2.zero;
                    }
                }
            }
        }
        
        // 공격
        if (isAttack)
        {
            if (curtime > 0)
            {
                curtime -= Time.deltaTime;
                Debug.Log(curtime);
            }
            if (curtime <= 0)
            {
                Collider2D[] Atcol = Physics2D.OverlapBoxAll(attackCheck.position, attackCheckSize, 0f);
                foreach (Collider2D Pcol in Atcol)
                {
                    if (Pcol.tag == "Player")
                    {
                        Rigidbody2D PlayerRb = Pcol.GetComponent<Rigidbody2D>();

                        Vector2 direction = (Pcol.transform.position - transform.position).normalized;
                        Scorpion.Play("ScorAttack");
                        Pcol.GetComponent<PL_Controller>().Pl_Damaged(1);
                        if (direction.x < 0)
                        {
                            PlayerRb.velocity = new Vector2(Pcol.transform.position.x, 3f);
                        }
                        if (direction.x > 0)
                        {
                            PlayerRb.velocity = new Vector2(Pcol.transform.position.x, 3f);
                        }
                        curtime = cooltime;
                    }
                }

            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerCheck.position, playerCheckSize);
        Gizmos.DrawWireCube(attackCheck.position, attackCheckSize);
    }
}
