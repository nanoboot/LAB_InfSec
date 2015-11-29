using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class Modes:Algorithm
    {
        public Modes() { }
        public Modes(BitArray aBitText, string Key): base(aBitText, Key) {   }

        public override void Encryption()
        {
            switch (Mode)
            {
                case Modes.ECB:
                    EncryptionECB();
                    break;
                case Modes.CBC:
                    EncryptionCBC();
                    break;
            }       
        }
      
        public override void Decryption( )
        {
            switch (Mode)
            {
                case Modes.ECB:
                    DecryptionECB( );
                    break;
                case Modes.CBC:
                    DecryptionCBC();
                    break;
            }
        }

        void EncryptionECB()
        {
            var key = Encoding.GetEncoding(1251).GetBytes(Key.ToString());
            GenerationKey(new BitArray(key));
            AddTempBit(BitArrayOT);
            BitArrayET = new BitArray(BitArrayOT.Length);
            for (var i = 0; i < BitArrayOT.Length; i += 64)
            {
                var aBitEncrypted = base.Encryption(new BitArray(GetValue(BitArrayOT, i, i + 64)));
                Concat(BitArrayET, aBitEncrypted, i);
            }
        }

        void DecryptionECB()
        {
            var key = Encoding.GetEncoding(1251).GetBytes(Key.ToString());
            GenerationKey(new BitArray(key));
            AddTempBit(BitArrayET);
            BitArrayDT = new BitArray(BitArrayET.Length);
            for (var i = 0; i < BitArrayET.Length; i += 64)
            {
                var aBitDecrypted = base.Decryption(new BitArray(GetValue(BitArrayET, i, i + 64)));
                Concat(BitArrayDT, aBitDecrypted, i);
            }
        }

        void EncryptionCBC()
        {
            var key = Encoding.GetEncoding(1251).GetBytes(Key.ToString().PadLeft(8, '0'));
            GenerationKey(new BitArray(key));
            AddTempBit(BitArrayOT);
            BitArrayET = new BitArray(BitArrayOT.Length);
            BitArray C = new BitArray(PSCh());
            for (var i = 0; i < BitArrayOT.Length; i += 64)
            {
                var M = GetValue(BitArrayOT, i, i + 64);
                var aBitEncrypted = base.Encryption(new BitArray(C.Xor(M)));
                C = aBitEncrypted;
                Concat(BitArrayET, aBitEncrypted, i);
            }
        }
        byte[] PSCh()
        {
            Random ran = new Random();
            byte[] aByte = new byte[8];
            byte T = 22;
            for (var i = 0; i < 8; i++)
            {
                aByte[i] = T;
                T = PSCh(T);
            }
            return aByte;
        }
        void DecryptionCBC()
        {
            var key = Encoding.GetEncoding(1251).GetBytes(Key.ToString().PadLeft(8, '0'));
            GenerationKey(new BitArray(key));
            AddTempBit(BitArrayET);
            BitArrayDT = new BitArray(BitArrayET.Length);
            BitArray C = new BitArray(PSCh());
            for (var i = 0; i < BitArrayET.Length; i += 64)
            {
                var aBitEncrypt = GetValue(BitArrayET, i, i + 64);
                var aBitDecryption = base.Decryption(new BitArray(aBitEncrypt));
                var M = C.Xor(aBitDecryption);
                C = aBitEncrypt;
                Concat(BitArrayDT, M, i);
            }
        }
        public byte PSCh(byte x, byte A = 25, byte B = 255, byte C = 37)
        {
            return Convert.ToByte((A * x + C) % B);
        }
    }
}
