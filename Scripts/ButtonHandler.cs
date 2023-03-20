using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Bid(string data);

    [DllImport("__Internal")]
    private static extern void Withdraw(int id);

    [DllImport("__Internal")]
    private static extern void Resale(int id);

    public GameObject inputForm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onBidOrWithdraw() {
        var name = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        if (name == "Bid") {
            inputForm.SetActive(true);
        } else if (name == "Collect") {
#if !UNITY_EDITOR
            Withdraw(MetaState.token_id);
#endif
        }
        else
        {
#if !UNITY_EDITOR
            Resale(MetaState.token_id);
#endif
        }
    }

    public void onBid() {
        var data = MetaState.token_id + "," + MetaState.bid;
#if !UNITY_EDITOR
        Bid(data);
#endif
    }
}
