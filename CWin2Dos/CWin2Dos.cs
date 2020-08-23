using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using System.Linq;

namespace SAFA2 
{
    public class CWin2Dos
    {

        public CWin2Dos()
        {
        }

        public static byte W2D(string CB, string Cin, string CF)
        {
            string CBack, CForward;
            bool BC;
            CBack = CB;
            CForward = CF;
            if (CBack.Trim() == "")
                BC = false;
            else
                BC = true;
            switch (Asc(Cin))
            {
                case 48:
                    return 128;

                case 49:
                    return 129;

                case 50:
                    return 130;

                case 51:
                    return 131;

                case 52:
                    return 132;

                case 53:
                    return 133;

                case 54:
                    return 134;

                case 55:
                    return 135;

                case 56:
                    return 136;

                case 57:
                    return 137;

                //case 143:
                // return 140;
                //
                case 194:
                    return 141;

                case 198:
                    return 142;

                case 193:
                    return 143;

                case 199:
                    if (BC)
                        return 145;
                    else
                        return 144;

                case 200:
                    if (IsNullOrWhiteSpace(CF))
                        return 146;
                    else
                        return 147;

                case 129:
                    if (IsNullOrWhiteSpace(CF))
                        return 148;
                    else
                        return 149;

                case 202:
                    if (IsNullOrWhiteSpace(CF))
                        return 150;
                    else
                        return 151;

                case 203:
                    if (IsNullOrWhiteSpace(CF))
                        return 152;
                    else
                        return 153;

                case 204:
                    if (IsNullOrWhiteSpace(CF))
                        return 154;
                    else
                        return 155;

                case 141:
                    if (IsNullOrWhiteSpace(CF))
                        return 156;
                    else
                        return 157;

                case 205:
                    if (IsNullOrWhiteSpace(CF))
                        return 158;
                    else
                        return 159;

                case 206:
                    if (IsNullOrWhiteSpace(CF))
                        return 160;
                    else
                        return 161;

                case 207:
                    return 162;

                case 208:
                    return 163;

                case 209:
                    return 164;

                case 210:
                    return 165;
                case 142:
                    return 166;
                case 211:
                    if (IsNullOrWhiteSpace(CF))
                        return 167;
                    else
                        return 168;

                case 212:
                    if (IsNullOrWhiteSpace(CF))
                        return 169;
                    else
                        return 170;

                case 213:
                    if (IsNullOrWhiteSpace(CF))
                        return 171;
                    else
                        return 172;

                case 214:
                    if (IsNullOrWhiteSpace(CF))
                        return 173;
                    else
                        return 174;

                case 216:
                    return 175;
                case 217:
                    return 224;
                case 218:
                    if (BC)
                    {
                        if (IsNullOrWhiteSpace(CF))
                            return 226;
                        else
                            return 227;
                    }
                    else
                    {
                        if (IsNullOrWhiteSpace(CF))
                            return 225;
                        else
                            return 228;
                    }

                case 219:
                    if (BC)
                    {
                        if (IsNullOrWhiteSpace(CF))
                            return 230;
                        else
                            return 231;
                    }
                    else
                    {
                        if (IsNullOrWhiteSpace(CF))
                            return 229;
                        else
                            return 232;
                    }

                case 221:
                    if (IsNullOrWhiteSpace(CF))
                        return 233;
                    else
                        return 234;

                case 222:
                    if (IsNullOrWhiteSpace(CF))
                        return 235;
                    else
                        return 236;

                case 152:
                    if (CF.Trim() != "")
                        return 238;
                    else
                        return 237;

                case 144:
                    if (IsNullOrWhiteSpace(CF))
                        return 239;
                    else
                        return 240;

                case 225:
                    if (IsNullOrWhiteSpace(CF))
                        return 241;
                    else
                        return 243;

                case 226:
                    return 242;

                case 227:
                    if (IsNullOrWhiteSpace(CF))
                        return 244;
                    else
                        return 245;

                case 228:
                    if (IsNullOrWhiteSpace(CF))
                        return 246;
                    else
                        return 247;

                case 230:
                    return 248;

                case 229:
                    if (BC)
                    {
                        if (IsNullOrWhiteSpace(CF))
                            return 249;
                        else
                            return 250;
                    }
                    else
                        return 251;

                case 237:
                    if (BC)
                    {
                        if (IsNullOrWhiteSpace(CF))
                            return 252;
                        else
                            return 254;
                    }
                    else
                        return 253;

                default:
                    //return Asc(Cin);
                    //Safa
                    return 255;

            }
        }



