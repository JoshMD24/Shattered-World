using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {
    public static Stats instance; 
    public float healthStatLevel;
    public float staminaStatLevel;
    public float weightStatLevel;
    public float strengthStatLevel;
    public float survivalStatLevel; 
    public float speedStatLevel;
    public float healthBoost;
    public float staminaBoost;
    public float weightBoost;
    public float strengthBoost;
    public float survivalBoost;
    public float speedBoost;
    public Text healthLevel;
    public Text staminaLevel;
    public Text weightLevel;
    public Text strengthLevel;
    public Text survivalLevel;
    public Text speedLevel;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        healthStatLevel = 0.0f;
        staminaStatLevel = 0.0f;
        weightStatLevel = 0.0f;
        strengthStatLevel = 0.0f;
        survivalStatLevel = 0.0f;
        speedStatLevel = 0.0f;
        healthBoost = 0.0f;
        staminaBoost = 0.0f;
        weightBoost = 0.0f;
        strengthBoost = 0.0f;
        survivalBoost = 0.0f;
        speedBoost = 0.0f;
    }

     void Update()
    {
        healthBoost = healthStatLevel * 10.0f;
        staminaBoost = staminaStatLevel * 10.0f;
        weightBoost = weightStatLevel * 10.0f;
        strengthBoost = strengthStatLevel * 0.5f;
        survivalBoost = survivalStatLevel * 10.0f;
        speedBoost = speedStatLevel * 0.2f;
        healthLevel.text = "Health Level: " + healthStatLevel;
        staminaLevel.text = "Stamina Level: " + staminaStatLevel;
        strengthLevel.text = "Strength Level: " + strengthStatLevel;
        weightLevel.text = "Weight Level: " + weightStatLevel;
        survivalLevel.text = "Survival Level: " + survivalStatLevel;
        speedLevel.text = "Speed Level: " + speedStatLevel;
    }
}
