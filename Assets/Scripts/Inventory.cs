using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public GameObject[] pst;
    int i = 1;
    int activeGun;
    public int puntuacion;
    public Text puntu;
    public GameObject pistolc;
    public GameObject escopec;
    public GameObject riflec;
    public GameObject subfc;
    public Text pistolt;
    public Text escopet;
    public Text riflet;
    public Text subft;
    public GameObject pistolta;
    public GameObject escopeta;
    public GameObject rifleta;
    public GameObject subfta;


    // Start is called before the first frame update
    void Start()
    {
        puntuacion = 0;
        Debug.Log(pst[0].transform.name);
        activeGun = 0;
    }

    // Update is called once per frame
    void Update()
    {
        puntu.text = puntuacion + "";

        if (Input.GetKey(KeyCode.Alpha1) && pst[0] != null)
        {
            foreach( GameObject g in pst)
            {
                if(g != null)
                    g.SetActive(false);
            }

            pst[0].SetActive(true);
            activeGun = 0;
        }

        if (Input.GetKey(KeyCode.Alpha2) && pst[1] != null)
        {
            foreach (GameObject g in pst)
            {
                if (g != null)
                    g.SetActive(false);
            }

            pst[1].SetActive(true);
            activeGun = 1;
        }

        if (Input.GetKey(KeyCode.Alpha3) && pst[2] != null)
        {
            foreach (GameObject g in pst)
            {
                if (g != null)
                    g.SetActive(false);
            }

            pst[2].SetActive(true);
            activeGun = 2;
        }

        if (Input.GetKey(KeyCode.Alpha4) && pst[3] != null)
        {
            foreach (GameObject g in pst)
            {
                if (g != null)
                    g.SetActive(false);
            }

            pst[3].SetActive(true);
            activeGun = 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gun")
        {
            if(i < pst.Length && other.gameObject.GetComponent<Gun>().trigg == true)
            {
                pst[i] = other.gameObject;
                pst[i].transform.position = pst[0].transform.position;
                pst[i].transform.rotation = pst[0].transform.rotation;
                pst[i].transform.SetParent(player.transform);
                pst[i].GetComponent<Gun>().active = true;
                pst[i].GetComponent<Gun>().trigg = false;
                pst[activeGun].SetActive(false);
                i++;
                activeGun = i;
                active(other.gameObject.transform.name, i);
            }
            else
            {

            }
        }
    }

    public void active(string name, int num)
    {
    
        if(name == "Fusil")
        {
            subfc.SetActive(true);
            subfta.SetActive(true);

            subft.text = num + "";
        }
        if(name == "SubFusil")
        {
            riflec.SetActive(true);
            rifleta.SetActive(true);
            riflet.text = num + "";
        }
        if (name == "Escopeta")
        {
            escopec.SetActive(true);
            escopeta.SetActive(true);
            escopet.text = num + "";
        }
    }
}
