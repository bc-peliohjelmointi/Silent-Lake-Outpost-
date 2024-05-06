using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Bringup : MonoBehaviour // - Aleksi
{
    public GameObject setting;
    public bool issettingactive;
    private FirstPersonController firstPersonController;

    private Animator playerAnimator;
    private Headbob headBobbingScript;



    [SerializeField] GameObject flashLight;
    [SerializeField] GameObject binoculars;

    public bool isPaused = false;


    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();

        playerAnimator = GetComponent<Animator>();

        headBobbingScript = GetComponent<Headbob>();

    }

    void Update() // Esc to activate pausemenu
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (issettingactive == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void SetLookingEnabled(bool enabled)
    {
        firstPersonController.enabled = enabled;
    }

    public void Pause() //Pause menu active
    {
        setting.SetActive(true);
        issettingactive = true;
        SetLookingEnabled(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        flashLight.SetActive(false);
        binoculars.SetActive(false);
        isPaused = true;

        if (headBobbingScript != null)
            headBobbingScript.enabled = false;

        if (playerAnimator != null)
            playerAnimator.enabled = false;
    }

    public void Resume() //  Resume game
    {
        setting.SetActive(false);
        issettingactive = false;
        SetLookingEnabled(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;

        if (headBobbingScript != null)
            headBobbingScript.enabled = true;

        if (playerAnimator != null)
            playerAnimator.enabled = true;
    }
}
