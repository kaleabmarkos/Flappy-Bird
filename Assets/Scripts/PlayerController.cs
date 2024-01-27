using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeedY = 10.0f; 
    
    float gameHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        gameHeight = GameController.Instance.GameHeight;
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        float positionY = transform.position.y + (directionY * moveSpeedY* Time.deltaTime);
        positionY = Mathf.Clamp(positionY, -gameHeight, gameHeight);
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
       
       //Debug.Log(Time.deltaTime);
    }

void onCollisionEnter2D(Collision2D other){
    if(other.gameObject.tag.Equals("Enemy")){

    Debug.Log("Collided");
    }
}

}
