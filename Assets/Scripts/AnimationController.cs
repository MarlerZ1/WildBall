using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private string[] parametrs;
    public void ChooseRandomAnimations()
    {
        for (int i = 0; i < parametrs.Length; i++)
        {
            anim.SetBool(parametrs[i], false);
        }
        int active = Random.Range(0, parametrs.Length);
        anim.SetBool(parametrs[active], true);
    }
}
