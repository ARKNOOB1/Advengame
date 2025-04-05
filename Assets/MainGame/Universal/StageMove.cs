using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour
{
    // 텔레포터
    [Header("Teleporter")]
    [SerializeField] public Transform EndPoint;
    [SerializeField] public bool isEnter;
    [SerializeField] public bool isInput;
    Collider2D Obj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isEnter)
            {
                Obj.transform.position = EndPoint.transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            isEnter = true;
            Obj = col;
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isEnter = false;
            Obj = null;
        }
        
    }
}
