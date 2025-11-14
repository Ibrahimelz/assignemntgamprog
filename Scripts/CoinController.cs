using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float hoverRange = 0.5f;       // eight that the coin will hover
    public float hoverSpeed = 0.5f;       // How fast the coin move up and down

    private Vector3 startPosition;
    
    private float topYPosition;

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
        
        topYPosition = startPosition.y + hoverRange;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * angle, Space.World);

        float pingPongValue = Mathf.PingPong(Time.time * hoverSpeed, hoverRange);

        float newY = startPosition.y + pingPongValue;

        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}