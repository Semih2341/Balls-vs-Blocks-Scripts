using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminKaydırıcı2 : MonoBehaviour
{    Transform oyuncu;

    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("2.İlerleme").transform;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            oyuncu.position = oyuncu.position + new Vector3(0, 0, 400);
            FindObjectOfType<colorSelector2>().RenkDegis();

        }
    }
}
