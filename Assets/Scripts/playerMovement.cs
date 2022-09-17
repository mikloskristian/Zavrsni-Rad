using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveXMulitply = 10.0f;
    [SerializeField] float moveYMultiply = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canMove();
        canShoot();
    }

    void canMove(){
        float moveX = Input.GetAxis("Horizontal") * moveXMulitply * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveYMultiply * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);
        
        //ovo uklonit nakon sto napravim shooting
        if(moveX < 0){
            transform.localScale = new Vector2(-1, 1);
        }
        else{
            transform.localScale = new Vector2(1, 1);
        }
    }

    void canShoot(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("Pucam!");
        }
    }
}
