using UnityEngine;
using System.Linq;

public class NPC : MonoBehaviour
{
    public string[] Interaction;
    public string[] Creation;
    private CircleCollider2D CircleClollider;
    private GameEngine Engine;
    private Character[] Characters;

    void Start()
    {
        this.CircleClollider = this.GetComponent<CircleCollider2D>();
        this.Engine = GameObject.FindGameObjectWithTag("Engine").GetComponent<GameEngine>();
        this.CreateCharacter();
    }

    public void CreateCharacter()
    {
        this.Characters = new Character[this.Creation.Length];
        this.Characters = this.Creation.Select((creacion) => this.Engine.Interprete.CreateCharacter(creacion)).ToArray();
    }

    public void Interact()
    {
        this.Engine.Enemies = this.Characters;
        foreach (string i_interaction in this.Interaction)
        {
            this.Engine.Interprete.ExecuteInteraction(i_interaction);
        }
    }
}
