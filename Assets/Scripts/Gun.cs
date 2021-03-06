﻿
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    Camera fpsCam;
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30F;
    public bool active = false;
    public bool trigg = true;
    public GameObject muzzlePrefab;
    public GameObject bala;
    GameObject reload;
    Text reloadTx;

    public int cargador;
    int ammo;


    private void Start()
    {

        fpsCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        ammo = cargador;
        reload = GameObject.FindWithTag("Reload");
        reloadTx = reload.GetComponent<Text>();
        reloadTx.text = "Bullets: " + ammo;
    }

    // Update is called once per frame
    void Update()
    {
        if(active == true)
        {
            reloadTx.text = "Bullets: " + ammo;
        }

        if (Input.GetMouseButtonDown(0) && active == true && ammo != 0)
        {
            if (muzzlePrefab != null)
            {

                var muzzleVFX = Instantiate(muzzlePrefab,bala.transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
                if (psMuzzle != null)
                {
                    Destroy(muzzleVFX, psMuzzle.main.duration);
                }
                else
                {
                    var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(muzzleVFX, psChild.main.duration);
                }
            }

            Debug.Log("Ince");
            shoot();
            ammo--;
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = cargador;
        }

        
    }

    void shoot()
    {
      
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            
        }
    }

}

