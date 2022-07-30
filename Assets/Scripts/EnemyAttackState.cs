using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : MonoBehaviour
{
    public bool attackState;
    public Animator animator;
    CapsuleCollider colider;
    float coliderRadius;
    float coliderHeight;
    Vector3 coliderCenter;
    Vector3 normalColiderCenter;



    public float coliderRadiusOnAttack;
    public float coliderHeightOnAttack;
    public float coliderCenterOnAttack;
    // Start is called before the first frame update
    void Start()
    {

        colider = GetComponent<CapsuleCollider>();
        normalColiderCenter = new Vector3(0, colider.center.y, 0);

        coliderRadius = colider.radius;
        coliderHeight = colider.height;


        colider.enabled = false;
        attackState = false;
        
    }

    // Update is called once per frame
    void Update() 
    {


        checkAttackState();

        if (attackState)
        {
            colider.radius = coliderRadiusOnAttack;
            colider.height = coliderHeightOnAttack;
            coliderCenter.y = coliderCenterOnAttack;
            colider.center = coliderCenter;
            colider.enabled = true;

        }
        else
        {
            colider.radius = coliderRadius;
            colider.height = coliderHeight;
            colider.center = normalColiderCenter;
            colider.enabled = false;
        }
    }



   


    void checkAttackState() 
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {

            // Animation State complete
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.05f)
            {
                attackState = false;


            }

            //Animation State begun 
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.05f)
            {
                attackState = true;
            }
        }
    }

}
