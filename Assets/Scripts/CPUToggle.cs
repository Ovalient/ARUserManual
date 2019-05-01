using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUToggle : MonoBehaviour
{
    public GameObject cpuObject;
    public GameObject vgaObject;
    public GameObject ramObject;
    public Animator animator;
    public AudioClip audioClip;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.Find("CPU_Woman_KR").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("LGASocketIdle"))
        {
            cpuObject.SetActive(true);
            ramObject.GetComponent<RAMToggle>().enabled = true;
            vgaObject.GetComponent<VGAToggle>().enabled = true;
            animator.SetBool("IsRunning", true);
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsName("LGASocketAnimation") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            cpuObject.SetActive(true);
            ramObject.GetComponent<RAMToggle>().enabled = true;
            vgaObject.GetComponent<VGAToggle>().enabled = true;
            animator.SetBool("IsRunning", true);
        }
    }

    private void OnMouseDown()
    {
        if(this.enabled)
        {
            cpuObject.SetActive(false);
            ramObject.GetComponent<RAMToggle>().enabled = false;
            vgaObject.GetComponent<VGAToggle>().enabled = false;
            animator.Play("LGASocketAnimation");
            audioSource.PlayOneShot(audioClip);
        }        
    }
}
