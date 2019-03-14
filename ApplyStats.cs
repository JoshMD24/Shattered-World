using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyStats : MonoBehaviour {

    public static ApplyStats instance;
    public float strength;
    public float maxWeight;
    public float health;
    public float weight;
    public float survival;
    public float stamina;
    public float maxHealth;
    public float maxStamina;
    public float maxStrength;
    public float maxSurvival;
    public float maxSpeed;
    public Text maxHealthText;
    public Text maxStaminaText;
    public Text maxWeightText;
    public Text maxStrengthText;
    public Text maxSurvivalText;
    public Text maxSpeedText;
    public Text currentHealthText;
    public Text currentStaminaText;
    public Text currentWeightText;
    public Text currentStrengthText;
    public Text currentSurvivalText;
    public Text currentSpeedText;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        strength = 1;
        health = 100;
        stamina = 100;
        weight = 0;
        maxWeight = 100;
        survival = 0;
        maxHealth = 100;
        maxStamina = 100;
        maxStrength = 1;
        maxSurvival = 0;
        maxSpeed = 3;
	}

    void Update()
    {
        maxHealthText.text = "Max Health: " + maxHealth;
        maxStaminaText.text = "Max Stamina: " + maxStamina;
        maxStrengthText.text = "Max Strength: " + maxStrength;
        maxWeightText.text = "Max Weight: " + maxWeight;
        maxSurvivalText.text = "Max Survival: " + maxSurvival;
        maxSpeedText.text = "Max Speed: " + Movement.instance.maxMoveSpeed;
        currentHealthText.text = "Health: " + health;
        currentStaminaText.text = "Stamina: " + stamina;
        currentWeightText.text = "Weight: " + weight;
        currentStrengthText.text = "Strength: " + strength;
        currentSurvivalText.text = "Survival: " + survival;
        currentSpeedText.text = "Speed: " + Movement.instance.moveSpeed;
    }
	
	public void LevelUpStrength()
    {
        Stats.instance.strengthStatLevel = Stats.instance.strengthStatLevel + 1;
        strength += 0.5f;
        maxStrength += 0.5f;
    }

    public void LevelUpHealth()
    {
        Stats.instance.healthStatLevel = Stats.instance.healthStatLevel + 1;
        health += 10;
        maxHealth += 10;
    }

    public void LevelUpStamina()
    {
        Stats.instance.staminaStatLevel = Stats.instance.staminaStatLevel + 1;
        stamina += 10;
        maxStamina += 10;
    }

    public void LevelUpWeight()
    {
        Stats.instance.weightStatLevel = Stats.instance.weightStatLevel + 1;
        maxWeight += 10;
    }

    public void LevelUpSurvival()
    {
        Stats.instance.survivalStatLevel = Stats.instance.survivalStatLevel + 1;
        survival += 10;
        maxSurvival += 10;
    }
}
