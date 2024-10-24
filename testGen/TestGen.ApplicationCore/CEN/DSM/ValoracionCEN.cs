

using System;
using System.Text;
using System.Collections.Generic;

using TestGen.ApplicationCore.Exceptions;

using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


namespace TestGen.ApplicationCore.CEN.DSM
{
/*
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionRepository _IValoracionRepository;

public ValoracionCEN(IValoracionRepository _IValoracionRepository)
{
        this._IValoracionRepository = _IValoracionRepository;
}

public IValoracionRepository get_IValoracionRepository ()
{
        return this._IValoracionRepository;
}

public int Nuevo (int p_mascotaRecibe, string p_usuarioValora, int p_valor)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();

        if (p_mascotaRecibe != -1) {
                // El argumento p_mascotaRecibe -> Property mascotaRecibe es oid = false
                // Lista de oids id
                valoracionEN.MascotaRecibe = new TestGen.ApplicationCore.EN.DSM.MascotaEN ();
                valoracionEN.MascotaRecibe.Id = p_mascotaRecibe;
        }


        if (p_usuarioValora != null) {
                // El argumento p_usuarioValora -> Property usuarioValora es oid = false
                // Lista de oids id
                valoracionEN.UsuarioValora = new TestGen.ApplicationCore.EN.DSM.UsuarioEN ();
                valoracionEN.UsuarioValora.Email = p_usuarioValora;
        }

        valoracionEN.Valor = p_valor;



        oid = _IValoracionRepository.Nuevo (valoracionEN);
        return oid;
}

public void Modificar (int p_Valoracion_OID, int p_valor)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id = p_Valoracion_OID;
        valoracionEN.Valor = p_valor;
        //Call to ValoracionRepository

        _IValoracionRepository.Modificar (valoracionEN);
}

public void Destruir (int id
                      )
{
        _IValoracionRepository.Destruir (id);
}

public ValoracionEN LeerOID (int id
                             )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionRepository.LeerOID (id);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> LeerTodos (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionRepository.LeerTodos (first, size);
        return list;
}
}
}
