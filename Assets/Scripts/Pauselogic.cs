using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauselogic : MonoBehaviour
{
    private Button btn_Start;

    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        btn_Start = GameObject.Find("PauseButtom").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
        btn_Start.onClick.AddListener(OnStartButtonClick);//监听点击事件
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnStartButtonClick()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }
}
