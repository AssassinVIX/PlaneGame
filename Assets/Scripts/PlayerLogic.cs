using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    //设置玩家移动速度
    public float movespeed;
    //子弹预制体
    public GameObject bulletPerfab;
    //子弹父节点
    public Transform bulletFolder;
    //子弹出生点
    public Transform firePoint;
    //开火间隔
    public float fireInterval = 0.1f;
    //设置初始分数
    public int score = 0;
    //引用文本组件
    public Text scoretext;
    //引用胜利或失败的文本
    public GameObject victorytext;
    public GameObject losetext;
    //引用血条节点
    public GameObject health;
    //设定分数最大值
    public int max;
    //引用目标分数文本
    public Text targettext;
    //引用暂停按钮
    public GameObject pausebutton;
    //引用目标分数的文本输入框
    private InputField targetScore;

    int n = 0;
    public void scoreoption()
    {
        //寻找物体文本输入框，并调用其文本输入框组件
        targetScore = GameObject.Find("InputField").GetComponent<InputField>();
        //将从文本输入框处接收到的字符串转换为int类型变量
        int maxscore = int.Parse(targetScore.text);
        //将接收到的值赋给max
        max = maxscore;
    }
    
    public void scoreChange(int newscore)
    {
        max = newscore;
    }
    // Start is called before the first frame update
    void Start()
    {
        //定时调用开火方法，实现连续开火
        //InvokeRepeating("Fire", fireInterval, fireInterval);
        targettext.text = "目标分数：" + max + "\n距离胜利还剩：" + max;

    }

    // Update is called once per frame
    void Update()
    {
        //定义x,z方向速度的局部变量
        float dx = 0;
        float dz = 0;

        //按下鼠标左键执行开火方法
        if (Input.GetMouseButtonDown(0))
        {
            startFire();
        }

        //松开鼠标左键执行停火方法
        if (Input.GetMouseButtonUp(0))
        {
            cancelFire();
        }

        //通过获取W,A,S,D四个按键事件改变x、y两个方向的速度
        if (Input.GetKey(KeyCode.A))
        {
            dx = -movespeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dx = movespeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dz = movespeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dz = -movespeed;
        }
        //物体移动
        this.transform.Translate(dx * Time.deltaTime, 0, dz * Time.deltaTime);
    }


    public void fire()
    {
        //在bulletFolder下实例化一个子弹节点
        GameObject node = Instantiate(bulletPerfab, bulletFolder);
        //设定子弹出生点
        node.transform.position = firePoint.position;
    }

    //开火方法
    public void startFire()
    {
        //fire方法未被调用时，定时调用fire
        if (!IsInvoking("Fire")) InvokeRepeating("Fire", fireInterval, fireInterval);
    }

    //停火方法
    public void cancelFire()
    {
        //结束对fire方法的定时调用
        CancelInvoke("fire");
    }

    //玩家掉血判定
    private void OnTriggerEnter(Collider other)
    {
     
        //判断与玩家发生碰撞的是不是怪兽节点
        if (other.name.StartsWith("StarSparrow20"))
        {
            Object.Destroy(other.gameObject);
            health.transform.GetChild(n).gameObject.SetActive(false);
            n = n + 1;
            SendMessage("uValue");
        }

    }

    //掉血后调用该方法
    public void uValue()
    {
        if (n == 3)
        {
            //显示失败界面并暂停游戏
            losetext.SetActive(true);
            pausebutton.SetActive(false);
            Object.Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }

    //子弹命中后调用该方法
    public void Value()
    {
        score = score + 1;
        Debug.Log("子弹于" + Time.time + "成功击毁了目标，当前得分" + score);
        scoretext.text = "分数：" + score;
        targettext.text = "目标分数：" + max + "\n距离胜利还剩：" + (max - score);
        if (score == max)
        {
            //显示胜利界面并暂停游戏
            victorytext.SetActive(true);
            pausebutton.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
