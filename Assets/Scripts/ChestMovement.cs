using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMovement : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float speed = 5.0f;

    void Update()
    {
        if (SceneARManager.INSTANCE.currentChest == null) return;
        float moveHorizontal = joystick.Horizontal();
        float moveVertical = joystick.Vertical();

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        SceneARManager.INSTANCE.currentChest.transform.Translate(movement * speed * Time.deltaTime);
    }
}
