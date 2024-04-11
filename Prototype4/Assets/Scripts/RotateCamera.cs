using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    private const string horizontal = horizontal;
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis(horizontal);
        transform.Rotate(Vector3.up, (horizontalInput * rotationSpeed * Time.deltaTime));
    }
}
