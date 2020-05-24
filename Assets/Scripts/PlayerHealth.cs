using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 0;
    public int maxHealth = 100;
    public float hbLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hbLength = Screen.with / 2;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeHealth(0);
    }

    void GUI()
    {
        GUI.Box(new Rect(10, 10, hbLength, 30), currentHealth + " / " + maxHealth);
    }

    public void ChangeHealth (int heealth)
    {
        hbLength = (Screen.width / 2) * (currentHealth / (float)maxHealth);
    }
}
