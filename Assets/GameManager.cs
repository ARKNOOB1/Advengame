using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // ���� ����
    public int coin;
    public int Price;

    public bool itP1 = false;
    public bool itP2 = false;
    public bool itP3 = false;
    public bool itP4 = false;
    public bool itP5 = false;
    public bool itP6 = false;


    // �����÷��� ����
    public float Oxygen = 120;
    public float SaveOx;

    public float time;

    public bool chestopend = false;

    // �κ��丮 ����

    public List<GameObject> Item;

    public int bagIndex = 0;







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
        SaveOx = Oxygen;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMap")
        {
            time += Time.deltaTime;
        }

        if (SceneManager.GetActiveScene().name == "MainScreen")
        {
            
        }
    }
}
