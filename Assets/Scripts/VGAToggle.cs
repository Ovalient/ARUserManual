using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VGAToggle : MonoBehaviour
{
    public GameObject vgaObject;
    public GameObject cpuObject;
    public GameObject ramObject;
    public Animator animator;
    public AudioClip audioClip;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.Find("VGA_Woman_KR").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("VGAIdle"))
        {
            vgaObject.SetActive(true);
            ramObject.GetComponent<RAMToggle>().enabled = true;
            cpuObject.GetComponent<CPUToggle>().enabled = true;
            animator.SetBool("IsRunning", true);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("VGAAnimation") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            vgaObject.SetActive(true);
            ramObject.GetComponent<RAMToggle>().enabled = true;
            cpuObject.GetComponent<CPUToggle>().enabled = true;
            animator.SetBool("IsRunning", true);
        }
    }

    private void OnMouseDown()
    {
        if(this.enabled)
        {
            vgaObject.SetActive(false);
            ramObject.GetComponent<RAMToggle>().enabled = false;
            cpuObject.GetComponent<CPUToggle>().enabled = false;
            animator.Play("VGAAnimation");
            audioSource.PlayOneShot(audioClip);
        }
    }
}
