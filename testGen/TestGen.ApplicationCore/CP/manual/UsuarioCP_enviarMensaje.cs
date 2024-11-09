
using System;
using System.Text;

using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CEN.DSM;



/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CP.DSM_Usuario_enviarMensaje) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CP.DSM
{
    public partial class UsuarioCP : GenericBasicCP
    {
        public void EnviarMensaje(string p_oid, UsuarioEN receptor, string contenido)
        {
            /*PROTECTED REGION ID(TestGen.ApplicationCore.CP.DSM_Usuario_enviarMensaje) ENABLED START*/

            UsuarioCEN usuarioCEN = null;
            MensajeCEN mensajeCEN = null;

            try
            {
                // Inicia la sesión de transacción
                CPSession.SessionInitializeTransaction();

                // Obtén el usuario emisor usando su ID
                usuarioCEN = new UsuarioCEN(CPSession.UnitRepo.UsuarioRepository);
                UsuarioEN emisor = usuarioCEN.LeerOID(p_oid);

                // Verificar que el emisor y receptor no sean nulos
                if (emisor == null || receptor == null)
                {
                    throw new Exception("Emisor o receptor no válido.");
                }

                // Crear el mensaje utilizando MensajeCEN
                mensajeCEN = new MensajeCEN(CPSession.UnitRepo.MensajeRepository);
                int mensajeId = mensajeCEN.Nuevo(contenido, emisor.Email, receptor.Email);

                // Añadir el mensaje a las listas de mensajes emitidos y recibidos
                MensajeEN mensaje = mensajeCEN.LeerOID(mensajeId);
                emisor.MensajesEmitidos.Add(mensaje);
                receptor.MensajesRecibidos.Add(mensaje);

                // Guardar cambios
                CPSession.Commit();
            }
            catch (Exception ex)
            {
                CPSession.RollBack();
                throw ex;
            }
            finally
            {
                CPSession.SessionClose();
            }


            /*PROTECTED REGION END*/
        }
    }
}
