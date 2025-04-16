using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int velocidad = 4;
    Rigidbody rigid;
    bool touchGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody>();//save the reference Rigidbody of our character  
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        transform.Rotate(0, Horizontal, 0);//The object can rotate to left or right side
        transform.Translate(0,0,Vertical * Time.deltaTime * velocidad);

        if (Input.GetKeyDown(KeyCode.Space) && touchGround == true)//press "SPACEBAR" key to jump & character is touching the ground
        {
            rigid.AddForce(Vector3.up * 7, ForceMode.Impulse);
            touchGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            touchGround = true;
        }
    }
}
