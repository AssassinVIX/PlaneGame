using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    //引用怪兽预制体
    public GameObject emenyPrefab;
    //引用怪兽出生点节点
    public Transform emenyHome;
    //设定刷怪间隔
    public float creatInterval;
    // Start is called before the first frame update
    void Start()
    {
        //重复调用Creat方法，实现持续出怪
        InvokeRepeating("Creat", creatInterval, creatInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Creat()
    {
        //引用怪兽预制体并设定父节点
        GameObject node = Instantiate(emenyPrefab, emenyHome);
        //设置怪兽出生的位置在父节点
        node.transform.position = emenyHome.position;
        node.transform.localEulerAngles = new Vector3(0, 180, 0);
        //定义一个范围，让出生点随机移动
        float dx = Random.Range(-20, 20);
        node.transform.Translate(dx, 0, 0, Space.Self); 
    }
}
