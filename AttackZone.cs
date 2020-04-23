using DitzeGames.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackZone : MonoBehaviour
{
    
    
    public Joystick JoystickAttack;
    
    public GameObject player;
    public GameObject Alan;
    
    public bool SavunmaAlan = false;
    bool Baslangıc = false;
    public bool AtakYaptıMı = false;
  public  bool Kontrol = false;
  public  float Bekleme = 0.89f;
    public float BeklemeDamage = 0.88f;
    public GameObject DefanceButton;


    Vector3 Vec;
    void Start()
    {
        

        Kontrol = false;
    }

    
    void Update()
    {

        
        
        Attack();
        OrbitAround();
        SavunmaKontrol();

        

        if (JoystickAttack.InputVector.x == 0 && JoystickAttack.InputVector.y == 0)
        {
            Alan.GetComponent<RawImage>().enabled = false;
            


        }



    }
    

    void OrbitAround()
    {
        Vec = new Vector3(JoystickAttack.AxisNormalized.x*-1*90 ,0,JoystickAttack.AxisNormalized.y*-1*90);
        
        if (Vec.x!=0||Vec.y!=0)
        {
            player.transform.LookAt(Vec);
        }
        



    }
    void SavunmaKontrol()
    {
        if (FindObjectOfType<DefanceDamage>() != null)
        {
            SavunmaAlan = FindObjectOfType<DefanceDamage>().SavunmaAlani;
        }
        else
        {
            SavunmaAlan = false;
        }
    }
    void Attack()
    {
        if ((JoystickAttack.AxisNormalized.x != 0 || JoystickAttack.AxisNormalized.y != 0 ) )
        {
            Alan.GetComponent<RawImage>().enabled = true;
            
            AtakYaptıMı = true;
            



            Baslangıc = true;
        }
        if (JoystickAttack.AxisNormalized.x == 0 && JoystickAttack.AxisNormalized.y == 0 && Baslangıc && AtakYaptıMı == true )
        {
            
            if (SavunmaAlan == false)
            {
                Alan.GetComponent<RawImage>().enabled = true;
                Alan.GetComponent<BoxCollider>().enabled = true;
                FindObjectOfType<JoyPlayerMovement>().Anim.SetBool("Atak", true);
                GameObject.Find("Canvas/Image/JoyAtak").GetComponent<Joystick>().enabled = false;
                DefanceButton.SetActive(false);
                Bekleme -= Time.deltaTime;
                



            }
            else if (SavunmaAlan == true)
            {
                
                Alan.GetComponent<RawImage>().enabled = true;
                Alan.GetComponent<BoxCollider>().enabled = true;
                FindObjectOfType<JoyPlayerMovement>().Anim.SetBool("BlockAtak", true);
                GameObject.Find("Canvas/Image/JoyAtak").GetComponent<Joystick>().enabled = false;//Joystigin işlevini kapatttım
                Bekleme -= Time.deltaTime;
            }
            if (Bekleme<=0)
            {
               
                AtakYaptıMı = false;
                Bekleme = 0.89f;
                Baslangıc = false;
                GameObject.Find("Canvas/Image/JoyAtak").GetComponent<Joystick>().enabled = true;
                DefanceButton.SetActive(true);
            }
            




            
        }
        if (AtakYaptıMı == false)
        {
            FindObjectOfType<JoyPlayerMovement>().Anim.SetBool("Atak", false);
            FindObjectOfType<JoyPlayerMovement>().Anim.SetBool("BlockAtak", false);
        }
        if (Baslangıc)
        {
            FindObjectOfType<JoyPlayerMovement>().Hiz = 2f;
        }
        else
        {
            FindObjectOfType<JoyPlayerMovement>().Hiz = 7f;
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Defance"))
        {
            GetComponent<BoxCollider>().enabled = false;

        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        if (other.gameObject.CompareTag("Düsman"))
        {
            if (BeklemeDamage <= 0)
            {
                FindObjectOfType<Can>().CanDeger -= 10;
                BeklemeDamage = 0.88f;
            }
            BeklemeDamage -= Time.deltaTime;

            
        }
    }




}
