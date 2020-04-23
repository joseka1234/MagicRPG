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
    public int DefCorte;
    public int Punzante;
    public int DefPunzante;
    public int Contundente;
    public int DefContundente;
    public int MProyectil;
    public int DefMProyectil;
    public int MChorro;
    public int DefMChorro;
    public int MCuerpoCuerpo;
    public int DefMCuerpoCuerpo;
    public int Velocidad;

    public Stats(int _Vida, int _Magia, int _Moral, int _Corte, int _DefCorte,
                int _Punzante, int _DefPunzante, int _Contundente, int _DefContundente,
                int _MProyectil, int _DefMProyectil, int _MChorro, int _DefMChorro,
                int _MCuerpoCuerpo, int _DefMCuerpoCuerpo, int _Velocidad)
    {
        this.MaxVida = _Vida;
        this.Vida = _Vida;
        this.MaxMagia = _Magia;
        this.Magia = _Magia;
        this.MaxMoral = _Moral;
        this.Moral = _Moral;

        this.Corte = _Corte;
        this.DefCorte = _DefCorte;
        this.Punzante = _Punzante;
        this.DefPunzante = _DefPunzante;
        this.Contundente = _Contundente;
        this.DefContundente = _DefContundente;
        this.MProyectil = _MProyectil;
        this.DefMProyectil = _DefMProyectil;
        this.MChorro = _MChorro;
        this.DefMChorro = _DefMChorro;
        this.MCuerpoCuerpo = _MCuerpoCuerpo;
        this.DefMCuerpoCuerpo = _DefMCuerpoCuerpo;
        this.Velocidad = _Velocidad;
    }
}
