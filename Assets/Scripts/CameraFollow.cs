using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform player;  // drag player ke sini di inspector
    [SerializeField] float fixedY = 19.2f; // posisi Y yang mau dikunci
    [SerializeField] float Xposition =  6.8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is create

    private void Start()
    {
        Vector3 newPos = player.position;
        newPos.x = Xposition;
        transform.position = newPos;

    }
    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPos = player.position;
            newPos.y = fixedY; // Y selalu tetap
            newPos.z = -10f;   // biasanya kamera di -10 agar terlihat

            transform.position = newPos;
        }
    }
}
