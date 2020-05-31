using System;
using System.Linq;
using System.Threading;
using Bam.Net;
using Bam.Net.CoreServices.ApplicationRegistration.Data;
using Bambot.Deployment.Data;
using Org.BouncyCastle.Crypto.Macs;

namespace Bambot.Deployment
{
    public class DeterministicSshHostPasswordGenerator : IDeterministicSshHostPasswordGenerator
    {
        private Instant _lastGen;
        public DeterministicSshHostPasswordGenerator()
        {
            SharedSecret = string.Empty;
            HashAlgorithm = HashAlgorithms.SHA512;
        }

        public const string Delimiter = ":";
        
        public HashAlgorithms HashAlgorithm
        {
            get;
            set;
        }
        
        /// <summary>
        /// The value used as the key to the Hmac algorithm
        /// </summary>
        public string SharedSecret { get; set; }

        public GeneratedPassword Generate()
        {
            return Generate(SshHostIdentifier.Current);
        }
        
        public GeneratedPassword Generate(double? julianDate = null)
        {
            julianDate = EnsureJulianDate(julianDate);
            return Generate(SshHostIdentifier.Current, julianDate);
        }
        
        public GeneratedPassword Generate(SshHostIdentifier sshHostIdentifier, double? julianDate = null)
        {
            julianDate = EnsureJulianDate(julianDate);
            string valueToEncode = $"{sshHostIdentifier.HostName}{Delimiter}{sshHostIdentifier.MacAddress}{Delimiter}{julianDate.ToString()}";
            string hmacHexString = valueToEncode.HmacHexString(SharedSecret, HashAlgorithm);
            _lastGen = Instant.Now;

            return new GeneratedPassword(hmacHexString) {JulianDate = julianDate};
        }
        
        public virtual string GetHostname()
        {
            return Machine.Current.Name;
        }

        public virtual string GetMacAddress()
        {
            return Machine.Current.GetFirstMac();
        }

        private double? EnsureJulianDate(double? julianDate)
        {
            Instant now = Instant.UtcNow;
            if (_lastGen != null)
            {
                if (now.DiffInSeconds(_lastGen) <= 1)
                {
                    Thread.Sleep(1001);
                }
            }

            if (julianDate == null)
            {
                julianDate = DateTime.UtcNow.ToJulianDate();
            }

            return julianDate;
        }
    }
}