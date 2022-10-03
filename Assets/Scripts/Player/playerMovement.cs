using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveXMulitply = 10.0f;
    [SerializeField] float moveYMultiply = 10.0f;
    [SerializeField] float moveXSprint = 15.0f;
    [SerializeField] float moveYSprint = 15.0f;
    float moveXSpeed = 1.0f;
    float moveYSpeed = 1.0f;
    float moveX;
    float moveY;
    bool canSprint = true;
    Animator myAnimator;

    // Start is called before the first frame update
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
