using UnityEngine;
using UnityEngine.InputSystem;

public class Piano : MonoBehaviour
{
    [SerializeField] AudioClip noteClip;
    [SerializeField] GameObject keyA;
    [SerializeField] GameObject keyS;
    [SerializeField] GameObject keyD;
    [SerializeField] GameObject keyF;
    [SerializeField] GameObject keyG;
    [SerializeField] GameObject keyH;
    [SerializeField] GameObject keyJ;
    [SerializeField] GameObject keyK;

    // relative pitches:
    // 0.8f, 0.9f, 1.0f, 1.12f, 1.26f, 1.41f, 1.58f, 1.67f

    public void OnPlayA(InputValue value)
    {
        PlayKey(keyA, 0.8f, Color.red);    
    }

    public void OnPlayS(InputValue value)
    {
        PlayKey(keyS, 0.9f, Color.orange);    
    }

    public void OnPlayD(InputValue value)
    {
        PlayKey(keyD, 1.0f, Color.yellow);    
    }

    public void OnPlayF(InputValue value)
    {
        PlayKey(keyF, 1.12f, Color.green);    
    }

    // TODO: Implement keys G, H, J, K

    void PlayKey(GameObject key, float pitch, Color color)
    {
        Debug.Log("Playing Key: " + key.name + " pitch: " + pitch);

        Animator animator = key.GetComponent<Animator>();
        animator.Play("KeyPressed");
        
        // TODO: Get the AudioSource component and play noteClip
        // Set the pitch for each source based on the value passed to this method

        // TODO: A-Rank make a refernece to the scene light
        // Set the color of the scene light based on the value passed to this method
    }
}
