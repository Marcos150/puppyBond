
using System;
using System.Text;
using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CEN.DSM_Notificacion_enviarCorreo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CEN.DSM
{
public partial class NotificacionCEN
{
public void EnviarCorreo (int p_oid)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CEN.DSM_Notificacion_enviarCorreo) ENABLED START*/

        // Write here your custom code...
        NotificacionEN notificacionEn = _INotificacionRepository.LeerOID (p_oid);

        EmailUtils.SendEmail (notificacionEn.UsuarioRecibe.Email, "¡Tienes una nueva notificación!", notificacionEn.Contenido);
        Console.WriteLine ("Correo de notificación enviado");

        //throw new NotImplementedException ("Method EnviarCorreo() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
