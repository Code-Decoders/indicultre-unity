using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;

public class PanelController : MonoBehaviour
{
    public GameObject details;

    public string language = "english";

    public bool panelOpen = false;

    public double timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        ChangeLanguage(language);
    }

    void OnEnable()
    {
        // Enable the update loop when the object becomes active
        Update();
        var token_id = gameObject.GetComponentInParent<ArtController>().token_id;
        MetaState.token_id = token_id;
    }

    private void OnDisable() {
    }


    private void Update()
    {
        if (timer > 0f)
        {
            timer = timer - Time.deltaTime;
        }
        if (panelOpen && timer <= 0f)
        {
            print("Token ID is");
            var token_id = gameObject.GetComponentInParent<ArtController>().token_id;
            print(token_id);
            GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().GetNFT(token_id.ToString());
            timer = 10f;
        }
        if (gameObject.active)
        {
            panelOpen = true;
        }
        if (Input.GetKeyDown(KeyCode.B) && gameObject.active)
        {
            Debug.Log("Popup");
            panelOpen = true;
            Debug.Log("Opening the Panel " + panelOpen);
            details.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.L) && gameObject.active)
        {
            if (language == "english")
                ChangeLanguage("gujarati");
            else
                ChangeLanguage("english");
        }
    }

    public void ChangeLanguage(string _language)
    {
        var token_id = gameObject.GetComponentInParent<ArtController>().token_id;
        var title = gameObject.transform.GetChild(0);
        var description = gameObject.transform.GetChild(1);
        var button = gameObject.transform.GetChild(2).GetChild(0);

        var data = MetaState.nfts.nfts[token_id];
        if (_language == "english")
        {
            title.GetComponent<TextMeshPro>().text = data.english.title;
            description.GetComponent<TextMeshPro>().text = data.english.description;
        }
        else
        {
            title.GetComponent<TextMeshPro>().text = data.gujarati.title;
            description.GetComponent<TextMeshPro>().text = data.gujarati.description;
        }
        button.GetComponent<TextMeshPro>().text = data.bidText;
        language = _language;
    }

    /*IEnumerator gettingData(string tokenId)
    {

        GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().GetNFT(tokenId);
        Debug.Log("Starting Getting the Data");
        while(true)
        {
            Debug.Log("Reload of Data");
            yield return new WaitForSeconds(10);
            GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().GetNFT(tokenId);
        } x
    }*/
    
}
