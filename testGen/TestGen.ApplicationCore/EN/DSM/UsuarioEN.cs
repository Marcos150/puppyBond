
using System;
// Definición clase UsuarioEN
namespace TestGen.ApplicationCore.EN.DSM
{
public partial class UsuarioEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo disponibilidad
 */
private string disponibilidad;



/**
 *	Atributo mascota
 */
private TestGen.ApplicationCore.EN.DSM.MascotaEN mascota;



/**
 *	Atributo mensajesEmitidos
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensajesEmitidos;



/**
 *	Atributo mensajesRecibidos
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensajesRecibidos;



/**
 *	Atributo valoracionesEnviadas
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.ValoracionEN> valoracionesEnviadas;



/**
 *	Atributo notificacionesRecibidas
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.NotificacionEN> notificacionesRecibidas;



/**
 *	Atributo ubicacion
 */
private string ubicacion;



/**
 *	Atributo tiqueEsDe
 */
private System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.TiqueSoporteEN> tiqueEsDe;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string Disponibilidad {
        get { return disponibilidad; } set { disponibilidad = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.MascotaEN Mascota {
        get { return mascota; } set { mascota = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> MensajesEmitidos {
        get { return mensajesEmitidos; } set { mensajesEmitidos = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> MensajesRecibidos {
        get { return mensajesRecibidos; } set { mensajesRecibidos = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.ValoracionEN> ValoracionesEnviadas {
        get { return valoracionesEnviadas; } set { valoracionesEnviadas = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.NotificacionEN> NotificacionesRecibidas {
        get { return notificacionesRecibidas; } set { notificacionesRecibidas = value;  }
}



public virtual string Ubicacion {
        get { return ubicacion; } set { ubicacion = value;  }
}



public virtual System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.TiqueSoporteEN> TiqueEsDe {
        get { return tiqueEsDe; } set { tiqueEsDe = value;  }
}





public UsuarioEN()
{
        mensajesEmitidos = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.MensajeEN>();
        mensajesRecibidos = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.MensajeEN>();
        valoracionesEnviadas = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.ValoracionEN>();
        notificacionesRecibidas = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.NotificacionEN>();
        tiqueEsDe = new System.Collections.Generic.List<TestGen.ApplicationCore.EN.DSM.TiqueSoporteEN>();
}



public UsuarioEN(string email, string nombre, string apellidos, String pass, string disponibilidad, TestGen.ApplicationCore.EN.DSM.MascotaEN mascota, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensajesEmitidos, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.ValoracionEN> valoracionesEnviadas, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.NotificacionEN> notificacionesRecibidas, string ubicacion, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.TiqueSoporteEN> tiqueEsDe
                 )
{
        this.init (Email, nombre, apellidos, pass, disponibilidad, mascota, mensajesEmitidos, mensajesRecibidos, valoracionesEnviadas, notificacionesRecibidas, ubicacion, tiqueEsDe);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Email, usuario.Nombre, usuario.Apellidos, usuario.Pass, usuario.Disponibilidad, usuario.Mascota, usuario.MensajesEmitidos, usuario.MensajesRecibidos, usuario.ValoracionesEnviadas, usuario.NotificacionesRecibidas, usuario.Ubicacion, usuario.TiqueEsDe);
}

private void init (string email
                   , string nombre, string apellidos, String pass, string disponibilidad, TestGen.ApplicationCore.EN.DSM.MascotaEN mascota, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensajesEmitidos, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.ValoracionEN> valoracionesEnviadas, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.NotificacionEN> notificacionesRecibidas, string ubicacion, System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.TiqueSoporteEN> tiqueEsDe)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Pass = pass;

        this.Disponibilidad = disponibilidad;

        this.Mascota = mascota;

        this.MensajesEmitidos = mensajesEmitidos;

        this.MensajesRecibidos = mensajesRecibidos;

        this.ValoracionesEnviadas = valoracionesEnviadas;

        this.NotificacionesRecibidas = notificacionesRecibidas;

        this.Ubicacion = ubicacion;

        this.TiqueEsDe = tiqueEsDe;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
