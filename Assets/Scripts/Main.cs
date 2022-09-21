using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] GameObject white;
    [SerializeField] GameObject black;
    [SerializeField] GameObject dotPrefab;
    public GameObject[,] dotArray;
    public GameObject SelectedFeature;
    void CreateField()
    {
        for (var x = 0; x < 8; x++)
        {
            for (var y = 0; y < 8; y++)
            {
                Vector3 pos = new Vector3(x - 3.5f, y - 3.5f, 0);
                GameObject clone = Instantiate(dotPrefab, pos, Quaternion.identity, gameObject.transform);
                dotArray[x, y] = clone;
                if ((x + y) % 2 == 0)
                {
                    
                    clone.AddComponent<DotClass>().main = gameObject.GetComponent<Main>();//��������
                }
            }
        }
        CreateDot();
    }
    void CreateDot()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (y < 3)
                {
                    if ((x + y) % 2 == 0)
                    {
                        Vector3 pos = dotArray[x, y].transform.position;
                        GameObject clone = Instantiate(white, pos, Quaternion.identity, gameObject.transform);
                        clone.name = "White";
                        dotArray[x, y].GetComponent<DotClass>().feature = clone;
                        Debug.Log(dotArray[x, y].GetComponent<DotClass>().feature);

                    }
                }
                if (y > 4)
                {
                    if ((x + y) % 2 == 0)
                    {
                        Vector3 pos = dotArray[x, y].transform.position;
                        GameObject clone = Instantiate(black, pos, Quaternion.identity, gameObject.transform);
                        clone.name = "Black";
                        dotArray[x, y].GetComponent<DotClass>().feature = clone;
                        Debug.Log(dotArray[x, y].GetComponent<DotClass>().feature);
                    }

                }
            }
        }
        
    }
    public void Start()
    {
        dotArray = new GameObject[8, 8];
        CreateField();
    }

    
}
