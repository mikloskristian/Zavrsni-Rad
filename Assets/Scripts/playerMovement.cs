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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canMove();
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(handleSprint());
        }
    }

    void canMove(){
        float moveX = Input.GetAxis("Horizontal") * moveXSpeed * moveXMulitply * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveYSpeed * moveYMultiply * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);
    }

    IEnumerator handleSprint() {
        moveXMulitply = moveXSprint;
        moveYMultiply = moveYSprint;
        yield return new WaitForSeconds(0.3f);
        moveXMulitply = 10.0f;
        moveYMultiply = 10.0f;
    }
}
