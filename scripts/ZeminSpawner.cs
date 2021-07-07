using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminSpawner : MonoBehaviour
{
    Transform zemin1;
    // Start is called before the first frame update
    void Start()
    {
        zemin1 = GameObject.FindGameObjectWithTag("1.Ýlerleme").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            zemin1.position = zemin1.position + new Vector3(0, 0, 400);
            FindObjectOfType<colorSelector>().RenkDegis();
            FindObjectOfType<gameManager>().ArkaPlan();
        }
    }
}
