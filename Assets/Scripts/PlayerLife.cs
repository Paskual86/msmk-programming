using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D _rbPlayer;
    private Animator _animator;

    [SerializeField] private AudioSource dieSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rbPlayer = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Trap"))  
        {
            DieAction();
        }
    }

    private void DieAction() 
    {
        _rbPlayer.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger("death");
        dieSoundEffect.Play();
    }

    public void RestartLevel() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
