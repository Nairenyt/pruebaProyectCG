using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminata : MonoBehaviour
{   
    private Animator anim;
    private Rigidbody rb;
    private float visionRadio;
    private float speed;
    public GameObject Cube;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
       
        speed = 5;
        visionRadio = 30;
        rb = gameObject.GetComponent<Rigidbody>();
        Cube = GameObject.FindGameObjectWithTag("Player");
        this.transform.LookAt(Cube.transform);
        initialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = initialPosition;
        this.transform.LookAt(Cube.transform);
        float dist = Vector3.Distance(Cube.transform.position, transform.position);
        if (dist < visionRadio)
        {
            target = Cube.transform.position;
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);


        }
    }

    
}
