using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsClearance : MonoBehaviour
{
    public Canvas[] canveses;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(FindObjectOfType<PlayerController_2>());
        Destroy(FindObjectOfType<GameManagementLogs>());
        canveses = FindObjectsOfType<Canvas>();
        for (int i = 0; i < 2; i++)
        {
            if (canveses[i].CompareTag("Credits"))
            {
                Debug.Log("yay");
            }
            else
            {
                Destroy(canveses[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
