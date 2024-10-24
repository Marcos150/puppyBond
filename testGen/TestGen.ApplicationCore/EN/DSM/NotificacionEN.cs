
using System;
// Definición clase NotificacionEN
namespace TestGen.ApplicationCore.EN.DSM
{
public partial class NotificacionEN
{
/**
 *	Atributo matchEnvia
 */
private TestGen.ApplicationCore.EN.DSM.MatchEN matchEnvia;



/**
 *	Atributo usuarioRecibe
 */
private TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioRecibe;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo mensaje
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensaje;



/**
 *	Atributo contenido
 */
private string contenido;






public virtual TestGen.ApplicationCore.EN.DSM.MatchEN MatchEnvia {
        get { return matchEnvia; } set { matchEnvia = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.UsuarioEN UsuarioRecibe {
        get { return usuarioRecibe; } set { usuarioRecibe = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}





public NotificacionEN()
{
        mensaje = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.MensajeEN>();
}



public NotificacionEN(int id, TestGen.ApplicationCore.EN.DSM.MatchEN matchEnvia, TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioRecibe, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensaje, string contenido
                      )
{
        this.init (Id, matchEnvia, usuarioRecibe, mensaje, contenido);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (notificacion.Id, notificacion.MatchEnvia, notificacion.UsuarioRecibe, notificacion.Mensaje, notificacion.Contenido);
}

private void init (int id
                   , TestGen.ApplicationCore.EN.DSM.MatchEN matchEnvia, TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioRecibe, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensaje, string contenido)
{
        this.Id = id;


        this.MatchEnvia = matchEnvia;

        this.UsuarioRecibe = usuarioRecibe;

        this.Mensaje = mensaje;

        this.Contenido = contenido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
