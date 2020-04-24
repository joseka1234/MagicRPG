using UnityEngine;
using System.Linq;

public class NPC : MonoBehaviour
{
    public string[] Interaccion;
    public string[] Creacion;
    private CircleCollider2D CircleClollider;
    private GameEngine Engine;
    private Personaje[] Personajes;

    void Start()
    {
        this.CircleClollider = this.GetComponent<CircleCollider2D>();
        this.Engine = GameObject.FindGameObjectWithTag("Engine").GetComponent<GameEngine>();
        this.CrearPersonaje();
    }

    public void CrearPersonaje()
    {
        this.Personajes = new Personaje[this.Creacion.Length];
        this.Personajes = this.Creacion.Select((creacion) => this.Engine.Interprete.CrearPersonaje(creacion)).ToArray();
    }

    public void Interactuar()
    {
        this.Engine.Enemigos = this.Personajes;
        foreach (string i_interaction in this.Interaccion)
        {
            this.Engine.Interprete.EjecutarInteraccion(i_interaction);
        }
    }
}
