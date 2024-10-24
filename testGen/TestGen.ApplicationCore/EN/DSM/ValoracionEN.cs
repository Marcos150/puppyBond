
using System;
// Definición clase ValoracionEN
namespace TestGen.ApplicationCore.EN.DSM
{
public partial class ValoracionEN
{
/**
 *	Atributo mascotaRecibe
 */
private TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaRecibe;



/**
 *	Atributo usuarioValora
 */
private TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioValora;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo valor
 */
private int valor;






public virtual TestGen.ApplicationCore.EN.DSM.MascotaEN MascotaRecibe {
        get { return mascotaRecibe; } set { mascotaRecibe = value;  }
}



public virtual TestGen.ApplicationCore.EN.DSM.UsuarioEN UsuarioValora {
        get { return usuarioValora; } set { usuarioValora = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Valor {
        get { return valor; } set { valor = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaRecibe, TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioValora, int valor
                    )
{
        this.init (Id, mascotaRecibe, usuarioValora, valor);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.Id, valoracion.MascotaRecibe, valoracion.UsuarioValora, valoracion.Valor);
}

private void init (int id
                   , TestGen.ApplicationCore.EN.DSM.MascotaEN mascotaRecibe, TestGen.ApplicationCore.EN.DSM.UsuarioEN usuarioValora, int valor)
{
        this.Id = id;


        this.MascotaRecibe = mascotaRecibe;

        this.UsuarioValora = usuarioValora;

        this.Valor = valor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
