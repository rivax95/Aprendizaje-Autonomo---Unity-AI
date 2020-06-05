//                                          ▂ ▃ ▅ ▆ █ ZEN █ ▆ ▅ ▃ ▂ 
//                                        ..........<(+_+)>...........
// .cs (//)
//Autor: Alejandro Rivas                 alejandrotejemundos@hotmail.es
//Desc:
//Mod : 
//Rev :
//..............................................................................................\\
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class Manager : MonoBehaviour {

    public GameObject botPrefab;
    public int poupulationSize = 50;
    List<GameObject> population = new List<GameObject>();
    public static float elapsed = 0;
    public float trialTime = 5;
    int generation = 1;

    public Text t1;
    public Text t2;
    public Text t3;

	void Start () {
        for (int i = 0; i < poupulationSize; i++)
        {
            Vector3 startpos = new Vector3(this.transform.position.x + Random.RandomRange(-2, 2), this.transform.position.y, this.transform.position.z + Random.RandomRange(-2, 2));
            GameObject b = Instantiate(botPrefab, startpos, this.transform.rotation);
            b.GetComponent<Brain>().Init();
            population.Add(b);
        }
	}
    GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector3 startpos = new Vector3(this.transform.position.x + Random.RandomRange(-2, 2), this.transform.position.y, this.transform.position.z + Random.RandomRange(-2, 2));
        GameObject obj = Instantiate(botPrefab, startpos, this.transform.rotation);
        Brain b = obj.GetComponent<Brain>();
        if (Random.Range(0, 100) == 1)
        {
            b.Init();
            b.adn.mutate();
        }
        else
        {
            b.Init();
            b.adn.combine(parent1.GetComponent<Brain>().adn, parent2.GetComponent<Brain>().adn);
        }
        return obj;
    }
    void BreedNewPopulation()
    {
    //    List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<Brain>().timeAlive).ToList();
        List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<Brain>().DistanciaRecorrida).ToList();
        population.Clear();
        for (int i = (int) (sortedList.Count/2.0f)-1; i <sortedList.Count-1 ; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }
        //ahora destruimos todos los padre previos a la poblacion
        for (int i = 0; i < sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }
        generation++;
    }
	void Update () {
        elapsed += Time.deltaTime;
        if (elapsed >= trialTime)
        {
            BreedNewPopulation();
            elapsed = 0;
        }
        t1.text = "Gen: " + generation;
        t2.text = string.Format("Time: {0:0.00}", elapsed);
        t3.text = "population: " + population.Count;
	}
}
