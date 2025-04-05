using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class PL_Controller : MonoBehaviour
{
    Rigidbody2D rb;

    public Text timer;

    // GAMEOVER
    public GameObject gameOver;
    public Text Totaltime;
    public Text Rank;

    // 애니메이션 변수
    [Header("Animation")]
    [SerializeField] private Animator Atani;
    [SerializeField] private Animator MvAni;

    // HP
    [Header("HP")]
    [SerializeField] public Slider HP;
    [SerializeField] public float Php = 6;

    // Oxygen
    [Header("Oxygen")]
    [SerializeField] public Text Ox;
    [SerializeField] public Slider OxyTank;
    [SerializeField] private float thisOxy;



    // 바닥 감지 변수
    [Header("isGround")]
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGround;

    // 이동 변수
    [Header("Move")]
    [SerializeField] public float moveSpd = 5f;
    [SerializeField] public float jumpForce = 7f;
    public int moveInput;

    // 공격 변수
    [Header("Attack")]
    [SerializeField] public GameObject attackObj;
    [SerializeField] public Transform attackCheck;
    [SerializeField] public Vector2 attackCheckSize = new Vector2(2f, 1f);
    private float curtime;
    public float cooltime = 0.5f;

    // 수류탄
    [Header("Grenade")]
    [SerializeField] public GameObject GrenadePrefab;
    [SerializeField] public float shootSpd = 10f;


    // 인벤토리
    [Header("Inventory")]
    [SerializeField] public GameObject inventory;
    [SerializeField] public Transform itemCheck;
    [SerializeField] public Vector2 itemCheckSize = new Vector2 (1.5f, 1f);





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thisOxy = GameManager.instance.Oxygen;
        GameManager.instance.Oxygen = GameManager.instance.SaveOx;
        attackObj.SetActive(false);
        gameOver.SetActive(false);
        inventory.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        GrCheck();
        Timer();
        Animation();
        Pl_Oxygen();
        Move();
        Jump();
        Attack();
        Inventory();
    }

    void Timer()
    {
        int timeM = (int)GameManager.instance.time / 60;
        int timeS = (int)GameManager.instance.time % 60;
        timer.text = "TIMER : "+timeM.ToString("D2")+ ":" + timeS.ToString("D2");
    }

    // 데미지
    public void Pl_Damaged(int Pdm)
    {
        Php -= Pdm;
        HP.value = Php / 6;

        if(Php <= 0)
        {
            GameOver();
        }
    }

    // 산소
    public void Pl_Oxygen()
    {
        GameManager.instance.Oxygen -= Time.deltaTime;
        Ox.text = GameManager.instance.Oxygen.ToString("F2");
        OxyTank.value = GameManager.instance.Oxygen / thisOxy;
        if(GameManager.instance.Oxygen <= 0)
        {
            GameOver();
        }

    }

    // 이동
    void Move()
    {
        moveInput = 0;

        if (Input.GetKey(KeyCode.A)){
            moveInput = -1;
            transform.localScale = new Vector2(-1, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
            transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
            moveInput = 0;
        }
            rb.velocity = new Vector2(moveInput * moveSpd, rb.velocity.y);
    }
    // 점프
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // 공격
    void Attack()
    {
        if (curtime > 0)
        {
            curtime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            if(curtime <= 0)
            {
                Collider2D[] ATcol = Physics2D.OverlapBoxAll(attackCheck.position, attackCheckSize, 0f);
                foreach (Collider2D col in ATcol)
                {
                    if (col.tag == "Enemy")
                    {
                        col.GetComponent<Enemy>().E_Dameged(1);
                    }
                    else if (col.tag == "FixedEnemy")
                    {
                        col.GetComponent<Fixed_Enemy>().FE_Dameged(1);
                    }
                }
                attackObj.SetActive(true);
                curtime = cooltime;
                Invoke("InvokeAt", 0.5f);
                if (Atani != null)
                {
                    Atani.SetTrigger("Attack");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G)) {
            GameObject grenade = Instantiate(GrenadePrefab, transform.position, Quaternion.identity);
            Rigidbody2D grenadeRb = grenade.GetComponent<Rigidbody2D>();

            if (grenadeRb != null)
            {
                if((Vector2)transform.localScale == new Vector2(1, 1))
                {
                    grenade.transform.rotation = Quaternion.Euler(0, 0, 45);
                    grenadeRb.velocity = new Vector2(5f, 7f);
                }
                if((Vector2)transform.localScale == new Vector2(-1, 1))
                {
                    grenade.transform.rotation = Quaternion.Euler(0, 0, 135);
                    grenadeRb.velocity = new Vector2(-5f, 7f);
                }
                
            }
        }
    }

    // 인벤토리
    void Inventory()
    {
        

        Collider2D[] checkCol = Physics2D.OverlapBoxAll(itemCheck.position, itemCheckSize, 0f);
        foreach (var itemCol in checkCol)
        {
            if (itemCol.tag == "item")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventory.SetActive(false);
        }

    }

    public void IvenCloseBtn()
    {
        inventory.SetActive(false);
    }



    // 숨기기
    void InvokeAt()
    {
        attackObj.SetActive(false);
    }

    // 게임 오버
    void GameOver()
    {
        gameOver.SetActive(true);
        int timeM = (int)GameManager.instance.time / 60;
        int timeS = (int)GameManager.instance.time % 60;
        Totaltime.text = "TotalTime : " + timeM.ToString("D2") + ":" + timeS.ToString("D2");
        Rank.text = "Rank : ".ToString();

        Destroy(gameObject, 1f);
    }






    private void GrCheck()
    {
        Collider2D collision = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, groundDistance, groundLayer);
        isGround = collision != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
        Gizmos.DrawWireCube(attackCheck.position, attackCheckSize);
        Gizmos.DrawWireCube(itemCheck.position, itemCheckSize);
    }

    private void Animation()
    {
        if (!isGround && rb.velocity.y > 0)
            MvAni.Play("PlayerJump");
        else if (moveInput == 0)
            MvAni.Play("PlayerIdle");
        else if (moveInput != 0)
            MvAni.Play("PlayerRun");
    }
}
