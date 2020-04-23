[System.Serializable]
public class Stats
{
    public int MaxVida;
    public int Vida;
    public int MaxMagia;
    public int Magia;
    public int MaxMoral;
    public int Moral;
    public int Corte;
    public int Punzante;
    public int Contundente;
    public int MProyectil;
    public int MChorro;
    public int MCuerpoCuerpo;
    public int Velocidad;

    public Stats(int _Vida, int _Magia, int _Moral, int _Corte,
                int _Punzante, int _Contundente, int _MProyectil,
                int _MChorro, int _MCuerpoCuerpo, int _Velocidad)
    {
        this.MaxVida = _Vida;
        this.Vida = _Vida;
        this.MaxMagia = _Magia;
        this.Magia = _Magia;
        this.MaxMoral = _Moral;
        this.Moral = _Moral;

        this.Corte = _Corte;
        this.Punzante = _Punzante;
        this.Contundente = _Contundente;
        this.MProyectil = _MProyectil;
        this.MChorro = _MChorro;
        this.MCuerpoCuerpo = _MCuerpoCuerpo;
        this.Velocidad = _Velocidad;
    }
}
