using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] InputAction lompat;
    [SerializeField] float KekuatanLompat = 10.0f;
    [SerializeField] float speed = 3.0f;


    bool isGrounded = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lompat.Enable();
        
    }

    // Update is called once per frame

    void Update()
    {
        // Auto run ke kanan
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        // Lompat
        if (lompat.WasPressedThisFrame()&& isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, KekuatanLompat);
            Debug.Log("berhasil lompat");
            isGrounded = false;
            speed = +4;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Mati");
            SceneManager.LoadScene("LoseScene");
        }

        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Nyentuh tanah");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Keluar dari tanah");
        }
    }
}
