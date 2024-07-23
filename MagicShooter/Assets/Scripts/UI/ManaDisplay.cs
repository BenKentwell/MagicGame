using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaDisplay : MonoBehaviour
{
    private TMP_Text display;

    private void Start()
    {
        display = GetComponent<TMP_Text>();
    }

    public void UpdateManaCounter(int _currentMana)
    {
        display.text = "Mana: " + _currentMana;
    }
}
