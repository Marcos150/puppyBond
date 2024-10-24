

using System;
using System.Text;
using System.Collections.Generic;

using TestGen.ApplicationCore.Exceptions;

using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


namespace TestGen.ApplicationCore.CEN.DSM
{
/*
 *      Definition of the class TiqueSoporteCEN
 *
 */
public partial class TiqueSoporteCEN
{
private ITiqueSoporteRepository _ITiqueSoporteRepository;

public TiqueSoporteCEN(ITiqueSoporteRepository _ITiqueSoporteRepository)
{
        this._ITiqueSoporteRepository = _ITiqueSoporteRepository;
}

public ITiqueSoporteRepository get_ITiqueSoporteRepository ()
{
        return this._ITiqueSoporteRepository;
}

public int Nuevo (string p_usuarioManda, string p_contenido)
{
        TiqueSoporteEN tiqueSoporteEN = null;
        int oid;

        //Initialized TiqueSoporteEN
        tiqueSoporteEN = new TiqueSoporteEN ();

        if (p_usuarioManda != null) {
                // El argumento p_usuarioManda -> Property usuarioManda es oid = false
                // Lista de oids id
                tiqueSoporteEN.UsuarioManda = new TestGen.ApplicationCore.EN.DSM.UsuarioEN ();
                tiqueSoporteEN.UsuarioManda.Email = p_usuarioManda;
        }

        tiqueSoporteEN.Contenido = p_contenido;



        oid = _ITiqueSoporteRepository.Nuevo (tiqueSoporteEN);
        return oid;
}

public void Modificar (int p_TiqueSoporte_OID, string p_contenido)
{
        TiqueSoporteEN tiqueSoporteEN = null;

        //Initialized TiqueSoporteEN
        tiqueSoporteEN = new TiqueSoporteEN ();
        tiqueSoporteEN.Id = p_TiqueSoporte_OID;
        tiqueSoporteEN.Contenido = p_contenido;
        //Call to TiqueSoporteRepository

        _ITiqueSoporteRepository.Modificar (tiqueSoporteEN);
}

public void Destruir (int id
                      )
{
        _ITiqueSoporteRepository.Destruir (id);
}
}
}
