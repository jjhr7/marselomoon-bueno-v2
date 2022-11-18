using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{   
    public float diameter;
    public GameObject prefab;
    GameObject ojeto;
    int i;
    List<GameObject> objects = new List<GameObject>();
    bool ya;
    public int nObjects;
    public bool muertos;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        diameter = this.gameObject.transform.lossyScale.x;
        i = 0;
        ya = false;
        movement = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (i < nObjects)
        {
            bool dale = false;
            i++;
            //update the x & z values depending on the specific boundaries of your scene
            Vector3 randomizePosition = Random.onUnitSphere * diameter/2;
            randomizePosition.y += this.transform.position.y;

            //update the y value depending on how much you want the thing to randomly rotate
            Quaternion randomizeRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            ojeto = Instantiate(prefab, randomizePosition, randomizeRotation);

            ojeto.transform.LookAt(this.transform.position);

            float dist = Vector3.Distance(ojeto.transform.position, this.transform.position);
                    if (i > 1)
                    {
                        for (int j = 0; j < objects.Count; j++)
                        {
                            if (Vector3.Distance(objects[j].transform.position, ojeto.transform.position) < 5)
                            {
                                dale = false;
                                i--;
                                Destroy(ojeto);
                                Debug.Log("F");
                                break;
                            }
                            else
                            {
                                Debug.Log(Vector3.Distance(objects[j].transform.position, ojeto.transform.position));
                                dale = true;
                            }
                        }
                        if (dale)
                        {

                            objects.Add(Instantiate(prefab, randomizePosition, randomizeRotation));
                            Destroy(ojeto);
                            Debug.Log(i);
                        }
                    }
                    else
                    {
                        objects.Add(Instantiate(prefab, randomizePosition, randomizeRotation));
                        Destroy(ojeto);
                        Debug.Log(i);
                    }

            
        }
        else
        {

            if (!ya)
            {
                Debug.Log("YA");
                for (int j = 0; j < objects.Count; j++)
                {
                    objects[j].transform.parent = this.transform;
                    objects[j].transform.LookAt(this.transform.position);
                    Debug.Log(Vector3.Distance(objects[j].transform.position, this.transform.position));
                }
                ya = true;
            }
            else
            {
                this.transform.Rotate(0.1f, 0.1f, 0);
            }
            
            for (int j = 0; j < objects.Count; j++)
            {
                if (objects[j] == null)
                {
                    muertos=true;
                }
                else
                {
                    muertos = false;
                    break;
                }

            }

            if (muertos)
            {
                objects.RemoveAll(item => item == null);
                i = 0;
                nObjects += 2;
                this.improveSpeedRotation();
                muertos=false;
                ya = false;
            }
        }
    }

    public void improveSpeedRotation()
    {
        Debug.Log("Aumentando velocidad");
        this.movement.y = this.movement.y + 30;
    }
    

}
