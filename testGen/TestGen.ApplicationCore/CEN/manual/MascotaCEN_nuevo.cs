
using System;
using System.Text;
using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;


/*PROTECTED REGION ID(usingTestGen.ApplicationCore.CEN.DSM_Mascota_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TestGen.ApplicationCore.CEN.DSM
{
public partial class MascotaCEN
{
public int Nuevo (string p_nombre, string p_raza, TestGen.ApplicationCore.Enumerated.DSM.SexoPerroEnum p_sexo, string p_vacunacion, TestGen.ApplicationCore.Enumerated.DSM.TamanyoPerroEnum p_tamanyo, string p_edad, string p_duenyo, string p_descripcion, double p_valoracionMedia)
{
        /*PROTECTED REGION ID(TestGen.ApplicationCore.CEN.DSM_Mascota_nuevo_customized) ENABLED START*/

        MascotaEN mascotaEN = null;

        int oid;

        //Initialized MascotaEN
        mascotaEN = new MascotaEN ();
        mascotaEN.Nombre = p_nombre;

        mascotaEN.Raza = p_raza;

        mascotaEN.Sexo = p_sexo;

        mascotaEN.Vacunacion = p_vacunacion;

        mascotaEN.Tamanyo = p_tamanyo;

        mascotaEN.Edad = p_edad;


        if (p_duenyo != null) {
                mascotaEN.Duenyo = new TestGen.ApplicationCore.EN.DSM.UsuarioEN ();
                mascotaEN.Duenyo.Email = p_duenyo;
        }

        mascotaEN.Descripcion = p_descripcion;

        mascotaEN.ValoracionMedia = p_valoracionMedia;

        mascotaEN.Imagen = "default.png";

        //Call to MascotaRepository

        oid = _IMascotaRepository.Nuevo (mascotaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
