
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.Infraestructure.Repository.DSM;
using TestGen.Infraestructure.CP;
using TestGen.ApplicationCore.Exceptions;

using TestGen.ApplicationCore.CP.DSM;
using TestGen.Infraestructure.Repository;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                MascotaRepository mascotarepository = new MascotaRepository ();
                MascotaCEN mascotacen = new MascotaCEN (mascotarepository);
                MensajeRepository mensajerepository = new MensajeRepository ();
                MensajeCEN mensajecen = new MensajeCEN (mensajerepository);
                MatchRepository matchrepository = new MatchRepository ();
                MatchCEN matchcen = new MatchCEN (matchrepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository ();
                ValoracionCEN valoracioncen = new ValoracionCEN (valoracionrepository);
                NotificacionRepository notificacionrepository = new NotificacionRepository ();
                NotificacionCEN notificacioncen = new NotificacionCEN (notificacionrepository);
                TiqueSoporteRepository tiquesoporterepository = new TiqueSoporteRepository ();
                TiqueSoporteCEN tiquesoportecen = new TiqueSoporteCEN (tiquesoporterepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                static void ImprimirVerde (string txt)
                {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine (txt);
                        Console.ResetColor ();
                }

                // You must write the initialisation of the entities inside the PROTECTED comments.
                // IMPORTANT:please do not delete them.

                // CREACION DE ENTIDADES

                // Creacion de usuario
                string emailUsuarioNuevo = usuariocen.Nuevo ("Elsa", "Pato", "elsapatitio@example.com", "Elsa", "Siempre", "Alicante");
                ImprimirVerde ("Usuario1 creado correctamente");
                string emailUsuarioNuevo2 = usuariocen.Nuevo ("Paco", "Pato", "32432432@example.com", "Paco", "Siempre", "Alicante");
                ImprimirVerde ("Usuario2 creado correctamente");

                // Creacion de mascotas (CRUD CUSTOMIZADA)
                int mascotaId1 = mascotacen.Nuevo ("Firulais", "Labrador", TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum.Macho,
                        "Vacunado", TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum.mediano,
                        "3 anyos", emailUsuarioNuevo, "Un perro jugueton y amigable");
                ImprimirVerde ("Mascota 1 creada correctamente");

                int mascotaId2 = mascotacen.Nuevo ("Luna", "Golden Retriever", TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum.Hembra,
                        "Vacunada", TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum.grande,
                        "2 anyos", emailUsuarioNuevo2, "Una perrita carinyosa y tranquila");
                ImprimirVerde ("Mascota 2 creada correctamente");

                // Creacion de matches (CRUD CUSTOMIZADA)
                int matchId = matchcen.Nuevo (mascotaId1, mascotaId2, "Alicante");
                matchcen.Modificar (matchId, TestGen.ApplicationCore.Enumerated.DSM.EstadoMatchEnum.aceptado, "Alicante");
                ImprimirVerde ("Match entre Mascota 1 y Mascota 2 creado y modificado a aceptado correctamente");

                // Creacion de mensajes (CRUD CUSTOMIZADA)
                //TODO: comprobar en mensajeNuevo que los usuarios estan matcheados
                int mensajeId1 = mensajecen.Nuevo ("Hola, estoy interesado en Firulais. ¿Sigue disponible?", emailUsuarioNuevo, emailUsuarioNuevo2);
                ImprimirVerde ("Mensaje 1 de usuario 1 a usuario 2 creado correctamente");

                // Creacion de valoraciones
                int valoracionId1 = valoracioncen.Nuevo (mascotaId2, emailUsuarioNuevo, 5);
                ImprimirVerde ("Valoracion 1 de usuario 1 a mascota 2 creada correctamente");

                // Creacion de notificaciones
                int notificacionId1 = notificacioncen.Nuevo (emailUsuarioNuevo, "Tu mascota Firulais ha recibido una nueva valoracion.");
                ImprimirVerde ("Notificacion 1 de usuario 1 creada correctamente");

                // Creacion de tiques de soporte
                int tiqueId1 = tiquesoportecen.Nuevo (emailUsuarioNuevo, "Problema con la visualizacion de mascotas.");
                ImprimirVerde ("Tique de soporte 1 de usuario 1 creado correctamente");

                // READFILTERS

                //ReadFilter de usuarios
                UsuarioEN usuMatcheado = usuariocen.ObtenerUsuariosMatcheados (emailUsuarioNuevo) [0];
                ImprimirVerde ("Primer usuario matcheado de Usuario 1: " + usuMatcheado.Nombre);

                //ReadFilter de mascotas
                MascotaEN labrador = mascotacen.LeerPorRaza ("Labrador") [0];
                ImprimirVerde ("Primer labrador en la BD: " + labrador.Nombre);
                MascotaEN macho = mascotacen.LeerPorSexo (TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum.Macho) [0];
                ImprimirVerde ("Primer macho en la BD: " + macho.Nombre);
                MascotaEN grande = mascotacen.LeerPorTamanyo (TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum.grande) [0];
                ImprimirVerde ("Primer perro grande en la BD: " + grande.Nombre);

                // CUSTOMS

                //Customs de usuario
                if (usuariocen.Login (emailUsuarioNuevo, "Elsa") != null)
                        ImprimirVerde ("El login es correcto");

                //Customs de mascota
                mascotacen.CambiarFoto(mascotaId1, "nuevaFoto.png");
                ImprimirVerde("Foto de mascota 1 cambiada correctamente");

                //Customs de notificacion
                notificacioncen.EnviarCorreo(notificacionId1);
                ImprimirVerde("Correo de notificacion enviado correctamente");

                //Customs de tique de soporte
                tiquesoportecen.EnviarCorreoSoporte (tiqueId1);
                ImprimirVerde ("Correo de tique de soporte enviado correctamente");

                // CUSTOM TRANSACTIONS

                //Custom transactions de usuario
                UsuarioCP usuarioCP = new(new SessionCPNHibernate ());
                usuarioCP.EnviarMensaje (emailUsuarioNuevo, emailUsuarioNuevo2, "Hola, ¿Qué tal?");
                ImprimirVerde ("Mensaje enviado de usuario 1 a usuario 2 correctamente");
                usuarioCP.PonerValoracion (emailUsuarioNuevo, 7, mascotaId2);
                ImprimirVerde ("Valoracion de usuario 1 a mascota 2 puesta correctamente");


                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
