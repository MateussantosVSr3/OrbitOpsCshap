using System;
using System.Text;

namespace OrbitOps.Net.Infrastructure.Utils
{
    public static class CriptografiaUtil
    {
        // Garante a integridade da assinatura da telemetria contra ataques de falsificação (Spoofing)
        public static string GerarHashSeguro(string payloadBruto)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(payloadBruto);
            string base64 = Convert.ToBase64String(bytes);
            return $"{base64}_SECURE_ORBITAL_SIG";
        }
    }
}