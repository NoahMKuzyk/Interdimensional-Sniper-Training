using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;



public class MainGunScript : MonoBehaviour {

    //Basic gun variables
    public int weaponDamage = 1;
    public int weaponFireRate = 100;
    public float weaponRange = 50f;
    public float weaponKnockback= 2000f;
    public Transform gunBarrel;
    public int weaponTimer = 150;

    //Public references for needed gameobjects
    public CinemachineVirtualCamera mainCam;
    public GameObject hitParticles;
    public UIManager eyeChanger;
    private Shootable health = null;

    //References for the player camera and assets needed for tracers
    private Camera FPScam;
    private WaitForSeconds shotDuration = new WaitForSeconds(3f);
    private LineRenderer laserLine;

    //Gun audio sources
    public AudioSource gunAudio;
    public AudioSource lensClick;
    public AudioSource plink;

    //Tracer information
    private float alphaValue;

    //Lens information
    private int lensColour;

    [SerializeField] private Animator animator = null;
    private bool lensChange = false;
 //   private bool isFiring = false;

    void Start() {
        //Declares tracer components and audio
        laserLine = GetComponent<LineRenderer>();
        FPScam = GetComponentInParent<Camera>();
    }

    void AnimateFiring()
    {
        animator.Play("Fire");
    }

    void Update()
    {

        animator.SetBool("LensChange", lensChange);
        if (lensChange == true) { lensChange = false; }

        //Raycasting variables
        Vector3 rayOrigin = FPScam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        //Increments timers for tracers+reload
        alphaValue -= 0.3f;
        weaponTimer++;


        //Gets scroll inputs and adjusts FOV accordingly
        if (Input.mouseScrollDelta.y > 0 && mainCam.m_Lens.FieldOfView > 10)
        {
            mainCam.m_Lens.FieldOfView -= 5;
        }
        else if (Input.mouseScrollDelta.y < 0 && mainCam.m_Lens.FieldOfView < 80)
        {
            mainCam.m_Lens.FieldOfView += 5;

        }

        //Gets input for Mouse 1
        if (Input.GetButtonDown("Fire1") && weaponTimer > weaponFireRate)
        {
            //Sets the initial position of the tracer. 
            laserLine.SetPosition(0, gunBarrel.position);

            //Resets relevant timers for tracers/reload
            weaponTimer = 0;
            alphaValue = 255;

            //Displays the tracer and plays required audio
            laserLine.enabled = true;
            gunAudio.Play();
            AnimateFiring();

            //Sets positions to draw the raycasts at depending on object colliders
            if (Physics.Raycast(rayOrigin, FPScam.transform.forward, out hit, weaponRange))
            {
                plink.Play();
                lensClick.PlayDelayed(1.6f);
                //Sets line position
                laserLine.SetPosition(1, hit.point);

                //Spawns particle object. Dies after 5 sec automatically
                Instantiate(hitParticles, hit.point, Quaternion.identity);

                AnimateFiring();

                //Code for hitting objects
               health = hit.collider.GetComponent<Shootable>();

                //Checks for lens colour
                if (health.objColour == lensColour)
                {
                    if (health != null)
                    {
                        health.Damage(weaponDamage);
                    }
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * weaponKnockback);
                    }
                }
                
            }
            else
            {
                laserLine.SetPosition(1, FPScam.transform.forward * weaponRange);
            }

        }

        //Changes lens colour based on keys
        if (Input.GetKeyDown("1") && weaponTimer > weaponFireRate) {
            //Red
            lensColour = 1;
            UIManager eye = eyeChanger;
            eye.ChangeToRed();
            lensClick.Play();
            animator.SetInteger("CurrentLens", 1);
            lensChange = true;
        }
        if (Input.GetKeyDown("2") && weaponTimer > weaponFireRate)
        {
            //Green
            lensColour = 2;
            UIManager eye = eyeChanger;
            eye.ChangeToGreen();
            lensClick.Play();
            animator.SetInteger("CurrentLens", 2);
            lensChange = true;
        }
        if (Input.GetKeyDown("3") && weaponTimer > weaponFireRate)
        {
            //Blue
            lensColour = 3;
            UIManager eye = eyeChanger;
            eye.ChangeToBlue();
            lensClick.Play();
            animator.SetInteger("CurrentLens", 3);
            lensChange = true;
        }
        if (Input.GetKeyDown("4") && weaponTimer > weaponFireRate)
        {
            //Yellow
            lensColour = 4;
            UIManager eye = eyeChanger;
            eye.ChangeToYellow();
            lensClick.Play();
            animator.SetInteger("CurrentLens", 4);
            lensChange = true;
        }


        //Sets the line to be transparent over time
        if (alphaValue >= 0f && alphaValue <= 255f)
        {
            Color transparentLineColour = new Color(0.8f, 0.8f, 0.8f, alphaValue / 255);
            laserLine.startColor = transparentLineColour;
            laserLine.endColor = transparentLineColour;
        }
        else
        {
            Color transparentLineColour = new Color(0.8f, 0.8f, 0.8f, 0.0f);
            this.GetComponent<LineRenderer>().startColor = transparentLineColour;
            this.GetComponent<LineRenderer>().endColor = transparentLineColour;
        }

        //Disables tracer after 1000 frames
        if (weaponTimer > 1000) { 
            laserLine.enabled = false;
        }
    }
}



