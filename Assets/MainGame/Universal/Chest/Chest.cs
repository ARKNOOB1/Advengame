using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool open = false;

    public Animator chest;

    public SpriteRenderer Img_Renderer;
    public Sprite SpriteChange;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                chest.Play("Open");
                Img_Renderer.sprite = SpriteChange;
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