        public static string Win2Dos(string Cin)
        {
            string S, E;
            byte WN;
            List<byte> Tmp = new List<byte>();
            int i1;
            i1 = Cin.Length;

            if (Information.IsNumeric(Cin))
            {
                if (Cin.Length > 0)
                {
                    for (int i = 1; i <= i1; i++)
                    {
                        if (i == i1)
                            S = "";
                        else
                            S = Strings.Mid(Cin, i + 1, 1);

                        if (i == 1)
                            E = "";
                        else
                            E = Strings.Mid(Cin, i - 1, 1);

                        WN = W2D(S, Strings.Mid(Cin, i, 1), E);
                        Tmp.Add(WN);
                    }
                }
            }
            else
                if (Cin.Length > 0)
                {
                    for (int i = i1; i >= 1; i--)
                    {
                        if (i == 1)
                            S = "";
                        else
                            S = Strings.Mid(Cin, i - 1, 1);

                        if (i == Cin.Length)
                            E = "";
                        else
                            E = Strings.Mid(Cin, i + 1, 1);

                        byte buff = WN = W2D(S, Strings.Mid(Cin, i, 1), E);

                        if (WN == 223 && (IsNullOrWhiteSpace(E)))
                            WN = 237;
                        else if (WN == 223)
                            WN = 238;

                        bool suc = S == "د" || S == "ذ" || S == "ر" || S == "ز" || S == "ژ" || S == "و";

                        if (Strings.Mid(Cin, i, 1) == "ا" && suc)
                            WN = 144;

                        if (i == 1 && buff == 253)
                            WN = 254;

                        if (i == 1 && buff == 228)
                            WN = 228;

                        if (buff == 227 && (S == "ا" || suc))
                            WN = 228;

                        if (buff == 250 && (S == "ا" || suc))
                            WN = 251;

                        if (buff == 231 && (S == "ا" || suc))
                            WN = 232;
                        if (S == "ل" && Strings.Mid(Cin, i, 1) == "ا")
                        {
                            WN = 242;
                            i--;
                        }
                        Tmp.Add(WN);
                    }
                }
            return Convert(Tmp.ToArray());
        }

        public static string MSMWin2Dos(string Cin0)
        {
            string Cin = "";
            StringBuilder PerStr = new StringBuilder(), OthStr = new StringBuilder(), NumStr = new StringBuilder();
            Cin = Win2Dos(Cin0);
            for (int i = 0; i < Cin.Length; i++)
            {
                string current = Cin.Substring(i, 1);
                byte st = W2D("", current, "");
                if (st < 128)
                    OthStr.Append(current);
                else if (st < 138 && st >= 128)
                    NumStr.Append(current);
                else
                {
                    if (NumStr.Length != 0) PerStr.Append(RevStr(NumStr.ToString()));
                    //NumStr.Clear();
                    NumStr.Remove(0, NumStr.Length);
                    if (OthStr.Length != 0) PerStr.Append(RevStr(OthStr.ToString()));
                    //OthStr.Clear();
                    OthStr.Remove(0, OthStr.Length);
                    PerStr.Append(current);
                }
            }
            return PerStr.ToString().Replace("\n", "");
        }

        public static string ConvertEncoding(string value, Encoding src, Encoding trg)
        {
            Decoder dec = src.GetDecoder();
            byte[] ba = trg.GetBytes(value);
            int len = dec.GetCharCount(ba, 0, ba.Length);
            char[] ca = new char[len];
            dec.GetChars(ba, 0, ba.Length, ca, 0);
            return new string(ca);

        }

        private static string Convert(byte[] bytes)
        {
            //Return the character value of the given character
            //return (char)B;

            StringBuilder sb = new StringBuilder();
            foreach (char c in Encoding.Default.GetChars(bytes))
                sb.Append(c);

            return sb.ToString();

            //return string.Concat(Encoding.Default.GetChars(bytes));
        }

        private static byte Asc(string ch)
        {
            //Return the character value of the given character
            return (byte)Encoding.Default.GetBytes(ch)[0];
        }

        private static string RevStr(string St)
        {
            return string.Concat(St.Reverse());
        }

        public static bool IsNullOrWhiteSpace(string value)
        {
            if (value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsWhiteSpace(value[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}


