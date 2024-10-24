
using System;
// Definición clase TiqueSoporteEN
namespace TestGen.ApplicationCore.EN.DSM
{
public partial class TiqueSoporteEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuarioManda
 */
private TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioManda;



/**
 *	Atributo contenido
 */
private string contenido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.UsuarioEN UsuarioManda {
        get { return usuarioManda; } set { usuarioManda = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}





public TiqueSoporteEN()
{
}



public TiqueSoporteEN(int id, TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioManda, string contenido
                      )
{
        this.init (Id, usuarioManda, contenido);
}


public TiqueSoporteEN(TiqueSoporteEN tiqueSoporte)
{
        this.init (tiqueSoporte.Id, tiqueSoporte.UsuarioManda, tiqueSoporte.Contenido);
}

private void init (int id
                   , TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioManda, string contenido)
{
        this.Id = id;


        this.UsuarioManda = usuarioManda;

        this.Contenido = contenido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TiqueSoporteEN t = obj as TiqueSoporteEN;
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
