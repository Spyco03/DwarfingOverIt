using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    public Text counter;
    public int counterValue = 0;

    valueSaver _valueSaver;


    void Start()
    {
        _valueSaver = GameObject.Find("Reasorces").GetComponent<valueSaver>();
        
    }

    // Update is called once per frame
    void Update()
    {
        counterValue = _valueSaver.materials;
        counter.text = counterValue.ToString();
    }
}
