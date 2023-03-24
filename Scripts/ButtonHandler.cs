using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Numerics;
using Nethereum.Util;

public class ButtonHandler : MonoBehaviour
{
    
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
            GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().Collect(MetaState.token_id);
/*#if !UNITY_EDITOR
            Withdraw(MetaState.token_id);
#endif*/
        }
        else
        {
            GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().Resale(MetaState.token_id.ToString());
/*#if !UNITY_EDITOR
            Resale(MetaState.token_id);
#endif*/
        }
    }

    public void onBid() {
        GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().Bid(MetaState.token_id.ToString(), new BigDecimal(new Decimal(Double.Parse(MetaState.bid))));
/*#if !UNITY_EDITOR
        Bid(data);
#endif*/
    }
}
