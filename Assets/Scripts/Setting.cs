using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
 }
    public void OnSubmitName(string name)
    { 
        Debug.Log(name);
    }
    public void OnSpeedValue()
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speedSlider.value);
        Debug.Log("Speed: " + speedSlider.value);
    }
    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }
}
