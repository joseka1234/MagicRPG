using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;

#region Maquinas Estados
public enum MaquinaEstadosJuego
{
    Mapa, Batalla
}

public enum MaquinaEstadosBatalla
{
    SinBatalla, ComprobarTurno, TurnoJugador,
    SeleccionarEnemigo, TurnoEnemigo,
    ComprobarFinBatalla
}
#endregion

public class GameEngine : MonoBehaviour
{
    public GameObject ObjetoJugador;
    
    [HideInInspector]
    public Personaje[] Party;
    [HideInInspector]
    public Personaje[] Enemigos;

    public Interprete Interprete;

    public MaquinaEstadosJuego MaginaEstadosJuego;
    public MaquinaEstadosBatalla MaquinaEstadosBatalla;

    private ControladorCanvas ControladorCanvas;
    private Personaje PersonajeTurnoActual;

    #region Preload Region
    void Awake()
    {
        MaginaEstadosJuego = MaquinaEstadosJuego.Mapa;
        MaquinaEstadosBatalla = MaquinaEstadosBatalla.SinBatalla;
        this.Interprete = this.GetComponent<Interprete>();
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        this.Party = new Personaje[] { this.Interprete.CrearPersonaje("PLAYER") };
    }

    private void CargarSpritesEnemigos()
    {
        for (int i = 0; i < this.Enemigos.Length; i++)
        {
            Image image = GameObject.Find("Enemy" + i).GetComponent<Image>();
            image.sprite = ControladorPersonaje.GetSprite(this.Enemigos[i])[6];
            image.color = Color.white;
        }
    }

    private void CargarSpritesParty()
    {
        for (int i = 0; i < this.Party.Length; i++)
        {
            Image image = GameObject.Find("Player" + i).GetComponent<Image>();
            image.sprite = ControladorPersonaje.GetSprite(this.Party[i])[18];
            image.color = Color.white;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (this.MaquinaEstadosBatalla != MaquinaEstadosBatalla.SinBatalla)
        {
            this.ControladorCanvas = GameObject.FindGameObjectWithTag("CanvasController").GetComponent<ControladorCanvasCombate>();

            this.CargarSpritesEnemigos();
            this.CargarSpritesParty();
            GameObject.Find("AttackButton").GetComponent<Button>().onClick.AddListener(
                () => this.MaquinaEstadosBatalla = MaquinaEstadosBatalla.SeleccionarEnemigo
            );
        }
    }
    #endregion

    void Update()
    {
        switch (MaginaEstadosJuego)
        {
            case MaquinaEstadosJuego.Mapa:
                // Por aquí nada todavía...
                break;
            case MaquinaEstadosJuego.Batalla:
                this.ProcesarBatalla();
                break;
        }
    }

    #region Battle Region
    private bool Atacando = false;

    private void ProcesarBatalla()
    {
        switch (this.MaquinaEstadosBatalla)
        {
            case MaquinaEstadosBatalla.ComprobarTurno:
                this.PersonajeTurnoActual = this.Party[0];
                this.MaquinaEstadosBatalla = MaquinaEstadosBatalla.TurnoJugador;
                break;

            case MaquinaEstadosBatalla.TurnoJugador:
                this.MostrarMenu();
                break;

            case MaquinaEstadosBatalla.SeleccionarEnemigo:
                if (!Atacando)
                {
                    this.MostrarMensajeBatalla("Selecciona un enemigo");
                    this.SeleccionarEnemigo();
                }
                break;

            case MaquinaEstadosBatalla.TurnoEnemigo:
                this.MostrarMensajeBatalla("¡El enemigo ha atacado!");
                this.MaquinaEstadosBatalla = MaquinaEstadosBatalla.ComprobarTurno;
                break;

            case MaquinaEstadosBatalla.ComprobarFinBatalla:
                break;
        }
    }

    private void SeleccionarEnemigo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            Match match = Regex.Match(raycastResults[0].gameObject.name, @"Enemy(\d)", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                StartCoroutine(this.Atacar(PersonajeTurnoActual, this.Enemigos[int.Parse(match.Groups[1].Value)]));
            }
        }
    }

    // Char1 ataca a Char2
    public IEnumerator Atacar(Personaje char1, Personaje char2)
    {
        // TODO: Implementar aquí el cálculo de daño de un personaje sobre otro
        // teniendo en cuenta el tipo de daño utilizado (más adelante se implementará
        // el sistema de habilidades) y teniendo en cuenta el equipamiento.
        this.Atacando = true;
        this.MostrarMensajeBatalla(
            string.Format("{0} a atacado a {1} y le ha hecho {2} puntos de daño.\nPulsa A para continuar",
                            char1.Nombre, char2.Nombre, char1.Stats.Corte)
        );
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.A));
        this.MaquinaEstadosBatalla = MaquinaEstadosBatalla.ComprobarTurno;
        this.Atacando = false;
    }

    private void MostrarMensajeBatalla(string _Mensaje)
    {
        ControladorCanvasCombate ccc = this.ControladorCanvas as ControladorCanvasCombate;
        ccc.Botones.SetActive(false);
        ccc.Mensajes.SetActive(true);
        ccc.SetMensaje(_Mensaje);
    }

    private void MostrarMenu()
    {
        ControladorCanvasCombate ccc = this.ControladorCanvas as ControladorCanvasCombate;
        ccc.Botones.SetActive(true);
        ccc.Mensajes.SetActive(false);
    }
    #endregion
}
