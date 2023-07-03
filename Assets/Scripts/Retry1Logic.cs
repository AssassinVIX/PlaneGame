using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry1Logic : MonoBehaviour
{
    private Button btn_Start;

    public GameObject victorytext;

    public GameObject losetext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 && victorytext.activeSelf == true && losetext.activeSelf == false)
        {
            btn_Start = GameObject.Find("Retry1").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
            btn_Start.onClick.AddListener(OnContinueButtonClick);//监听点击事件
        }
    }

    private void OnContinueButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
