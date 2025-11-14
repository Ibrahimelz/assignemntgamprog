using UnityEngine;

public class EnemyController : MonoBehaviour
{
 
    public float rangeY = 1f;
    
    public float speed = 3f;

 
    private Vector3 initialPosition;

    private void Start()
    {
       
        initialPosition = transform.position;
    }

    void Update()
    {
       
        float pingPongValue = Mathf.PingPong(Time.time * speed, rangeY);

    
        float newY = initialPosition.y + pingPongValue;

  
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}