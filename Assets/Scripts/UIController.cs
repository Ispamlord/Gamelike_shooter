using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreLabel;
    [SerializeField] private Setting setting;

    public void OnOpenSettings()
    {
        setting.Open();
    }

    
    
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
    private int _score;
    public const float baseSpeed = 3.0f;
    
    
    
    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit); 
}
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit); 
}
    void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();
        setting.Close();
    }
    private void OnEnemyHit()
    {
        _score += 1; 
        scoreLabel.text = _score.ToString();
    }
}
