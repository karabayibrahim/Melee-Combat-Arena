using DitzeGames.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Joystick JoystickAttack;
    
    public GameObject player;
    public GameObject Alan;
    public float Ver;
    public float Hor;
    public float rotSpeed;
    
    bool Baslangıc = false;
  public  bool Kontrol = false;
    float Bekleme = 0.8f;
    
    Vector3 Vec;
    void Start()
    {
        
        
        Kontrol = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ver = JoystickAttack.AxisNormalized.x;
        Hor = JoystickAttack.AxisNormalized.y;
        Attack();
        OrbitAround();
        if (JoystickAttack.AxisNormalized.x == 0 && JoystickAttack.AxisNormalized.y== 0 && Baslangıc)
        {
            Alan.GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            FindObjectOfType<JoyPlayerMovement>().Anim.SetBool("Atak", false);
            Baslangıc = false;
        }
        if (JoystickAttack.InputVector.x == 0 && JoystickAttack.InputVector.y == 0 )
        {
            Alan.GetComponent<MeshRenderer>().enabled = false;
            
        }



    }
    

    void OrbitAround()
    {
        Vec = new Vector3(JoystickAttack.AxisNormalized.x*-1*90 ,0,JoystickAttack.AxisNormalized.y*-1*90);
        transform.LookAt(Vec);
        
        
        
    }
    void Attack()
    {
        if (JoystickAttack.AxisNormalized.x != 0 || JoystickAttack.AxisNormalized.y != 0)
        {
            Alan.GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            FindObjectOfType<JoyPlayerMovement>().Anim.SetBool("Atak", true);
            player.transform.LookAt(Vec);
            
            Baslangıc = true;
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
     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Düsman"))
        {
            
            if (Bekleme<=0)
            {
                FindObjectOfType<Can>().CanDeger -= 10;
                Bekleme = 0.8f;
            }
            Bekleme -= Time.deltaTime;

            Debug.Log("Değdi");
        }
        else
        {
            Kontrol = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Düsman"))
        {
            FindObjectOfType<Can>().CanDeger -= 10;
        }
    }



}
