
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{   
    public static Player Players;
    
    public Rigidbody RB;
    public float Speed = 5;
    public float health = 100;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        controller();
        //die();
    }

    void controller()
    {
                //You've seen this movement code before
        Vector3 vel = Vector3.zero;
        if (Keyboard.current.dKey.isPressed)
            vel.x = Speed;
        else if (Keyboard.current.aKey.isPressed)
            vel.x = -Speed;
        if (Keyboard.current.wKey.isPressed)
            vel.z = Speed;
        else if (Keyboard.current.sKey.isPressed)
            vel.z = -Speed;
        RB.linearVelocity = vel;
        
        //If I click, shoot!
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Okay, but where am I aiming? Let's find out where the mouse cursor is
            Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //This little bit of math calculates what direction the bullet should
            //  aim to be facing at the mouse cursor. Don't sweat the details
            float angle = Mathf.Atan2(pos.y-transform.position.y, pos.x-transform.position.x) * Mathf.Rad2Deg;
           
        }
    }

    // void die()
    // {
    //     if (health > 0)
    //         Destroy(gameObject);
    // }
}

