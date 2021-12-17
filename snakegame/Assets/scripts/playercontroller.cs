using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playercontroller : MonoBehaviour
{
    public playerDirection direction;

    public float step_length = 0.2f;
    float x = 0;

    public float movement_freq = 0.1f;
    private float counter;
    private bool move;
    [SerializeField]
      private GameObject tailprefab;

    private List<Vector3> positions;
    private List<Rigidbody> nodes;

    private Rigidbody mainbody;
    private Rigidbody head;
    private Transform tr;

    private bool createnode_at_tail;

    private void Awake()
    {
        tr = transform;
        mainbody = GetComponent<Rigidbody>();

        Snakes_nodes();
        positions = new List<Vector3>
        {
            new Vector3(-step_length,0),

            new Vector3(0,0,step_length),
             new Vector3(step_length,0),
             new Vector3(0,0,-step_length),

        };
        SetRandomDirection();
    }
    void Start()
    {
        Time.timeScale = 1f;
       
      
    }

    // Update is called once per frame
    void Update()
    {
        x = x + Time.deltaTime;
        checkmovementfrequency();
    }
    private void FixedUpdate()
    {
       
        if (move)
        {
            move = false;
            Move();
        }
    }
    void Snakes_nodes()
    {
        nodes = new List<Rigidbody>();
        nodes.Add(tr.GetChild(0).GetComponent<Rigidbody>());
        nodes.Add(tr.GetChild(1).GetComponent<Rigidbody>());
        nodes.Add(tr.GetChild(2).GetComponent<Rigidbody>());

        head = nodes[0];
    }

    void SetRandomDirection()
    {
        int dirrandom = Random.Range(0, (int)playerDirection.COUNT);
        direction = (playerDirection)dirrandom;
    }

    void Move()
    {
        if (x>2f)
        {

            Vector3 deltapos = positions[(int)direction];

            Vector3 parentpos = head.position;
            Vector3 prevpos;

            mainbody.position = mainbody.position + deltapos;
            head.position = head.position + deltapos;

            for (int i = 1; i < nodes.Count; i++)
            {
                prevpos = nodes[i].position;

                nodes[i].position = parentpos;
                parentpos = prevpos;
            }

            if (createnode_at_tail)
            {
                createnode_at_tail = false;
                GameObject newnode = Instantiate(tailprefab, nodes[nodes.Count - 1].position, Quaternion.identity);
                newnode.transform.SetParent(transform, true);
                nodes.Add(newnode.GetComponent<Rigidbody>());
            }
        }
    }
    void checkmovementfrequency()
    {
        counter += Time.deltaTime;

        if (counter >= movement_freq)
        {
            counter = 0;
            move = true;
        }
    }

    public void inputdirection(playerDirection dir)
    {
         if(dir==playerDirection.UP&&direction==playerDirection.DOWN||
           dir == playerDirection.DOWN && direction == playerDirection.UP ||
           dir==playerDirection.RIGHT&&direction==playerDirection.LEFT||
           dir == playerDirection.LEFT && direction == playerDirection.RIGHT)
        {
            return;
        }
        direction = dir;

        ForceMove();
    }

    void ForceMove()
    {
        counter = 0;
        move = false;
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tags.Wall || other.tag == tags.BOMB||other.tag==tags.TAIL)
        {
            Debug.Log("walls"); 
            audiomanager.instance.ded();
            Time.timeScale = 0f;
            SceneManager.LoadScene("snakegame");
            
           
        }
        if (other.tag == tags.FRUIT)
        {
            Destroy(other.gameObject);
            createnode_at_tail=true;
            GameController.instance.incsreasescore();
            audiomanager.instance.picksound();
            
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
    }
}

