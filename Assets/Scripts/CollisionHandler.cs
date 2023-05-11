using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("CookieCoo has obtained a cookie");
                break;
            case "Friendly":
                Debug.Log("CookieCoo is touching a friendly object");
                break;
            case "Finish":
                LoadNextLevel();
                Debug.Log("The CookieCoo game is done! Thanks for playing");
                break;
            default:
                ReloadLevel();
                //Debug.Log("CookieCoo has blown up!");
                break;
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
