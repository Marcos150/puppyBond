

using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.Infraestructure.Repository.DSM;
using TestGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IMascotaRepository MascotaRepository {
        get
        {
                this.mascotarepository = new MascotaRepository ();
                this.mascotarepository.setSessionCP (session);
                return this.mascotarepository;
        }
}

public override IMensajeRepository MensajeRepository {
        get
        {
                this.mensajerepository = new MensajeRepository ();
                this.mensajerepository.setSessionCP (session);
                return this.mensajerepository;
        }
}

public override IMatchRepository MatchRepository {
        get
        {
                this.matchrepository = new MatchRepository ();
                this.matchrepository.setSessionCP (session);
                return this.matchrepository;
        }
}

public override IValoracionRepository ValoracionRepository {
        get
        {
                this.valoracionrepository = new ValoracionRepository ();
                this.valoracionrepository.setSessionCP (session);
                return this.valoracionrepository;
        }
}

public override INotificacionRepository NotificacionRepository {
        get
        {
                this.notificacionrepository = new NotificacionRepository ();
                this.notificacionrepository.setSessionCP (session);
                return this.notificacionrepository;
        }
}

public override ITiqueSoporteRepository TiqueSoporteRepository {
        get
        {
                this.tiquesoporterepository = new TiqueSoporteRepository ();
                this.tiquesoporterepository.setSessionCP (session);
                return this.tiquesoporterepository;
        }
}
}
}

