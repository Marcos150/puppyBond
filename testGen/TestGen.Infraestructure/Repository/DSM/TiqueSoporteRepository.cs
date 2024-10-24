
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
 * Clase TiqueSoporte:
 *
 */

namespace TestGen.Infraestructure.Repository.DSM
{
public partial class TiqueSoporteRepository : BasicRepository, ITiqueSoporteRepository
{
public TiqueSoporteRepository() : base ()
{
}


public TiqueSoporteRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public TiqueSoporteEN ReadOIDDefault (int id
                                      )
{
        TiqueSoporteEN tiqueSoporteEN = null;

        try
        {
                SessionInitializeTransaction ();
                tiqueSoporteEN = (TiqueSoporteEN)session.Get (typeof(TiqueSoporteNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return tiqueSoporteEN;
}

public System.Collections.Generic.IList<TiqueSoporteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TiqueSoporteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TiqueSoporteNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<TiqueSoporteEN>();
                        else
                                result = session.CreateCriteria (typeof(TiqueSoporteNH)).List<TiqueSoporteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in TiqueSoporteRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TiqueSoporteEN tiqueSoporte)
{
        try
        {
                SessionInitializeTransaction ();
                TiqueSoporteNH tiqueSoporteNH = (TiqueSoporteNH)session.Load (typeof(TiqueSoporteNH), tiqueSoporte.Id);


                tiqueSoporteNH.Contenido = tiqueSoporte.Contenido;

                session.Update (tiqueSoporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in TiqueSoporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (TiqueSoporteEN tiqueSoporte)
{
        TiqueSoporteNH tiqueSoporteNH = new TiqueSoporteNH (tiqueSoporte);

        try
        {
                SessionInitializeTransaction ();
                if (tiqueSoporte.UsuarioManda != null) {
                        // Argumento OID y no colección.
                        tiqueSoporteNH
                        .UsuarioManda = (TestGen.ApplicationCore.EN.DSM.UsuarioEN)session.Load (typeof(TestGen.ApplicationCore.EN.DSM.UsuarioEN), tiqueSoporte.UsuarioManda.Email);

                        tiqueSoporteNH.UsuarioManda.TiqueEsDe
                        .Add (tiqueSoporteNH);
                }

                session.Save (tiqueSoporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in TiqueSoporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tiqueSoporteNH.Id;
}

public void Modificar (TiqueSoporteEN tiqueSoporte)
{
        try
        {
                SessionInitializeTransaction ();
                TiqueSoporteNH tiqueSoporteNH = (TiqueSoporteNH)session.Load (typeof(TiqueSoporteNH), tiqueSoporte.Id);

                tiqueSoporteNH.Contenido = tiqueSoporte.Contenido;

                session.Update (tiqueSoporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in TiqueSoporteRepository.", ex);
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
                TiqueSoporteNH tiqueSoporteNH = (TiqueSoporteNH)session.Load (typeof(TiqueSoporteNH), id);
                session.Delete (tiqueSoporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in TiqueSoporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
