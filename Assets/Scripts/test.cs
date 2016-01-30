using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetInteger("State", 0);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetInteger("State", 1);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            animator.SetInteger("State", 2);
        }
    }
}
