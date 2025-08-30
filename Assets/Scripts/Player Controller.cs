using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] InputAction lompat;
    [SerializeField] float KekuatanLompat = 5.0f;
    [SerializeField] float speedNormal = 2.0f;
    [SerializeField] private AudioClip[] sfxClips; // Put your 2 (or more) clips here
    private AudioSource audioSource;
    private float SpeedUdara = 1.0f;
    private float speed;
    bool isGrounded = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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
            speed = speedNormal+ SpeedUdara;
            PlayRandomSFX();
            
        }


    }

    void PlayRandomSFX()
    {
        if (sfxClips.Length == 0) return;
        int randomIndex = Random.Range(0, sfxClips.Length);
        audioSource.PlayOneShot(sfxClips[randomIndex]);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Mati");
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }

        if (other.gameObject.CompareTag("Win"))
        {
            Debug.Log("Menang");
            SceneManager.LoadScene("Win");
        }

        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Nyentuh tanah");
            speed = speedNormal;
            animator.SetBool("IsJumping", !isGrounded);
         
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Keluar dari tanah");
            animator.SetBool("IsJumping", !isGrounded);
        }
    }
}
