using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private Pin pin_class;
    private Rigidbody2D rb;
    public GameObject bubble_dead;
    public Inputs inputs_class;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;

    void Start()
    {
        rb = pin_class.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            if (pin_class.lives != 0) pin_class.lives--;
            if(pin_class.lives == 3)
            {
                live1.SetActive(true);
                live2.SetActive(true);
                live3.SetActive(true);
            }
            if(pin_class.lives == 2)
            {
                live1.SetActive(true);
                live2.SetActive(true);
                live3.SetActive(false);
            }
            if(pin_class.lives == 1)
            {
                live1.SetActive(true);
                live2.SetActive(false);
                live3.SetActive(false);
            }
            if (pin_class.lives == 0)
            {
                live1.SetActive(false);
                live2.SetActive(false);
                live3.SetActive(false);
                rb.isKinematic = true;
                rb.simulated = false;
                inputs_class.gameOver = true;
                pin_class.transform.parent = collision.transform;
            }
        }

        if (collision.gameObject.CompareTag("Bubble"))
        {
            Destroy(collision.gameObject);
            Instantiate(bubble_dead, collision.gameObject.transform.position, collision.gameObject.transform.rotation); ;
        }

        if (collision.gameObject.name == "final")
        {
            inputs_class.gameOver = true;
        }
    }
}
