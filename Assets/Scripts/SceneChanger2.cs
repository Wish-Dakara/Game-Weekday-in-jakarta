using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2 : MonoBehaviour
{
    public void LoadScene(string MainMenu)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
