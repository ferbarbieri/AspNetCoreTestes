using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    /// <summary>
    /// Status do Tenant.
    /// </summary>
    public enum TenantStatus : byte
    {
        AguardandoConfirmacaoRegistro = 0,
        AtivoDemo = 1,
        Ativo = 2,
        Bloqueado = 3 

    }
}
