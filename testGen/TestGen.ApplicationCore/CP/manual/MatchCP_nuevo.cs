
using System;
using System.Text;

using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CEN.DSM;



/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CP.DSM_Match_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CP.DSM
{
public partial class MatchCP : GenericBasicCP
{
public TestGen.ApplicationCore.EN.DSM.MatchEN Nuevo (int p_mascotaEnvia, int p_mascotaRecibe, string p_ubicacion)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CP.DSM_Match_nuevo) ENABLED START*/

        MatchCEN matchCEN = null;
        MascotaCEN mascotaCEN = null;
        NotificacionCEN notificacionCEN = null;
        TestGen.ApplicationCore.EN.DSM.MatchEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                matchCEN = new  MatchCEN (CPSession.UnitRepo.MatchRepository);
                mascotaCEN = new MascotaCEN(CPSession.UnitRepo.MascotaRepository);
                notificacionCEN = new NotificacionCEN(CPSession.UnitRepo.NotificacionRepository);

                if (p_mascotaEnvia == p_mascotaRecibe) {
                throw new Exception ("No puedes hacer match contigo mismo");
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

                oid = matchCEN.get_IMatchRepository ().Nuevo (matchEN);

                result = matchCEN.get_IMatchRepository ().ReadOIDDefault (oid);

                mascotaCEN.AgregarMatchEnviado(p_mascotaEnvia, [oid]);
                mascotaCEN.AgregarMatchRecibido(p_mascotaRecibe, [oid]);
                int idNotif = notificacionCEN.Nuevo(mascotaCEN.LeerOID(p_mascotaRecibe).Duenyo.Email, "Solicitud de amistad de: " + mascotaCEN.LeerOID(p_mascotaEnvia).Nombre);
                notificacionCEN.EnviarCorreo(idNotif);

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
