
using System;
// Definición clase MensajeEN
namespace TestGen.ApplicationCore.EN.DSM
{
public partial class MensajeEN
{
/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo emisor
 */
private TestGen.ApplicationCore.EN.DSM.UsuarioEN emisor;



/**
 *	Atributo receptor
 */
private TestGen.ApplicationCore.EN.DSM.UsuarioEN receptor;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo notificacionesEnviadaMsj
 */
private TestGen.ApplicationCore.EN.DSM.NotificacionEN notificacionesEnviadaMsj;






public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.UsuarioEN Emisor {
        get { return emisor; } set { emisor = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.UsuarioEN Receptor {
        get { return receptor; } set { receptor = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.NotificacionEN NotificacionesEnviadaMsj {
        get { return notificacionesEnviadaMsj; } set { notificacionesEnviadaMsj = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int id, string contenido, TestGen.ApplicationCore.EN.DSM.UsuarioEN emisor, TestGen.ApplicationCore.EN.DSM.UsuarioEN receptor, Nullable<DateTime> fecha, TestGen.ApplicationCore.EN.DSM.NotificacionEN notificacionesEnviadaMsj
                 )
{
        this.init (Id, contenido, emisor, receptor, fecha, notificacionesEnviadaMsj);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (mensaje.Id, mensaje.Contenido, mensaje.Emisor, mensaje.Receptor, mensaje.Fecha, mensaje.NotificacionesEnviadaMsj);
}

private void init (int id
                   , string contenido, TestGen.ApplicationCore.EN.DSM.UsuarioEN emisor, TestGen.ApplicationCore.EN.DSM.UsuarioEN receptor, Nullable<DateTime> fecha, TestGen.ApplicationCore.EN.DSM.NotificacionEN notificacionesEnviadaMsj)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Emisor = emisor;

        this.Receptor = receptor;

        this.Fecha = fecha;

        this.NotificacionesEnviadaMsj = notificacionesEnviadaMsj;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
