using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 0.75f;
    [SerializeField] AudioClip crashedcookieNoise;
    [SerializeField] AudioClip successfulcookieNoise;
    [SerializeField] AudioClip munchingcookieNoise;
    [SerializeField] ParticleSystem successCookies;
    [SerializeField] ParticleSystem crashCookies;
    AudioSource audioSource;
    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Fuel":
                //audioSource.PlayOneShot(munchingcookieNoise);
                Debug.Log("CookieCoo has obtained a cookie");
                break;
            case "Friendly":
                Debug.Log("CookieCoo is touching a friendly object");
                break;
            case "Finish":
                SucessSequence();
                Debug.Log("The CookieCoo game is done! Thanks for playing");
                break;
            default:
                CrashSequence();
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

    void CrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashedcookieNoise);
        crashCookies.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",delay);
    }

    void SucessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successfulcookieNoise);
        successCookies.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",delay);
    }
}
