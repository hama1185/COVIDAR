using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateElement : MonoBehaviour
{
    public GameObject element;//prefabから指定
    // Start is called before the first frame update
    public void onClick(){
        Instantiate(element,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity);
    }
}
