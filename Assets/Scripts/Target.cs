using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float healt = 50f;
    public GameObject player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void TakeDamage(float am)
    {
        healt -= am;

        if(healt <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        player.GetComponent<Inventory>().puntuacion += 5;
        Destroy(gameObject);
    }

}
