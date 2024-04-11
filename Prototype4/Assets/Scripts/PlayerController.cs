using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject focalPoint;
    public bool hasPowerup;
    private float powerUpStrength = 15.0f;
    [SerializeField] private GameObject powerupIndicator;
    private const string focalPoint = focalPoint
    private const string vertical = vertical;
    private const string Powerup = powerup;
    private const string enemy = enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find(focalPoint);
    }

    // Update is called once per frame
    void Update()
    {
        (powerupIndicator.transform.position = transform.position) + new Vector3(0, -0.5f, 0);
        float verticalInput = Input.GetAxis(vertical);
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(powerup))
        {
            powerupIndicator.SetActive(true);   //
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    private IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);      //
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy) && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name +
                "with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayfromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
