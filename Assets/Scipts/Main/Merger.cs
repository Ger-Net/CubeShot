using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Merger : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    public void Merge(Cube cube1, Cube cube2)
    {
        Cube cube = _spawner.MergeSpawn(cube1, cube1.gameObject.transform.position);
        cube.OnCollisionDetected += Merge;
        cube1.OnCollisionDetected -= Merge;
        cube2.OnCollisionDetected -= Merge;
        Destroy(cube1.gameObject);
        Destroy(cube2.gameObject);
        Jump(cube);
        
    }
    private void Awake()
    {
        var cubes = FindObjectsOfType<Cube>();
        foreach(Cube cube in cubes)
        {
            cube.OnCollisionDetected += Merge;
        }
    }
    private void Jump(Cube cube)
    {
        Cube second = FindObjectsOfType<Cube>().FirstOrDefault(t => t != cube && t.Data.Index == cube.Data.Index);
        var rigidbody = cube.GetComponent<Rigidbody>();
        Vector3 finalVelocity;
        if (second != null)
        {
            finalVelocity = CalculateVelocity(cube, second.transform.position);
        }
        else
        {
            finalVelocity = CalculateVelocity(cube, new(Random.Range(-1, 1), 0, Random.Range(-1, 1)));  
        }
        rigidbody.AddForce(finalVelocity * rigidbody.mass, ForceMode.Impulse);
    }

    private Vector3 CalculateVelocity(Cube cube, Vector3 position)
    {
        float gravity = Physics.gravity.magnitude;
        // Selected angle in radians
        float angle = 75 * Mathf.Deg2Rad;

        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(position.x, 0, position.z);
        Vector3 planarPostion = new Vector3(cube.transform.position.x, 0, cube.transform.position.z);

        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distance along the y axis between objects
        float yOffset = cube.transform.position.y - position.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate our velocity to match the direction between the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion) * (position.x > transform.position.x ? 1 : -1);
        Vector3 finalVelocity;
        return finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
    }
}

