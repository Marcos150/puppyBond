
using System;
using System.Text;
using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CEN.DSM_Mensaje_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CEN.DSM
{
public partial class MensajeCEN
{
public int Nuevo (string p_contenido, string p_emisor, string p_receptor)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CEN.DSM_Mensaje_nuevo_customized) START*/

        MensajeEN mensajeEN = null;

        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Contenido = p_contenido;


        if (p_emisor != null) {
                mensajeEN.Emisor = new TestGen.ApplicationCore.EN.DSM.UsuarioEN ();
                mensajeEN.Emisor.Email = p_emisor;
        }


        if (p_receptor != null) {
                mensajeEN.Receptor = new TestGen.ApplicationCore.EN.DSM.UsuarioEN ();
                mensajeEN.Receptor.Email = p_receptor;
        }

        //Call to MensajeRepository

        oid = _IMensajeRepository.Nuevo (mensajeEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
