﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
	public Text levelText;
	public Text nameText;
	public Slider hpSlider;

	public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		levelText.text = "Lvl " + unit.unitLevel;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;		
	}

	public void SetHP(int hp)
	{
		hpSlider.value = hp;
	}

}
