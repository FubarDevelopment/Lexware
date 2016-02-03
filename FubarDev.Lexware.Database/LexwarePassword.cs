// <copyright file="LexwarePassword.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FubarDev.Lexware.Database
{
    /// <summary>
    /// Ver- und Entschlüsselung von Lexware-Passwörtern
    /// </summary>
    public static class LexwarePassword
    {
        private static readonly byte[] _magicValues1 =
        {
            0x38, 0x30, 0x28, 0x20, 0x18, 0x10,  0x8,  0x0,
            0x39, 0x31, 0x29, 0x21, 0x19, 0x11,  0x9,  0x1,
            0x3A, 0x32, 0x2A, 0x22, 0x1A, 0x12, 0x0A,  0x2,
            0x3B, 0x33, 0x2B, 0x23, 0x3E, 0x36, 0x2E, 0x26,
            0x1E, 0x16, 0x0E,  0x6, 0x3D, 0x35, 0x2D, 0x25,
            0x1D, 0x15, 0x0D,  0x5, 0x3C, 0x34, 0x2C, 0x24,
            0x1C, 0x14, 0x0C,  0x4, 0x1B, 0x13, 0x0B,  0x3
        };

        private static readonly byte[] _magicValues2 =
        {
            0x01, 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C, 0x0E,
            0x0F, 0x11, 0x13, 0x15, 0x17, 0x19, 0x1B, 0x1C
        };

        private static readonly byte[] _magicValues3 =
        {
            0x0D, 0x10, 0x0A, 0x17, 0x00, 0x04, 0x02, 0x1B,
            0x0E, 0x05, 0x14, 0x09, 0x16, 0x12, 0x0B, 0x03,
            0x19, 0x07, 0x0F, 0x06, 0x1A, 0x13, 0x0C, 0x01
        };

        private static readonly uint[] _magicValues4 =
        {
            0x00800000, 0x00400000, 0x00200000, 0x00100000, 0x00080000, 0x00040000, 0x00020000, 0x00010000,
            0x00008000, 0x00004000, 0x00002000, 0x00001000, 0x00000800, 0x00000400, 0x00000200, 0x00000100,
            0x00000080, 0x00000040, 0x00000020, 0x00000010, 0x00000008, 0x00000004, 0x00000002, 0x00000001
        };

        private static readonly byte[] _magicValues5 =
        {
            0x28, 0x33, 0x1E, 0x24, 0x2E, 0x36, 0x1D, 0x27,
            0x32, 0x2C, 0x20, 0x2F, 0x2B, 0x30, 0x26, 0x37,
            0x21, 0x34, 0x2D, 0x29, 0x31, 0x23, 0x1C, 0x1F
        };

        private static readonly uint[] _magicValues6 =
        {
            0x00200000,  0x4200002,  0x4000802, 0x00000000,      0x800,  0x4000802,   0x200802,  0x4200800,
            0x04200802,   0x200000,          0,  0x4000002,          2,  0x4000000,  0x4200002,      0x802,
            0x04000800,   0x200802,   0x200002,  0x4000800,  0x4000002,  0x4200000,  0x4200800,   0x200002,
            0x04200000,      0x800,      0x802,  0x4200802,   0x200800,          2,  0x4000000,   0x200800,
            0x04000000,   0x200800,   0x200000,  0x4000802,  0x4000802,  0x4200002,  0x4200002,          2,
            0x00200002,  0x4000000,  0x4000800,   0x200000,  0x4200800,      0x802,   0x200802,  0x4200800,
            0x00000802,  0x4000002,  0x4200802,  0x4200000,   0x200800,          0,          2,  0x4200802,
            0x00000000,   0x200802,  0x4200000,      0x800,  0x4000002,  0x4000800,      0x800,   0x200002
        };

        private static readonly uint[] _magicValues7 =
        {
            0x00000100,  0x2080100,  0x2080000, 0x42000100,    0x80000,      0x100, 0x40000000,  0x2080000,
            0x40080100,    0x80000,  0x2000100, 0x40080100, 0x42000100, 0x42080000,    0x80100, 0x40000000,
            0x02000000, 0x40080000, 0x40080000,          0, 0x40000100, 0x42080100, 0x42080100,  0x2000100,
            0x42080000, 0x40000100,          0, 0x42000000,  0x2080100,  0x2000000, 0x42000000,    0x80100,
            0x00080000, 0x42000100,      0x100,  0x2000000, 0x40000000,  0x2080000, 0x42000100, 0x40080100,
            0x02000100, 0x40000000, 0x42080000,  0x2080100, 0x40080100,      0x100,  0x2000000, 0x42080000,
            0x42080100,    0x80100, 0x42000000, 0x42080100,  0x2080000,          0, 0x40080000, 0x42000000,
            0x00080100,  0x2000100, 0x40000100,    0x80000,          0, 0x40080000,  0x2080100, 0x40000100
        };

        private static readonly uint[] _magicValues8 =
        {
            0x00000208,  0x8020200,          0,  0x8020008,  0x8000200,          0,    0x20208,  0x8000200,
            0x00020008,  0x8000008,  0x8000008,    0x20000,  0x8020208,    0x20008,  0x8020000,      0x208,
            0x08000000,          8,  0x8020200,      0x200,    0x20200,  0x8020000,  0x8020008,    0x20208,
            0x08000208,    0x20200,    0x20000,  0x8000208,          8,  0x8020208,      0x200,  0x8000000,
            0x08020200,  0x8000000,    0x20008,      0x208,    0x20000,  0x8020200,  0x8000200,          0,
            0x00000200,    0x20008,  0x8020208,  0x8000200,  0x8000008,      0x200,          0,  0x8020008,
            0x08000208,    0x20000,  0x8000000,  0x8020208,          8,    0x20208,    0x20200,  0x8000008,
            0x08020000,  0x8000208,      0x208,  0x8020000,    0x20208,          8,  0x8020008,    0x20200
        };

        private static readonly uint[] _magicValues9 =
        {
            0x1010400,          0,    0x10000,  0x1010404,  0x1010004,    0x10404,          4,    0x10000,
            0x0000400,  0x1010400,  0x1010404,      0x400,  0x1000404,  0x1010004,  0x1000000,          4,
            0x0000404,  0x1000400,  0x1000400,    0x10400,    0x10400,  0x1010000,  0x1010000,  0x1000404,
            0x0010004,  0x1000004,  0x1000004,    0x10004,          0,      0x404,    0x10404,  0x1000000,
            0x0010000,  0x1010404,          4,  0x1010000,  0x1010400,  0x1000000,  0x1000000,      0x400,
            0x1010004,    0x10000,    0x10400,  0x1000004,      0x400,          4,  0x1000404,    0x10404,
            0x1010404,    0x10004,  0x1010000,  0x1000404,  0x1000004,      0x404,    0x10404,  0x1010400,
            0x0000404,  0x1000400,  0x1000400,          0,    0x10004,    0x10400,          0,  0x1010004
        };

        private static readonly uint[] _magicValues10 =
        {
            0x10001040,     0x1000,    0x40000, 0x10041040, 0x10000000, 0x10001040,       0x40, 0x10000000,
            0x00040040, 0x10040000, 0x10041040,    0x41000, 0x10041000,    0x41040,     0x1000,       0x40,
            0x10040000, 0x10000040, 0x10001000,     0x1040,    0x41000,    0x40040, 0x10040040, 0x10041000,
            0x00001040,          0,          0, 0x10040040, 0x10000040, 0x10001000,    0x41040,    0x40000,
            0x00041040,    0x40000, 0x10041000,     0x1000,       0x40, 0x10040040,     0x1000,    0x41040,
            0x10001000,       0x40, 0x10000040, 0x10040000, 0x10040040, 0x10000000,    0x40000, 0x10001040,
            0x00000000, 0x10041040,    0x40040, 0x10000040, 0x10040000, 0x10001000, 0x10001040,          0,
            0x10041040,    0x41000,    0x41000,     0x1040,     0x1040,    0x40040, 0x10000000, 0x10041000
        };

        private static readonly uint[] _magicValues11 =
        {
            0x20000010, 0x20400000,     0x4000, 0x20404010, 0x20400000,       0x10, 0x20404010,   0x400000,
            0x20004000,   0x404010,   0x400000, 0x20000010,   0x400010, 0x20004000, 0x20000000,     0x4010,
            0x00000000,   0x400010, 0x20004010,     0x4000,   0x404000, 0x20004010,       0x10, 0x20400010,
            0x20400010,          0,   0x404010, 0x20404000,     0x4010,   0x404000, 0x20404000, 0x20000000,
            0x20004000,       0x10, 0x20400010,   0x404000, 0x20404010,   0x400000,     0x4010, 0x20000010,
            0x00400000, 0x20004000, 0x20000000,     0x4010, 0x20000010, 0x20404010,   0x404000, 0x20400000,
            0x00404010, 0x20404000,          0, 0x20400010,       0x10,     0x4000, 0x20400000,   0x404010,
            0x00004000,   0x400010, 0x20004010,          0, 0x20404000, 0x20000000,   0x400010, 0x20004010
        };

        private static readonly uint[] _magicValues12 =
        {
            0x00802001,     0x2081,     0x2081,       0x80,   0x802080,   0x800081,   0x800001,     0x2001,
            0x00000000,   0x802000,   0x802000,   0x802081,       0x81,          0,   0x800080,   0x800001,
            0x00000001,     0x2000,   0x800000,   0x802001,       0x80,   0x800000,     0x2001,     0x2080,
            0x00800081,          1,     0x2080,   0x800080,     0x2000,   0x802080,   0x802081,       0x81,
            0x00800080,   0x800001,   0x802000,   0x802081,       0x81,          0,          0,   0x802000,
            0x00002080,   0x800080,   0x800081,          1,   0x802001,     0x2081,     0x2081,       0x80,
            0x00802081,       0x81,          1,     0x2000,   0x800001,     0x2001,   0x802080,   0x800081,
            0x00002001,     0x2080,   0x800000,   0x802001,       0x80,   0x800000,     0x2000,   0x802080
        };

        private static readonly uint[] _magicValues13 =
        {
            0x80108020, 0x80008000,     0x8000,   0x108020,   0x100000,       0x20, 0x80100020, 0x80008020,
            0x80000020, 0x80108020, 0x80108000, 0x80000000, 0x80008000,   0x100000,       0x20, 0x80100020,
            0x00108000,   0x100020, 0x80008020,          0, 0x80000000,     0x8000,   0x108020, 0x80100000,
            0x00100020, 0x80000020,          0,   0x108000,     0x8020, 0x80108000, 0x80100000,     0x8020,
            0x00000000,   0x108020, 0x80100020,   0x100000, 0x80008020, 0x80100000, 0x80108000,     0x8000,
            0x80100000, 0x80008000,       0x20, 0x80108020,   0x108020,       0x20,     0x8000, 0x80000000,
            0x00008020, 0x80108000,   0x100000, 0x80000020,   0x100020, 0x80008020, 0x80000020,   0x100020,
            0x00108000,          0, 0x80008000,     0x8020, 0x80000000, 0x80100020, 0x80108020,   0x108000
        };

        private static readonly byte[] _byteBits =
        {
            0x80,
            0x40,
            0x20,
            0x10,
            0x08,
            0x04,
            0x02,
            0x01
        };

        /// <summary>
        /// Verschlüsselung das Passworts mit dem angegebenen Schlüssel
        /// </summary>
        /// <param name="password">Das zu verschlüsselnde Passwort</param>
        /// <param name="key">Der Schlüssel mit dem das Passwort verschlüsselt werden soll</param>
        /// <returns>Das verschlüsselte Passwort</returns>
        public static string Encrypt(string password, string key = "LEXWARE")
        {
            return PerformCrypt(password, true, key);
        }

        /// <summary>
        /// Entschlüsselung des Passworts mit dem angegebenen Schlüssel
        /// </summary>
        /// <param name="encryptedPassword">Das zu entschlüsselnde Passwort</param>
        /// <param name="key">Der Schlüssel mit dem das Passwort verschlüsselt wurde</param>
        /// <returns>Das enschlüsselte Passwort</returns>
        public static string Decrypt(string encryptedPassword, string key = "LEXWARE")
        {
            return PerformCrypt(encryptedPassword, false, key);
        }

        private static string PerformCrypt(string pwd, bool encrypt, string currentKey)
        {
            if (string.IsNullOrEmpty(currentKey))
                return pwd;
            if (currentKey == "DUMMY")
                return new string(pwd.Reverse().ToArray());
            if (currentKey == "LEXWARE")
                currentKey = "1a1z";
            if (encrypt)
                return DoEncryption(pwd, currentKey);
            return DoDecryption(pwd, currentKey);
        }

        private static string DoEncryption(string pwd, string key)
        {
            var buffer = new byte[0xC0];
            InitBufferWithKey(buffer, key);
            if (string.IsNullOrEmpty(pwd))
                return null;
            return DoEncryption(buffer, pwd);
        }

        private static string DoEncryption(byte[] buffer, string pwd)
        {
            if (string.IsNullOrEmpty(pwd) || pwd.Length > 0x100)
                return null;

            int encryptedLength = 0x200;
            var encrypted = new byte[encryptedLength];
            var pwdBuffer = Encoding.Default.GetBytes(pwd);
            DoEncryption(buffer, pwdBuffer, encrypted, out encryptedLength);
            return BytesToHex(encrypted.ToSlice(0, encryptedLength));
        }

        private static void DoEncryption(byte[] buffer, byte[] pwdBuffer, byte[] encrypted, out int encryptedLengthRef)
        {
            var keyChars = buffer.ToSlice(0xAC, 8);
            var keyIndexes = buffer.ToSlice(0xB4, 8);
            var encryptedData = buffer.ToSlice(0x00, 8);
            var dataToEncrypt = buffer.ToSlice(0x08, 8);
            var cryptProcessingBuffer = buffer.ToSlice(0x18, 0x90);

            MemSet(encryptedData, 1, 8);

            var blockLength = Math.Min(8, pwdBuffer.Length);
            MemCopy(dataToEncrypt, pwdBuffer, blockLength);
            var processedPasswordLength = blockLength;

            var resultLength = 0;
            var isLastBlock = false;
            while (!isLastBlock)
            {
                if (blockLength < 8)
                {
                    var blockFillLength = (byte)(8 - blockLength);
                    MemSet(dataToEncrypt.ToSlice(blockLength, blockFillLength), 0, blockFillLength);
                    dataToEncrypt[7] = blockFillLength;
                    isLastBlock = true;
                }

                for (var index1 = 0; index1 != 8; ++index1)
                {
                    dataToEncrypt[index1] = (byte)(encryptedData[index1] ^ dataToEncrypt[index1]);
                }

                BuildCryptKey(
                    cryptProcessingBuffer,
                    keyChars,
                    keyIndexes,
                    true);
                ProcessSymmetricCrypt(
                    cryptProcessingBuffer,
                    buffer.ToSlice(0x00, 0x08 * 8),
                    buffer.ToSlice(0x08, 0x08 * 8),
                    8,
                    true);

                MemCopy(encrypted.ToSlice(resultLength, 8), buffer, 8);
                resultLength += 8;

                if (pwdBuffer.Length >= processedPasswordLength + 8)
                {
                    MemCopy(dataToEncrypt, pwdBuffer.ToSlice(processedPasswordLength, 8), 8);
                    blockLength = 8;
                }
                else
                {
                    if (pwdBuffer.Length > resultLength)
                    {
                        var remainingLength = pwdBuffer.Length - processedPasswordLength;
                        MemCopy(dataToEncrypt, pwdBuffer.ToSlice(processedPasswordLength, remainingLength), remainingLength);
                        blockLength = remainingLength;
                    }
                    else
                    {
                        blockLength = 0;
                    }
                }

                processedPasswordLength += blockLength;
            }

            encryptedLengthRef = resultLength;
        }

        private static string DoDecryption(string pwd, string key)
        {
            var buffer = new byte[0xC0];
            InitBufferWithKey(buffer, key);
            if (string.IsNullOrEmpty(pwd))
                return null;
            return DoDecryption(buffer, pwd);
        }

        private static string DoDecryption(byte[] buffer, string pwd)
        {
            if (string.IsNullOrEmpty(pwd) || pwd.Length > 0x200)
                return null;

            var pwdBuffer = HexToBytes(pwd);
            if (pwdBuffer == null)
                return null;

            return DoDecryption(buffer, pwdBuffer);
        }

        private static string DoDecryption(byte[] buffer, byte[] pwdBuffer)
        {
            var dest = new byte[256];
            int destLength;
            DoDecryption(buffer, pwdBuffer, dest, out destLength);
            var text = Encoding.Default.GetString(dest, 0, destLength);
            return text;
        }

        private static void DoDecryption(byte[] buffer, byte[] pwdBuffer, byte[] dest, out int destLengthRef)
        {
            var blockCount = pwdBuffer.Length / 8;

            var decryptedData = buffer.ToSlice(0, 8);
            MemSet(decryptedData, 1, 8);

            var cryptProcessingBuffer = buffer.ToSlice(0x18, 0x90);
            var dataToDecrypt = buffer.ToSlice(0x08, 8);
            var dataToDecryptCopy = buffer.ToSlice(0x10, 8);
            var keyChars = buffer.ToSlice(0xAC, 8);
            var keyIndexes = buffer.ToSlice(0xB4, 8);

            var blockLength = Math.Min(pwdBuffer.Length, 8);
            MemCopy(dataToDecrypt, pwdBuffer, blockLength);

            var processedBlockLength = blockLength;
            var decryptedLength = 0;

            while (blockCount-- != 0)
            {
                MemCopy(dataToDecryptCopy, dataToDecrypt, 8);
                BuildCryptKey(
                    cryptProcessingBuffer,
                    keyChars,
                    keyIndexes,
                    false);
                ProcessSymmetricCrypt(
                    cryptProcessingBuffer,
                    buffer.ToSlice(0x08, 0x08 * 8),
                    buffer.ToSlice(0x08, 0x08 * 8),
                    8,
                    false);

                for (var index1 = 0; index1 != 8; ++index1)
                    dataToDecrypt[index1] = (byte)(decryptedData[index1] ^ dataToDecrypt[index1]);

                if (blockCount == 0)
                {
                    var var19 = buffer[0x0F];
                    if (var19 <= 8)
                    {
                        blockLength -= var19;
                    }
                    else
                    {
                        buffer[0x0f] = 0x27;
                    }
                }

                if (blockLength > 8)
                {
                    dest[0] = 0;
                    destLengthRef = 0;
                    return;
                }

                MemCopy(dest.ToSlice(decryptedLength, 8), dataToDecrypt, blockLength);
                decryptedLength += blockLength;

                MemCopy(decryptedData, dataToDecryptCopy, 8);

                if (pwdBuffer.Length >= processedBlockLength + 8)
                {
                    MemCopy(dataToDecrypt, pwdBuffer.ToSlice(processedBlockLength, 8), 8);
                    blockLength = 8;
                }
                else
                {
                    if (pwdBuffer.Length > processedBlockLength)
                    {
                        var copyLength = pwdBuffer.Length - processedBlockLength;
                        MemCopy(dataToDecrypt, pwdBuffer.ToSlice(processedBlockLength, copyLength), copyLength);
                    }
                    blockLength = 0;
                }

                processedBlockLength += blockLength;
            }

            destLengthRef = decryptedLength;
        }

        private static void BuildCryptKey(Slice<byte> cryptProcessingBuffer, Slice<byte> keyChars, Slice<byte> inputIndexes, bool encrypt)
        {
            CopyReverse4X2(cryptProcessingBuffer.ToSlice(0x80, 0x08), inputIndexes);
            CopyReverse4X2(cryptProcessingBuffer.ToSlice(0x88, 0x08), inputIndexes);
            BuildCryptKey(cryptProcessingBuffer, keyChars, encrypt);
        }

        private static void ProcessSymmetricCrypt(Slice<byte> cryptProcessingBuffer, Slice<byte> target, Slice<byte> blocks, byte length, bool encrypt)
        {
            if ((length % 8) != 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be a multiple of 8");
            var temp = new byte[8];
            var blockCount = length / 8;
            for (var index = 0; index != blockCount; ++index)
            {
                CopyReverse4X2(temp.ToSlice(), blocks.ToSlice(index * 8, 0x08));

                uint itemLo, itemHi;
                var isDecryption = !encrypt;
                if (isDecryption)
                {
                    itemLo = BitConverter.ToUInt32(temp, 0);
                    itemHi = BitConverter.ToUInt32(temp, 4);
                }
                else
                {
                    itemLo = BitConverter.ToUInt32(temp, 0);
                    var tempLo = BitConverter.ToUInt32(cryptProcessingBuffer.ToArray(0x80, 4), 0);
                    itemLo ^= tempLo;

                    itemHi = BitConverter.ToUInt32(temp, 4);
                    var tempHi = BitConverter.ToUInt32(cryptProcessingBuffer.ToArray(0x84, 4), 0);
                    itemHi ^= tempHi;
                }
                PerformCrypt(cryptProcessingBuffer.ToArray(), ref itemLo, ref itemHi);
                if (isDecryption)
                {
                    var tempLo = BitConverter.ToUInt32(cryptProcessingBuffer.ToArray(0x80, 4), 0);
                    var tempHi = BitConverter.ToUInt32(cryptProcessingBuffer.ToArray(0x84, 4), 0);
                    itemLo ^= tempLo;
                    itemHi ^= tempHi;
                    cryptProcessingBuffer.ToSlice(0x80, 8).CopyFrom(temp);
                }
                else
                {
                    cryptProcessingBuffer.ToSlice(0x80, 4).CopyFrom(BitConverter.GetBytes(itemLo));
                    cryptProcessingBuffer.ToSlice(0x84, 4).CopyFrom(BitConverter.GetBytes(itemHi));
                }

                WriteToBigEndian32(target.ToSlice(index * 8, 8), itemLo, itemHi);
            }
        }

        private static void WriteToBigEndian32(IList<byte> target, uint itemLo, uint itemHi)
        {
            var unk2Index = 0;
            target[unk2Index++] = (byte)((itemLo >> 0x18) & 0xFF);
            target[unk2Index++] = (byte)((itemLo >> 0x10) & 0xFF);
            target[unk2Index++] = (byte)((itemLo >> 0x08) & 0xFF);
            target[unk2Index++] = (byte)((itemLo >> 0x00) & 0xFF);
            target[unk2Index++] = (byte)((itemHi >> 0x18) & 0xFF);
            target[unk2Index++] = (byte)((itemHi >> 0x10) & 0xFF);
            target[unk2Index++] = (byte)((itemHi >> 0x08) & 0xFF);
            target[unk2Index] = (byte)((itemHi >> 0x00) & 0xFF);
        }

        private static void PerformCrypt(byte[] source, ref uint itemLo, ref uint itemHi)
        {
            var temp1 = itemLo;
            var temp2 = itemHi;
            var temp3 = ((temp1 >> 0x04) ^ temp2) & 0x0F0F0F0F;
            temp2 ^= temp3;
            temp1 ^= temp3 << 0x04;

            temp3 = ((temp1 >> 0x10) ^ temp2) & 0x0000FFFF;
            temp2 ^= temp3;
            temp1 ^= temp3 << 0x10;

            temp3 = ((temp2 >> 0x02) ^ temp1) & 0x33333333;
            temp1 ^= temp3;
            temp2 ^= temp3 << 0x02;

            temp3 = ((temp2 >> 0x08) ^ temp1) & 0x00FF00FF;
            temp1 ^= temp3;
            temp2 ^= temp3 << 0x08;

            temp2 = (temp2 << 0x01) | (temp2 >> 0x1F);
            temp3 = (temp1 ^ temp2) & 0xAAAAAAAA;
            temp1 ^= temp3;
            temp2 ^= temp3;
            temp1 = (temp1 << 0x01) | (temp1 >> 0x1F);

            var sourceOffset = 0;

            for (int i = 0; i != 8; ++i)
            {
                temp3 = ((temp2 >> 0x04) | (temp2 << 0x1C)) ^ BitConverter.ToUInt32(source, sourceOffset);
                temp1 ^= _magicValues6[temp3 & 0x3F];
                temp1 ^= _magicValues7[(temp3 >> 8) & 0x3F];
                temp1 ^= _magicValues8[(temp3 >> 0x10) & 0x3F];
                temp1 ^= _magicValues9[(temp3 >> 0x18) & 0x3F];

                temp3 = temp2 ^ BitConverter.ToUInt32(source, sourceOffset + 4);
                temp1 ^= _magicValues10[temp3 & 0x3F];
                temp1 ^= _magicValues11[(temp3 >> 8) & 0x3F];
                temp1 ^= _magicValues12[(temp3 >> 0x10) & 0x3F];
                temp1 ^= _magicValues13[(temp3 >> 0x18) & 0x3F];

                temp3 = ((temp1 >> 0x04) | (temp1 << 0x1C)) ^ BitConverter.ToUInt32(source, sourceOffset + 8);
                temp2 ^= _magicValues6[temp3 & 0x3F];
                temp2 ^= _magicValues7[(temp3 >> 8) & 0x3F];
                temp2 ^= _magicValues8[(temp3 >> 0x10) & 0x3F];
                temp2 ^= _magicValues9[(temp3 >> 0x18) & 0x3F];

                temp3 = temp1 ^ BitConverter.ToUInt32(source, sourceOffset + 12);
                temp2 ^= _magicValues10[temp3 & 0x3F];
                temp2 ^= _magicValues11[(temp3 >> 8) & 0x3F];
                temp2 ^= _magicValues12[(temp3 >> 0x10) & 0x3F];
                temp2 ^= _magicValues13[(temp3 >> 0x18) & 0x3F];

                sourceOffset += 16;
            }

            temp2 = (temp2 << 0x1F) | (temp2 >> 0x01);
            temp3 = (temp1 ^ temp2) & 0xAAAAAAAA;
            temp1 ^= temp3;
            temp2 ^= temp3;
            temp1 = (temp1 << 0x1F) | (temp1 >> 0x01);

            temp3 = ((temp1 >> 0x08) ^ temp2) & 0x00FF00FF;
            temp2 ^= temp3;
            temp1 ^= temp3 << 0x08;

            temp3 = ((temp1 >> 0x02) ^ temp2) & 0x33333333;
            temp2 ^= temp3;
            temp1 ^= temp3 << 0x02;

            temp3 = ((temp2 >> 0x10) ^ temp1) & 0x0000FFFF;
            temp1 ^= temp3;
            temp2 ^= temp3 << 0x10;

            temp3 = ((temp2 >> 0x04) ^ temp1) & 0x0F0F0F0F;
            temp1 ^= temp3;
            temp2 ^= temp3 << 0x04;

            itemLo = temp2;
            itemHi = temp1;
        }

        private static void BuildCryptKey(IList<byte> cryptProcessingBuffer, IReadOnlyList<byte> keyChars, bool encrypt)
        {
            var firstHalf = new byte[0x1C];
            var secondHalf = new byte[0x1C];
            var keyInputBits = new byte[0x38];
            var tempResult = new uint[0x40];

            for (var i = 0; i != 0x38; ++i)
            {
                var temp = _magicValues1[i];
                var offset1 = temp & 0x7;
                var ch = (int)keyChars[temp >> 3];
                var bits = (int)_byteBits[offset1];
                keyInputBits[i] = (ch & bits) != 0 ? (byte)1 : (byte)0;
            }

            for (var outerIndex = 0; outerIndex != 16; ++outerIndex)
            {
                var offset1 = outerIndex * 2;
                var offset2 = offset1 + 1;
                tempResult[offset2] = 0;
                tempResult[offset1] = 0;
                for (var innerIndex = 0; innerIndex < 0x1C; ++innerIndex)
                {
                    var temp = _magicValues2[outerIndex] + innerIndex;
                    if (temp < 0x1C)
                    {
                        firstHalf[innerIndex] = keyInputBits[temp];
                    }
                    else
                    {
                        firstHalf[innerIndex] = keyInputBits[temp - 0x1C];
                    }
                }

                for (var innerIndex = 0x1C; innerIndex < 0x38; ++innerIndex)
                {
                    var temp = _magicValues2[outerIndex] + innerIndex;
                    if (temp < 0x38)
                    {
                        secondHalf[innerIndex - 0x1C] = keyInputBits[temp];
                    }
                    else
                    {
                        secondHalf[innerIndex - 0x1C] = keyInputBits[temp - 0x1C];
                    }
                }

                for (var innerIndex = 0x00; innerIndex < 0x18; ++innerIndex)
                {
                    if (firstHalf[_magicValues3[innerIndex]] != 0)
                    {
                        tempResult[offset1] |= _magicValues4[innerIndex];
                    }
                    if (secondHalf[_magicValues5[innerIndex] - 0x1C] != 0)
                    {
                        tempResult[offset2] |= _magicValues4[innerIndex];
                    }
                }
            }

            JuggleData(cryptProcessingBuffer, tempResult, encrypt);
        }

        private static void JuggleData(IList<byte> destination, uint[] source, bool encrypt)
        {
            var currentSourceIndex = 0;
            var startDestIndex = encrypt ? 0 : 0x78;
            var currentDestIndex = startDestIndex;
            var destIndexChange = encrypt ? 0 : -16;
            for (var index1 = 0; index1 != 16; ++index1)
            {
                var sourceIndexAtLoopStart = currentSourceIndex;
                currentSourceIndex += 1;

                uint temp = 0;
                temp |= (source[sourceIndexAtLoopStart] & 0x00FC0000) << 6;     // 0x3F000000
                temp |= (source[sourceIndexAtLoopStart] & 0x00000FC0) << 10;    // 0x003F0000

                temp |= (source[currentSourceIndex] & 0x00FC0000) >> 10;        // 0x00003F00
                temp |= (source[currentSourceIndex] & 0x00000FC0) >> 6;         // 0x0000003F

                var data = BitConverter.GetBytes(temp);
                for (int i = 0; i != data.Length; ++i)
                    destination[currentDestIndex + i] = data[i];
                currentDestIndex += 4;

                temp = 0;
                temp |= (source[sourceIndexAtLoopStart] & 0x0003F000) << 12;    // 0x3F000000
                temp |= (source[sourceIndexAtLoopStart] & 0x0000003F) << 16;    // 0x003F0000

                temp |= (source[currentSourceIndex] & 0x0003F000) >> 4;         // 0x00003F00
                temp |= (source[currentSourceIndex] & 0x0000003F) >> 0;         // 0x0000003F

                data = BitConverter.GetBytes(temp);
                for (int i = 0; i != data.Length; ++i)
                    destination[currentDestIndex + i] = data[i];

                currentDestIndex += 4 + destIndexChange;

                currentSourceIndex += 1;
            }
        }

        private static void InitBufferWithKey(IList<byte> buffer, string key)
        {
            if (string.IsNullOrEmpty(key))
                return;
            var keyBuffer = new byte[16];
            for (int index = 0; index != 16; ++index)
            {
                var ch = key[index % key.Length];
                keyBuffer[index] = (byte)ch;
            }
            FillBufferWithKey(buffer, keyBuffer);
        }

        private static void FillBufferWithKey(IList<byte> buffer, IReadOnlyList<byte> keyBuffer)
        {
            for (var index = 0; index != 8; ++index)
            {
                var v = keyBuffer[index];
                buffer[index + 0xAC] = v;
                buffer[index + 0xB4] = (byte)index;
            }
        }

        private static void CopyReverse4X2(IList<byte> destination, IReadOnlyList<byte> source)
        {
            for (var index = 0; index != 4; ++index)
                destination[3 - index] = source[index];
            for (var index = 0; index != 4; ++index)
                destination[7 - index] = source[index + 4];
        }

        private static string BytesToHex(IEnumerable<byte> input)
        {
            return string.Join(string.Empty, input.Select(x => x.ToString("x2")));
        }

        private static byte[] HexToBytes(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            var source = Enumerable
                .Range(0, s.Length / 2)
                .Select(x => s.Substring(x * 2, 2))
                .Select(x => Convert.ToByte(x, 16))
                .ToArray();
            return source;
        }

        private static void MemCopy(IList<byte> dest, IReadOnlyList<byte> source, int length)
        {
            for (var i = 0; i != length; ++i)
                dest[i] = source[i];
        }

        private static void MemSet(IList<byte> dest, byte value, int length)
        {
            for (var i = 0; i != length; ++i)
                dest[i] = value;
        }
    }
}
