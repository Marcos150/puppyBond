
using System;
using System.Text;
using System.Collections.Generic;
using TestGen.ApplicationCore.Exceptions;
using TestGen.ApplicationCore.EN.DSM;
using TestGen.ApplicationCore.IRepository.DSM;
using TestGen.ApplicationCore.CEN.DSM;
using TestGen.ApplicationCore.Utils;



namespace TestGen.ApplicationCore.CP.DSM
{
public partial class MascotaCP : GenericBasicCP
{
public MascotaCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public MascotaCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
