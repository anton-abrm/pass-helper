using System;
using System.Collections.Generic;
using System.IO;

namespace PassHelper {

    internal static class PasswordConverter {

        private const string UpperAll = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string UpperHuman = "ABCDEFGHJKLMNPQRSTUVWXYZ";
        private const string LowerAll = "abcdefghijklmnopqrstuvwxyz";
        private const string LowerHuman = "abcdefghijkmnpqrstuvwxyz";
        private const string DigitAll = "0123456789";
        private const string DigitHuman = "23456789";
        private const string SpecialAll = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        private const string SpecialHuman = "!#$%&()*+/<>?@[\\]^{}~";
        private const string SpecialSafe = "!#$%&*@^";

        private static int NextByte(Stream stream, int max) {

            var bound = 256 - (256 % max);

            while (true) {
                var r = stream.ReadByte();
                if (r < 0) {
                    throw new EndOfStreamException();
                }

                if (r < bound) {
                    return r % max;
                }
            }
        }

        private static void Shuffle(Stream stream, IList<char> pass) {

            for (var i = 0; i < pass.Count; i++) {

                var r = i + NextByte(stream, pass.Count - i);     // between i and n-1

                var temp = pass[i];
                pass[i] = pass[r];
                pass[r] = temp;
            }
        }

        private static string[] GetAlphabets(string format) {

            var alphabets = new List<string>();

            switch (format[0]) {

                case 'a':
                    alphabets.Add(UpperAll);
                    break;

                case 'h':
                    alphabets.Add(UpperHuman);
                    break;

                case 'x':
                    break;

                default:
                    throw new FormatException("Invalid format.");
            }

            switch (format[1]) {

                case 'a':
                    alphabets.Add(LowerAll);
                    break;

                case 'h':
                    alphabets.Add(LowerHuman);
                    break;

                case 'x':
                    break;

                default:
                    throw new FormatException("Invalid format.");
            }

            switch (format[2]) {

                case 'a':
                    alphabets.Add(DigitAll);
                    break;

                case 'h':
                    alphabets.Add(DigitHuman);
                    break;

                case 'x':
                    break;

                default:
                    throw new FormatException("Invalid format.");
            }

            switch (format[3]) {

                case 'a':
                    alphabets.Add(SpecialAll);
                    break;

                case 'h':
                    alphabets.Add(SpecialHuman);
                    break;

                case 's':
                    alphabets.Add(SpecialSafe);
                    break;

                case 'x':
                    break;

                default:
                    throw new FormatException("Invalid format.");
            }

            return alphabets.ToArray();
        }

        public static char[] Convert(Stream input, string format) {

            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            if (format is null) {
                throw new ArgumentNullException(nameof(format));
            }

            if (format.Length < 5 || format.Length > 7) {
                throw new ArgumentException("Invalid format.", nameof(format));
            }

            int pwIdx = 0;
            var pwLen = int.Parse(format.Substring(0, format.Length - 4));
            var pwFmt = format.Substring(format.Length - 4, 4);

            var alphabets = GetAlphabets(pwFmt);

            var pwChars = new char[pwLen];

            foreach (var al in alphabets) {
                pwChars[pwIdx++] = al[NextByte(input, al.Length)];
            }

            var mrgAl = string.Concat(alphabets);

            while (pwIdx < pwChars.Length) {
                pwChars[pwIdx++] = mrgAl[NextByte(input, mrgAl.Length)];
            }

            Shuffle(input, pwChars);

            return pwChars;

        }
    }


}
