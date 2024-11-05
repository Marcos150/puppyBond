
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
                CPSession.SessionInitializeTransaction ();
                mascotaCEN = new  MascotaCEN (CPSession.UnitRepo.MascotaRepository);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method CambiarFoto() not yet implemented.");



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
