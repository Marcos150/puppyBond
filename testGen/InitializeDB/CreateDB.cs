
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

                // You must write the initialisation of the entities inside the PROTECTED comments.
                // IMPORTANT:please do not delete them.

                // Creacion de usuario
                string emailUsuarioNuevo = usuariocen.Nuevo ("Elsa", "Pato", "elsapatitio@example.com", "Elsa", "Siempre", "Alicante");
                Console.WriteLine ("Se crea el usuario correctamente");
                //Login
                if (usuariocen.Login (emailUsuarioNuevo, "Elsa") != null)
                        Console.WriteLine ("El login es correcto");

                // Creacion de mascotas
                int mascotaId1 = mascotacen.Nuevo ("Firulais", "Labrador", TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum.Macho,
                        "Vacunado", TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum.mediano,
                        "3 anyos", emailUsuarioNuevo, "Un perro jugueton y amigable", 4.5);
                Console.WriteLine ("Mascota 1 creada correctamente");

                int mascotaId2 = mascotacen.Nuevo ("Luna", "Golden Retriever", TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum.Hembra,
                        "Vacunada", TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum.grande,
                        "2 anyos", emailUsuarioNuevo, "Una perrita carinyosa y tranquila", 5.0);
                Console.WriteLine ("Mascota 2 creada correctamente");

                // Filtros custom
                mascotacen.LeerPorRaza ("Labrador");
                mascotacen.LeerPorSexo (TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum.Macho);
                mascotacen.LeerPorTamanyo (TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum.grande);

                // Creacion de mensajes
                int mensajeId1 = mensajecen.Nuevo ("Hola, estoy interesado en Firulais. ¿Sigue disponible?", emailUsuarioNuevo, emailUsuarioNuevo);
                Console.WriteLine ("Mensaje 1 creado correctamente");

                // Creacion de matches
                int matchId1 = matchcen.Nuevo (mascotaId1, mascotaId2, "Alicante");
                Console.WriteLine ("Match 1 creado correctamente");

                // Creacion de valoraciones
                int valoracionId1 = valoracioncen.Nuevo (mascotaId1, emailUsuarioNuevo, 5);
                Console.WriteLine ("Valoracion 1 creada correctamente");

                // Creacion de notificaciones
                int notificacionId1 = notificacioncen.Nuevo (matchId1, emailUsuarioNuevo, "Tu mascota Firulais ha recibido una nueva valoracion.");
                Console.WriteLine ("Notificacion 1 creada correctamente");

                // Envío de correo para la notificación
                notificacioncen.EnviarCorreo (notificacionId1);
                Console.WriteLine ("Correo de notificación enviado correctamente");

                // Creacion de tiques de soporte
                int tiqueId1 = tiquesoportecen.Nuevo (emailUsuarioNuevo, "Problema con la visualizacion de mascotas.");
                Console.WriteLine ("Tique de soporte 1 creado correctamente");

                // Envio correo soporte
                tiquesoportecen.EnviarCorreoSoporte (tiqueId1);

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
