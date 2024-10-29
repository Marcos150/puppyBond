
using System;
// Definición clase MascotaEN
namespace TestGen.ApplicationCore.EN.DSM
{
public partial class MascotaEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo raza
 */
private string raza;



/**
 *	Atributo sexo
 */
private TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum sexo;



/**
 *	Atributo vacunacion
 */
private string vacunacion;



/**
 *	Atributo tamanyo
 */
private TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum tamanyo;



/**
 *	Atributo edad
 */
private string edad;



/**
 *	Atributo duenyo
 */
private TestGen.ApplicationCore.EN.DSM.UsuarioEN duenyo;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo matchEnviados
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MatchEN> matchEnviados;



/**
 *	Atributo matchRecibidos
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MatchEN> matchRecibidos;



/**
 *	Atributo valoracionesRecibidas
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.ValoracionEN> valoracionesRecibidas;



/**
 *	Atributo valoracionMedia
 */
private double valoracionMedia;



/**
 *	Atributo imagen
 */
private string imagen;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Raza {
        get { return raza; } set { raza = value;  }
}



public virtual TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum Sexo {
        get { return sexo; } set { sexo = value;  }
}



public virtual string Vacunacion {
        get { return vacunacion; } set { vacunacion = value;  }
}



public virtual TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum Tamanyo {
        get { return tamanyo; } set { tamanyo = value;  }
}



public virtual string Edad {
        get { return edad; } set { edad = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.UsuarioEN Duenyo {
        get { return duenyo; } set { duenyo = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MatchEN> MatchEnviados {
        get { return matchEnviados; } set { matchEnviados = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MatchEN> MatchRecibidos {
        get { return matchRecibidos; } set { matchRecibidos = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.ValoracionEN> ValoracionesRecibidas {
        get { return valoracionesRecibidas; } set { valoracionesRecibidas = value;  }
}



public virtual double ValoracionMedia {
        get { return valoracionMedia; } set { valoracionMedia = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}





public MascotaEN()
{
        matchEnviados = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.MatchEN>();
        matchRecibidos = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.MatchEN>();
        valoracionesRecibidas = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.ValoracionEN>();
}



public MascotaEN(int id, string nombre, string raza, TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum sexo, string vacunacion, TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum tamanyo, string edad, TestGen.ApplicationCore.EN.DSM.UsuarioEN duenyo, string descripcion, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MatchEN> matchEnviados, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MatchEN> matchRecibidos, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.ValoracionEN> valoracionesRecibidas, double valoracionMedia, string imagen
                 )
{
        this.init (Id, nombre, raza, sexo, vacunacion, tamanyo, edad, duenyo, descripcion, matchEnviados, matchRecibidos, valoracionesRecibidas, valoracionMedia, imagen);
}


public MascotaEN(MascotaEN mascota)
{
        this.init (mascota.Id, mascota.Nombre, mascota.Raza, mascota.Sexo, mascota.Vacunacion, mascota.Tamanyo, mascota.Edad, mascota.Duenyo, mascota.Descripcion, mascota.MatchEnviados, mascota.MatchRecibidos, mascota.ValoracionesRecibidas, mascota.ValoracionMedia, mascota.Imagen);
}

private void init (int id
                   , string nombre, string raza, TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum sexo, string vacunacion, TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum tamanyo, string edad, TestGen.ApplicationCore.EN.DSM.UsuarioEN duenyo, string descripcion, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MatchEN> matchEnviados, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MatchEN> matchRecibidos, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.ValoracionEN> valoracionesRecibidas, double valoracionMedia, string imagen)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Raza = raza;

        this.Sexo = sexo;

        this.Vacunacion = vacunacion;

        this.Tamanyo = tamanyo;

        this.Edad = edad;

        this.Duenyo = duenyo;

        this.Descripcion = descripcion;

        this.MatchEnviados = matchEnviados;

        this.MatchRecibidos = matchRecibidos;

        this.ValoracionesRecibidas = valoracionesRecibidas;

        this.ValoracionMedia = valoracionMedia;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MascotaEN t = obj as MascotaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
