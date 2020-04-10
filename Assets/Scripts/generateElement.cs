using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//prefabの直方体をサイズ指定して生成
public class generateElement : MonoBehaviour
{
    public GameObject WebManager;
    public GameObject element;//prefabから指定
    GetWeb getWeb;
    // Start is called before the first frame update
    void Start() {
        getWeb = WebManager.GetComponent<GetWeb>();
    }
    public void onClick(){
        // var sizeElement = Instantiate(element,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity);
        var sizeElement = Instantiate(element, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
        sizeElement.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f * getWeb.data.area[0].npatients, 0.1f);
    }
}
