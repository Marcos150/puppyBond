
using System;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.CP.DSM;

namespace TestGen.ApplicationCore.IRepository.DSM
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



string Nuevo (UsuarioEN usuario);

void Modificar (UsuarioEN usuario);


void Destruir (string email
               );


UsuarioEN LeerOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> LeerAll (int first, int size);
}
}
