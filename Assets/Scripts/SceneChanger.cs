using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string Gameplay)
    {
        Debug.Log(Gameplay);

        if (Gameplay == "Gameplay") 
        {
            SceneManager.LoadScene("Gameplay");
        }

        if (Gameplay == "Win")
        {
            SceneManager.LoadScene("Win");
        }

        if (Gameplay == "MainMenu")
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Gameplay == "Lose")
        {
            SceneManager.LoadScene("Lose");
        }
    }


}
