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

public class ADN  {

    List<int> genes = new List<int>();
    int adnLenght = 9;
    int maxValue = 0;
   
    public ADN (int l,int v){
        adnLenght = l;
        maxValue = v;
        SetRandom();
    }
    public void SetRandom()
    {
        genes.Clear();
        for (int i = 0; i < adnLenght; i++)
        {
            genes.Add(Random.Range(0, maxValue));
        }
    }
    public void setInt(int pos, int value){
        genes[pos] = value;

    }
    public void combine(ADN D1, ADN D2)
    {
        for (int i = 0; i < adnLenght; i++)
        {
            if (i < adnLenght / 2.0f) // la mitad de las celulas
            {
                int c = D1.genes[i];
                genes[i] = c;
            }
            else
            {
                int c = D2.genes[i];
                genes[i] = c;
            }
        }
    }
    public void mutate()
    {
        genes[Random.Range(0, adnLenght)] = Random.Range(0, maxValue);
    }
    public int GetGene(int pos)
    {
        return genes[pos];
    }
}
