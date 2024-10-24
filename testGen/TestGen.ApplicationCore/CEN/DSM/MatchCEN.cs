

using System;
using System.Text;
using System.Collections.Generic;

using TestGen.ApplicationCore.Exceptions;

using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


namespace TestGen.ApplicationCore.CEN.DSM
{
/*
 *      Definition of the class MatchCEN
 *
 */
public partial class MatchCEN
{
private IMatchRepository _IMatchRepository;

public MatchCEN(IMatchRepository _IMatchRepository)
{
        this._IMatchRepository = _IMatchRepository;
}

public IMatchRepository get_IMatchRepository ()
{
        return this._IMatchRepository;
}

public void Modificar (int p_Match_OID, TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum p_estado, string p_ubicacion)
{
        MatchEN matchEN = null;

        //Initialized MatchEN
        matchEN = new MatchEN ();
        matchEN.Id = p_Match_OID;
        matchEN.Estado = p_estado;
        matchEN.Ubicacion = p_ubicacion;
        //Call to MatchRepository

        _IMatchRepository.Modificar (matchEN);
}

public void Destruir (int id
                      )
{
        _IMatchRepository.Destruir (id);
}

public MatchEN LeerOID (int id
                        )
{
        MatchEN matchEN = null;

        matchEN = _IMatchRepository.LeerOID (id);
        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> LeerTodos (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> list = null;

        list = _IMatchRepository.LeerTodos (first, size);
        return list;
}
}
}
