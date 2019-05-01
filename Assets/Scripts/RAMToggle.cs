using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAMToggle : MonoBehaviour
{
    public GameObject ramObject;
    public GameObject cpuObject;
    public GameObject vgaObject;
    public Animator animator;
    public AudioClip audioClip;
    public AudioSource audioSource;
    
    void Start()
    {
        audioSource = GameObject.Find("RAM_Woman_KR").GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("RAMIdle"))
        {
            ramObject.SetActive(true);
            cpuObject.GetComponent<CPUToggle>().enabled = true;
            vgaObject.GetComponent<VGAToggle>().enabled = true;
            animator.SetBool("IsRunning", true);
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("RAMAnimation") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            ramObject.SetActive(true);
            cpuObject.GetComponent<CPUToggle>().enabled = true;
            vgaObject.GetComponent<VGAToggle>().enabled = true;
            animator.SetBool("IsRunning", true);
        }
    }

    private void OnMouseDown()
    {
        if(this.enabled)
        {
            ramObject.SetActive(false);
            cpuObject.GetComponent<CPUToggle>().enabled = false;
            vgaObject.GetComponent<VGAToggle>().enabled = false;
            animator.Play("RAMAnimation");
            audioSource.PlayOneShot(audioClip);
        }        
    }
}
