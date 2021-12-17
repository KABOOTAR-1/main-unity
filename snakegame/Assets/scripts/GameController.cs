using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject fruit_ob, bomb_ob;

    private float minx = 4.70f, minz = 3.2f;
    private Text score;
    private int scorecount=0;
    private void Awake()
    {
        Makeinstance();
       
    }
    void Start()
    {
        score = GameObject.Find("Text").GetComponent<Text>();
        StartCoroutine(spawnobject());
       score.text = "SCORE:" + scorecount;
    }
     void Makeinstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator spawnobject()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));

        if (Random.Range(0, 10) > 1)
        {
            Instantiate(fruit_ob, new Vector3(Random.Range(-minx, minx), 0.2f, Random.Range(-minz, minz)), Quaternion.identity);
        }
        else
        {
            Instantiate(bomb_ob, new Vector3(Random.Range(-minx, minx), 0.2f, Random.Range(-minz, minz)), Quaternion.identity);
        }

        StartCoroutine(spawnobject());
    }

    public void incsreasescore()
    {
        scorecount++;
        score.text = "SCORE:" + scorecount;
    }
}
