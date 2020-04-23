using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        switch(GameStateMachine)
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
                this.BattleStateMachine = BattleStateMachine.PlayerTurn;
                break;

            case BattleStateMachine.PlayerTurn:
                break;

            case BattleStateMachine.SelectEnemy:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                }
                break;

            case BattleStateMachine.EnemyTurn:
                break;

            case BattleStateMachine.CheckBattle:
                break;
        }
    }

    // Char1 ataca a Char2
    public void Attack(Character char1, Character char2)
    {
        
    }
}
