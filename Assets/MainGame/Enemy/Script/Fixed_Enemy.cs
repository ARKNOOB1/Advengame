using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Fixed_Enemy : MonoBehaviour
{
    Rigidbody2D Ferb;

    // HP
    [Header("HP")]
    [SerializeField] public float Fehp = 3;

    // 애니메이션
    [Header("Animation")]
    [SerializeField] public Animator Scorpion;

    // 공격
    [Header("Attck")]
    [SerializeField] public Transform attackCheck;
    [SerializeField] private Vector2 attackCheckSize = new Vector2(15f, 15f);
    [SerializeField] private float curtime;
    [SerializeField] public float cooltime = 3f;
    [SerializeField] public bool isAttack = true;
    public float shootSpd = 7f;

    [Header("Bullet")]
    [SerializeField] public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        Ferb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AI();
    }

    public void FE_Dameged(int Fedm)
    {

        Fehp -= Fedm;
        if (Fehp > 0)
        {
            Scorpion.SetTrigger("Fdmg");
        }
        else if (Fehp <= 0)
        {
            isAttack = false;
            Scorpion.Play("FScorDead");
            Destroy(gameObject, 0.8f);

        }
    }

    void AI()
    {
        // 공격
        if (isAttack)
        {
            if (curtime > 0)
            {
                curtime -= Time.deltaTime;
            }
            if (curtime <= 0)
            {
                Collider2D[] Atcol = Physics2D.OverlapBoxAll(attackCheck.position, attackCheckSize, 0f);
                foreach (Collider2D Pcol in Atcol)
                {
                    if (Pcol.tag == "Player")
                    {
                        Scorpion.Play("FScorAttack");
                        
                        ShootBullet(Pcol.transform.position);
                        curtime = cooltime;
                        break;
                    }
                }

            }
        }
    }

    void ShootBullet(Vector2 targetPosition)
    {
        GameObject Bullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D BulletRb = Bullet.GetComponent<Rigidbody2D>();

        if (BulletRb != null)
        {
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            BulletRb.velocity = direction * shootSpd;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackCheck.position, attackCheckSize);
    }
}
