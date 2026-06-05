using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform GolfBallTransform;

    private Golfball golfBall;

    public float DistanceFromBall = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        golfBall = GolfBallTransform.gameObject.GetComponent<Golfball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 arrowDirection = golfBall.GetForceDirection();

        // Update the length of the vector so it's at an appropriate distance from the ball
        arrowDirection *= DistanceFromBall;

        // Set the position of the arrow to the position of the ball + the vector we just calculated
        transform.position = GolfBallTransform.position + arrowDirection;

        // Calculate the angle of rotation based on the vector above
        float angle = Mathf.Atan2(arrowDirection.z, arrowDirection.x) * Mathf.Rad2Deg;

        // Apply the rotation to the arrow
        transform.rotation = Quaternion.Euler(90f, -angle, 0f);
    }
}
