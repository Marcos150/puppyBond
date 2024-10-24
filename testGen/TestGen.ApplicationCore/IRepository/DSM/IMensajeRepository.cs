
using System;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.CP.DSM;

namespace TestGen.ApplicationCore.IRepository.DSM
{
public partial interface IMensajeRepository
{
void setSessionCP (GenericSessionCP session);

MensajeEN ReadOIDDefault (int id
                          );

void ModifyDefault (MensajeEN mensaje);

System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size);



int Nuevo (MensajeEN mensaje);

void Modificar (MensajeEN mensaje);


void Destruir (int id
               );


MensajeEN LeerOID (int id
                   );


System.Collections.Generic.IList<MensajeEN> LeerTodos (int first, int size);
}
}
