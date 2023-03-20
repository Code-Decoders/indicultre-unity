using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class ArtPieceController : MonoBehaviour
{
    public LayerMask mask;

    public GameObject hint;

    public TextMeshProUGUI min_bid;

    public GameObject timer;

    public GameObject player;

    public float height = 0.5f;

    private bool isCalled = false;

    

    // Start is called before the first frame update
    void Start()
    {
        print("called");
    }

    // Update is called once per frame
    void Update()
    {
        var vector = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        Ray ray = new(vector, Vector3.forward);
        if (!Physics.Raycast(ray, out _, 2f, mask))
        {
            var panels = GameObject.FindGameObjectsWithTag("Details");
            for (int i = 0; i < panels.Length; i++) 
            {
                panels[i].SetActive(false);
            }
            isCalled = false;

        }
        if (Physics.Raycast(vector, transform.forward, out var hit, 1f, mask) && !isCalled)
        {
            hit.collider.gameObject.transform.parent.parent.transform.GetChild(1).gameObject.SetActive(true);
            isCalled = true;
        }
    }

  


}
