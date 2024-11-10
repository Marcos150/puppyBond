
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

        try
        {
                // Inicia la sesion de transaccion
                CPSession.SessionInitializeTransaction ();

                // Obten el usuario emisor y receptor usando su ID
                usuarioCEN = new UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);
                UsuarioEN emisorEN = usuarioCEN.LeerOID (p_oid);
                UsuarioEN receptorEN = usuarioCEN.LeerOID (receptor);

                // Verificar que el emisor y receptor no sean nulos
                if (emisorEN == null || receptor == null) {
                        throw new Exception ("Emisor o receptor no valido.");
                }

                IList<UsuarioEN> usuariosMatcheadosEmisor = usuarioCEN.ObtenerUsuariosMatcheados(p_oid);

                //Comprueba que el emisor este matcheado con el receptor
                if (!usuariosMatcheadosEmisor.Where(usu => usu.Email == receptor).Any())
                {
                    throw new Exception("El receptor no esta matcheado con el emisor");
                }

                // Crear el mensaje utilizando MensajeCEN
                mensajeCEN = new MensajeCEN (CPSession.UnitRepo.MensajeRepository);
                int mensajeId = mensajeCEN.Nuevo (contenido, emisorEN.Email, receptorEN.Email);

                // Anyadir el mensaje a las listas de mensajes emitidos y recibidos
                MensajeEN mensaje = mensajeCEN.LeerOID (mensajeId);
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
