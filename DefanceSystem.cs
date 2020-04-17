using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;

public class DefanceSystem : MonoBehaviour
{
    public Joystick JoyDefence;
    public GameObject AtakJoy;
    public GameObject DefanceJoy;
    public GameObject Defance;
    public GameObject DefanceButton;
    public GameObject AtakHandle;
    public GameObject Player;
    public float DefanceTime = 5f;
    bool ZamanKontrol = false;

    Vector3 Vec2;
    void Start()
    {
        DefanceButton = GameObject.Find("DefanceButton");
        AtakJoy = GameObject.Find("JoyAtak");
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(DefanceTime);
        //Debug.Log(JoyDefence.AxisNormalized.x);
        Orbit();
        DefanceAktif();
        DefanceOrbit();
        Defanceİnaktif();
    }
    void DefanceAktif()
    {
        if (DefanceButton.GetComponent<Button>().Pressed)
        {
            ZamanKontrol = true;
            FindObjectOfType<AttackZone>().enabled = false;
            FindObjectOfType<JoyPlayerMovement>().Anim.SetBool("Defance", true);
            DefanceJoy.SetActive(true);
            AtakJoy.SetActive(false);
            Defance.SetActive(true);

            


        }
        

    }
    void DefanceOrbit()
    {
        if (JoyDefence.AxisNormalized.x != 0 || JoyDefence.AxisNormalized.y != 0)
        {
            Debug.Log("Çalışıyor");
            Player.transform.LookAt(Vec2);
        }

    }
    void Orbit()
    {
        Vec2 = new Vector3(JoyDefence.AxisNormalized.x * -1*90, 0, JoyDefence.AxisNormalized.y * -1*90);
        transform.LookAt(Vec2);

    }
    void Defanceİnaktif()
    {
        if (ZamanKontrol)
        {
            DefanceTime -=Time.deltaTime;
        }
        if (DefanceTime <= 0)
        {
            FindObjectOfType<AttackZone>().enabled = true;
            FindObjectOfType<JoyPlayerMovement>().Anim.SetBool("Defance", false);
            DefanceJoy.SetActive(false);
            AtakJoy.SetActive(true);
            Defance.SetActive(false);
            DefanceTime = 5f;
            ZamanKontrol = false;
        }
    }
   
}
