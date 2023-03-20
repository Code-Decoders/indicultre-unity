using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BidController : MonoBehaviour
{
    public InputField input; 
   
    public void SetValue() {
        MetaState.bid = input.text;
    }
}
