using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSoundEffect;
    private bool levelComplete = false;
    // Start is called before the first frame update
    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.name == "Player" && !levelComplete) 
        {
            finishSoundEffect.Play();
            levelComplete = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}