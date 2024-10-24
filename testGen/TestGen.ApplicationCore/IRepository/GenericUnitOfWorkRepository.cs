
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGen.ApplicationCore.IRepository.DSM
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IMascotaRepository mascotarepository;
protected IMensajeRepository mensajerepository;
protected IMatchRepository matchrepository;
protected IValoracionRepository valoracionrepository;
protected INotificacionRepository notificacionrepository;
protected ITiqueSoporteRepository tiquesoporterepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IMascotaRepository MascotaRepository {
        get;
}
public abstract IMensajeRepository MensajeRepository {
        get;
}
public abstract IMatchRepository MatchRepository {
        get;
}
public abstract IValoracionRepository ValoracionRepository {
        get;
}
public abstract INotificacionRepository NotificacionRepository {
        get;
}
public abstract ITiqueSoporteRepository TiqueSoporteRepository {
        get;
}
}
}
