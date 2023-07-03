using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    //设定子弹移动速度
    public float speed = 1;

    //设定子弹飞行时间
    public float lifeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestory", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    //碰撞检测
    private void OnTriggerEnter(Collider other)
    {
        
        //判断与子弹发生碰撞的是不是怪兽节点
        if (other.name.StartsWith("StarSparrow20"))
        {
            Object.Destroy(other.gameObject);
            Object.Destroy(this.gameObject);
            GameObject.Find("Player").SendMessage("Value");
        }
        
    }

    //子弹自毁
    private void SelfDestory()
    {
        Destroy(this.gameObject);
    }
        
}
