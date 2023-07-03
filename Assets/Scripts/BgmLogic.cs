using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmLogic : MonoBehaviour
{
    //引用滑动条节点
    public Slider slider;
    //引用音频组件
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //监听滑动条值的改变，若改变，则调用OnVolumeChanged方法
        slider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnVolumeChanged(float volume)
    {
        //修改音频组件的音量属性
        audioSource.volume = volume;
    }
}
