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

    public Personaje CrearPersonaje(string Name)
    {
        return JsonUtility.FromJson<Personaje>(File.ReadAllText(ENEMY_PATH + Name + ".json"));
    }

    public Enemigo CrearEnemigo(string Name)
    {
        return JsonUtility.FromJson<Enemigo>(File.ReadAllText(ENEMY_PATH + Name + ".json"));
    }

    public void EjecutarInteraccion(string Order)
    {
        /*
        *  Comandos del intérprete
        *  BATLE -> Carga la escena de batalla con los personajes que se estén utilizando en este momento.
        *  TEST CHARACTER -> Crea un ejemplo de personaje en formato JSON
        *  TEXT 'Texto' -> Imprime el texto entre comillas simples en pantalla a modo de conversación.
        */

        if (Regex.IsMatch(Order, @"BATTLE", RegexOptions.IgnoreCase))
        {
            this.Engine.MaginaEstadosJuego = MaquinaEstadosJuego.Batalla;
            this.Engine.MaquinaEstadosBatalla = MaquinaEstadosBatalla.ComprobarTurno;
            SceneManager.LoadSceneAsync("BattleScene");
        }
        else if (Regex.IsMatch(Order, @"TEST CHARACTER", RegexOptions.IgnoreCase))
        {
            Equipo espadaWapa = new Equipo("Espada", "Espadota toa wapa",
                                                new Estadisticas(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                                                TipoEquipo.Arma, "");
            Personaje testCharacter = new Personaje(
                "Carlos", "Chara2", 1, 0, new Estadisticas(100, 100, 20, 20, 10, 10, 10,
                10, 10, 10, 10, 10, 10, 10, 10, 5), new List<Equipo>() { espadaWapa },
                new Elemento[] { Elemento.Agua, Elemento.Aire }, new Elemento[] { Elemento.Rayo, Elemento.Planta },
                new Habilidad[] { new Habilidad(Elemento.Fuego, TipoAtaque.Corte, 100) }
            );

            Enemigo testEnemy = new Enemigo(
                "Enemigo", "Chara1", 1, 0, new Estadisticas(100, 100, 20, 20, 10, 10, 10,
                10, 10, 10, 10, 10, 10, 10, 10, 5), new List<Equipo>() { espadaWapa },
                new Elemento[] { Elemento.Agua, Elemento.Aire }, new Elemento[] { Elemento.Rayo, Elemento.Planta },
                new Habilidad[] { new Habilidad(Elemento.Fuego, TipoAtaque.Corte, 100) },
                new Dictionary<Objeto, float>() { { espadaWapa, 0.8f } }, 100, TiposIA.SIN_IA
            );

            File.WriteAllText(ENEMY_PATH + "PLAYER.json", JsonUtility.ToJson(testCharacter));
            File.WriteAllText(ENEMY_PATH + "ENEMIGO.json", JsonUtility.ToJson(testEnemy));
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

    public void EjecutarInteraccionEqupo()
    {
        // TODO: Esta parte se encargará de ejecutar las
        // acciones extras que proporcionen los elementos equipados.
    }
}
