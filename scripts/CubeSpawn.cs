using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    int konum;
    public int x, delaytime;
    public GameObject coin;
    Transform oyuncu;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("player").transform;
        Delay1();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {

    }
    void Delay1()
    {
            Vector3 spanwpoint = new Vector3(2.201026f, -1.53429f, oyuncu.position.z + 55);
            Instantiate(coin, spanwpoint, Quaternion.identity);
        Invoke("Delay2", delaytime);
    }
    void Delay2()
    {
        Vector3 spanwpoint = new Vector3(2.201026f, -1.53429f, oyuncu.position.z + 55);
        Instantiate(coin, spanwpoint, Quaternion.identity);
        Invoke("Delay1", delaytime);
    }
}
