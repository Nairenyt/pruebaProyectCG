using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlGeneracion : MonoBehaviour
{

    private float rangoGeneracion;
    public GameObject prefabEnemigo;
    public int numeroEnemigos;
    public int numeroOleada;
    private float currentTime = 0;
    private float maxTime = 5;
    public Text Oleada;
    public int zombies;
    public GameObject generador;
    

    // Start is called before the first frame update
    void Start()
    {
        zombies = 1;
        numeroOleada = 1;
        Oleada.text = "" + numeroOleada;
        rangoGeneracion = 1f;
        
        GeneradorEnemigos(numeroOleada);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(currentTime.ToString());
        numeroEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (numeroEnemigos == 0)
        {
            //StartCoroutine(Esperar());

            currentTime += Time.deltaTime;

            if (currentTime >= maxTime)
            {
                zombies += 2;
                numeroOleada ++;
                Oleada.text = "" + numeroOleada;
                GeneradorEnemigos(zombies);

                currentTime = 0;
            }
           
        }
    }

    void GeneradorEnemigos(int EnemigosAGenerar)
    {
        for (int i = 0; i < EnemigosAGenerar; i++)
        {
            Instantiate(prefabEnemigo, DamePosicionGeneracion(), prefabEnemigo.transform.rotation);
        }
    }

    Vector3 DamePosicionGeneracion()
    {
        float GeneracionX = generador.transform.position.x;
        float GeneracionY = generador.transform.position.z;

        Vector3 posAleatoria = new Vector3(GeneracionX, 0, GeneracionY);
        return posAleatoria;
    }
    //IEnumerator Esperar()
    //{
    //    yield return new WaitForSeconds(2);
    //    Debug.Log("WE WAITbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
    //}
 
}
