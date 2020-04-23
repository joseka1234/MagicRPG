using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed = 1f;
    private BoxCollider2D Collider;
    private const string NPC_TAG = "NPC";
    private GameObject Interactable;

    // Start is called before the first frame update
    void Start()
    {
        this.Collider = this.GetComponent<BoxCollider2D>();
        this.Interactable = null;
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.Interact();
    }

    private void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        this.transform.position += (move.normalized * Speed) / 100;
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (this.Interactable != null)
            {
                switch (this.Interactable.tag)
                {
                    case NPC_TAG:
                        this.Interactable.GetComponent<NPC>().Interact();
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
