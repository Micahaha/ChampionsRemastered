using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour
{
    public bool attackState;

    public AnimationStateController animController;
    public Animator animator;
    CapsuleCollider colider;
    float coliderRadius;
    float coliderHeight;
    Vector3 coliderCenter;
    Vector3 normalColiderCenter;



    public float coliderRadiusOnAttack;
    public float coliderHeightOnAttack;
    public float coliderCenterOnAttack;



    Enemy enemy; 
    public Transform destroyed_Jar;

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



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Destructible"))
        {
            Debug.Log("Colision detected with: " + collision.gameObject.name);
            Transform instantiated_jar = Instantiate(destroyed_Jar, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Debug.Log("Destroyed");

            foreach (Transform child in instantiated_jar)
            {
                if (child.TryGetComponent(out Rigidbody childRigidBody))
                {
                    childRigidBody.AddForce(0, 3f, 0, ForceMode.Impulse);
                }
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Killed");
            enemy = collision.GetComponent<Enemy>();
        }
    }


    void checkAttackState() 
    {
        if (animController.attack == true)
        {
            attackState = true;
            
        }

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
