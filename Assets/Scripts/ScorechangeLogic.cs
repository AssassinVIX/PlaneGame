using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorechangeLogic : MonoBehaviour
{
    private Button btn_sc1;

    private Button btn_sc2;

    private Button btn_scy;

    public GameObject btn_scyy;

    public GameObject victorytext;

    public GameObject loseText;

    public GameObject menu;

    public PlayerLogic player;

    public GameObject startMenu;

    public GameObject scoreChangem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && victorytext.activeSelf == false && loseText.activeSelf == false && menu.activeSelf == true && btn_scyy.activeSelf == true)
        {
            btn_scy = GameObject.Find("ScoreYs").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_scy.onClick.AddListener(OnscyClick);//监听点击事件
        }

        if (Time.timeScale == 0 && victorytext.activeSelf == false && loseText.activeSelf == false && scoreChangem.activeSelf == true && startMenu.activeSelf == true)
        {
            btn_sc1 = GameObject.Find("Score1").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_sc1.onClick.AddListener(Onsc1Click);//监听点击事件
            btn_sc2 = GameObject.Find("Score2").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_sc2.onClick.AddListener(Onsc2Click);//监听点击事件
        }
    }

    private void OnscyClick()
    {
        btn_scyy.SetActive(false);
        scoreChangem.SetActive(true);
    }
    private void Onsc1Click()
    {
        PlayerLogic playerLogic = player.GetComponent<PlayerLogic>();
        playerLogic.scoreChange(25);
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    private void Onsc2Click()
    {
        PlayerLogic playerLogic = player.GetComponent<PlayerLogic>();
        playerLogic.scoreChange(50);
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
