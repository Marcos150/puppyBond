
using System;
using System.Text;
using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CEN.DSM_Match_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CEN.DSM
{
public partial class MatchCEN
{
public int Nuevo (int p_mascotaEnvia, int p_mascotaRecibe, string p_ubicacion)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CEN.DSM_Match_nuevo_customized) ENABLED START*/

        if (p_mascotaEnvia == p_mascotaRecibe)
        {
            throw new Exception("No puedes hacer match contigo mismo");
        }
        MatchEN matchEN = null;

        int oid;

        //Initialized MatchEN
        matchEN = new MatchEN ();

        if (p_mascotaEnvia != -1) {
                matchEN.MascotaEnvia = new TestGen.ApplicationCore.EN.DSM.MascotaEN ();
                matchEN.MascotaEnvia.Id = p_mascotaEnvia;
        }


        if (p_mascotaRecibe != -1) {
                matchEN.MascotaRecibe = new TestGen.ApplicationCore.EN.DSM.MascotaEN ();
                matchEN.MascotaRecibe.Id = p_mascotaRecibe;
        }

        matchEN.Ubicacion = p_ubicacion;
        matchEN.Estado = Enumerated.DSM.EstadoMatchEnum.pendiente;

        //Call to MatchRepository

        oid = _IMatchRepository.Nuevo (matchEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
