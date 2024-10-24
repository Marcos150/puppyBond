
using System;
using System.Text;
using TestGen.ApplicationCore.CEN.DSM;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CP.DSM;
using TestGen.Infraestructure.EN.DSM;


/*
 * Clase Match:
 *
 */

namespace TestGen.Infraestructure.Repository.DSM
{
public partial class MatchRepository : BasicRepository, IMatchRepository
{
public MatchRepository() : base ()
{
}


public MatchRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MatchEN ReadOIDDefault (int id
                               )
{
        MatchEN matchEN = null;

        try
        {
                SessionInitializeTransaction ();
                matchEN = (MatchEN)session.Get (typeof(MatchNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MatchNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MatchEN>();
                        else
                                result = session.CreateCriteria (typeof(MatchNH)).List<MatchEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MatchRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MatchEN match)
{
        try
        {
                SessionInitializeTransaction ();
                MatchNH matchNH = (MatchNH)session.Load (typeof(MatchNH), match.Id);

                matchNH.Estado = match.Estado;





                matchNH.Ubicacion = match.Ubicacion;

                session.Update (matchNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MatchRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MatchEN match)
{
        MatchNH matchNH = new MatchNH (match);

        try
        {
                SessionInitializeTransaction ();
                if (match.MascotaEnvia != null) {
                        // Argumento OID y no colección.
                        matchNH
                        .MascotaEnvia = (TestGen.ApplicationCore.EN.DSM.MascotaEN)session.Load (typeof(TestGen.ApplicationCore.EN.DSM.MascotaEN), match.MascotaEnvia.Id);

                        matchNH.MascotaEnvia.MatchEnviados
                        .Add (matchNH);
                }
                if (match.MascotaRecibe != null) {
                        // Argumento OID y no colección.
                        matchNH
                        .MascotaRecibe = (TestGen.ApplicationCore.EN.DSM.MascotaEN)session.Load (typeof(TestGen.ApplicationCore.EN.DSM.MascotaEN), match.MascotaRecibe.Id);

                        matchNH.MascotaRecibe.MatchRecibidos
                        .Add (matchNH);
                }

                session.Save (matchNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MatchRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return matchNH.Id;
}

public void Modificar (MatchEN match)
{
        try
        {
                SessionInitializeTransaction ();
                MatchNH matchNH = (MatchNH)session.Load (typeof(MatchNH), match.Id);

                matchNH.Estado = match.Estado;


                matchNH.Ubicacion = match.Ubicacion;

                session.Update (matchNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MatchRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destruir (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                MatchNH matchNH = (MatchNH)session.Load (typeof(MatchNH), id);
                session.Delete (matchNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MatchRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: LeerOID
//Con e: MatchEN
public MatchEN LeerOID (int id
                        )
{
        MatchEN matchEN = null;

        try
        {
                SessionInitializeTransaction ();
                matchEN = (MatchEN)session.Get (typeof(MatchNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> LeerTodos (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MatchNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MatchEN>();
                else
                        result = session.CreateCriteria (typeof(MatchNH)).List<MatchEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MatchRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
