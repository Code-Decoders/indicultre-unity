// using UnityEngine.InputSystem;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;



    private void Start()
    {
        print(GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().getUser());
        //var arts = GameObject.FindObjectsOfType<ArtController>();
        //string data = "sep=@\nToken Id, Name, Description\n";
        //for (int i = 0; i < arts.Length; i++)
        //{
        //    var token_id = arts[i].token_id;
        //    var title = arts[i].transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text;
        //    var description = arts[i].transform.GetChild(1).GetChild(1).GetComponent<TextMeshPro>().text;
        //    data += (token_id + "@" + title + "@" + description + "\n");
        //}
        //Debug.Log(data);
        /*Debug.Log(MetaState.nfts.nfts[1].ToString());
#if !UNITY_EDITOR
        GetUser();
#endif*/
    }

    private void Update()
    {
        
    }


    // Update is called once per frame

    public void SetNft(string data)
    {
        print(data);
        NFTData nft = JsonUtility.FromJson<NFTData>(data);
        print(nft.toString());
        MetaState.nft = nft;
    }

    public void SetUser(string user) {
        print(user);
        MetaState.user = user;
        print(MetaState.user);
    }

    
}