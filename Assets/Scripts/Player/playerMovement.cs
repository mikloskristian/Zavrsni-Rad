using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] float moveXMulitply;
    [SerializeField] float moveYMultiply;
    [SerializeField] float moveXSprint;
    [SerializeField] float moveYSprint;
    
    [Header("Health and Damage")]
    [SerializeField] public float health;
    [SerializeField] float damage;
    float moveXSpeed = 1.0f;
    float moveYSpeed = 1.0f;
    float moveX;
    float moveY;
    bool canSprint = true;
    Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove();
        if(Input.GetKeyDown(KeyCode.Space) && canSprint){
            
            StartCoroutine(handleSprint());
        }
    }

    void canMove(){
        moveX = Input.GetAxis("Horizontal") * moveXSpeed * moveXMulitply * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveYSpeed * moveYMultiply * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);
    }

    IEnumerator handleSprint() {
        moveXMulitply = moveXSprint;
        moveYMultiply = moveYSprint;
        //particles start

        yield return new WaitForSeconds(0.3f);
        moveXMulitply = 6.0f;
        moveYMultiply = 6.0f;
        //particles end

        canSprint = false;
        yield return new WaitForSeconds(2.0f);
        canSprint = true;
    }
}
