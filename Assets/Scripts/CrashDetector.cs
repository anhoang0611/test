using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D head;
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashDetector;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;
    private void Start()
    {
        head = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && head.IsTouching(collision.collider) && !hasCrashed)
        {   
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashDetector.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);

            Debug.Log("hit!");
            Invoke("ReloadScene", loadDelay);

            
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
