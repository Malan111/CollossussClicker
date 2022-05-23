using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CntrlAnimation : MonoBehaviour
{
    [SerializeField] Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play("AnimSliderMainer");
    }

}
