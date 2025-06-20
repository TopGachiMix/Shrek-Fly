using UnityEngine;
using UnityEngine.SceneManagement;

public class Scener : MonoBehaviour
{
    public void ChangeScen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
