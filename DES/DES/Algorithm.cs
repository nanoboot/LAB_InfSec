using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class Algorithm
    {
        public BitArray BitArrayOT { get; protected set; }
        public BitArray BitArrayET { get; protected set; }
        public BitArray BitArrayDT { get; protected set; }

        protected string Key;
        public  enum Modes { ECB, CBC} 

        public static Modes Mode;
        public Algorithm() { }
        public Algorithm(BitArray aBitText, string Key)
        {
            this.BitArrayOT = aBitText;
            this.BitArrayET = aBitText;
            this.Key = Key;
        }

        List<BitArray> key = new List<BitArray>(); 

        // константы
        //массив начальной перестановки 
        int[] IPOT = new int[] { 58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4,
                               62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8,
                               57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3,
                               61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7};
        
        //массив обратной перестановки 
        int[] IPBI = new int[] { 40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31,
                                38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29,
                                36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27,
                                34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25};
       //функция расширения
        int[] E = new int[]{ 32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11,
                             12, 13, 12, 13, 14, 15, 16, 17, 16, 17, 18, 19, 20, 21, 20, 21,
                             22, 23, 24, 25, 24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1};


        byte[,] S1 = new byte[,]{{14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
                                {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
                                {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
                                {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}};

        byte[,] S2 = new byte[,]{{15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
                                 {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
                                 {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
                                 {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}};

        byte[,] S3 = new byte[,]{{10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
                                 {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
                                 {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
                                 {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}};

        byte[,] S4 = new byte[,]{{7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
                                 {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
                                 {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
                                 {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}};

        byte[,] S5 = new byte[,]{{2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
                                 {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
                                 {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
                                 {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}};

        byte[,] S6 = new byte[,]{{12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
                                 {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
                                 {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
                                 {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}};

        byte[,] S7 = new byte[,]{{4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
                                 {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
                                 {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
                                 {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}};

        byte[,] S8 = new byte[,]{{13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
                                 {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
                                 {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
                                 {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}};
       
        int[] P = new int[] {16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10,
                             2, 8, 24, 14, 32, 27, 3, 9, 19, 13, 30, 6, 22, 11, 4, 25};

        int[] G = new int[] {57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18,
                            10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44,
                            36, 63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22,
                            14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4};

        int[] LS = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        int[] H = new int[]{14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4,
                            26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55, 30, 40,
                            51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32};

        public virtual void Encryption() { }
        // шифрование блока
        public BitArray Encryption(BitArray BlockBite)
        {
            BlockBite = Permutation(BlockBite, IPOT); // начальная перестановка
            var Left = GetValue(BlockBite, 0, (BlockBite.Length / 2)); // левый полублок
            var Right = GetValue(BlockBite, BlockBite.Length / 2, BlockBite.Length); // правый полублок
            for (var i = 1; i <= 16; i++)   // 16 шифрующих преобразований
            {
                var Temp = Left.Xor(F(new BitArray(Right), key[i - 1]));
                Left = Right;
                Right = Temp;
            }
            return Permutation(ConcatLR(Left, Right), IPBI); // конечная перестановка
        }
        
        public virtual void Decryption( ) { }
        // дешифрование блока
        public BitArray Decryption(BitArray BlockBite)
        {
            BlockBite = Permutation(BlockBite, IPOT);
            var Left = GetValue(BlockBite, 0, (BlockBite.Length / 2)); 
            var Right = GetValue(BlockBite, BlockBite.Length / 2, BlockBite.Length);
            for (var i = 16; i >= 1; i--)
            {
                var Temp = Right.Xor(F(new BitArray( Left),  key[i - 1]));
                Right = Left;
                Left = Temp;
            }
            return Permutation(ConcatLR(Left, Right), IPBI);
        }

        BitArray F(BitArray aBite, BitArray Key)
        {
            ExtensionE(ref aBite);
            aBite.Xor(Key);
            BitArray tempBitArray = new BitArray(32);  
            var iBlock = 1;
            var iTempBitsBlock = 0;
            for (var i = 0; i < aBite.Length; i += 6)
            {
                SetBits(ref tempBitArray, GammirovaniyeS(GetValue(aBite, i, i + 6), iBlock++), iTempBitsBlock);
                iTempBitsBlock += 4;
            }
            aBite = Permutation(tempBitArray, P);
            return aBite;
        }

        // функция расширения E
        void ExtensionE(ref BitArray aBit)
        {
            BitArray TempBits = new BitArray(E.Length);
            for (var iBit = 0; iBit < E.Length; iBit++)
                TempBits[iBit] = aBit[E[iBit] - 1];
            aBit.Length = E.Length;
            aBit = TempBits;     
        }

        // функция перестановки
        BitArray Permutation(BitArray aBit, int[] IndexPerm)
        {
            BitArray TempBits = new BitArray(IndexPerm.Length);
            for (var iBit = 0; iBit < IndexPerm.Length; iBit++){
                TempBits[iBit] = aBit[IndexPerm[iBit] - 1];
            }
            return TempBits;
        }
             
        BitArray GammirovaniyeS(BitArray aByte, int numBlock)
        {
            byte k = 0;
            byte l = 0;
            SetBit(ref k, 1, aByte[0]);
            SetBit(ref k, 0, aByte[5]);
            SetBit(ref l, 3, aByte[1]);
            SetBit(ref l, 2, aByte[2]);
            SetBit(ref l, 1, aByte[3]);
            SetBit(ref l, 0, aByte[4]);
            byte Temp = 0;
            switch (numBlock)
            {
                case 1: Temp = S1[k, l];
                    break;
                case 2: Temp = S2[k, l];
                    break;
                case 3: Temp = S3[k, l];
                    break;
                case 4: Temp = S4[k, l];
                    break;
                case 5: Temp = S5[k, l];
                    break;
                case 6: Temp = S6[k, l];
                    break;
                case 7: Temp = S7[k, l];
                    break;
                case 8: Temp = S8[k, l];
                    break;
            }
            return  GetValue(new BitArray(new byte[] { Temp }), 0, 4);
        }

        // генерация ключа
        public void GenerationKey(BitArray Key)
        {
            Key = Permutation(Key, G);
            var L = GetValue(Key, 0, (Key.Length/2));
            var R = GetValue(Key, (Key.Length / 2), Key.Length );
            for (var i = 1; i <= 16; i++)
            {
                var temp=Permutation(ConcatLR(L, R), H);     
                LeftShift(ref L, LS[i - 1]);
                LeftShift(ref R, LS[i - 1]);
                key.Add(temp);
            }
        }

        public void SetBit(ref byte aByte, int Pos, bool Value)
        {
            if (Value)
                aByte = (byte)(aByte | (1 << Pos));
            else
                aByte = (byte)(aByte & ~(1 << Pos));
        }

        void SetBits(ref BitArray aBit1, BitArray aBit2,  int begin)
        {
            var iBit = begin;
            for (var jBit=0; jBit < aBit2.Length; jBit++,iBit++)
            {
                aBit1.Set(iBit, aBit2.Get(jBit));
            }
        }

        void LeftShift(ref BitArray aBit, int CountShift)
        {
            BitArray Temp = new BitArray(aBit.Length, false);
            while (CountShift-- != 0)
            {
                var temp = aBit[0];
                for (var i = 0; i < aBit.Length - 1; i++)
                    aBit[i] = aBit[i + 1];
                aBit[aBit.Length - 1] = temp;
            }
        }

        protected BitArray ConcatLR(BitArray Left, BitArray Right)
        {
            BitArray Rezult = new BitArray(Left.Length + Right.Length);
            var iRez = 0;
            for (var i = 0; i < Left.Length; i++)
               Rezult.Set(iRez++, Left.Get(i));
            for (var j = 0; j < Right.Length; j++)
                Rezult.Set(iRez++, Right.Get(j));
            return Rezult;
        }

        public BitArray GetValue(BitArray aBite, int begin, int end)
        {
            BitArray Value = new BitArray((end - begin));
            int iBit=0;
            for (var i = begin; i < end; i++)
            {
                Value[iBit] = aBite.Get(i);
                iBit++;
            }
            return Value;
        }

        protected  byte BitArrayToByte(BitArray aBit)
        {
            byte result = 0;
            for (byte index = 0, m = 1; index < 8; index++, m *= 2)
                result += aBit.Get(index) ? m : (byte)0;
            return result;
        }
 
       public BitArray AddTempBit(BitArray aBit)
        {
            while (aBit.Length % 64 != 0)
                aBit.Length++;
            return aBit;
        }

       public string GetText(BitArray aBit)
       {
           byte[] RezArrayByte = new byte[aBit.Length / 8];
           var iByte = 0;
           for (var iBit = 0; iBit < aBit.Length; iBit += 8)
               RezArrayByte[iByte++] = BitArrayToByte(GetValue(aBit, iBit, iBit + 8));
           return Encoding.GetEncoding(1251).GetString(RezArrayByte);
       }
       protected void Concat(BitArray Left, BitArray Right, int index)
       {
           int iBit = 0;
           for (var i = index; iBit < Right.Length; i++)
               Left[i] = Right[iBit++];
       }
    }
}
