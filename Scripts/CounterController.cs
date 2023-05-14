using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class CounterController : MonoBehaviour {

    public GameObject bidder, amount, button;


    private TextMeshProUGUI text;

    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
        
    }

    public void ChangeTime(string time, int id) {

        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        epochStart = epochStart.ToLocalTime();
        Int64 cur_time = (Int64)((System.DateTime.Now - epochStart).TotalSeconds * 1000);
        var distance = Int64.Parse(MetaState.nft.end_timestamp) - cur_time;
        var rawDays = distance / (1000 * 60 * 60 * 24);
        var days = Math.Floor((double)rawDays);
        var rawhours = (distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60);
        var hours = Math.Floor((double)rawhours);
        var rawMinutes = (distance % (1000 * 60 * 60)) / (1000 * 60);
        var minutes = Math.Floor((double)rawMinutes);
        var rawSeconds = (distance % (1000 * 60)) / 1000;
        var seconds = Math.Floor((double)rawSeconds);
        if (distance < 0)
        {
            OnCompleted();
        }
        else
        {
            SetTimer(days + "d " + hours + "h " + minutes + "m " + seconds + "s ");
        }
        /*#if !UNITY_EDITOR
                StartCountDown(time + "," + id);
        #endif*/
    }

    public void SetTimer(string value) {
        text.text = "Time Remaining: " + value;
        amount.GetComponent<TextMeshProUGUI>().text = "Min Bid: " + MetaState.nft.min_bid + "BNB";
        bidder.GetComponent<TextMeshProUGUI>().text = "Highest Bidder: " + MetaState.nft.highest_bidder;
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        epochStart = epochStart.ToLocalTime();
        Int64 cur_time = (Int64)((System.DateTime.Now - epochStart).TotalSeconds * 1000);
        var user = GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().getUser();
        if (Int64.Parse(MetaState.nft.end_timestamp) > cur_time && MetaState.nft.owner == user)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Resale";
            button.GetComponent<Button>().interactable = false;
        }
        else
        {

            button.GetComponentInChildren<TextMeshProUGUI>().text = "Bid";
        }
    }

    public void OnCompleted() {
        SetTimer("Completed");
        var user = GameObject.FindObjectOfType<MetaMask.Unity.Samples.MetaMaskDemo>().getUser().ToLower();
        Debug.Log("User" + user);
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        Int64 cur_time = (Int64)((System.DateTime.Now - epochStart).TotalSeconds * 1000);
        if (Int64.Parse(MetaState.nft.end_timestamp) < cur_time && MetaState.nft.highest_bidder == user && MetaState.nft.owner != user)
        { 
            bidder.GetComponent<TextMeshProUGUI>().text = "Highest Bidder: " + MetaState.nft.highest_bidder;
        }
        else
        {
            bidder.GetComponent<TextMeshProUGUI>().text = "Owner: " + MetaState.nft.owner;
        }
        amount.GetComponent<TextMeshProUGUI>().text = "Sold at: " + MetaState.nft.min_bid + "BNB";
        if (Int64.Parse(MetaState.nft.end_timestamp) < cur_time && MetaState.nft.owner == user && MetaState.nft.highest_bidder == user)
        {
            
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Resale";
            
        }
        else
        {
            print("Collect");
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Collect";
        }
        Debug.Log(MetaState.nft.owner);
        Debug.Log(MetaState.nft.highest_bidder);
        Debug.Log(user);
        Debug.Log(MetaState.nft.owner != user);
        if (MetaState.nft.owner != user && MetaState.nft.highest_bidder != user) {
            button.SetActive(false);
        }

    }
}