using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLogic : MonoBehaviour
{
    private Button btn_Start;
    private Button btn_Quit;
    public GameObject startMenu;
    private GameObject player;
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 0 && startMenu.activeSelf == true)
        {
            pause.SetActive(false);
            btn_Start = GameObject.Find("StartButton").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_Start.onClick.AddListener(OnContinueButtonClick);//监听点击事件
            btn_Quit = GameObject.Find("QuitButton").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_Quit.onClick.AddListener(OnQuitButtonClick);//监听点击事件           
        }

        if (Time.timeScale == 1 && pause.activeSelf == false)
        {
            pause.SetActive(true);
        }
    }

    private void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        startMenu.SetActive(false);
    }

    private void OnQuitButtonClick()
    {
        UnityEngine.Application.Quit();
    }
}
