using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MPBar : MonoBehaviour
{
    public Image _mpBar;

    public void UpdateMPBar(float currentMp, float maxMp)
    {
        _mpBar.fillAmount = currentMp / maxMp;
    }
}
