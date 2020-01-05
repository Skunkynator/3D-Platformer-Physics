using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxRayController3D))]
class Player:MonoBehaviour
{
    public float moveSpeed;
    Vector3 velocity;
    Vector3 gravity = new Vector3(0,-9.8f,0);
    Vector3 gravVelocity;
    Vector3 directionalInput;
    BoxRayController3D controller;
    float velocityXSmoothing;
    float velocityYSmoothing;
    float velocityZSmoothing;
    float accelerationTimeGrounded = 0.1f;
    private void Start()
    {
        controller = GetComponent<BoxRayController3D>();
        controller.GravityDir = gravity;
        Time.timeScale = 0.3f;
    }

    private void Update()
    {
        CalculateVelocity();
        controller.move((gravVelocity + velocity) * Time.deltaTime);
    }
    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = transform.worldToLocalMatrix.MultiplyVector(new Vector3(input.x,0,input.y));
    }
    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGrounded);
        float targetVelocityY = directionalInput.y * moveSpeed;
        velocity.y = Mathf.SmoothDamp(velocity.y, targetVelocityY, ref velocityYSmoothing, accelerationTimeGrounded);
        float targetVelocityZ = directionalInput.z * moveSpeed;
        velocity.z = Mathf.SmoothDamp(velocity.z, targetVelocityZ, ref velocityZSmoothing, accelerationTimeGrounded);
        gravVelocity += gravity * Time.deltaTime;
    }
}
