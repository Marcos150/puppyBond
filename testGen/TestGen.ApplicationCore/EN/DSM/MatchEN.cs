
using System;
// Definición clase MatchEN
namespace TestGen.ApplicationCore.EN.DSM
{
public partial class MatchEN
{
/**
 *	Atributo estado
 */
private TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum estado;



/**
 *	Atributo mascotaEnvia
 */
private TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaEnvia;



/**
 *	Atributo mascotaRecibe
 */
private TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaRecibe;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo notificacionesEnviadasMatch
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.NotificacionEN> notificacionesEnviadasMatch;



/**
 *	Atributo ubicacion
 */
private string ubicacion;






public virtual TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.MascotaEN MascotaEnvia {
        get { return mascotaEnvia; } set { mascotaEnvia = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.MascotaEN MascotaRecibe {
        get { return mascotaRecibe; } set { mascotaRecibe = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.NotificacionEN> NotificacionesEnviadasMatch {
        get { return notificacionesEnviadasMatch; } set { notificacionesEnviadasMatch = value;  }
}



public virtual string Ubicacion {
        get { return ubicacion; } set { ubicacion = value;  }
}





public MatchEN()
{
        notificacionesEnviadasMatch = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.NotificacionEN>();
}



public MatchEN(int id, TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum estado, TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaEnvia, TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaRecibe, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.NotificacionEN> notificacionesEnviadasMatch, string ubicacion
               )
{
        this.init (Id, estado, mascotaEnvia, mascotaRecibe, notificacionesEnviadasMatch, ubicacion);
}


public MatchEN(MatchEN match)
{
        this.init (match.Id, match.Estado, match.MascotaEnvia, match.MascotaRecibe, match.NotificacionesEnviadasMatch, match.Ubicacion);
}

private void init (int id
                   , TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum estado, TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaEnvia, TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaRecibe, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.NotificacionEN> notificacionesEnviadasMatch, string ubicacion)
{
        this.Id = id;


        this.Estado = estado;

        this.MascotaEnvia = mascotaEnvia;

        this.MascotaRecibe = mascotaRecibe;

        this.NotificacionesEnviadasMatch = notificacionesEnviadasMatch;

        this.Ubicacion = ubicacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MatchEN t = obj as MatchEN;
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
