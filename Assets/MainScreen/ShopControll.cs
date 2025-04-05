using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopControll : MonoBehaviour
{
    public GameObject Shop;
    public Text COIN;

    

    public Image Item1;
    public Image Item2;
    public Image Item3;
    public Image Item4;
    public Image Item5;
    public Image Item6;

    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false);
        COIN.text = "COIN : " + GameManager.instance.coin;

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartGame()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void ShopOpen()
    {
        Shop.SetActive(true);
    }

    public void ShopClose()
    {
        Shop.SetActive(false);
    }

    public void Purchase1()
    {
        if (GameManager.instance.itP1)
        {
            Debug.Log("이미 구매한 상품 입니다.");
            return;
        }
        if (GameManager.instance.itP2 || GameManager.instance.itP3)
        {
            Debug.Log("구매할 수 없습니다.");
            return;
        }
        if (GameManager.instance.coin >= 20)
        {
            Color color = Item1.color;
            if(color.a > 128f / 255f)
            {
                color.a = color.a /2;
            }

            Item1.color = color;

            GameManager.instance.coin -= 20;
            COIN.text = "COIN : " + GameManager.instance.coin;
            GameManager.instance.Oxygen = 180;
            GameManager.instance.SaveOx = 180;
            Debug.Log("상품을 구매하였습니다.");
        }

        GameManager.instance.itP1 = true;
    }
    public void Purchase2()
    {
        if (GameManager.instance.itP2)
        {
            Debug.Log("이미 구매한 상품 입니다.");
            return;
        }
        if (GameManager.instance.itP3)
        {
            Debug.Log("구매할 수 없습니다.");
            return;
        }
        if (GameManager.instance.coin >= 40)
        {
            Color color = Item2.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }

            Item2.color = color;

            GameManager.instance.coin -= 40;
            COIN.text = "COIN : " + GameManager.instance.coin;
            GameManager.instance.Oxygen = 240;
            GameManager.instance.SaveOx = 240;
            Debug.Log("상품을 구매하였습니다.");
        }

        GameManager.instance.itP2 = true;
    }
    public void Purchase3()
    {
        if (GameManager.instance.itP3)
        {
            Debug.Log("이미 구매한 상품 입니다.");
            return;
        }

        if (GameManager.instance.coin >= 80)
        {
            Color color = Item3.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }

            Item3.color = color;

            GameManager.instance.coin -= 80;
            COIN.text = "COIN : " + GameManager.instance.coin;
            GameManager.instance.Oxygen = 320;
            GameManager.instance.SaveOx = 320;
            Debug.Log("상품을 구매하였습니다.");
        }

        GameManager.instance.itP3 = true;
    }
    public void Purchase4()
    {
        if (GameManager.instance.itP4 || GameManager.instance.itP5)
        {
            Debug.Log("이미 구매한 상품 입니다.");
            return;
        }

        if (GameManager.instance.coin >= 60)
        {
            Color color = Item4.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }

            Item4.color = color;

            GameManager.instance.coin -= 60;
            COIN.text = "COIN : " + GameManager.instance.coin;
            Debug.Log("상품을 구매하였습니다.");
        }

        GameManager.instance.itP4 = true;
    }
    public void Purchase5()
    {
        if (GameManager.instance.itP5)
        {
            Debug.Log("이미 구매한 상품 입니다.");
            return;
        }

        if (GameManager.instance.coin >= 120)
        {
            Color color = Item5.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }

            Item5.color = color;

            GameManager.instance.coin -= 120;
            COIN.text = "COIN : " + GameManager.instance.coin;
            Debug.Log("상품을 구매하였습니다.");
        }

        GameManager.instance.itP5 = true;
    }
    public void Purchase6()
    {
        if (GameManager.instance.itP6)
        {
            Debug.Log("이미 구매한 상품 입니다.");
            return;
        }

        if (GameManager.instance.coin >= 200)
        {
            Color color = Item6.color;
            if (color.a > 128f / 255f)
            {
                color.a = color.a / 2;
            }

            Item6.color = color;

            GameManager.instance.coin -= 200;
            COIN.text = "COIN : " + GameManager.instance.coin;
            Debug.Log("상품을 구매하였습니다.");
        }

        GameManager.instance.itP6 = true;
    }
    
}
