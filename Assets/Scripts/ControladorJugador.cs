using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public float Velocidad = 1f;
    private BoxCollider2D Colision;
    private const string NPC_TAG = "NPC";
    private GameObject Interactable;
    public bool MovimientoBloqueado;

    // Start is called before the first frame update
    void Start()
    {
        this.Colision = this.GetComponent<BoxCollider2D>();
        this.Interactable = null;
        this.MovimientoBloqueado = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.Mover();
        this.Interactuar();
    }

    private void Mover()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        this.transform.position += (move.normalized * Velocidad) / 100;
    }

    private void Interactuar()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (this.Interactable != null)
            {
                switch (this.Interactable.tag)
                {
                    case NPC_TAG:
                        this.Interactable.GetComponent<NPC>().Interactuar();
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Interactable = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.Interactable = null;
    }
}
