
using System;
using System.Text;

using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CEN.DSM;



/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CP.DSM_Usuario_ponerValoracion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CP.DSM
{
public partial class UsuarioCP : GenericBasicCP
{
public void PonerValoracion (string p_oid, int valor, int oid_mascota)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CP.DSM_Usuario_ponerValoracion) ENABLED START*/

        UsuarioCEN usuarioCEN = null;
        MascotaCEN mascotaCEN = null;
        ValoracionCEN valoracionCEN = null;

        try
        {
                // Inicializar transaccion
                CPSession.SessionInitializeTransaction ();

                // Crear instancias de los CEN necesarios
                usuarioCEN = new UsuarioCEN (CPSession.UnitRepo.UsuarioRepository);
                mascotaCEN = new MascotaCEN (CPSession.UnitRepo.MascotaRepository);
                valoracionCEN = new ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);

                // Obtener el usuario y la mascota a partir de sus OID
                UsuarioEN usuario = usuarioCEN.LeerOID (p_oid);
                MascotaEN mascota = mascotaCEN.LeerOID (oid_mascota);

                // Validar que ambos existan
                if (usuario == null) {
                        throw new Exception ("Usuario no encontrado");
                }

                if (mascota == null) {
                        throw new Exception ("Mascota no encontrada");
                }

                // Validar que el valor de la valoracion esta dentro de un rango adecuado (por ejemplo, 1 a 5)
                if (valor < 1 || valor > 10) {
                        throw new Exception ("El valor de la valoracion debe estar entre 1 y 10");
                }

                // Crear una nueva valoracion y asignarla al usuario y la mascota
                int nuevaValoracionId = valoracionCEN.Nuevo (mascota.Id, usuario.Email, valor);

                // Confirmar la transaccion
                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                // Revertir la transaccion en caso de error
                CPSession.RollBack ();
                throw ex;
            }
        finally
        {
                // Cerrar la sesion
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
