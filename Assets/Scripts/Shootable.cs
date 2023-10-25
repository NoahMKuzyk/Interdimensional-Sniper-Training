using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

    //Health total of the object
    public int currentHealth;

    public int objColour;
    //1: Red
    //2: Green
    //3: Blue
    //4: Yellow

    public AudioSource brokenWood;
    public MeshRenderer render;
    public Light disabledLight;
    public BoxCollider collide;

    private void Start()
    {
        collide = GetComponent<BoxCollider>();
    }

    public void Damage(int damageAmount) {

        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Deactivate if the health is lower than 0
        if (currentHealth <= 0) {
            brokenWood.Play();
            render.enabled = false;
            if (disabledLight)
            {
                disabledLight.enabled = false;
            }
            if (collide)
            {
                collide.enabled = false;
            }
                Destroy(gameObject, 2);
        }

    }

}
