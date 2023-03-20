using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;

public class PanelController : MonoBehaviour
{
    public GameObject details;

    public string language = "english";

    [DllImport("__Internal")]
    private static extern void GetData(int token_id);

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
        MetaState.token_id = 0;
    }


    private void Update()
    {
        Debug.Log("Panel Update");
        if (Input.GetKeyDown(KeyCode.B) && gameObject.active)
        {
            Debug.Log("Popup");
            var token_id = gameObject.GetComponentInParent<ArtController>().token_id;
#if !UNITY_EDITOR && UNITY_WEBGL
            GetData(token_id);
#endif
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


    
}
