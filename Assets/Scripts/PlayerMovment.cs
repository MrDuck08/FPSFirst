using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : Damageable
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.82f;
    public float jumpHeight = 3f;
    public float yThenStop;

    Vector3 velocity;

    public bool isGrounded;
    bool stopGettingY;
    bool wallRunning;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask BulletsLayer;

    public GameObject Enemys;

    Menuhandler MenuHandler;

    private void Start()
    {
        MenuHandler = FindAnyObjectByType<Menuhandler>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0 )
        {
            velocity.y = -1.0f;
        }

        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * X + transform.forward * Z;

        controller.Move(Move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
             velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);            
        }



        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    #region Failling At WallRun // No I Will succed ): // I SUCCEDED (:

    public override void OnCollisionStay(Collision collision)
    {
        if(Input.GetAxis("Horizontal") == 0) { return; }
        if (collision.gameObject.layer == 6)
        {
            GetYThenStop();

            WallRun();

            wallRunning = true;
        }
        else
        {
            stopGettingY = true;

            wallRunning = false;
        }
    }

    void WallRun()
    {
        transform.position = new Vector3(transform.position.x, yThenStop, transform.position.z);
    }

    void GetYThenStop()
    {
        if(stopGettingY) { return;  }
        yThenStop = transform.position.y;
    }

    IEnumerator WallRunStopCourutine()
    {
        yield return new WaitForSeconds(0.5f);

        velocity.x = 0;
        velocity.z = 0;
    }
    #endregion

    #region Spawn Enemies

    void SpawnEnemies()
    {
        if(MenuHandler.MenuIsActive) { return; }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            float XPos = Random.Range(-40.2f, -132f);
            float YPos = Random.Range(22.36f, 50f);
            float ZPos = Random.Range(46.93f, -55.37f);

            Instantiate(Enemys, new Vector3(XPos, YPos, ZPos), Quaternion.identity);
        }
    }

    #endregion
}
