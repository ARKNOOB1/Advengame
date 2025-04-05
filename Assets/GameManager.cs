using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // 상점 변수
    public int coin;

    public bool itP1 = false;
    public bool itP2 = false;
    public bool itP3 = false;
    public bool itP4 = false;
    public bool itP5 = false;
    public bool itP6 = false;


    // 게임플레이 변수
    public float Oxygen = 120;

    public float time;

    // 인벤토리 변수
    public bool itIn1 = false;
    public bool itIn2 = false;
    public bool itIn3 = false;
    public bool itIn4 = false;

    public bool itIn5 = false;
    public bool itIn6 = false;

    public bool itIn7 = false;
    public bool itIn8 = false;

    public GameObject ITEM1;
    public GameObject ITEM2;
    public GameObject ITEM3;
    public GameObject ITEM4;

    public GameObject ITEM5;
    public GameObject ITEM6;

    public GameObject ITEM7;
    public GameObject ITEM8;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        
    }
}
