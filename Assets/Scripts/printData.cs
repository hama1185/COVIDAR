using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printData : MonoBehaviour
{
    public GameObject uiMethod;
    GetWeb getWeb;
    // Start is called before the first frame update
    void Start(){
        getWeb = uiMethod.GetComponent<GetWeb>();
    }

    // Update is called once per frame
    public void onClick(){
        Debug.Log(getWeb.data.area[0].name);
    }
}
