using UnityEngine;
using UnityEngine.UI;

public class gyro : MonoBehaviour
{
    public Slider hassasiyet;
    float Score;
    private Touch touch;
    public Text puantext;
    private float speedModifier;
    public float currentSpeed = 0f;
    public float maxSpeed = 10f;
    public bool touchControl;
    float minSpeed;
    public bool durdur=false;
    public GameObject pausemenu;
    public float time = 0f;
    float accelerationTime = 60;
    public float xcalibrate = 90f;
    public GameObject CalButton;
    public float sens;
    public GameObject resumeButton;
    Vector3 tilt = Vector3.zero;
    Vector3 hedef = new Vector3(0, 0, 1);
    public bool isFlat = true;
    public int speed = 1;
    Rigidbody rb;
    public static bool Menüde;
    // Start is called before the first frame update
    void Start()
    {
        hassasiyet.value = PlayerPrefs.GetFloat("hassasiyet");
        rb = GetComponent<Rigidbody>();
        minSpeed = currentSpeed;
        speedModifier = 0.02f;

    }

    // Update is called once per frame
    void Update()
    {   
        if (transform.position.y < -1)
        {
            FindObjectOfType<gameManager>().bitisegidis();
            Destroy(gameObject);
        }
            
        if (Menüde == false)
        {
            Debug.Log("1.if");

            if (durdur == false)
            {
                Debug.Log("2.if");
                if (PlayerPrefs.GetString("Dokunmak") == "evet")
                    
                {
                    Debug.Log("3.if");
                    puanSayacý();
                    currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + hedef, currentSpeed * Time.deltaTime);
                    if (Input.touchCount > 0)
                    {
                        touch = Input.GetTouch(0);

                        if (touch.phase == TouchPhase.Moved)
                        {

                            transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier,
                            transform.position.y,
                            transform.position.z);


                        }
                    }
                }
                else
                {
                    currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + hedef, currentSpeed * Time.deltaTime);
                    //rb.AddForce(0, 0,0.5f);

                    tilt.x = Input.acceleration.x;
                    tilt = Quaternion.Euler(90, 0, 0) * tilt;
                    rb.AddForce(tilt.x * sens, 0, 0);
                    Debug.Log(xcalibrate);
                    puanSayacý();

                }
            }
            else
            {
                Debug.Log("else düþüyor");
            }
        }
    }

    public void CarpmaTrue()
    {
        durdur = true;
    }
    public void CarpmaFalse()
    {
        durdur = false;
    }
    public void TopuPatlat()
    {
        FindObjectOfType<gameManager>().bitisegidis();
        Destroy(gameObject);

    }
    public void TouchControlTrue()
    {
        PlayerPrefs.SetString("Dokunmak", "evet");
    }
    public void TouchControlFalse()
    {
        PlayerPrefs.SetString("Dokunmak", "hayýr");
    }
    public void puanSayacý()
    {
        Score = transform.position.z + 97;
        puantext.text = Score.ToString("0");
        PlayerPrefs.SetFloat("YeniSkor",Score);
        if (PlayerPrefs.GetFloat("YeniSkor") > PlayerPrefs.GetFloat("EskiSkor", 0))
        {
            PlayerPrefs.SetFloat("EskiSkor",PlayerPrefs.GetFloat("YeniSkor"));
        }
    }
    public void Sensivity(float sens)
    {
        PlayerPrefs.SetFloat("hassasiyet",sens);
        speedModifier = PlayerPrefs.GetFloat("hassasiyet");
       
    }
}
