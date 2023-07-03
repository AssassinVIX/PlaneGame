using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float zSpeed = 40;
    //横移速度
    float xSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SnakeMove", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(xSpeed * Time.deltaTime, 0, zSpeed * Time.deltaTime, Space.Self);
    }
    void SnakeMove()
    {
        //定义一个数组，实现敌人横移速度的随机
        float[] options = { -15, -10, 10, 15};

        int sel = Random.Range(0, options.Length);

        xSpeed = options[sel];

    }
}
