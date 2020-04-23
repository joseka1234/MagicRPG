using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Interprete : MonoBehaviour
{
    private GameEngine Engine;

    private const string ENEMY_PATH = "Assets/Enemies/";

    private void Start()
    {
        this.Engine = GameObject.FindGameObjectWithTag("Engine").GetComponent<GameEngine>();
    }

    public Character CreateCharacter(string Order)
    {
        return JsonUtility.FromJson<Character>(File.ReadAllText(ENEMY_PATH + Order + ".json"));
    }

    public void ExecuteInteraction(string Order)
    {
        /**
        *  Comandos del intérprete
        *  BATLE -> Carga la escena de batalla con los personajes que se estén utilizando en este momento.
        *  TEST CHARACTER -> Crea un ejemplo de personaje en formato JSON
        *  TEXT 'Texto' -> Imprime el texto entre comillas simples en pantalla a modo de conversación.
        */

        if (Regex.IsMatch(Order, @"BATTLE", RegexOptions.IgnoreCase))
        {
            this.Engine.GameStateMachine = GameStateMachine.BattleState;
            this.Engine.BattleStateMachine = BattleStateMachine.CheckTurn;
            SceneManager.LoadSceneAsync("BattleScene");
        }
        else if (Regex.IsMatch(Order, @"TEST CHARACTER", RegexOptions.IgnoreCase))
        {
            Character testCharacter = new Character(
                "Carlos", "Chara2", new Stats(100, 100, 20, 20, 10, 10, 10,
                10, 10, 10, 10, 10, 10, 10, 10, 5), new List<Equipo>() { new Equipo("Espada", "Espadota toa wapa",
                TipoEquipo.Arma, new Stats(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0), "") },
                new Elemento[] { Elemento.Agua, Elemento.Aire }, new Elemento[] { Elemento.Rayo, Elemento.Planta },
                new Habilidad[] { new Habilidad(Elemento.Fuego, Tipo.Corte, 100) }
            );

            File.WriteAllText(ENEMY_PATH + "PLAYER.json", JsonUtility.ToJson(testCharacter));
        }
        else if (Regex.IsMatch(Order, @"TEXT\s*\'.*\'", RegexOptions.IgnoreCase))
        {
            Debug.Log(Regex.Match(Order, @"TEXT\s*\'(.*)\'", RegexOptions.IgnoreCase).Groups[1]);
        }
        else
        {
            Debug.LogError("Comando Desconocido: " + Order);
        }
    }

    public void InterpretarCaracteristicasEquipo()
    {
        // TODO: Esta parte se encargará de ejecutar las
        // acciones extras que proporcionen los elementos equipados.
    }
}
