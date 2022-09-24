using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        Destroy(canvas);
        if (collision.CompareTag("Player"))
        {
            LoadEndScene();
        }
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("Credits");
    }


}
