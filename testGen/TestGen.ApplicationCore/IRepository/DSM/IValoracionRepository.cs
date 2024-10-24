
using System;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.CP.DSM;

namespace TestGen.ApplicationCore.IRepository.DSM
{
public partial interface IValoracionRepository
{
void setSessionCP (GenericSessionCP session);

ValoracionEN ReadOIDDefault (int id
                             );

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);



int Nuevo (ValoracionEN valoracion);

void Modificar (ValoracionEN valoracion);


void Destruir (int id
               );


ValoracionEN LeerOID (int id
                      );


System.Collections.Generic.IList<ValoracionEN> LeerTodos (int first, int size);
}
}
