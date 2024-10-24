
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
 * Clase Mensaje:
 *
 */

namespace TestGen.Infraestructure.Repository.DSM
{
public partial class MensajeRepository : BasicRepository, IMensajeRepository
{
public MensajeRepository() : base ()
{
}


public MensajeRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MensajeEN ReadOIDDefault (int id
                                 )
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MensajeNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                        else
                                result = session.CreateCriteria (typeof(MensajeNH)).List<MensajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), mensaje.Id);

                mensajeNH.Contenido = mensaje.Contenido;




                mensajeNH.Fecha = mensaje.Fecha;


                session.Update (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MensajeEN mensaje)
{
        MensajeNH mensajeNH = new MensajeNH (mensaje);

        try
        {
                SessionInitializeTransaction ();
                if (mensaje.Emisor != null) {
                        // Argumento OID y no colección.
                        mensajeNH
                        .Emisor = (TestGen.ApplicationCore.EN.DSM.UsuarioEN)session.Load (typeof(TestGen.ApplicationCore.EN.DSM.UsuarioEN), mensaje.Emisor.Email);

                        mensajeNH.Emisor.MensajesEmitidos
                        .Add (mensajeNH);
                }
                if (mensaje.Receptor != null) {
                        // Argumento OID y no colección.
                        mensajeNH
                        .Receptor = (TestGen.ApplicationCore.EN.DSM.UsuarioEN)session.Load (typeof(TestGen.ApplicationCore.EN.DSM.UsuarioEN), mensaje.Receptor.Email);

                        mensajeNH.Receptor.MensajesRecibidos
                        .Add (mensajeNH);
                }

                session.Save (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajeNH.Id;
}

public void Modificar (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), mensaje.Id);

                mensajeNH.Contenido = mensaje.Contenido;


                mensajeNH.Fecha = mensaje.Fecha;

                session.Update (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
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
                MensajeNH mensajeNH = (MensajeNH)session.Load (typeof(MensajeNH), id);
                session.Delete (mensajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: LeerOID
//Con e: MensajeEN
public MensajeEN LeerOID (int id
                          )
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> LeerTodos (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MensajeNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                else
                        result = session.CreateCriteria (typeof(MensajeNH)).List<MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MensajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
