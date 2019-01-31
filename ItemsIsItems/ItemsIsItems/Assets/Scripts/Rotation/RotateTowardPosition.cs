using System;
using UnityEngine;

public class RotateTowardPosition : MonoBehaviour
{
    public int rotationOffset;
    private Vector2 currentTargetPosition;

    void Start()
    {
        currentTargetPosition = new Vector2(transform.position.x, transform.position.y);
    }

    public void rotateToPosition(Vector2 targetPosition)
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
<<<<<<< HEAD

        if (currentTargetPosition == targetPosition || targetPosition == null || targetPosition.Equals(currentPosition))
=======
        if (currentTargetPosition.Equals(targetPosition) || targetPosition == null || targetPosition.Equals(currentPosition))
>>>>>>> JordanDialog
        {
            return;
        }

        currentTargetPosition = targetPosition;

        Vector3 object_pos = this.transform.position;
        targetPosition.x = targetPosition.x - object_pos.x;
        targetPosition.y = targetPosition.y - object_pos.y;

        float angle = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
        angle -= 90;

        float newRotationAngle = angle + rotationOffset;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, newRotationAngle));
    }

    public Vector2 getCurrentTargetPosition()
    {
        return currentTargetPosition;
    }


}