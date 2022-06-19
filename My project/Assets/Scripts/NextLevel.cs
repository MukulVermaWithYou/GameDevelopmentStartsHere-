using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.layer == 7 )
        {
            Invoke( "CompleteGame", 2f );
        }
    }

    private void CompleteGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
    }
}

