using System.Collections;
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
    [SerializeField] GameObject dancer;
    [SerializeField] GameObject moodLight;
    [SerializeField] float lightHoldTime = 0.5f;   // stays on the note's color
    [SerializeField] float fadeDuration = 1f;      // time to blend back to white
    [SerializeField] float torque = 5f;
    float spinTimer = 0f;

    Coroutine resetRoutine;
    Light light;
    // Rigidbody rb;

    public void Awake() {
        light = moodLight.GetComponent<Light>();
        // rb = dancer.GetComponent<Rigidbody>();
    }

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

    public void OnPlayG(InputValue value)
    {
        PlayKey(keyG, 1.26f, Color.mediumAquamarine * 1.25f);
    }

    public void OnPlayH(InputValue value)
    {
        PlayKey(keyH, 1.41f, Color.dodgerBlue);
    }

    public void OnPlayJ(InputValue value)
    {
        PlayKey(keyJ, 1.58f, Color.blueViolet);
    }
    public void OnPlayK(InputValue value)
    {
        PlayKey(keyK, 1.67f, Color.magenta);
    }

    void PlayKey(GameObject key, float pitch, Color color)
    {
        Debug.Log("Playing Key: " + key.name + " pitch: " + pitch);

        // rb.AddRelativeTorque(new Vector3(0f, torque, 0f));
        addTimer(1f);

        Animator animator = key.GetComponent<Animator>();
        animator.Play("KeyPressed");

        AudioSource note = key.GetComponent<AudioSource>();
        note.clip = noteClip;
        note.pitch = pitch;  
        note.Play();

        light.color = color;

        if (resetRoutine != null) StopCoroutine(resetRoutine);
        resetRoutine = StartCoroutine(FadeToWhite());
    }

    public void addTimer(float t)
    {
        spinTimer += t;
    }

    IEnumerator FadeToWhite()
    {
        yield return new WaitForSeconds(lightHoldTime);

        Color start = light.color;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            light.color = Color.Lerp(start, Color.white, t / fadeDuration);
            yield return null;
        }

        light.color = Color.white;
        resetRoutine = null;
    }

    protected void Update()
    {
        if (spinTimer > 0f)
        {
            dancer.transform.Rotate(Vector3.up * spinTimer * torque);
            spinTimer -= Time.deltaTime;
        } else if (spinTimer < 0f)
        {
            spinTimer = 0f;
        }
    }
}
