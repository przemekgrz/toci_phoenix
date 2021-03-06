﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Toci.DigitalSignature.Abstract;
using Toci.DigitalSignature.Interfaces;

namespace Toci.DigitalSignature.DigitalSignHandlers
{
    public class Sign: CertificateParsers, ISign
    {
        protected const string crypthoAlgorithm = "RSA";
        protected const string secureHashAlgorithm1 = "sha1";
        protected const string messageDigestAlgorithm5 = "md5";

        public virtual byte[] SignFile(byte[] inputFile, X509Certificate2 certificate)
        {
            if ( (inputFile.Equals(null)  || !certificate.HasPrivateKey)) return default(byte[]);

            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, string.Empty);
            var privateKey = (RSACryptoServiceProvider) certificate.PrivateKey;

            if (!algorithmName.Contains(secureHashAlgorithm1) && !algorithmName.Contains(messageDigestAlgorithm5))
            {
                RSACryptoServiceProvider privateKey1 = new RSACryptoServiceProvider();
                privateKey1.ImportParameters(privateKey.ExportParameters(true));
                privateKey = privateKey1;
            }

            try
            {
                byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
                return privateKey.SignHash(hash, CryptoConfig.MapNameToOID(algorithmName));
            }
            catch (Exception)
            {
                throw new Exception("Invalid algorithm method");
            }
        }

        public virtual byte[] SignFile(byte[] inputFile, string base64String)
        {
            return SignFile(inputFile, Base64ToCertificate(base64String));
        }
    }
}