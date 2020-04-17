using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProg : MonoBehaviour
{
    public float maximum;
    public float minimum;
    public float current;
    public Image mask;
    public Image fill;
    // Start is called before the first frame update
    void Start()
    {
        maximum = FindObjectOfType<DefanceSystem>().DefanceTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        current = FindObjectOfType<DefanceSystem>().DefanceTime;

        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        fill.fillAmount = current/maximum;
        
    }
}
