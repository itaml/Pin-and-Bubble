using UnityEngine;

public class End : MonoBehaviour
{
    public Pin pin_class;
    public Tap tap_class;
    public GameObject red;
    public GameObject blue;
    public GameObject green;
    private Rigidbody2D rb;

    void Start()
    {
        rb = pin_class.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            pin_class.flip = false;
            rb.isKinematic = true;
            rb.simulated = false;
            tap_class.gameOver = true;
            pin_class.transform.parent = collision.transform;
        }

        if (collision.gameObject.CompareTag("Red"))
        {
            Destroy(collision.gameObject);
            Instantiate(red,collision.gameObject.transform.position,collision.gameObject.transform.rotation);
        }
        if (collision.gameObject.CompareTag("Blue"))
        {
            Destroy(collision.gameObject);
            Instantiate(blue, collision.gameObject.transform.position, collision.gameObject.transform.rotation); ;
        }
        if (collision.gameObject.CompareTag("Green"))
        {
            Destroy(collision.gameObject);
            Instantiate(green, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
    }
}
