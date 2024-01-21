using UnityEngine;

public class CameraPlayerController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/
    
    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
    }
}
