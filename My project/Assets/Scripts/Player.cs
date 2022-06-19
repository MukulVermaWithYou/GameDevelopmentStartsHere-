using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform groundCheckTransform = null;

    // Sound Effects
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource coinCollectSoundEffect; 
    [SerializeField] private AudioSource gemCollectSoundEffect; 

    bool jumpKeyWasPressed;
    float horizontalInput;
    
    
    public int coinsCollected = 0;
    public int gemsCollected = 0;


    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if( Input.GetKeyDown(KeyCode.Space) )
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }


    // Method FixedUpdate is called once every Physics Update 
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput * 1.2f, rigidbodyComponent.velocity.y, 0);
        
        // Checks with the imaginary Sphere and the position of Empty GameObject if colliding with Ground
        if( Physics.OverlapSphere( groundCheckTransform.position, 0.1f, playerMask ).Length == 0 )
        {
            return;
        }

        if ( jumpKeyWasPressed )
        {
            rigidbodyComponent.AddForce(Vector3.up * 6.5f, ForceMode.VelocityChange);
            jumpSoundEffect.Play();
            jumpKeyWasPressed = false;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.layer == 8 )
        {
            Destroy(other.gameObject);
            coinCollectSoundEffect.Play();
            coinsCollected++;
        }

        else if( other.gameObject.layer == 9 )
        {
            Destroy(other.gameObject);
            gemCollectSoundEffect.Play();
            gemsCollected++;
        }

    }

}
