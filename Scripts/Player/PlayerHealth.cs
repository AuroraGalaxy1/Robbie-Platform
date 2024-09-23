using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject deathVFXPrefab;
    public GameObject deathVFXPose;
    int trapsLayer;


    void Start()
    {
        trapsLayer = LayerMask.NameToLayer("Traps");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == trapsLayer)
        {
            Instantiate(deathVFXPrefab, transform.position, transform.rotation);
            Instantiate(deathVFXPose, transform.position, Quaternion.Euler(0, 0, Random.Range(-45, 90)));
            gameObject.SetActive(false);

            AudioManager.PlayDeathAudio();
            Invoke("Died", 1.5f);
        }
    }
    void Died()
    {
        GameManager.PlayerDied();
    }
}
