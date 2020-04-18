using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An object spawner
/// </summary>
public class SpawnObject : MonoBehaviour
{
    #region Variables
    // needed for spawning
    GameObject spawnObject;

    [SerializeField]
    GameObject plane;

    // spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 5;
    Timer
        spawnTimer;

    // spawn location support
    float randomX;
    float randomY;
    float randomZ;

    //list of prefabs
    GameObject[] prefabs = new GameObject[12];

    int boxValue;

    Ray ray;
    RaycastHit hit;

    string equation = "";
    List<int> equationArray = new List<int>();

    #endregion

    #region Methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        plane = GameObject.FindWithTag("Plane");

        // save spawn boundaries for efficiency
        float randomX = Random.Range(plane.transform.position.x - plane.transform.localScale.x / 2, plane.transform.position.x + plane.transform.localScale.x / 2);
        float randomY = Random.Range(plane.transform.position.y - plane.transform.localScale.y / 2, plane.transform.position.y + plane.transform.localScale.y / 2);
        float randomZ = Random.Range(plane.transform.position.y - plane.transform.localScale.z / 2, plane.transform.position.y + plane.transform.localScale.z / 2);

        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // check for time to spawn a new enemy
        if (spawnTimer.Finished)
        {
            objectSpawn();

            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }

        //clicking on the box to get the value of box

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
                print("Click on this box : "+hit.collider.GetComponent<Box>().value.value);
            createEquation(hit.collider.GetComponent<Box>().value.value);
        }

    }

    /// <summary>
    /// Spawns an object at a random location on a plane
    /// </summary>
    void objectSpawn()
    {
        // generate random location and create new object
        Vector3 randomPosition = GetARandomPos(plane);

        //pick random prefab from the folder
        //provide path to that prefab
        //instantiate the prefab at random position.

        prefabs  = Resources.LoadAll<GameObject>("Prefabs");

      //  Debug.Log("prefab length "+prefabs.Length);

        foreach (GameObject prefab in prefabs)
        {
           // Debug.Log("prefab --------: " + prefab.name);
        }

        spawnObject = prefabs[Random.Range(0, prefabs.Length)];

       // Debug.Log("prefab to spawn :" + spawnObject.name);


        Instantiate<GameObject>(spawnObject, randomPosition, Quaternion.identity);

        //Get value of the box
        spawnObject.GetComponent<Box>().value.print();

        boxValue = spawnObject.GetComponent<Box>().value.value;

       // createEquation(boxValue);

    }

    /// <summary>
    /// Return random position on the plane
    /// </summary>
    public Vector3 GetARandomPos(GameObject plane)
    {

        Mesh planeMesh = plane.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;

        float minX = plane.transform.position.x - plane.transform.localScale.x * bounds.size.x * 0.5f;
        float minZ = plane.transform.position.z - plane.transform.localScale.z * bounds.size.z * 0.5f;

        Vector3 newVec = new Vector3(Random.Range(minX, -minX),
                                     plane.transform.position.y,
                                     Random.Range(minZ, -minZ));
        return newVec;
    }

   public void createEquation(int value)
    {
        equationArray.Add(value);

        equation = string.Join(" ", equationArray.ToArray());



        //equation = value.ToString();

        Debug.Log("the equation is : "+equation);
    }

    #endregion
}