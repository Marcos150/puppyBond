
using System;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.CP.DSM;

namespace TestGen.ApplicationCore.IRepository.DSM
{
public partial interface INotificacionRepository
{
void setSessionCP (GenericSessionCP session);

NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int Nuevo (NotificacionEN notificacion);

void Modificar (NotificacionEN notificacion);


void Destruir (int id
               );


NotificacionEN LeerOID (int id
                        );


System.Collections.Generic.IList<NotificacionEN> LeerTodos (int first, int size);
}
}
