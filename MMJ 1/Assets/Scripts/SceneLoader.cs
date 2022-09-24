using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class SceneLoader : MonoBehaviour
{
    //every portal has a "portalIndex"
    // when the nextPortalIndex of a portal you are entering is the portalIndex of another, the player entering that portal will be transfered to the "another" portal location
    [Header ("Portal Data")]
    public int portalIndex;
    public int nextPortalIndex;
    public Transform portalLocation;

    [Header ("Game Log Data")]
    public string sceneNameToLoad;
    public PlayerController_2 playerObject;
    public GameManagementLogs gameManagementLogs;
    public CinemachineVirtualCamera currentVCam;

    private void Awake()
    {
        gameManagementLogs = FindObjectOfType<GameManagementLogs>();
        if (portalIndex == gameManagementLogs.nextActivePortalIndex)
        {
            //playerObject = gameManagementLogs.InstantiateMeHere(portalLocation);
            if (gameManagementLogs.reviveMe == false)
            {
                gameManagementLogs.PutMeHere(portalLocation);
                gameManagementLogs.CreateVirtualCamera(portalLocation);
                currentVCam = FindObjectOfType<CinemachineVirtualCamera>();
            }
            Debug.Log("this happened");
        }
        else
        {
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player"))
        {
            gameManagementLogs.GetNextPortalIndex(nextPortalIndex);
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(portalLocation.position, 0.3f);
    }
}
