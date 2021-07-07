using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
    int x;
    public TMP_Text BallScore;
    Transform oyuncu;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("player").transform;

        x = Random.Range(1, 10);
        BallScore.text = x.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(oyuncu.position, transform.position) >31)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {   
            FindObjectOfType<gameManager>().Puan(x);
            Destroy(gameObject);
        }
    }
}
