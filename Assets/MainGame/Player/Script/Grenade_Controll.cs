using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Grenade_Controll : MonoBehaviour
{
    Rigidbody2D rb;

    private float curtime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3.1f);
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
            Debug.Log("A");
        }
    }
}
