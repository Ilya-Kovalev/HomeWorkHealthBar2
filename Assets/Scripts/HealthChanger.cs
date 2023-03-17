using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthChanger : MonoBehaviour
{
    public Player player;
    public Slider slider;
    public Button buttonTreatment;
    public Button buttonDamage;
    private float _minHealth = 0;
    private float _maxHealth = 100;
    private float _amountOfChangePerClick = 10;
    private float _timeForChange = 0.1f;

    public void Start()
    {
        slider.value = player.GetHealth();
    }

    public void ChangSliderValue(int directionOfChange) 
    { 
        StartCoroutine(SetSliderValue(directionOfChange));
        CompareValueWithLimit(buttonTreatment, _maxHealth);
        CompareValueWithLimit(buttonDamage, _minHealth);
    }

    private void CompareValueWithLimit(Button button, float limitValue) 
    {
        button.interactable = true;
        float playerHealth = player.GetHealth();

        if(playerHealth == limitValue)
        {
            button.interactable = false;
        }
    }

    private IEnumerator SetSliderValue(int directionOfChange) 
    {
        float currentValue = slider.value;
        var waightForSomeSeconds = new WaitForSeconds(_timeForChange);

        for(float i = 0; i < _amountOfChangePerClick; i++) 
        {        
            slider.value += directionOfChange;

            yield return waightForSomeSeconds;
        }     
    }
}   


