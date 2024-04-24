using UnityEngine;
using UnityEngine.SceneManagement;

public class scenetransition : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "intro")
        {
            // Starting the game with 'SPACE'
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key pressed");
                SceneManager.LoadScene("main");
            }
        }

        if (SceneManager.GetActiveScene().name == "gameover")
        {
            // Restarting the game with 'SPACE'
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key pressed");
                SceneManager.LoadScene("intro");
            }
        }
    }
}