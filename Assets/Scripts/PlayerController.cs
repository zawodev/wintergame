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

        /*if (crossHair != null) {
            var dir = crossHair.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 45f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        */

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movement.magnitude > 1) movement.Normalize();
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
    /*
    public void GaveImpact(float power) {
        Vector2 crossHair = CrossHair.crossHair.cursorPos;
        rb.AddForce(((Vector2)transform.position - crossHair).normalized * power * 1000f, ForceMode2D.Force);
    }*/
}