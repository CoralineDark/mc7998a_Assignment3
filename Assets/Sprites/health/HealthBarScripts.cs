using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScripts : MonoBehaviour
{
    public Slider slider;
    //public PlayerEffects player;
    private int _maxHealth;
    private int _currentHealth;
    //private bool _loseStateReached = false;
    private void Start() { 
        _maxHealth = 100; 
        _currentHealth = _maxHealth; 
    }
    private void OnEnable() {
        EnemyDamage.PlayerDamaged += SubHealth; 
    }
    private void OnDisable() { 
        EnemyDamage.PlayerDamaged -= SubHealth;     
    }

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
        _maxHealth = health;
        _currentHealth = health;
    }
    public void SetHealth(int health) {
        slider.value = health;
        _currentHealth = health;
    }

    public void AddHealth(int health) {
        slider.value += health;
        _currentHealth += health;
    }

    public void SubHealth(int health) {
        slider.value -= health;
        _currentHealth -= health;
    }

    private void Update() {
        if (_currentHealth <= 0) {
            GameObject.FindWithTag("Player").GetComponent<PlayerDeath>().PlayerDies(); 
        }
    }
}
