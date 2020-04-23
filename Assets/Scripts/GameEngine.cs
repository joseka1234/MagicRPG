using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public enum GameStateMachine
{
    MapState, BattleState
}

public enum BattleStateMachine
{
    Off, CheckTurn, PlayerTurn,
    SelectEnemy, EnemyTurn, CheckBattle
}

public class GameEngine : MonoBehaviour
{
    public GameObject PlayerObject;
    
    [HideInInspector]
    public Character[] Party;
    [HideInInspector]
    public Character[] Enemies;

    public Interprete Interprete;

    public GameStateMachine GameStateMachine;
    public BattleStateMachine BattleStateMachine;

    private Character CurrentCharacterTurn;

    // Start is called before the first frame update
    void Awake()
    {
        GameStateMachine = GameStateMachine.MapState;
        BattleStateMachine = BattleStateMachine.Off;
        this.Interprete = this.GetComponent<Interprete>();
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        this.Party = new Character[] { this.Interprete.CreateCharacter("PLAYER") };
    }
    
    private void OnLevelWasLoaded(int level)
    {
        if (this.BattleStateMachine != BattleStateMachine.Off)
        {
            // TODO: Hacer que se carguen los sprites y tal
            // de los miembros de la party y de los enemigos.
            this.LoadEnemiesSprites();
            this.LoadPartySprites();
            GameObject.Find("AttackButton").GetComponent<Button>().onClick.AddListener(
                () => this.BattleStateMachine = BattleStateMachine.SelectEnemy
            );
        }
    }

    private void LoadEnemiesSprites()
    {
        for (int i = 0; i < this.Enemies.Length; i++)
        {
            Image image = GameObject.Find("Enemy" + i).GetComponent<Image>();
            image.sprite = this.Enemies[i].GetSprite()[6];
            image.color = Color.white;
        }
    }

    private void LoadPartySprites()
    {
        for (int i = 0; i < this.Party.Length; i++)
        {
            Image image = GameObject.Find("Player" + i).GetComponent<Image>();
            image.sprite = this.Party[i].GetSprite()[18];
            image.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameStateMachine)
        {
            case GameStateMachine.MapState:
                // Por aquí nada...
                break;
            case GameStateMachine.BattleState:
                this.ProcessBattle();
                break;
        }
    }

    private void ProcessBattle()
    {
        switch (this.BattleStateMachine)
        {
            case BattleStateMachine.CheckTurn:
                this.CurrentCharacterTurn = this.Party[0];
                this.BattleStateMachine = BattleStateMachine.PlayerTurn;
                break;

            case BattleStateMachine.PlayerTurn:
                break;

            case BattleStateMachine.SelectEnemy:
                this.SelectEnemy();
                break;

            case BattleStateMachine.EnemyTurn:
                break;

            case BattleStateMachine.CheckBattle:
                break;
        }
    }

    private void SelectEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raysastResults);

            Match match = Regex.Match(raysastResults[0].gameObject.name, @"Enemy(\d)", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                this.Attack(CurrentCharacterTurn, this.Enemies[int.Parse(match.Groups[1].Value)]);
            }
        }
    }

    // Char1 ataca a Char2
    public void Attack(Character char1, Character char2)
    {
        Debug.Log(string.Format("{0} a atacado a {1} y le ha hecho {2} puntos de daño.", char1.Nombre, char2.Nombre, char1.Stats.Corte));
    }
}
