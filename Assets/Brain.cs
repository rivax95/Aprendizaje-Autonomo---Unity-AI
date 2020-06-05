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
using UnityStandardAssets.Characters.ThirdPerson;
public class Brain : MonoBehaviour
{

    public int dnaLenght = 1;
    public float timeAlive = 0;
    public ADN adn;
    public float DistanciaRecorrida;
    private ThirdPersonCharacter m_Character;
    private Vector3 m_Move;
    private bool m_Jump;
    bool alive = true;
    Vector3 startPos;
    void Start()
    {

    }


    void Update()
    {

    }
    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "dead")
        {
            alive = false;
        }
    }
    public void Init()
    {
        // estos son los comandos que le damos al character
        //0 adelante
        //1 atras
        //2 derecha
        //3 izquierda
        //    4 salto
        //        5 agacharse

        adn = new ADN(dnaLenght, 6);
        m_Character = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
        startPos = this.transform.position;
    }
    public void FixedUpdate()
    {
        float h = 0;
        float v = 0;
        bool crouch = false;
        if (adn.GetGene(0) == 0) v = 1;
        else if (adn.GetGene(0) == 1) v = -1;
        else if (adn.GetGene(0) == 2) h = -1;
        else if (adn.GetGene(0) == 3) h = 1;
        else if (adn.GetGene(0) == 4) m_Jump = true;
        else if (adn.GetGene(0) == 5) crouch = true;
        m_Move = v * Vector3.forward + h * Vector3.right;
        m_Character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
        if (alive)
        {
            timeAlive += Time.deltaTime;
            DistanciaRecorrida = Vector3.Distance(this.transform.position, startPos);
        }
    }
}
