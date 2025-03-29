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
        float _moveHorizontal = joystick.Horizontal();
        float _moveVertical = joystick.Vertical();

        Vector3 _direction = new Vector3(_moveHorizontal, 0, _moveVertical);
        //on s'adapte à l'utilisateur
        _direction = Camera.main.transform.TransformDirection(_direction);
        //tout en ignorant la verticalité
        _direction.y = 0;

        SceneARManager.INSTANCE.currentChest.transform.Translate(_direction * speed * Time.deltaTime);
    }
}
