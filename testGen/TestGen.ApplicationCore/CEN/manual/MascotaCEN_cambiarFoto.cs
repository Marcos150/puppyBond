
using System;
using System.Text;
using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CP.DSM;


/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CEN.DSM_Mascota_cambiarFoto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CEN.DSM
{
public partial class MascotaCEN
{
public void CambiarFoto (int p_oid, string imagen)
{
            /*PROTECTED REGION ID(TestGen.ApplicationCore.CEN.DSM_Mascota_cambiarFoto) ENABLED START*/

            // Obtener la mascota por su ID
                MascotaEN mascota = LeerOID (p_oid);
                if (mascota == null) {
                        throw new Exception ("Mascota no encontrada");
                }

            // Asignar la nueva foto a la mascota utilizando el metodo Modificar

                Modificar (
                     p_Mascota_OID: p_oid,
                     p_nombre: mascota.Nombre,
                     p_raza: mascota.Raza,
                     p_sexo: mascota.Sexo,
                     p_vacunacion: mascota.Vacunacion,
                     p_tamanyo: mascota.Tamanyo,
                     p_edad: mascota.Edad,
                     p_descripcion: mascota.Descripcion,
                     p_imagen: imagen                    // Aqui se asigna la nueva imagen
                        );


        /*PROTECTED REGION END*/
}
}
}
