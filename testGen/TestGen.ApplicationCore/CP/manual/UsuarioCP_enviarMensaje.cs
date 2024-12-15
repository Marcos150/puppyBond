
using System;
using System.Text;

using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CEN.DSM;



/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CP.DSM_Usuario_enviarMensaje) ENABLED START*/
//  references to other libraries

using System.Linq;

/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CP.DSM
{
public partial class UsuarioCP : GenericBasicCP
{
public void EnviarMensaje (string p_oid, string receptor, string contenido)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CP.DSM_Usuario_enviarMensaje) ENABLED START*/

        UsuarioCEN usuarioCEN = null;
        MensajeCEN mensajeCEN = null;
        NotificacionCEN notificacionCEN = null;

        try
        {
                // Inicia la sesion de transaccion
                CPSession.SessionInitializeTransaction ();

                // Obten el usuario emisor y receptor usando su ID
                usuarioCEN = new UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);
                notificacionCEN = new NotificacionCEN (CPSession.UnitRepo.NotificacionRepository);
                UsuarioEN emisorEN = usuarioCEN.LeerOID (p_oid);
                UsuarioEN receptorEN = usuarioCEN.LeerOID (receptor);


                // Verificar que el emisor y receptor no sean nulos
                if (emisorEN == null || receptor == null) {
                        throw new Exception ("Emisor o receptor no valido.");
                }

                IList<UsuarioEN> usuariosMatcheadosEmisor = usuarioCEN.ObtenerUsuariosMatcheados (p_oid);

                // Crear el mensaje utilizando MensajeCEN
                mensajeCEN = new MensajeCEN (CPSession.UnitRepo.MensajeRepository);
                int mensajeId = mensajeCEN.Nuevo (contenido, emisorEN.Email, receptorEN.Email);

                MensajeEN mensaje = mensajeCEN.LeerOID (mensajeId);

                int idNotif = notificacionCEN.Nuevo (receptorEN.Email, "Tienes un mensaje de:<br>" + emisorEN.Nombre);
                NotificacionEN notif = notificacionCEN.LeerOID (idNotif);
                notif.Mensaje = mensaje;

                //Si hace mas de 3 dias desde el ultimo mensaje, enviar correo
                if (DateTime.Now - receptorEN.MensajesRecibidos.Where (msg => msg.Emisor.Email == emisorEN.Email).Last ().Fecha > TimeSpan.FromDays (3)) {
                        notificacionCEN.EnviarCorreo (idNotif);
                }

                // Anyadir el mensaje a las listas de mensajes emitidos y recibidos
                emisorEN.MensajesEmitidos.Add (mensaje);
                receptorEN.MensajesRecibidos.Add (mensaje);

                // Guardar cambios
                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
