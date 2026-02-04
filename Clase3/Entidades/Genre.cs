using System;
using System.Collections.Generic;

namespace ConexionALaBaseDeDatos.Entidades;

public partial class Genre
{
    public int GenreId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
