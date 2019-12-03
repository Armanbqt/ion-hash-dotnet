﻿namespace Amazon.IonHash
{
    using System.Security.Cryptography;

    public class IonHasher : IIonHasher
    {
        private readonly HashAlgorithm hashAlgorithm;

        public IonHasher(string algorithm)
        {
            this.hashAlgorithm = HashAlgorithm.Create(algorithm);

            if (this.hashAlgorithm == null)
            {
                throw new IonHashException("Invalid Algorithm Specified");
            }
        }

        public byte[] Hash
        {
            get { return this.hashAlgorithm.Hash; }
        }

        public int TransformBlock(
            byte[] inputBuffer,
            int inputOffset,
            int inputCount,
            byte[] outputBuffer,
            int outputOffset)
        {
            return this.hashAlgorithm.TransformBlock(inputBuffer, inputOffset, inputCount, outputBuffer, outputOffset);
        }

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            return this.hashAlgorithm.TransformFinalBlock(inputBuffer, inputOffset, inputCount);
        }
    }
}
