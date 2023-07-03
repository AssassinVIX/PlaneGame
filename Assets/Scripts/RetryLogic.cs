using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryLogic : MonoBehaviour
{
    private Button btn_Retry;

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
            btn_Retry = GameObject.Find("Retry").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_Retry.onClick.AddListener(OnRetryButtonClick);//监听点击事件
        }
    }

    private void OnRetryButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;                      // 重开后设置重置
    }
}
