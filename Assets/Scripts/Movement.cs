using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _charController;
    public float speed = 3f;
    public float gravity = -9.8f;
void Start() {
        _charController = GetComponent<CharacterController>(); 
}
    public const float baseSpeed = 6.0f;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement = Vector3.ClampMagnitude(movement, speed); 
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement); 
        _charController.Move(movement); 
    }
}
