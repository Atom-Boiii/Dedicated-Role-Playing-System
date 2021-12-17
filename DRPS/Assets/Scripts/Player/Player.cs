using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth;
    public float maxArmor;
    public float maxStamina;
    public float maxHunger;
    public float maxThirst;

    [Header("Modifiers")]
    [SerializeField] private float hungerModifier;

    protected float health;
    protected float armor;
    protected float stamina;
    protected float hunger;
    protected float thirst;

    private void Start()
    {
        health = maxHealth;
        armor = maxArmor;
        stamina = maxStamina;
        hunger = maxHunger;
        thirst = maxThirst;
    }

    private void Update()
    {
        if(hunger >= 0)
        {
            hunger -= Time.deltaTime / hungerModifier;
        }
    }
}
