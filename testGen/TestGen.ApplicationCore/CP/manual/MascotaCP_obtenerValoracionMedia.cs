
using System;
using System.Text;

using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CEN.DSM;



/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CP.DSM_Mascota_obtenerValoracionMedia) ENABLED START*/
//  references to other libraries

using System.Linq;

/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CP.DSM
{
public partial class MascotaCP : GenericBasicCP
{
public double ObtenerValoracionMedia (int p_oid)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CP.DSM_Mascota_obtenerValoracionMedia) ENABLED START*/

        MascotaCEN mascotaCEN = null;

        double result = 0;


        try
        {
                CPSession.SessionInitializeTransaction ();
                mascotaCEN = new  MascotaCEN (CPSession.UnitRepo.MascotaRepository);

                MascotaEN mascota = mascotaCEN.LeerOID (p_oid);

                IList<ValoracionEN> valoraciones = mascota.ValoracionesRecibidas;
                Console.WriteLine (valoraciones);
                result = valoraciones.Average (valoracion => valoracion.Valor);

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
        return result;


        /*PROTECTED REGION END*/
}
}
}
