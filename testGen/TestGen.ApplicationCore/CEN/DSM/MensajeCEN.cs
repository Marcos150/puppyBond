

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
