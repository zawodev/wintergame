using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController playerController;
    public Animator anim;

    Camera _camera;
    public Rigidbody2D rb;
    //Health health;

    Vector2 movement;

    [Space]
    public float acceleration;
    public float maxSpeed;

    [HideInInspector]
    public bool isMoving;

    private void Awake() {
        playerController = this;
    }
    void Update() {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movement.magnitude > 1) movement.Normalize();

        if (Input.GetAxis("Horizontal") > 0) RotatePlayer(0f);
        else if (Input.GetAxis("Horizontal") < 0) RotatePlayer(180f);
        else isMoving = false;
    }
    private void FixedUpdate() {
        Move(maxSpeed * movement, acceleration);
        anim.SetFloat("speed", Mathf.Max(Mathf.Abs(Input.GetAxis("Horizontal")), Mathf.Abs(Input.GetAxis("Vertical"))) * acceleration);
    }
    public void Move(Vector2 velocity, float force) {
        velocity += velocity.normalized * 0.2f * rb.drag;
        force = Mathf.Clamp(force, -rb.mass / Time.fixedDeltaTime, rb.mass / Time.fixedDeltaTime);

        if (velocity.magnitude == 0) {
            rb.AddForce(velocity * force, ForceMode2D.Force);
        }
        else {
            Vector2 vel = velocity.normalized * Vector2.Dot(velocity, rb.velocity) / velocity.magnitude;
            rb.AddForce((velocity - vel) * force, ForceMode2D.Force);
        }
    }
    public void RotatePlayer(float y) {
        isMoving = true;
        transform.rotation = new Quaternion(0f, y, 0f, 0f);
    }
}
