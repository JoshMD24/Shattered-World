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
    public float hunger;
    public float thirst;
    public float starvation;
    public float dehydration;
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

    public bool isSprinting;
    public bool inCombat;
    public bool hasSkillPoint = false;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
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
        hunger = 100;
        thirst = 100;
        isSprinting = false;
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
        starvation = 0.01f;
        dehydration = 0.01f;

        //Health code
        if (health < maxHealth)
        {
            health = health += 0.1f;
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        //Stamina code
        if(stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        if (isSprinting == false && stamina < maxStamina)
        {
            StartCoroutine(Sprinting());
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Sprinting");
            sprinting();
            isSprinting = true;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            isSprinting = false;
        }

        //Weight code
        if(weight > maxWeight)
        {
            Debug.Log("Over Weight");
            Movement.instance.moveSpeed = 0.0f;
        }
        if(weight <= maxWeight)
        {
            Movement.instance.moveSpeed = Movement.instance.maxMoveSpeed;
        }

        if(Movement.instance.sprint == true)
        {
            Movement.instance.moveSpeed = Movement.instance.moveSpeed * 1.5f;
        }

        //Strength code
        strength = maxStrength;

        //Hunger/Thirst code
        hunger = hunger - starvation; //code starvation so survival can affect starvation
        if (hunger < 0)
        {
            hunger = 0;
        }
        thirst = thirst - dehydration;
        if (thirst < 0)
        {
            thirst = 0;
        }
        if(hunger == 0)
        {
            health = health - 0.1f;
        }
        if(thirst == 0)
        {
            health = health - 0.1f;
        }
        if(Experience.instance.skillPoints >= 1)
        {
            hasSkillPoint = true;
        }
        if(Experience.instance.skillPoints == 0)
        {
            hasSkillPoint = false;
        }
    }
    
	void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Tiger")
        {
            health = health - 30;

            if(health <= 0)
            {
                die();
            }
        }
    }

	public void LevelUpStrength()
    {
        if (hasSkillPoint == true)
        {
            Stats.instance.strengthStatLevel = Stats.instance.strengthStatLevel + 1;
            strength += 0.5f;
            maxStrength += 0.5f;
            Experience.instance.skillPoints--;
        }
    }

    public void LevelUpHealth()
    {
        if (hasSkillPoint == true)
        {
            Stats.instance.healthStatLevel = Stats.instance.healthStatLevel + 1;
            health += 10;
            maxHealth += 10;
            Experience.instance.skillPoints--;
        }
    }

    public void LevelUpStamina()
    {
        if (hasSkillPoint == true)
        {
            Stats.instance.staminaStatLevel = Stats.instance.staminaStatLevel + 1;
            stamina += 10;
            maxStamina += 10;
            Experience.instance.skillPoints--;
        }
    }

    public void LevelUpWeight()
    {
        if (hasSkillPoint == true)
        {
            Stats.instance.weightStatLevel = Stats.instance.weightStatLevel + 1;
            maxWeight += 10;
            Experience.instance.skillPoints--;
        }
    }

    public void LevelUpSurvival()
    {
        if (hasSkillPoint == true)
        {
            Stats.instance.survivalStatLevel = Stats.instance.survivalStatLevel + 1;
            survival += 0.01f;
            maxSurvival += 0.01f;
            Experience.instance.skillPoints--;
        }
    }

    void die()
    {
        Destroy(this.gameObject);
    }

    void sprinting()
    {
        stamina = stamina - 0.1f;
    }

    IEnumerator Sprinting()
    {
        yield return new WaitForSeconds(0.5f);
        stamina = stamina + 0.1f;
    }

    IEnumerator InCombat()
    {
        yield return new WaitForSeconds(5.0f);
        inCombat = false;
    }

}
