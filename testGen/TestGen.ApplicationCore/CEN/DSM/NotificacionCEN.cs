

using System;
using System.Text;
using System.Collections.Generic;

using TestGen.ApplicationCore.Exceptions;

using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


namespace TestGen.ApplicationCore.CEN.DSM
{
/*
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionRepository _INotificacionRepository;

public NotificacionCEN(INotificacionRepository _INotificacionRepository)
{
        this._INotificacionRepository = _INotificacionRepository;
}

public INotificacionRepository get_INotificacionRepository ()
{
        return this._INotificacionRepository;
}

public int Nuevo (int p_matchEnvia, string p_usuarioRecibe, string p_contenido)
{
        NotificacionEN notificacionEN = null;
        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();

        if (p_matchEnvia != -1) {
                // El argumento p_matchEnvia -> Property matchEnvia es oid = false
                // Lista de oids id
                notificacionEN.MatchEnvia = new TestGen.ApplicationCore.EN.DSM.MatchEN ();
                notificacionEN.MatchEnvia.Id = p_matchEnvia;
        }


        if (p_usuarioRecibe != null) {
                // El argumento p_usuarioRecibe -> Property usuarioRecibe es oid = false
                // Lista de oids id
                notificacionEN.UsuarioRecibe = new TestGen.ApplicationCore.EN.DSM.UsuarioEN ();
                notificacionEN.UsuarioRecibe.Email = p_usuarioRecibe;
        }

        notificacionEN.Contenido = p_contenido;



        oid = _INotificacionRepository.Nuevo (notificacionEN);
        return oid;
}

public void Modificar (int p_Notificacion_OID, string p_contenido)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Contenido = p_contenido;
        //Call to NotificacionRepository

        _INotificacionRepository.Modificar (notificacionEN);
}

public void Destruir (int id
                      )
{
        _INotificacionRepository.Destruir (id);
}

public NotificacionEN LeerOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionRepository.LeerOID (id);
        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> LeerTodos (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionRepository.LeerTodos (first, size);
        return list;
}
}
}
