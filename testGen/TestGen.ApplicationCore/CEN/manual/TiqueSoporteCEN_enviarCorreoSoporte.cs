
using System;
using System.Text;
using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CEN.DSM_TiqueSoporte_enviarCorreoSoporte) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CEN.DSM
{
public partial class TiqueSoporteCEN
{
public void EnviarCorreoSoporte (int p_oid)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CEN.DSM_TiqueSoporte_enviarCorreoSoporte) ENABLED START*/

        // Write here your custom code...

        TiqueSoporteEN tiqueSoporteEn = _ITiqueSoporteRepository.ReadOIDDefault (p_oid);

        //TODO: De momento se envia correo a si mismo. Esto se podria cambiar
        EmailUtils.SendEmailToSelf ("Tique de soporte enviado por: " + tiqueSoporteEn.UsuarioManda.Email, tiqueSoporteEn.Contenido);
        Console.WriteLine ("Correo de soporte enviado");

        //throw new NotImplementedException ("Method EnviarCorreoSoporte() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
