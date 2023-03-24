using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class DetailController : MonoBehaviour
{
    public GameObject loading;

    public GameObject timer, amount, owner, bid;

    private StarterAssets.StarterAssetsInputs playerInputs;

    // Start is called before the first frame update
    void Start()
    {
    }


    private void OnDisable()
    {
        playerInputs = GameObject.FindObjectOfType<StarterAssets.StarterAssetsInputs>();
        Debug.Log("Popup Disable");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerInputs.cursorLocked = true;
        playerInputs.cursorInputForLook = true;
        playerInputs.SetCursorState(true);
        var player = GameObject.FindObjectOfType<StarterAssets.ThirdPersonController>();
        player.stopMovement = false;
        player.LockCameraPosition = false;
        MetaState.nft = null;

    }

    private void OnEnable()
    {
        playerInputs = GameObject.FindObjectOfType<StarterAssets.StarterAssetsInputs>();
        Debug.Log("Popup Opened");

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerInputs.cursorLocked = false;
        playerInputs.cursorInputForLook = false;
        playerInputs.SetCursorState(false);
        var player = GameObject.FindObjectOfType<StarterAssets.ThirdPersonController>();
        player.stopMovement = true;
        player.LockCameraPosition = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (MetaState.nft == null)
        {
            loading.SetActive(true);
            timer.SetActive(false);
            amount.SetActive(false);
            owner.SetActive(false);
            bid.SetActive(false);
        }
        else
        {
            loading.SetActive(false);
            timer.SetActive(true);
            amount.SetActive(true);
            owner.SetActive(true);
            bid.SetActive(true);
            print(GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().getUser());
            timer.GetComponent<CounterController>().ChangeTime(MetaState.nft.end_timestamp, MetaState.nft.id);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.SetActive(false);
        }
    }

    
}
