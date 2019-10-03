using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSettings : MonoBehaviour
{
    [SerializeField] private float thrustJump;

    public bool isDie;
    public bool isWin;

    private Rigidbody rb;
    private GameObject thisSection;
    public GameObject ThisSection
    {
        get
        {
            return thisSection;
        }
    }

    private ButtonController buttonController;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisSection = GameObject.FindGameObjectWithTag("StartSection");
        buttonController = FindObjectOfType<ButtonController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "DefaultPlatform")
        {
            rb.AddForce(transform.up * thrustJump);
        }

        if (collision.collider.tag == "EnemyPlatform")
        {
            isDie = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            buttonController.UIShow();
        }

        if (collision.collider.tag == "FinishSection")
        {
            isWin = true;
            buttonController.UIShow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EnterTrigger")
        {
            thisSection = other.gameObject.transform.parent.gameObject;        
        }
    }
}
