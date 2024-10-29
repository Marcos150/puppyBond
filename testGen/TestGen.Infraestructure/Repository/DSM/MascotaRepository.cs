
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
 * Clase Mascota:
 *
 */

namespace TestGen.Infraestructure.Repository.DSM
{
public partial class MascotaRepository : BasicRepository, IMascotaRepository
{
public MascotaRepository() : base ()
{
}


public MascotaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MascotaEN ReadOIDDefault (int id
                                 )
{
        MascotaEN mascotaEN = null;

        try
        {
                SessionInitializeTransaction ();
                mascotaEN = (MascotaEN)session.Get (typeof(MascotaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mascotaEN;
}

public System.Collections.Generic.IList<MascotaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MascotaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MascotaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MascotaEN>();
                        else
                                result = session.CreateCriteria (typeof(MascotaNH)).List<MascotaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MascotaEN mascota)
{
        try
        {
                SessionInitializeTransaction ();
                MascotaNH mascotaNH = (MascotaNH)session.Load (typeof(MascotaNH), mascota.Id);

                mascotaNH.Nombre = mascota.Nombre;


                mascotaNH.Raza = mascota.Raza;


                mascotaNH.Sexo = mascota.Sexo;


                mascotaNH.Vacunacion = mascota.Vacunacion;


                mascotaNH.Tamanyo = mascota.Tamanyo;


                mascotaNH.Edad = mascota.Edad;



                mascotaNH.Descripcion = mascota.Descripcion;





                mascotaNH.ValoracionMedia = mascota.ValoracionMedia;


                mascotaNH.Imagen = mascota.Imagen;

                session.Update (mascotaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MascotaEN mascota)
{
        MascotaNH mascotaNH = new MascotaNH (mascota);

        try
        {
                SessionInitializeTransaction ();
                if (mascota.Duenyo != null) {
                        // Argumento OID y no colección.
                        mascotaNH
                        .Duenyo = (TestGen.ApplicationCore.EN.DSM.UsuarioEN)session.Load (typeof(TestGen.ApplicationCore.EN.DSM.UsuarioEN), mascota.Duenyo.Email);

                        mascotaNH.Duenyo.Mascota
                                = mascotaNH;
                }

                session.Save (mascotaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mascotaNH.Id;
}

public void Modificar (MascotaEN mascota)
{
        try
        {
                SessionInitializeTransaction ();
                MascotaNH mascotaNH = (MascotaNH)session.Load (typeof(MascotaNH), mascota.Id);

                mascotaNH.Nombre = mascota.Nombre;


                mascotaNH.Raza = mascota.Raza;


                mascotaNH.Sexo = mascota.Sexo;


                mascotaNH.Vacunacion = mascota.Vacunacion;


                mascotaNH.Tamanyo = mascota.Tamanyo;


                mascotaNH.Edad = mascota.Edad;


                mascotaNH.Descripcion = mascota.Descripcion;


                mascotaNH.ValoracionMedia = mascota.ValoracionMedia;


                mascotaNH.Imagen = mascota.Imagen;

                session.Update (mascotaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
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
                MascotaNH mascotaNH = (MascotaNH)session.Load (typeof(MascotaNH), id);
                session.Delete (mascotaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: LeerOID
//Con e: MascotaEN
public MascotaEN LeerOID (int id
                          )
{
        MascotaEN mascotaEN = null;

        try
        {
                SessionInitializeTransaction ();
                mascotaEN = (MascotaEN)session.Get (typeof(MascotaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return mascotaEN;
}

public System.Collections.Generic.IList<MascotaEN> LeerTodos (int first, int size)
{
        System.Collections.Generic.IList<MascotaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MascotaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MascotaEN>();
                else
                        result = session.CreateCriteria (typeof(MascotaNH)).List<MascotaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorRaza (string raza)
{
        System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MascotaNH self where select mas FROM MascotaNH as mas where mas.Raza = :raza";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MascotaNHleerPorRazaHQL");
                query.SetParameter ("raza", raza);

                result = query.List<TestGen.ApplicationCore.EN.DSM.MascotaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorTamanyo (TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum ? tamanyo)
{
        System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MascotaNH self where select mas FROM MascotaNH as mas where mas.Tamanyo = :tamanyo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MascotaNHleerPorTamanyoHQL");
                query.SetParameter ("tamanyo", tamanyo);

                result = query.List<TestGen.ApplicationCore.EN.DSM.MascotaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorSexo (TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum ? sexo)
{
        System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MascotaNH self where select mas FROM MascotaNH as mas where mas.Sexo = :sexo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MascotaNHleerPorSexoHQL");
                query.SetParameter ("sexo", sexo);

                result = query.List<TestGen.ApplicationCore.EN.DSM.MascotaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TestGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new TestGen.ApplicationCore.Exceptions.DataLayerException ("Error in MascotaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
