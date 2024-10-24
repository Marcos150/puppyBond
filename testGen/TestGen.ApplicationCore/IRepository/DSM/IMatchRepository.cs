
using System;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.CP.DSM;

namespace TestGen.ApplicationCore.IRepository.DSM
{
public partial interface IMatchRepository
{
void setSessionCP (GenericSessionCP session);

MatchEN ReadOIDDefault (int id
                        );

void ModifyDefault (MatchEN match);

System.Collections.Generic.IList<MatchEN> ReadAllDefault (int first, int size);



int Nuevo (MatchEN match);

void Modificar (MatchEN match);


void Destruir (int id
               );


MatchEN LeerOID (int id
                 );


System.Collections.Generic.IList<MatchEN> LeerTodos (int first, int size);
}
}
