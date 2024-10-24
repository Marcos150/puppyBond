
using System;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.CP.DSM;

namespace TestGen.ApplicationCore.IRepository.DSM
{
public partial interface ITiqueSoporteRepository
{
void setSessionCP (GenericSessionCP session);

TiqueSoporteEN ReadOIDDefault (int id
                               );

void ModifyDefault (TiqueSoporteEN tiqueSoporte);

System.Collections.Generic.IList<TiqueSoporteEN> ReadAllDefault (int first, int size);



int Nuevo (TiqueSoporteEN tiqueSoporte);

void Modificar (TiqueSoporteEN tiqueSoporte);


void Destruir (int id
               );
}
}
