using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Grenade_Controll : MonoBehaviour
{
    Rigidbody2D rb;

    public ParticleSystem Explosive;

    public Transform ExplosivePosition;
    public Vector2 ExplosiveRange = new Vector2(5f, 5f);

    private float curtime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(curtime > 0)
        {
            curtime -= Time.deltaTime;
            Debug.Log(curtime);
        }
        if(curtime <= 0)
        {
            SpriteRenderer grenade = GetComponent<SpriteRenderer>();
            grenade.color = new Color(1, 1, 1, 0);
            Collider2D[] Excol = Physics2D.OverlapBoxAll(ExplosivePosition.position, ExplosiveRange, 0f);
            foreach(Collider2D Entity in Excol)
            {
                if(Entity.tag == "Player")
                {
                    Entity.GetComponent<PL_Controller>().Pl_Damaged(5);
                }
                if(Entity.tag == "Enemy")
                {
                    Entity.GetComponent<Enemy>().E_Dameged(5);
                }
                if(Entity.tag == "FixedEnemy")
                {
                    Entity.GetComponent<Fixed_Enemy>().FE_Dameged(5);
                }
                rb.velocity = Vector2.zero;
            }
            curtime = 3f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(ExplosivePosition.position, ExplosiveRange);
    }
}
