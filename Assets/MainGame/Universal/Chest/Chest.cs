using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool open = false;
    public bool opend = GameManager.instance.chestopend;

    public Animator chest;

    public GameObject chestobj;
    public SpriteRenderer Img_Renderer;
    public Sprite SpriteChange;
    // Start is called before the first frame update
    void Start()
    {
        opend = GameManager.instance.chestopend;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            if(opend == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    chest.Play("Open");
                    Img_Renderer.sprite = SpriteChange;
                    opend = true;
                    GameManager.instance.chestopend = opend;
                }
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            open = true;
            
        }
    }
}
