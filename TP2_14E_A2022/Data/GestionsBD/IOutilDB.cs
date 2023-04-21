using System.Collections.Generic;
using TP2_14E_A2022.Data.Entites;

namespace TP2_14E_A2022.Data.GestionsBD;

public interface IOutilDB
{
    List<Outils> GetOutils();
    void CreerOutil(Outils outil);
}