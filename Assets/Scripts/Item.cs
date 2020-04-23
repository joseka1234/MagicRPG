using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    string Nombre;
    string Descripcion;
    Stats Incrementos;

    public Item(string _Nombre, string _Descripcion, Stats _Incrementos)
    {
        this.Nombre = _Nombre;
        this.Descripcion = _Descripcion;
        this.Incrementos = _Incrementos;
    }
}
