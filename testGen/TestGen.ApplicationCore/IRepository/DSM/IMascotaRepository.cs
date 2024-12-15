
using System;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.CP.DSM;

namespace TestGen.ApplicationCore.IRepository.DSM
{
public partial interface IMascotaRepository
{
void setSessionCP (GenericSessionCP session);

MascotaEN ReadOIDDefault (int id
                          );

void ModifyDefault (MascotaEN mascota);

System.Collections.Generic.IList<MascotaEN> ReadAllDefault (int first, int size);



int Nuevo (MascotaEN mascota);

void Modificar (MascotaEN mascota);


void Destruir (int id
               );


MascotaEN LeerOID (int id
                   );


System.Collections.Generic.IList<MascotaEN> LeerTodos (int first, int size);


System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorRaza (string raza);


System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorTamanyo (TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum ? tamanyo);


System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorSexo (TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum ? sexo);




void AgregarMatchEnviado (int p_Mascota_OID, System.Collections.Generic.IList<int> p_matchEnviados_OIDs);

void AgregarMatchRecibido (int p_Mascota_OID, System.Collections.Generic.IList<int> p_matchRecibidos_OIDs);
}
}
