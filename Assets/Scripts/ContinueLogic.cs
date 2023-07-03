using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueLogic : MonoBehaviour
{
    private Button btn_Continue;

    public GameObject menu;

    public GameObject victorytext;

    public GameObject losetext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && victorytext.activeSelf == false && losetext.activeSelf == false && menu.activeSelf == true)
        {
            btn_Continue = GameObject.Find("Continue").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_Continue.onClick.AddListener(OnContinueButtonClick);//监听点击事件
        }
    }
    private void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
