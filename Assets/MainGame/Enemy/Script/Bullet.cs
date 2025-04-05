using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D Brb;



    // Start is called before the first frame update
    void Start()
    {
        Brb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PL_Controller>().Pl_Damaged(1);
            Destroy(gameObject); // 플레이어를 맞추면 화살 삭제
        }
        else if (col.tag == "Ground") // 벽이나 땅에 부딪히면 제거
        {
            Destroy(gameObject);
        }
    }
}
