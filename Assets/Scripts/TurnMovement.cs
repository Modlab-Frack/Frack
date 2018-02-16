using UnityEngine;
using System.Collections;

public class TurnMovement : MonoBehaviour {
    Maintenance turn;
    public Vector2 initialPlayer2;
    // Use this for initialization
    public void movePlayer1()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        Rigidbody2D player1RigidBody = player1.GetComponent<Rigidbody2D>();
        player1RigidBody.gravityScale = 0;
        player1RigidBody.mass = 100;

        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        Rigidbody2D player2RigidBody = player2.GetComponent<Rigidbody2D>();
        player2RigidBody.gravityScale = 0;
        player2RigidBody.mass = 100;

        GameObject player3 = GameObject.FindGameObjectWithTag("Player3");
        Rigidbody2D player3RigidBody = player3.GetComponent<Rigidbody2D>();
        player3RigidBody.gravityScale = 0;
        player3RigidBody.mass = 100;


        //transform.rigidbody.velocity.x = moveDirection.x;
        //transform.rigidbody.velocity.y = moveDirection.y;
        //rigidbody.AddForce(Vector3.up * -10);

        player1RigidBody.velocity = new Vector2(0, 80);// * (float)0.01;
        player1RigidBody.drag = 2;

        player2RigidBody.velocity = new Vector2(0, 80);// * (float)0.01;
        player2RigidBody.drag = 2;

        player3RigidBody.velocity = new Vector2(0, -175);// * (float)0.01;
        player3RigidBody.drag = 2;

        return;
    }

    public void movePlayer2()
    {
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        Rigidbody2D player2RigidBody = player2.GetComponent<Rigidbody2D>();
        player2RigidBody.gravityScale = 0;
        player2RigidBody.mass = 100;
        Vector2 player2Start = player2.transform.position;

        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        Rigidbody2D player1RigidBody = player1.GetComponent<Rigidbody2D>();
        player1RigidBody.gravityScale = 0;
        player1RigidBody.mass = 100;
        Vector2 player1Start = player1.transform.position;


        //transform.rigidbody.velocity.x = moveDirection.x;
        //transform.rigidbody.velocity.y = moveDirection.y;
        //rigidbody.AddForce(Vector3.up * -10);

        Vector2 player2End = player2Start + new Vector2(0, 43);
        player2RigidBody.velocity = new Vector2(0, 80);// * (float)0.01;
        player2RigidBody.drag = 2;

        player1RigidBody.velocity = new Vector2(0, -90);// * (float)0.01;
        player1RigidBody.drag = 2;

        return;
    }

    public void movePlayer3()
    {
        GameObject player3 = GameObject.FindGameObjectWithTag("Player3");
        Rigidbody2D player3RigidBody = player3.GetComponent<Rigidbody2D>();
        player3RigidBody.gravityScale = 0;
        player3RigidBody.mass = 100;
        Vector2 player3Start = player3.transform.position;
        //initialPlayer3 = player3Start;

        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        Rigidbody2D player2RigidBody = player2.GetComponent<Rigidbody2D>();
        player2RigidBody.gravityScale = 0;
        player2RigidBody.mass = 100;
        Vector2 player2Start = player2.transform.position;


        //transform.rigidbody.velocity.x = moveDirection.x;
        //transform.rigidbody.velocity.y = moveDirection.y;
        //rigidbody.AddForce(Vector3.up * -10);

        Vector2 player3End = player3Start + new Vector2(0, 43);
        player3RigidBody.velocity = new Vector2(0, 165);// * (float)0.01;
        player3RigidBody.drag = 2;

        player2RigidBody.velocity = new Vector2(0, -170);// * (float)0.01;
        player2RigidBody.drag = 2;

        return;
    }

    // Update is called once per frame
    void Update () {
    }
}
