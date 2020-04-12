using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resizeData : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WebManager;
    GetWeb getWeb;
    // Start is called before the first frame update
    void Start() {
        getWeb = WebManager.GetComponent<GetWeb>();
    }
    public void onClick(){
        for(int i = 0;i < transform.childCount; i++){
            if(transform.GetChild(i).name == getWeb.data.area[i].name){
                var prefecture = transform.GetChild(i).GetComponent<Transform>();
                prefecture.localScale = new Vector3(0.1f, 0.1f * getWeb.data.area[i].npatients, 0.1f);
                prefecture.position = new Vector3(i * 0.1f, 0.05f * getWeb.data.area[i].npatients, 0.0f);
            }
            else{
                Debug.Log("getWeb" + getWeb.data.area[i].name);
                Debug.Log("object" + transform.GetChild(i).name);
            }
        }
    }
}
