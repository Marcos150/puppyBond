

using System;
using System.Text;
using System.Collections.Generic;

using TestGen.ApplicationCore.Exceptions;

using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


namespace TestGen.ApplicationCore.CEN.DSM
{
/*
 *      Definition of the class MascotaCEN
 *
 */
public partial class MascotaCEN
{
private IMascotaRepository _IMascotaRepository;

public MascotaCEN(IMascotaRepository _IMascotaRepository)
{
        this._IMascotaRepository = _IMascotaRepository;
}

public IMascotaRepository get_IMascotaRepository ()
{
        return this._IMascotaRepository;
}

public void Modificar (int p_Mascota_OID, string p_nombre, string p_raza, TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum p_sexo, string p_vacunacion, TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum p_tamanyo, string p_edad, string p_descripcion, string p_imagen)
{
        MascotaEN mascotaEN = null;

        //Initialized MascotaEN
        mascotaEN = new MascotaEN ();
        mascotaEN.Id = p_Mascota_OID;
        mascotaEN.Nombre = p_nombre;
        mascotaEN.Raza = p_raza;
        mascotaEN.Sexo = p_sexo;
        mascotaEN.Vacunacion = p_vacunacion;
        mascotaEN.Tamanyo = p_tamanyo;
        mascotaEN.Edad = p_edad;
        mascotaEN.Descripcion = p_descripcion;
        mascotaEN.Imagen = p_imagen;
        //Call to MascotaRepository

        _IMascotaRepository.Modificar (mascotaEN);
}

public void Destruir (int id
                      )
{
        _IMascotaRepository.Destruir (id);
}

public MascotaEN LeerOID (int id
                          )
{
        MascotaEN mascotaEN = null;

        mascotaEN = _IMascotaRepository.LeerOID (id);
        return mascotaEN;
}

public System.Collections.Generic.IList<MascotaEN> LeerTodos (int first, int size)
{
        System.Collections.Generic.IList<MascotaEN> list = null;

        list = _IMascotaRepository.LeerTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorRaza (string raza)
{
        return _IMascotaRepository.LeerPorRaza (raza);
}
public System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorTamanyo (TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum ? tamanyo)
{
        return _IMascotaRepository.LeerPorTamanyo (tamanyo);
}
public System.Collections.Generic.IList<TestGen.ApplicationCore.EN.DSM.MascotaEN> LeerPorSexo (TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum ? sexo)
{
        return _IMascotaRepository.LeerPorSexo (sexo);
}
public void AgregarMatchEnviado (int p_Mascota_OID, System.Collections.Generic.IList<int> p_matchEnviados_OIDs)
{
        //Call to MascotaRepository

        _IMascotaRepository.AgregarMatchEnviado (p_Mascota_OID, p_matchEnviados_OIDs);
}
public void AgregarMatchRecibido (int p_Mascota_OID, System.Collections.Generic.IList<int> p_matchRecibidos_OIDs)
{
        //Call to MascotaRepository

        _IMascotaRepository.AgregarMatchRecibido (p_Mascota_OID, p_matchRecibidos_OIDs);
}
}
}
