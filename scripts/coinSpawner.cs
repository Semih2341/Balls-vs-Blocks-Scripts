using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawner : MonoBehaviour
{
    int konum,a,b,c;
    public int x,delaytime;
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
    void Delay1()
    {

        a = Random.Range(-5, 6);
        if (a != -5 || a != 5)
        {
            b = Random.Range(-5, a);
            c = Random.Range(a + 1, 6);

        }
        if (a == -5)
        {
            b = Random.Range(a + 1, 0);
            c = Random.Range(0, -6);
        }
        if (a == 5)
        {
            b = Random.Range(-5, 0);
            c = Random.Range(0, a);
        }

        Vector3 spanwpoint1 = new Vector3(a, 1, oyuncu.position.z + 30);
        Vector3 spanwpoint2 = new Vector3(b, 1, oyuncu.position.z + 30);
        Vector3 spanwpoint3 = new Vector3(c, 1, oyuncu.position.z + 30);
        Instantiate(coin, spanwpoint1, Quaternion.identity);
        Instantiate(coin, spanwpoint2, Quaternion.identity);
        Instantiate(coin, spanwpoint3, Quaternion.identity);
        Invoke("Delay1", delaytime);
    }
}
