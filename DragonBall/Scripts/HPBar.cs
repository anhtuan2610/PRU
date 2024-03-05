using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{
    public Image _hpBar;

    public void UpdateHPBar(float currentHp, float maxHp)
    {
        _hpBar.fillAmount = currentHp/maxHp;
    }
}
