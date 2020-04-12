using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManage : MonoBehaviour
{
    // Start is called before the first frame update
    public Text UpdateTime;
    public GameObject WebManager;
    GetWeb getWeb;
    void Start(){
        getWeb = WebManager.GetComponent<GetWeb>();
    }

    // Update is called once per frame
    void Update(){
        UpdateTime.text = "This data is for" + getWeb.data.lastUpdate;
    }
}
