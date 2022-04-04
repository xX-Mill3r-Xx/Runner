using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataforms : MonoBehaviour
{
    public List<GameObject> plataforms = new List<GameObject>();
    public List<Transform> current = new List<Transform>();
    public int offSet;

    private Transform player;
    private Transform currentPlataformPoint;
    private int plataformIndex;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < plataforms.Count; i++)
        {
            Transform p = Instantiate(plataforms[i], new Vector3(0, 0, i * 30), transform.rotation).transform;
            current.Add(p);
            offSet += 30;
        }

        currentPlataformPoint = current[plataformIndex].GetComponent<Plataforms>().point;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - currentPlataformPoint.position.z;
        if (distance >= 9)
        {
            Recicle(current[plataformIndex].gameObject);
            plataformIndex++;
            if (plataformIndex > current.Count - 1)
            {
                plataformIndex = 0;
            }
            currentPlataformPoint = current[plataformIndex].GetComponent<Plataforms>().point;
        }
    }

    public void Recicle(GameObject plataform)
    {
        plataform.transform.position = new Vector3(0, 0, offSet);
        offSet += 30;
    }
}
