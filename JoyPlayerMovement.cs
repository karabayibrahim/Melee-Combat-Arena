using DitzeGames.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyPlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Değerler") ]
    public Joystick Joy;
    
    
    //public Button Button;
    public float rotSpeed;
    public float rotX;
    public float rotY;
    public float rotZ;
    public Animator Anim;
    public float Hiz;

    void Start()
    {        
        //Button = FindObjectOfType<Button>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    //void Update()
    //{




    //}
    void FixedUpdate()
    {
        Movement();
        Animasyon();
    }


    void Movement()
    {
        
        transform.position = new Vector3(transform.position.x + Joy.AxisNormalized.x * Time.fixedDeltaTime * Hiz * -1,0, transform.position.z + Joy.AxisNormalized.y * Time.fixedDeltaTime * Hiz * -1);


        Vector3 Vec=new Vector3(transform.position.x + Joy.InputVector.x * Time.fixedDeltaTime * 3f * -1, 0,

            transform.position.z + Joy.AxisNormalized.y* Time.fixedDeltaTime * 3f * -1);
        transform.LookAt(Vec);
        


    }
  public  void Animasyon()
    {
        Anim.SetBool("İdle", false);
        //Anim.SetFloat("vertical", Joystick.AxisNormalized.y * -1);
        //Anim.SetFloat("horizontal", Joystick.AxisNormalized.x);
        float Ver = Joy.InputVector.x;
        float Hor = Joy.InputVector.y;
        if (Ver==0&&Hor==0)
        {
            Anim.SetBool("İdle", true);
            Anim.SetBool("WalkBool", false);

        }
        if (Ver != 0 || Hor != 0)
        {
            Anim.SetBool("WalkBool", true);
        }
        

    }
    
}
