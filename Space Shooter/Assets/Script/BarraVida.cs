using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BarraVida : MonoBehaviour {

    public Scrollbar HealthBar;
	public float Health = 100;

	public void Damage(float value)
	{
		Health -= value;
		HealthBar.size = Health / 100f;
        
	}


}
