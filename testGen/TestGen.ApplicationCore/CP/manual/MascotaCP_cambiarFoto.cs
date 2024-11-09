
using System;
using System.Text;

using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CEN.DSM;



/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CP.DSM_Mascota_cambiarFoto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CP.DSM
{
public partial class MascotaCP : GenericBasicCP
{
public void CambiarFoto (int p_oid, string imagen)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CP.DSM_Mascota_cambiarFoto) ENABLED START*/

         MascotaCEN mascotaCEN = null;

            try
            {
                // Iniciar la transacción
                CPSession.SessionInitializeTransaction();
                mascotaCEN = new MascotaCEN(CPSession.UnitRepo.MascotaRepository);

                // Obtener la mascota por su ID
                MascotaEN mascota = mascotaCEN.LeerOID(p_oid);
                if (mascota == null)
                {
                    throw new Exception("Mascota no encontrada");
                }

                // Asignar la nueva foto a la mascota utilizando el método Modificar
                mascotaCEN.Modificar(
                    p_Mascota_OID: p_oid,
                    p_nombre: mascota.Nombre,
                    p_raza: mascota.Raza,
                    p_sexo: mascota.Sexo,
                    p_vacunacion: mascota.Vacunacion,
                    p_tamanyo: mascota.Tamanyo,
                    p_edad: mascota.Edad,
                    p_descripcion: mascota.Descripcion,
                    p_valoracionMedia: mascota.ValoracionMedia,
                    p_imagen: imagen // Aquí se asigna la nueva imagen
                );

                // Confirmar la transacción
                CPSession.Commit();
            }
            catch (Exception ex)
            {
                // Revertir la transacción en caso de error
                CPSession.RollBack();
                throw ex;
            }
            finally
            {
                // Cerrar la sesión
                CPSession.SessionClose();
            }


        /*PROTECTED REGION END*/
}
}
}
