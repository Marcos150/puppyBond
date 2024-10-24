

using System;
using System.Text;
using System.Collections.Generic;

using TestGen.ApplicationCore.Exceptions;

using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


namespace TestGen.ApplicationCore.CEN.DSM
{
/*
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeRepository _IMensajeRepository;

public MensajeCEN(IMensajeRepository _IMensajeRepository)
{
        this._IMensajeRepository = _IMensajeRepository;
}

public IMensajeRepository get_IMensajeRepository ()
{
        return this._IMensajeRepository;
}

public int Nuevo (string p_contenido, string p_emisor, string p_receptor, Nullable<DateTime> p_fecha)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Contenido = p_contenido;


        if (p_emisor != null) {
                // El argumento p_emisor -> Property emisor es oid = false
                // Lista de oids id
                mensajeEN.Emisor = new TestGen.ApplicationCore.EN.DSM.UsuarioEN ();
                mensajeEN.Emisor.Email = p_emisor;
        }


        if (p_receptor != null) {
                // El argumento p_receptor -> Property receptor es oid = false
                // Lista de oids id
                mensajeEN.Receptor = new TestGen.ApplicationCore.EN.DSM.UsuarioEN ();
                mensajeEN.Receptor.Email = p_receptor;
        }

        mensajeEN.Fecha = p_fecha;



        oid = _IMensajeRepository.Nuevo (mensajeEN);
        return oid;
}

public void Modificar (int p_Mensaje_OID, string p_contenido, Nullable<DateTime> p_fecha)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.Contenido = p_contenido;
        mensajeEN.Fecha = p_fecha;
        //Call to MensajeRepository

        _IMensajeRepository.Modificar (mensajeEN);
}

public void Destruir (int id
                      )
{
        _IMensajeRepository.Destruir (id);
}

public MensajeEN LeerOID (int id
                          )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeRepository.LeerOID (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> LeerTodos (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeRepository.LeerTodos (first, size);
        return list;
}
}
}
