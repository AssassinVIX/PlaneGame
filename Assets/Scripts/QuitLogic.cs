using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitLogic : MonoBehaviour
{
    private Button btn_Quit;

    public GameObject victorytext;

    public GameObject losetext;

    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && victorytext.activeSelf == false && losetext.activeSelf == false && menu.activeSelf == true)
        {
            btn_Quit = GameObject.Find("Quit").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_Quit.onClick.AddListener(OnQuitButtonClick);//监听点击事件
        }
    }

    private void OnQuitButtonClick()
    {
        UnityEngine.Application.Quit();                   // 重开后设置重置
    }
}
